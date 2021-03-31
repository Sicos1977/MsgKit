//
// Strings.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2021 Magic-Sessions. (www.magic-sessions.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MsgKit.Helpers
{
    /// <summary>
    ///     This class contains string related helper methods
    /// </summary>
    internal static class Strings
    {
        #region ReadNullTerminatedString
        /// <summary>
        ///     Reads from the <paramref name="binaryReader"/> until a null terminated char is read
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public static string ReadNullTerminatedString(BinaryReader binaryReader, bool unicode = true)
        {
            return unicode ? ReadNullTerminatedUnicodeString(binaryReader) : ReadNullTerminatedAsciiString(binaryReader);
        }
        #endregion

        #region ReadNullTerminatedString
        /// <summary>
        ///     Reads from the <paramref name="binaryReader"/> until a null terminated char is read
        /// </summary>
        /// <param name="binaryReader">The <see cref="BinaryReader" /></param>
        /// <returns></returns>
        public static string ReadNullTerminatedAsciiString(BinaryReader binaryReader)
        {
            var result = new MemoryStream();

            var b = binaryReader.ReadByte();
            while (b != 0)
            {
                result.WriteByte(b);
                b = binaryReader.ReadByte();
            }

            return Encoding.ASCII.GetString(result.ToArray());
        }
        #endregion

        #region ReadNullTerminatedUnicodeString
        /// <summary>
        ///     Reads from the <paramref name="binaryReader"/> until a null terminated char is read
        /// </summary>
        /// <param name="binaryReader">The <see cref="BinaryReader" /></param>
        /// <returns></returns>
        public static string ReadNullTerminatedUnicodeString(BinaryReader binaryReader)
        {
            var result = new MemoryStream();

            var b = binaryReader.ReadBytes(2);
            while (b[0] != 0 && b[1] != 0)
            {
                result.WriteByte(b[0]);
                result.WriteByte(b[2]);
                b = binaryReader.ReadBytes(2);
            }

            return Encoding.Unicode.GetString(result.ToArray());
        }
        #endregion

        #region WriteNullTerminatedString
        /// <summary>
        ///     Writes the given <paramref name="str"/> to the <paramref name="binaryWriter"/>
        /// </summary>
        /// <param name="binaryWriter"></param>
        /// <param name="str">The string to write</param>
        /// <param name="unicode"></param>
        public static void WriteNullTerminatedString(BinaryWriter binaryWriter, 
                                                     string str,
                                                     bool unicode = true)
        {
            if (unicode)
                WriteNullTerminatedUnicodeString(binaryWriter, str);
            else
                WriteNullTerminatedAsciiString(binaryWriter, str);
        }
        #endregion

        #region WriteNullTerminatedString
        /// <summary>
        ///     Writes the given <paramref name="str"/> to the <paramref name="binaryWriter"/>
        /// </summary>
        /// <param name="binaryWriter"></param>
        /// <param name="str">The string to write</param>
        public static void WriteNullTerminatedAsciiString(BinaryWriter binaryWriter, string str)
        {
            var unicode = Encoding.Unicode.GetBytes(str);
            var ascii = Encoding.ASCII.GetString(unicode);
            binaryWriter.Write(ascii);
            binaryWriter.Write(0x00);
        }
        #endregion

        #region WriteNullTerminatedUnicodeString
        /// <summary>
        ///     Writes the given <paramref name="str"/> to the <paramref name="binaryWriter"/>
        /// </summary>
        /// <param name="binaryWriter"></param>
        /// <param name="str">The string to write</param>
        public static void WriteNullTerminatedUnicodeString(BinaryWriter binaryWriter, string str)
        {
            var bytes = Encoding.Unicode.GetBytes(str);
            binaryWriter.Write(bytes);
            binaryWriter.Write(new byte[2]);
        }
        #endregion

        #region GetEscapedRtf
        /// <summary>
        /// Returns the <paramref name="str"/> as an escaped RTF string
        /// </summary>
        /// <returns></returns>
        public static string GetEscapedRtf(string str)
        {
            // Convert Unicode string to RTF according to specification
            var rtfEscaped = new StringBuilder();
            var escapedChars = new int[] { '{', '}', '\\' };
            foreach (var @char in str)
            {
                var intChar = Convert.ToInt32(@char);

                // Ignore control characters
                if (intChar <= 31) continue;

                if (intChar <= 127)
                {
                    if (escapedChars.Contains(intChar))
                        rtfEscaped.Append('\\');
                    rtfEscaped.Append(@char);
                }
                else if (intChar <= 255)
                {
                    rtfEscaped.Append("\\'" + intChar.ToString("x2"));
                }
                else
                {
                    rtfEscaped.Append("\\u");
                    rtfEscaped.Append(intChar);
                    rtfEscaped.Append('?');
                }
            }

            return "{\\rtf1\\ansi\\ansicpg1252\\fromhtml1 {\\*\\htmltag1 " + rtfEscaped + " }}";
            //return "{\\rtf1\\ansi\\ansicpg1252\\fromhtml1 " + rtfEscaped + "}";
        }
        #endregion
    }
}

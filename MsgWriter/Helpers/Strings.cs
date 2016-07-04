using System.IO;
using System.Text;

/*
   Copyright 2015 - 2016 Kees van Spelde

   Licensed under The Code Project Open License (CPOL) 1.02;
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.codeproject.com/info/cpol10.aspx

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace MsgWriter.Helpers
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
        public static string ReadNullTerminatedString(BinaryReader binaryReader, bool unicode)
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
    }
}

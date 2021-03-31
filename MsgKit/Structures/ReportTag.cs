//
// ReportTag.cs
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

using System.IO;
// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace MsgKit.Structures
{
    /// <summary>
    ///     The PidTagReportTag property ([MS-OXPROPS] section 2.917) contains the data that is used to correlate the report
    ///     and the original message. The property can be absent if the sender does not request a reply or response to the
    ///     original e-mail message. If the original E-mail object has either the PidTagResponseRequested property (section
    ///     2.2.1.46) set to 0x01 or the PidTagReplyRequested property (section 2.2.1.45) set to 0x01, then the property is set
    ///     on the original E-mail object by using the following format.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee160822(v=exchg.80).aspx
    /// </remarks>
    internal class ReportTag
    {
        #region Properties
        /// <summary>
        ///     (9 bytes): A null-terminated string of nine characters used for validation; set to "PCDFEB09".
        /// </summary>
        public string Cookie => "PCDFEB09\0";

        /// <summary>
        ///     (4 bytes): This field specifies the version. If the SearchFolderEntryId field is present, this field MUST be set to
        ///     0x00020001; otherwise, this field MUST be set to 0x00010001.
        /// </summary>
        public int Version => 0x00010001;

        /// <summary>
        ///     (4 bytes): Size of the StoreEntryId field.
        /// </summary>
        public int StoreEntryIdSize => 0x00000000;

        /// <summary>
        ///     (Variable length of bytes): This field specifies the entry ID of the mailbox that contains the original message. If
        ///     the value of the
        ///     StoreEntryIdSize field is 0x00000000, this field is omitted. If the value is not zero, this field is filled with
        ///     the number of bytes specified by the StoreEntryIdSize field.
        /// </summary>
        public byte[] StoreEntryId { get; }

        /// <summary>
        ///     (4 bytes): Size of the FolderEntryId field.
        /// </summary>
        public int FolderEntryIdSize => 0x00000000;

        /// <summary>
        ///     (Variable): This field specifies the entry ID of the folder that contains the original message. If the value of the
        ///     FolderEntryIdSize field is 0x00000000, this field is omitted. If the value is not zero, the field is filled with
        ///     the number of bytes specified by the FolderEntryIdSize field.
        /// </summary>
        public int FolderEntryId { get; }

        /// <summary>
        ///     (4 bytes): Size of the MessageEntryId field.
        /// </summary>
        public int MessageEntryIdSize => 0x00000000;

        /// <summary>
        ///     (Variable): This field specifies the entry ID of the original message. If the value of the MessageEntryIdSize field
        ///     is 0x00000000, this field is omitted. If the value is not zero, the field is filled with the number of bytes
        ///     specified by the MessageEntryIdSize field.
        /// </summary>
        public int MessageEntryId { get; }

        /// <summary>
        ///     (4 bytes): Size of the SearchFolderEntryId field.
        /// </summary>
        public int SearchFolderEntryIdSize => 0x00000000;

        /// <summary>
        ///     (Variable): This field specifies the entry ID of an alternate folder that contains the original message. If the
        ///     value of the SearchFolderEntryIdSize field is 0x00000000, this field is omitted. If the value is not zero, the
        ///     field is filled with the number of bytes specified by the SearchFolderEntryIdSize field.
        /// </summary>
        public byte[] SearchFolderEntryId { get; }

        /// <summary>
        ///     (4 bytes): Size of the MessageSearchKey field.
        /// </summary>
        public int MessageSearchKeySize => 0x00000000;

        /// <summary>
        ///     (variable): This field specifies the search key of the original message. If the value of the MessageSearchKeySize
        ///     field is 0x00000000, this field is omitted. If the value is not zero, the MessageSearchKey field is filled with the
        ///     number of bytes specified by the MessageSearchKeySize field.
        /// </summary>
        public byte[] MessageSearchKey { get; }

        /// <summary>
        ///     (4 bytes): Number of characters in the ANSI Text field.
        /// </summary>
        public int ANSITextSize => ANSIText.Length;

        /// <summary>
        ///     (Variable): The subject of the original message. If the value of the ANSITextSize field is 0x00000000, this field
        ///     is omitted. If the value is not zero, the field is filled with the number of bytes specified by the ANSITextSize
        ///     field.
        /// </summary>
        public string ANSIText { get; internal set; }
        #endregion

        #region ToByteArray
        /// <summary>
        ///     Returns this class as a byte array
        /// </summary>
        internal byte[] ToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                // Cookie (9 bytes): A null-terminated string of nine characters used for validation; set to "PCDFEB09".
                binaryWriter.Write(Cookie);

                // Version (4 bytes): This field specifies the version. If the SearchFolderEntryId field is present,
                // this field MUST be set to 0x00020001; otherwise, this field MUST be set to 0x00010001.
                binaryWriter.Write(Version);

                // (4 bytes): Size of the StoreEntryId field.
                binaryWriter.Write(StoreEntryIdSize);

                // (Variable length of bytes): This field specifies the entry ID of the mailbox that contains the original message. If
                // the value of the StoreEntryIdSize field is 0x00000000, this field is omitted. If the value is not zero, this field
                // is filled with the number of bytes specified by the StoreEntryIdSize field.
                //binaryWriter.Write(StoreEntryId);

                // (4 bytes): Size of the FolderEntryId field.
                binaryWriter.Write(FolderEntryIdSize);

                // (Variable): This field specifies the entry ID of the folder that contains the original message. If the value of the
                // FolderEntryIdSize field is 0x00000000, this field is omitted. If the value is not zero, the field is filled with
                // the number of bytes specified by the FolderEntryIdSize field.
                //binaryWriter.Write(FolderEntryId);

                // (4 bytes): Size of the MessageEntryId field.
                binaryWriter.Write(MessageEntryIdSize);

                // (Variable): This field specifies the entry ID of the original message. If the value of the MessageEntryIdSize field
                // is 0x00000000, this field is omitted. If the value is not zero, the field is filled with the number of bytes
                // specified by the MessageEntryIdSize field.
                //binaryWriter.Write(MessageEntryId);

                // (4 bytes): Size of the SearchFolderEntryId field.
                binaryWriter.Write(SearchFolderEntryIdSize);
                
                // (Variable): This field specifies the entry ID of an alternate folder that contains the original message. If the
                // value of the SearchFolderEntryIdSize field is 0x00000000, this field is omitted. If the value is not zero, the
                // field is filled with the number of bytes specified by the SearchFolderEntryIdSize field.
                //binaryWriter.Write(SearchFolderEntryId);

                // (4 bytes): Size of the MessageSearchKey field.
                binaryWriter.Write(MessageSearchKeySize);

                // (variable): This field specifies the search key of the original message. If the value of the MessageSearchKeySize
                // field is 0x00000000, this field is omitted. If the value is not zero, the MessageSearchKey field is filled with the
                // number of bytes specified by the MessageSearchKeySize field.
                //binaryWriter.Write(MessageSearchKey);
                
                // (4 bytes): Number of characters in the ANSI Text field.
                binaryWriter.Write(ANSITextSize);

                // (Variable): The subject of the original message. If the value of the ANSITextSize field is 0x00000000, this field
                // is omitted. If the value is not zero, the field is filled with the number of bytes specified by the ANSITextSize
                // field.
                binaryWriter.Write(ANSIText);

                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}
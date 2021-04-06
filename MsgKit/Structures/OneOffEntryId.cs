//
// OneOffEntryId.cs
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
using System.Collections;
using System.IO;
using System.Linq;
using MsgKit.Enums;
using MsgKit.Helpers;

namespace MsgKit.Structures
{
    /// <summary>
    ///     A One-Off EntryID structure specifies a set of data representing recipients
    ///     that do not exist in the directory. All information about a one-off recipient
    ///     is contained in the EntryID.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee202811(v=exchg.80).aspx
    /// </remarks>
    internal class OneOffEntryId : Address
    {
        #region Fields
        /// <summary>
        ///     <see cref="MessageFormat" />
        /// </summary>
        private readonly MessageFormat _messageFormat;

        /// <summary>
        ///     A flag that indicates whether the server can look up an address in the
        ///     address book
        /// </summary>
        private readonly bool _canLookupEmailAddress;
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email" /></param>
        /// <param name="addressType">The <see cref="Address.AddressType" /></param>
        /// <param name="messageFormat"><see cref="MessageFormat"/></param>
        /// <param name="canLookupEmailAddress"></param>
        public OneOffEntryId(string email,
            string displayName,
            AddressType addressType = AddressType.Smtp,
            MessageFormat messageFormat = MessageFormat.TextAndHtml,
            bool canLookupEmailAddress = false) : base(email, displayName, addressType)
        {
            _messageFormat = messageFormat;
            _canLookupEmailAddress = canLookupEmailAddress;
        }
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

                // Flags (4 bytes): This value is set to 0x00000000. Bits in this field indicate under what circumstances 
                // a short-term EntryID is valid. However, in any EntryID stored in a property value, these 4 bytes are 
                // zero, indicating a long-term EntryID.
                binaryWriter.Write(new byte[4]);
                
                // ProviderUID (16 bytes): The identifier of the provider that created the EntryID. This value is used to 
                // route EntryIDs to the correct provider and MUST be set to %x81.2B.1F.A4.BE.A3.10.19.9D.6E.00.DD.01.0F.54.02.
                binaryWriter.Write(new byte[] {0x81, 0x2B, 0x1F, 0xA4, 0xBE, 0xA3, 0x10, 0x19, 0x9D, 0x6E, 0x00, 0xDD, 0x01, 0x0F, 0x54, 0x02});
                
                // Version (2 bytes): This value is set to 0x0000.
                binaryWriter.Write(new byte[2]);
                
                var bitArray = new BitArray(new byte[2]);
                
                // Pad(1 bit): (mask 0x8000) Reserved.This value is set to '0'.
                bitArray.Set(0, false);

                // MAE (2 bits): (mask 0x0C00) The encoding used for Macintosh-specific data attachments, as specified in 
                // [MS-OXCMAIL] section 2.1.3.4.3. The values for this field are specified in the following table.
                // Name        | Word value | Field value | Description 
                // BinHex        0x0000       b'00'         BinHex encoded.
                // UUENCODE      0x0020       b'01'         UUENCODED.Not valid if the message is in Multipurpose Internet Mail 
                //                                          Extensions(MIME) format, in which case the flag will be ignored and 
                //                                          BinHex used instead.
                // AppleSingle   0x0040      b'10'          Apple Single encoded.Allowed only when the message format is MIME.
                // AppleDouble   0x0060      b'11'          Apple Double encoded.Allowed only when the message format is MIME.
                bitArray.Set(1, false);
                bitArray.Set(2, false);
                
                // Format (4 bits): (enumeration, mask 0x1E00) The message format desired for this recipient (1), as specified 
                // in the following table.
                // Name        | Word value | Field value | Description 
                // TextOnly      0x0006       b'0011'       Send a plain text message body.
                // HtmlOnly      0x000E       b'0111'       Send an HTML message body.
                // TextAndHtml   0x0016       b'1011'       Send a multipart / alternative body with both plain text and HTML.
                switch (_messageFormat)
                {
                    case MessageFormat.TextOnly:
                        bitArray.Set(3, false);
                        bitArray.Set(4, false);
                        bitArray.Set(5, true);
                        bitArray.Set(6, true);
                        break;

                    case MessageFormat.HtmlOnly:
                        bitArray.Set(3, false);
                        bitArray.Set(4, true);
                        bitArray.Set(5, true);
                        bitArray.Set(6, true);
                        break;

                    case MessageFormat.TextAndHtml:
                        bitArray.Set(3, true);
                        bitArray.Set(4, false);
                        bitArray.Set(5, true);
                        bitArray.Set(6, true);
                        break;
                }

                // M (1 bit): (mask 0x0100) A flag that indicates how messages are to be sent. If b'0', indicates messages are 
                // to be sent to the recipient (1) in Transport Neutral Encapsulation Format (TNEF) format; if b'1', messages 
                // are sent to the recipient (1) in pure MIME format.
                bitArray.Set(7, true);
                
                // U (1 bit): (mask 0x0080) A flag that indicates the format of the string fields that follow. If b'1', the 
                // string fields following are in Unicode (UTF-16 form) with 2-byte terminating null characters; if b'0', the 
                // string fields following are multibyte character set (MBCS) characters terminated by a single 0 byte.
                bitArray.Set(8, true);
                
                // R (2 bits): (mask 0x0060) Reserved. This value is set to b'00'.
                bitArray.Set(9, false);
                bitArray.Set(10, false);
                
                // L (1 bit): (mask 0x0010) A flag that indicates whether the server can look up an address in the address 
                // book. If b'1', server cannot look up this user's email address in the address book. If b'0', server can 
                // look up this user's email address in the address book.
                bitArray.Set(11, _canLookupEmailAddress);
                
                // Pad (4 bits): (mask 0x000F) Reserved. This value is set to b'0000'.
                bitArray.Set(12, false);
                bitArray.Set(13, false);
                bitArray.Set(14, false);
                bitArray.Set(15, false);
                
                var bits = new byte[2];
                bitArray.CopyTo(bits, 0);

                if (BitConverter.IsLittleEndian)
                {
                    bits = bits.Reverse().ToArray();
                    binaryWriter.Write(bits);
                }
                else
                    binaryWriter.Write(bits);

                Strings.WriteNullTerminatedUnicodeString(binaryWriter, DisplayName);
                Strings.WriteNullTerminatedUnicodeString(binaryWriter, AddressTypeString);
                Strings.WriteNullTerminatedUnicodeString(binaryWriter, Email);

                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}
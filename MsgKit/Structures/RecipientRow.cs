//
// RecipientRow.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2023 Magic-Sessions. (www.magic-sessions.com)
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
using System.Collections.Generic;
using System.IO;
using MsgKit.Enums;
using MsgKit.Helpers;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace MsgKit.Structures
{
    /// <summary>
    ///     An array of RecipientRow structures, as specified in [MS-OXCDATA] section 2.8.3.
    ///     Each structure specifies an unsendable attendee. The RowCount field specifies the
    ///     number of structures contained in this field. For details about properties that can
    ///     be set on RecipientRow structures for Calendar objects and meeting-related objects,
    ///     see section 2.2.4.10.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee179606(v=exchg.80).aspx
    /// </remarks>
    public class RecipientRow
    {
        #region Properties
        /// <summary>
        /// The <see cref="RecipientType"/> or null when not available
        /// </summary>
        public RecipientType RecipientType { get; }

        /// <summary>
        ///     The <see cref="RecipientRowAddressType" />
        /// </summary>
        public RecipientRowAddressType RecipientRowAddressType { get; }

        /// <summary>
        ///     The address prefix used
        /// </summary>
        public uint AddressPrefixUsed { get; }

        /// <summary>
        ///     The <see cref="RecipientRowDisplayType" />
        /// </summary>
        public RecipientRowDisplayType RecipientRowDisplayType { get; }

        /// <summary>
        ///     This field MUST be present when the <see cref="RecipientRowAddressType" /> field of the RecipientFlags
        ///     field is set to X500DN (0x1) and MUST NOT be present otherwise. This value specifies the X500 DN of
        ///     this recipient (1).
        /// </summary>
        /// <remarks>
        ///     A distinguished name (DN), in Teletex form, of an object that is in an address book. An X500 DN can be more limited
        ///     in the size and number of relative distinguished names (RDNs) than a full DN.
        /// </remarks>
        public string X500Dn { get; }

        /// <summary>
        ///     This field MUST be present when the <see cref="RecipientRowAddressType" /> field of the RecipientFlags field is set to
        ///     PersonalDistributionList1 (0x6) or PersonalDistributionList2 (0x7). This field MUST
        ///     NOT be present otherwise. This value specifies the size of the EntryID field.
        /// </summary>
        public uint EntryIdSize { get; }

        /// <summary>
        ///     This field MUST be present when the <see cref="RecipientRowAddressType" /> field of the RecipientFlags field is set to
        ///     PersonalDistributionList1 (0x6) or PersonalDistributionList2 (0x7). This field MUST NOT be present otherwise. The
        ///     number of bytes in this field MUST be the same as specified in the EntryIdSize field. This array specifies the
        ///     address book EntryID structure, as specified in section 2.2.5.2, of the distribution list.
        /// </summary>
        public AddressBookEntryId EntryId { get; }

        /// <summary>
        ///     This field MUST be present when the <see cref="RecipientRowAddressType" /> field of the RecipientFlags field is set to
        ///     PersonalDistributionList1 (0x6) or PersonalDistributionList2 (0x7). This field MUST
        ///     NOT be present otherwise. This value specifies the size of the SearchKey field.
        /// </summary>
        public uint SearchKeySize { get; }

        /// <summary>
        ///     This field is used when the <see cref="RecipientRowAddressType" /> field of the RecipientFlags field is set to
        ///     PersonalDistributionList1 (0x6) or PersonalDistributionList2 (0x7). This field MUST
        ///     NOT be present otherwise. The number of bytes in this field MUST be the same as what
        ///     is specified in the SearchKeySize field and can be 0. This array specifies the search
        ///     key of the distribution list.
        /// </summary>
        public byte[] SearchKey { get; }

        /// <summary>
        ///     This field MUST be present when the <see cref="RecipientRowAddressType" /> field of the
        ///     RecipientsFlags field is set to NoType (0x0) and the O flag of the RecipientsFlags field
        ///     is set. This field MUST NOT be present otherwise. This string specifies the address type
        ///     of the recipient (1).
        /// </summary>
        public string AddresType { get; }

        /// <summary>
        ///     A null-terminated string. This field MUST be present when the E flag of the RecipientsFlags
        ///     field is set and MUST NOT be present otherwise. This field MUST be specified in Unicode
        ///     characters if the U flag of the RecipientsFlags field is set and in the 8-bit character set
        ///     otherwise. This string specifies the email address of the recipient (1).
        /// </summary>
        public string EmailAddress { get; }

        /// <summary>
        ///     This field MUST be present when the D flag of the RecipientsFlags
        ///     field is set and MUST NOT be present otherwise. This field MUST be specified in Unicode characters if the U flag of
        ///     the RecipientsFlags field is set and in the 8-bit character set otherwise. This string specifies the email address
        ///     of the recipient (1).
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        ///     A null-terminated string. This field MUST be present when the I flag of the RecipientsFlags field is set and MUST
        ///     NOT be present otherwise. This field MUST be specified in Unicode characters if the U flag of the RecipientsFlags
        ///     field is set and in the 8-bit character set otherwise. This string specifies the email address of the recipient
        ///     (1).
        /// </summary>
        public string SimpleDisplayName { get; }

        /// <summary>
        ///     This field MUST be present when the T flag of the RecipientsFlags field is set and MUST NOT be present otherwise.
        ///     This field MUST be specified in Unicode characters if the U flag of the RecipientsFlags field is set and in the
        ///     8-bit character set otherwise. This string specifies the email address of the recipient (1).
        /// </summary>
        public string TransmittableDisplayName { get; }

        /// <summary>
        ///     PropertyRow structures, as specified in section 2.8.1. The columns used for this row are those specified in
        ///     RecipientProperties.
        /// </summary>
        public List<Property> RecipientProperties { get; }

        /// <summary>
        ///     Specifies that the recipient does support receiving rich text messages.
        /// </summary>
        public bool SupportsRtf { get; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's properties
        /// </summary>
        /// <param name="binaryReader">The <see cref="BinaryReader" /></param>
        /// <param name="recipientRowAddressType">The <see cref="RecipientRowAddressType" /></param>
        /// <param name="supportsRtf">
        ///     Set to <c>true</c> when the recipient in the <see cref="RecipientRow" />
        ///     supports RTF
        /// </param>
        /// <param name="displayNameIncluded">If this flag is b'1', the DisplayName (section 2.8.3.2) field is included</param>
        /// <param name="emailAddressIncluded">If this flag is b'1', the EmailAddress (section 2.8.3.2) field is included.</param>
        /// <param name="addressTypeIncluded">
        ///     If this flag is b'1', this recipient (1) has a non-standard address type and the
        ///     AddressType field is included.
        /// </param>
        /// <param name="simpleDisplayNameIncluded">If this flag is b'1', the SimpleDisplayName field is included.</param>
        /// <param name="transmittableDisplayNameSameAsDisplayName">
        ///     If this flag is b'1', the value of the TransmittableDisplayName
        ///     field is the same as the value of the DisplayName field.
        /// </param>
        /// <param name="transmittableDisplayNameIncluded">
        ///     If this flag is b'1', the TransmittableDisplayName (section 2.8.3.2)
        ///     field is included.
        /// </param>
        /// <param name="stringsInUnicode">
        ///     If this flag is b'1', the associated string properties are in Unicode with a 2-
        ///     byte terminating null character; if this flag is b'0', string properties are MBCS with a single
        ///     terminating null character, in the code page sent to the server in the EcDoConnectEx method,
        ///     as specified in [MS-OXCRPC] section 3.1.4.1, or the Connect request type 6, as specified in
        ///     [MS-OXCMAPIHTTP] section 2.2.4.1.
        /// </param>
        internal RecipientRow(BinaryReader binaryReader,
            RecipientRowAddressType recipientRowAddressType,
            bool supportsRtf,
            bool displayNameIncluded,
            bool emailAddressIncluded,
            bool addressTypeIncluded,
            bool simpleDisplayNameIncluded,
            bool transmittableDisplayNameSameAsDisplayName,
            bool transmittableDisplayNameIncluded,
            bool stringsInUnicode)
        {
            RecipientRowAddressType = recipientRowAddressType;
            SupportsRtf = supportsRtf;

            switch (RecipientRowAddressType)
            {
                case RecipientRowAddressType.X500Dn:
                    AddressPrefixUsed = binaryReader.ReadByte();
                    RecipientRowDisplayType = (RecipientRowDisplayType)binaryReader.ReadByte();
                    X500Dn = Strings.ReadNullTerminatedAsciiString(binaryReader);
                    break;

                case RecipientRowAddressType.PersonalDistributionList1:
                case RecipientRowAddressType.PersonalDistributionList2:
                    EntryIdSize = binaryReader.ReadUInt16();
                    EntryId = new AddressBookEntryId(binaryReader);
                    SearchKeySize = binaryReader.ReadUInt16();
                    if (SearchKeySize > 0)
                        SearchKey = binaryReader.ReadBytes((int)SearchKeySize);
                    break;

                case RecipientRowAddressType.NoType:
                    if (addressTypeIncluded) AddresType = Strings.ReadNullTerminatedAsciiString(binaryReader);
                    break;
            }

            // MUST be specified in Unicode characters if the U flag of the RecipientsFlags field is set
            if (emailAddressIncluded) EmailAddress = Strings.ReadNullTerminatedString(binaryReader, stringsInUnicode);
            if (displayNameIncluded) DisplayName = Strings.ReadNullTerminatedString(binaryReader, stringsInUnicode);
            if (simpleDisplayNameIncluded) SimpleDisplayName = Strings.ReadNullTerminatedString(binaryReader, stringsInUnicode);
            if (transmittableDisplayNameSameAsDisplayName) TransmittableDisplayName = DisplayName;
            else if (transmittableDisplayNameIncluded)
                TransmittableDisplayName = Strings.ReadNullTerminatedString(binaryReader, stringsInUnicode);

            // This value specifies the number of columns from the RecipientColumns field that are included in 
            // the RecipientProperties field. 
            var columns = binaryReader.ReadInt16();

            // Skip the next 6 bytes
            binaryReader.ReadBytes(6);

            RecipientProperties = new List<Property>();
            for (var column = 0; column < columns; column++)
            {
                var type = (PropertyType)binaryReader.ReadUInt16();
                var id = binaryReader.ReadUInt16();
                byte[] data;

                switch (type)
                {
                    case PropertyType.PT_NULL:
                    {
                        data = new byte[0];
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_BOOLEAN:
                    {
                        data = binaryReader.ReadBytes(1);
                        binaryReader.ReadByte();
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_SHORT:
                    {
                        data = binaryReader.ReadBytes(2);
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_LONG:
                    case PropertyType.PT_FLOAT:
                    case PropertyType.PT_ERROR:
                    {
                        data = binaryReader.ReadBytes(4);
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_DOUBLE:
                    case PropertyType.PT_APPTIME:
                    case PropertyType.PT_I8:
                    case PropertyType.PT_SYSTIME:
                    {
                        data = binaryReader.ReadBytes(8);
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_CLSID:
                    {
                        data = binaryReader.ReadBytes(16);
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_OBJECT:
                        throw new NotSupportedException("The PT_OBJECT type is not supported");

                    case PropertyType.PT_STRING8:
                    case PropertyType.PT_UNICODE:
                    case PropertyType.PT_BINARY:
                    {
                        var length = binaryReader.ReadInt16();
                        data = binaryReader.ReadBytes(length);
                        RecipientProperties.Add(new Property(id, type, data));
                        break;
                    }

                    case PropertyType.PT_MV_SHORT:
                    {
                        var count = binaryReader.ReadInt16();
                        for (var i = 0; i < count; i++)
                        {
                            data = binaryReader.ReadBytes(2);
                            RecipientProperties.Add(new Property(id, type, data, i));
                        }
                        break;
                    }

                    case PropertyType.PT_MV_LONG:
                    case PropertyType.PT_MV_FLOAT:
                    {
                        var count = binaryReader.ReadInt16();
                        for (var i = 0; i < count; i++)
                        {
                            data = binaryReader.ReadBytes(4);
                            RecipientProperties.Add(new Property(id, type, data, i));
                        }
                        break;
                    }

                    case PropertyType.PT_MV_DOUBLE:
                    case PropertyType.PT_MV_APPTIME:
                    case PropertyType.PT_MV_LONGLONG:
                    case PropertyType.PT_MV_SYSTIME:
                    {
                        var count = binaryReader.ReadInt16();
                        for (var i = 0; i < count; i++)
                        {
                            data = binaryReader.ReadBytes(8);
                            RecipientProperties.Add(new Property(id, type, data, i));
                        }
                        break;
                    }

                    case PropertyType.PT_MV_TSTRING:
                    case PropertyType.PT_MV_STRING8:
                    case PropertyType.PT_MV_BINARY:
                    {
                        var count = binaryReader.ReadInt16();
                        for (var i = 0; i < count; i++)
                        {
                            var length = binaryReader.ReadInt16();
                            data = binaryReader.ReadBytes(length);
                            RecipientProperties.Add(new Property(id, type, data, i));
                        }
                        break;
                    }

                    case PropertyType.PT_MV_CLSID:
                    {
                        var count = binaryReader.ReadInt16();
                        for (var j = 0; j < count; j++)
                        {
                            data = binaryReader.ReadBytes(16);
                            RecipientProperties.Add(new Property(id, type, data));
                        }
                        break;
                    }

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                var addressTypeProperty = RecipientProperties.Find(m => m.Id == PropertyTags.PR_ADDRTYPE_W.Id);
                var emailAddressProperty = RecipientProperties.Find(m => m.Id == PropertyTags.PR_EMAIL_ADDRESS_W.Id);
                var smtpAddressProperty = RecipientProperties.Find(m => m.Id == PropertyTags.PR_SMTP_ADDRESS_W.Id);

                if (addressTypeProperty != null &&
                    addressTypeProperty.ToString == "EX" &&
                    smtpAddressProperty != null)
                {
                    EmailAddress = Helpers.EmailAddress.RemoveSingleQuotes(smtpAddressProperty.ToString);
                }
                else if (emailAddressProperty != null)
                    EmailAddress = Helpers.EmailAddress.RemoveSingleQuotes(emailAddressProperty.ToString);
            }

            if (string.IsNullOrWhiteSpace(DisplayName))
            {
                var value = RecipientProperties.Find(m => m.Id == PropertyTags.PR_DISPLAY_NAME_W.Id);
                if (value != null)
                    DisplayName = value.ToString;
            }

            if (string.IsNullOrWhiteSpace(SimpleDisplayName))
            {
                var value = RecipientProperties.Find(m => m.Id == PropertyTags.PR_7BIT_DISPLAY_NAME_W.Id);
                if (value != null)
                    SimpleDisplayName = value.ToString;
            }

            if (string.IsNullOrWhiteSpace(TransmittableDisplayName))
            {
                var value = RecipientProperties.Find(m => m.Id == PropertyTags.PR_TRANSMITABLE_DISPLAY_NAME_W.Id);
                if (value != null)
                    TransmittableDisplayName = value.ToString;
            }

            if (transmittableDisplayNameSameAsDisplayName) TransmittableDisplayName = DisplayName;

            var recipientTypeProperty = RecipientProperties.Find(m => m.Id == PropertyTags.PR_RECIPIENT_TYPE.Id);
            if (recipientTypeProperty != null)
                RecipientType = (RecipientType)recipientTypeProperty.ToInt;

            var displayTypeProperty = RecipientProperties.Find(m => m.Id == PropertyTags.PR_RECIPIENT_TYPE.Id);
            if (displayTypeProperty != null)
                RecipientRowDisplayType = (RecipientRowDisplayType)displayTypeProperty.ToInt;
        }
        #endregion
    }
}
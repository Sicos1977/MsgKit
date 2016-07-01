using System.Collections;
using System.Collections.Generic;
using System.IO;
using MsgWriter.Helpers;

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

namespace MsgWriter.Structures
{
    #region Enum AddressType
    /// <summary>
    ///     The <see cref="RecipientRow.DisplayType" />
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        ///     No type is set
        /// </summary>
        NoType = 0x0,

        /// <summary>
        ///     X500DN
        /// </summary>
        X500Dn = 0x1,

        /// <summary>
        ///     Ms mail
        /// </summary>
        MsMail = 0x2,

        /// <summary>
        ///     SMTP
        /// </summary>
        Smtp = 0x3,

        /// <summary>
        ///     Fax
        /// </summary>
        Fax = 0x4,

        /// <summary>
        ///     Professional office system
        /// </summary>
        ProfessionalOfficeSystem = 0x5,

        /// <summary>
        ///     Personal distribution list 1
        /// </summary>
        PersonalDistributionList1 = 0x6,

        /// <summary>
        ///     Personal distribution list 2
        /// </summary>
        PersonalDistributionList2 = 0x7
    }
    #endregion

    #region Enum DisplayType
    /// <summary>
    ///     An enumeration. This field MUST be present when the Type field
    ///     of the RecipientFlags field is set to X500DN(0x1) and MUST NOT be present otherwise.This
    ///     value specifies the display type of this address.Valid values for this field are specified in the
    ///     following table.
    /// </summary>
    public enum DisplayType
    {
        /// <summary>
        ///     A messaging user
        /// </summary>
        MessagingUser = 0x00,

        /// <summary>
        ///     A distribution list
        /// </summary>
        DistributionList = 0x01,

        /// <summary>
        ///     A forum, such as a bulletin board service or a public or shared folder
        /// </summary>
        Forum = 0x02,

        /// <summary>
        ///     An automated agent
        /// </summary>
        AutomatedAgent = 0x03,

        /// <summary>
        ///     An Address Book object defined for a large group, such as helpdesk, accounting, coordinator, or
        ///     department
        /// </summary>
        AddressBook = 0x04,

        /// <summary>
        ///     A private, personally administered distribution list
        /// </summary>
        PrivateDistributionList = 0x05,

        /// <summary>
        ///     An Address Book object known to be from a foreign or remote messaging system
        /// </summary>
        RemoteAddressBook = 0x06
    }
    #endregion

    #region Enum AddressBookEntryId
    /// <summary>
    ///     An integer representing the type of the object. It MUST be one of the values from the following table.
    /// </summary>
    public enum AddressBookEntryIdType
    {
        /// <summary>
        /// A local mail user
        /// </summary>
        LocalMailUser = 0x00000000,

        /// <summary>
        /// A distribution list
        /// </summary>
        DistributionList = 0x00000001,

        /// <summary>
        /// A bulletinboard or public folder
        /// </summary>
        BulletinBoardOrPublicFolder = 0x00000002,

        /// <summary>
        /// An automated mailbox
        /// </summary>
        AutomatedMailBox = 0x00000003,

        /// <summary>
        /// An organiztional mailbox
        /// </summary>
        OrganizationalMailBox = 0x00000004,

        /// <summary>
        /// A private distribtion list
        /// </summary>
        PrivateDistributionList = 0x00000005,

        /// <summary>
        /// A remote mail user
        /// </summary>
        RemoteMailUser = 0x00000006,

        /// <summary>
        /// A container
        /// </summary>
        Container = 0x00000100,

        /// <summary>
        /// A template
        /// </summary>
        Template = 0x00000101,

        /// <summary>
        /// One off user
        /// </summary>
        OneOffUser = 0x00000102,

        /// <summary>
        /// Search
        /// </summary>
        Search = 0x00000200
    }
    #endregion

    /// <summary>
    ///     The PidLidAppointmentUnsendableRecipients  property ([MS-OXPROPS] section 2.35) contains a list of
    ///     unsendable attendees. This property is not required but SHOULD be set
    /// </summary>
    public class UnsendableRecipients : List<RecipientRow>
    {
        #region Properties
        /// <summary>
        ///     An integer that specifies the number of structures in the RecipientRow field
        /// </summary>
        public uint RowCount { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', a different transport is responsible for delivery to this recipient(1).
        /// </summary>
        public bool DifferentTransportDelivery { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', the DisplayName (section 2.8.3.2) field is included
        /// </summary>
        public bool DisplayNameIncluded { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', the EmailAddress (section 2.8.3.2) field is included.
        /// </summary>
        public bool EmailAddressIncluded { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', this recipient (1) has a non-standard address type and the AddressType field is included.
        /// </summary>
        public bool AddressTypeIncluded { get; }

        /// <summary>
        ///     If this flag is b'1', the SimpleDisplayName field is included.
        /// </summary>
        public bool SimpleDisplayNameIncluded { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', the value of the TransmittableDisplayName field is the same as the value of the DisplayName
        ///     field.
        /// </summary>
        public bool TransmittableDisplayNameSameAsDisplayName { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', the TransmittableDisplayName (section 2.8.3.2) field is included.
        /// </summary>
        public bool TransmittableDisplayNameIncluded { get; internal set; }

        /// <summary>
        ///     If this flag is b'1', the associated string properties are in Unicode with a 2-
        ///     byte terminating null character; if this flag is b'0', string properties are MBCS with a single
        ///     terminating null character, in the code page sent to the server in the EcDoConnectEx method,
        ///     as specified in [MS-OXCRPC] section 3.1.4.1, or the Connect request type 6, as specified in
        ///     [MS-OXCMAPIHTTP] section 2.2.4.1.
        /// </summary>
        public bool StringsInUnicode { get; internal set; }
        #endregion

        #region Constructor
        internal UnsendableRecipients(byte[] data)
        {
            var binaryReader = new BinaryReader(new MemoryStream(data));
            RowCount = binaryReader.ReadUInt32();

            // RecipientFlags https://msdn.microsoft.com/en-us/library/ee201786(v=exchg.80).aspx
            var b = new BitArray(binaryReader.ReadBytes(4));
            DifferentTransportDelivery = b[0];
            TransmittableDisplayNameSameAsDisplayName = b[1];
            TransmittableDisplayNameIncluded = b[2];
            DisplayNameIncluded = b[3];
            EmailAddressIncluded = b[4];
            // This enumeration specifies the type of address.
            var bt = new BitArray(3);
            bt.Set(0, b[5]);
            bt.Set(1, b[6]);
            bt.Set(2, b[7]);
            var array = new int[1];
            bt.CopyTo(array, 0);
            var recipientType = (AddressType)array[0];
            AddressTypeIncluded = b[8];
            SimpleDisplayNameIncluded = b[13];
            StringsInUnicode = b[14];
            var supportsRtf = !b[15];

            while (!binaryReader.Eos())
                Add(new RecipientRow(binaryReader,
                    recipientType,
                    supportsRtf,
                    DisplayNameIncluded,
                    EmailAddressIncluded,
                    AddressTypeIncluded,
                    SimpleDisplayNameIncluded,
                    TransmittableDisplayNameSameAsDisplayName,
                    TransmittableDisplayNameIncluded, StringsInUnicode));
        }
        #endregion
    }
}
//
// UnsendableRecipients.cs
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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using MsgKit.Enums;
using MsgKit.Helpers;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The PidLidAppointmentUnsendableRecipients property ([MS-OXPROPS] section 2.35) contains a list of
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
            var recipientType = (RecipientRowAddressType)array[0];
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
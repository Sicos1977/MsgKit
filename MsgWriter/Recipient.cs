using System;
using System.Collections.Generic;
using MsgWriter.Enums;
using MsgWriter.Helpers;
using MsgWriter.Streams;
using MsgWriter.Structures;
using OpenMcdf;

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

namespace MsgWriter
{
    /// <summary>
    ///     Contains a list of <see cref="Recipients"/> objects that are added to a <see cref="Message"/>
    /// </summary>
    public sealed class Recipients : List<Recipient>
    {
        #region AddRecipient
        /// <summary>
        ///     Add's an <see cref="RecipientType.To"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="addrType">The <see cref="RecipientAddrType"/></param>
        public void AddRecipientTo(string email, 
                                   string displayName = "",
                                    RecipientAddrType addrType = RecipientAddrType.Smtp)
        {
            Add(new Recipient(email,
                              displayName,
                              RecipientType.To));
        }

        /// <summary>
        ///     Add's an <see cref="RecipientType.Cc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="addrType">The <see cref="RecipientAddrType"/></param>
        public void AddRecipientCc(string email, 
                                   string displayName = "",
                                   RecipientAddrType addrType = RecipientAddrType.Smtp)
        {
            Add(new Recipient(email,
                              displayName,
                              RecipientType.Cc));
        }

        /// <summary>
        ///     Add's an <see cref="RecipientType.Bcc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="addrType">The <see cref="RecipientAddrType"/></param>
        public void AddRecipientBcc(string email, 
                                    string displayName = "",
                                    RecipientAddrType addrType = RecipientAddrType.Smtp)
        {
            Add(new Recipient(email,
                              displayName,
                              RecipientType.Bcc));
        }

        /// <summary>
        ///     Add's an <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="type">The <see cref="RecipientType"/></param>
        /// <param name="addrType">The <see cref="RecipientAddrType"/></param>
        public void AddRecipient(string email,
                                 string displayName, 
                                 RecipientType type,
                                 RecipientAddrType addrType = RecipientAddrType.Smtp)
        {
            Add(new Recipient(email,
                              displayName,
                              type));
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes the <see cref="Recipient"/> objects to the given <paramref name="rootStorage"/>
        ///     and it will set all the needed properties
        /// </summary>
        /// <param name="rootStorage">The root <see cref="CFStorage"/></param>
        internal void WriteToStorage(CFStorage rootStorage)
        {
            for (var index = 0; index < Count; index++)
            {
                var recipient = this[index];
                var storage = rootStorage.AddStorage(PropertyTags.RecipientStoragePrefix + index.ToString("X8").ToUpper());
                recipient.WriteProperties(storage);
            }
        }
        #endregion
    }

    /// <summary>
    /// This class represents a recipient
    /// </summary>
    public sealed class Recipient
    {
        #region Fields
        private RecipientAddrType _addrType;
        #endregion

        #region Properties
        /// <summary>
        ///     The E-mail address
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        ///     The display name
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        ///     The <see cref="RecipientType"/>
        /// </summary>
        public RecipientType Type { get; private set; }

        /// <summary>
        ///     Returns the messaging user's e-mail address type. Use <see cref="AddrTypeString"/>
        ///     when this property returns <see cref="RecipientAddrType.Unknown"/>
        /// </summary>
        public RecipientAddrType AddrType
        {
            get { return _addrType; }
            private set
            {
                _addrType = value;
                switch (value)
                {
                    case RecipientAddrType.Unknown:
                        AddrTypeString = string.Empty;
                        break;

                    case RecipientAddrType.Ex:
                        AddrTypeString = "EX";
                        break;

                    case RecipientAddrType.Smtp:
                        AddrTypeString = "SMTP";
                        break;

                    case RecipientAddrType.Fax:
                        AddrTypeString = "FAX";
                        break;

                    case RecipientAddrType.Mhs:
                        AddrTypeString = "MHS";
                        break;

                    case RecipientAddrType.Profs:
                        AddrTypeString = "PROFS";
                        break;

                    case RecipientAddrType.X400:
                        AddrTypeString = "X400";
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        /// <summary>
        ///     Returns the <see cref="AddrType"/> as a string
        /// </summary>
        public string AddrTypeString { get; private set; }

        /// <summary>
        ///     The <see cref="RecipientFlags"/>
        /// </summary>
        public RecipientFlags Flags { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates a new recipient object and sets all its properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="type">The <see cref="RecipientType"/></param>
        /// <param name="addrType">The <see cref="RecipientAddrType"/></param>
        internal Recipient(string email, 
                           string displayName, 
                           RecipientType type, 
                           RecipientAddrType addrType = RecipientAddrType.Smtp)
        {
            Email = email;
            DisplayName = string.IsNullOrWhiteSpace(displayName) ? email : displayName;
            Type = type;
            AddrType = addrType;
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all <see cref="Property">properties</see> either as a <see cref="CFStream"/> or as a collection in
        ///     a <see cref="PropertyTags.PropertiesStreamName"/> stream to the given <see cref="storage"/>, this depends 
        ///     on the <see cref="PropertyType"/>
        /// </summary>
        /// <remarks>
        ///     See the <see cref="Properties"/> class it's <see cref="Properties.WriteProperties"/> method for the logic
        ///     that is used to determine this
        /// </remarks>
        /// <param name="storage">The <see cref="CFStorage"/></param>
        internal void WriteProperties(CFStorage storage)
        {
            var propertiesStream = new RecipientProperties();
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RECORD_KEY, Mapi.GenerateRecordKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_TYPE, (int) Type);
            propertiesStream.AddProperty(PropertyTags.PR_EMAIL_ADDRESS_W, Email);
            propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_DISPLAY_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_ADDRTYPE_W, AddrTypeString);
            propertiesStream.WriteProperties(storage);
        }
        #endregion
    }
}

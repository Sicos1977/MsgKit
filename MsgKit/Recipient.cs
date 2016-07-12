using System.Collections.Generic;
using MsgKit.Enums;
using MsgKit.Helpers;
using MsgKit.Streams;
using MsgKit.Structures;
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

namespace MsgKit
{
    /// <summary>
    ///     Contains a list of <see cref="Recipients"/> objects that are added to a <see cref="Message"/>
    /// </summary>
    public class Recipients : List<Recipient>
    {
        #region AddRecipient
        /// <summary>
        ///     Add's an <see cref="RecipientType.To"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        public void AddRecipientTo(string email, 
                                   string displayName = "",
                                   AddressType addressType = AddressType.Smtp)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              RecipientType.To));
        }

        /// <summary>
        ///     Add's an <see cref="RecipientType.Cc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        public void AddRecipientCc(string email, 
                                   string displayName = "",
                                   AddressType addressType = AddressType.Smtp)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              RecipientType.Cc));
        }

        /// <summary>
        ///     Add's an <see cref="RecipientType.Bcc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        public void AddRecipientBcc(string email, 
                                    string displayName = "",
                                    AddressType addressType = AddressType.Smtp)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              RecipientType.Bcc));
        }

        /// <summary>
        ///     Add's an <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        /// <param name="recipientType">The <see cref="RecipientType"/></param>
        public void AddRecipient(string email,
                                 string displayName, 
                                 AddressType addressType,
                                 RecipientType recipientType)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              recipientType));
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes the <see cref="Recipient"/> objects to the given <paramref name="rootStorage"/>
        ///     and it will set all the needed properties
        /// </summary>
        /// <param name="rootStorage">The root <see cref="CFStorage"/></param>
        /// <returns>
        ///     Total size of the written <see cref="Recipient"/> objects and it's <see cref="Properties"/>
        /// </returns>
        internal long WriteToStorage(CFStorage rootStorage)
        {
            long size = 0;

            for (var index = 0; index < Count; index++)
            {
                var recipient = this[index];
                var storage = rootStorage.AddStorage(PropertyTags.RecipientStoragePrefix + index.ToString("X8").ToUpper());
                size += recipient.WriteProperties(storage);
            }

            return size;
        }
        #endregion
    }

    /// <summary>
    ///     This class represents a recipient
    /// </summary>
    public class Recipient : Address
    {
        #region Properties
        /// <summary>
        ///     Returns or sets a unique identifier for a recipient in a recipient table or status table.
        /// </summary>
        public long RowId { get; private set; }

        /// <summary>
        ///     The <see cref="RecipientType"/>
        /// </summary>
        public RecipientType RecipientType { get; private set; }

        /// <summary>
        ///     The <see cref="RecipientFlags"/>
        /// </summary>
        public RecipientFlags Flags { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates a new recipient object and sets all its properties
        /// </summary>
        /// <param name="rowId">Contains a unique identifier for a recipient in a recipient table or status table.</param>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="recipientType">The <see cref="RecipientType"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        internal Recipient(long rowId,
                           string email, 
                           string displayName,
                           AddressType addressType,
                           RecipientType recipientType) : base(email, displayName, addressType)
        {
            RowId = rowId;
            Email = email;
            DisplayName = string.IsNullOrWhiteSpace(displayName) ? email : displayName;
            AddressType = addressType;
            RecipientType = recipientType;
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
        /// <returns>
        ///     Total size of the written <see cref="Recipient"/> object and it's <see cref="Properties"/>
        /// </returns>
        internal long WriteProperties(CFStorage storage)
        {
            var propertiesStream = new RecipientProperties();
            propertiesStream.AddProperty(PropertyTags.PR_ROWID, RowId);
            propertiesStream.AddProperty(PropertyTags.PR_ENTRYID, Mapi.GenerateEntryId());
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey());
            propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_TYPE, RecipientType);
            propertiesStream.AddProperty(PropertyTags.PR_ADDRTYPE_W, AddressTypeString);
            propertiesStream.AddProperty(PropertyTags.PR_EMAIL_ADDRESS_W, Email);
            propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_SEARCH_KEY, Mapi.GenerateSearchKey(AddressTypeString, Email));
            return propertiesStream.WriteProperties(storage);
        }
        #endregion
    }
}

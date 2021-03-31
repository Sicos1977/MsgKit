//
// Recipient.cs
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

using System.Collections.Generic;
using MsgKit.Enums;
using MsgKit.Helpers;
using MsgKit.Streams;
using MsgKit.Structures;
using OpenMcdf;

namespace MsgKit
{
    /// <summary>
    ///     Contains a list of <see cref="Recipients"/> objects that are added to a <see cref="Message"/>
    /// </summary>
    public class Recipients : List<Recipient>
    {
        #region Add
        /// <summary>
        ///     Adds an <see cref="RecipientType.To"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        /// <param name="objectType"><see cref="MapiObjectType"/></param>
        /// <param name="displayType"><see cref="RecipientRowDisplayType"/></param>
        public void AddTo(string email, 
                          string displayName = "",
                          AddressType addressType = AddressType.Smtp, 
                          MapiObjectType objectType = MapiObjectType.MAPI_MAILUSER,
                          RecipientRowDisplayType displayType = RecipientRowDisplayType.MessagingUser)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              RecipientType.To,
                              objectType,
                              displayType
                              ));
        }

        /// <summary>
        ///     Adds an <see cref="RecipientType.Cc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        /// <param name="objectType"><see cref="MapiObjectType"/></param>
        /// <param name="displayType"><see cref="RecipientRowDisplayType"/></param>
        public void AddCc(string email, 
                          string displayName = "",
                          AddressType addressType = AddressType.Smtp,
                          MapiObjectType objectType = MapiObjectType.MAPI_MAILUSER,
                          RecipientRowDisplayType displayType = RecipientRowDisplayType.MessagingUser)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              RecipientType.Cc,
                              objectType,
                              displayType));
        }

        /// <summary>
        ///     Adds an <see cref="RecipientType.Bcc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        /// <param name="objectType"><see cref="MapiObjectType"/></param>
        /// <param name="displayType"><see cref="RecipientRowDisplayType"/></param>
        public void AddBcc(string email, 
                           string displayName = "",
                           AddressType addressType = AddressType.Smtp,
                           MapiObjectType objectType = MapiObjectType.MAPI_MAILUSER,
                           RecipientRowDisplayType displayType = RecipientRowDisplayType.MessagingUser)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              RecipientType.Bcc,
                              objectType,
                              displayType));
        }

        /// <summary>
        ///     Adds an <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        /// <param name="recipientType">The <see cref="RecipientType"/></param>
        /// <param name="objectType"><see cref="MapiObjectType"/></param>
        /// <param name="displayType"><see cref="RecipientRowDisplayType"/></param>
        public void AddRecipient(string email,
                                 string displayName, 
                                 AddressType addressType,
                                 RecipientType recipientType,
                                 MapiObjectType objectType = MapiObjectType.MAPI_MAILUSER,
                                 RecipientRowDisplayType displayType = RecipientRowDisplayType.MessagingUser)
        {
            Add(new Recipient(Count,
                              email,
                              displayName,
                              addressType,
                              recipientType,
                              objectType,
                              displayType));
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
        public long RowId { get; }

        /// <summary>
        ///     The <see cref="RecipientType"/>
        /// </summary>
        public RecipientType RecipientType { get; }

        /// <summary>
        ///     The <see cref="RecipientFlags"/>
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public RecipientFlags Flags { get; private set; }

        /// <summary>
        /// Contains the type of email object. 
        /// </summary>
        public MapiObjectType ObjectType { get; }

        /// <summary>
        /// Contains the display type. 
        /// </summary>
        public RecipientRowDisplayType DisplayType { get; }
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
        /// <param name="objectType"><see cref="MapiObjectType"/></param>
        /// <param name="displayType"><see cref="RecipientRowDisplayType"/></param>
        internal Recipient(long rowId,
                           string email, 
                           string displayName,
                           AddressType addressType,
                           RecipientType recipientType,
                           MapiObjectType objectType,
                           RecipientRowDisplayType displayType) : base(email, displayName, addressType)
        {
            RowId = rowId;
            Email = email;
            DisplayName = string.IsNullOrWhiteSpace(displayName) ? email : displayName;
            AddressType = addressType;
            RecipientType = recipientType;
            DisplayType = displayType;
            ObjectType = objectType;
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all <see cref="Property">properties</see> either as a <see cref="CFStream"/> or as a collection in
        ///     a <see cref="PropertyTags.PropertiesStreamName"/> stream to the given <paramref name="storage"/>, this depends 
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
            propertiesStream.AddProperty(PropertyTags.PR_OBJECT_TYPE, ObjectType);
            propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_TYPE, DisplayType);
            propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_SEARCH_KEY, Mapi.GenerateSearchKey(AddressTypeString, Email));
            return propertiesStream.WriteProperties(storage);
        }
        #endregion
    }
}

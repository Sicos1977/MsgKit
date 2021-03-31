//
// Sender.cs
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

using MsgKit.Enums;
using MsgKit.Streams;
using MsgKit.Structures;
using OpenMcdf;

namespace MsgKit
{
    /// <summary>
    ///     Contains the message sender's e-mail address.
    /// </summary>
    /// <remarks>
    ///     These properties are examples of the address properties for the message sender. They must be set by the outgoing
    ///     transport provider, which should never propagate any previously existing values.
    /// </remarks>
    public class Sender : Address
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

        /// <summary>
        ///     Set to <c>true</c> when the sender is also the creator of the message (default <c>true</c>)
        /// </summary>
        private readonly bool _senderIsCreator;
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email" /></param>
        /// <param name="addressType">The <see cref="Address.AddressType" /></param>
        /// <param name="messageFormat"><see cref="MessageFormat"/></param>
        /// <param name="canLookupEmailAddress">Indicates that the <paramref name="email"/> address 
        /// can be lookup in the addressbook. This parameter is only usefull when opening E-mails in an Exchange environment</param>
        /// <param name="senderIsCreator">Set to <c>true</c> when the sender is also the creator of the message (default <c>true</c>)</param>
        public Sender(string email, 
                      string displayName, 
                      AddressType addressType = AddressType.Smtp,
                      MessageFormat messageFormat = MessageFormat.TextAndHtml,
                      bool canLookupEmailAddress = false,
                      bool senderIsCreator = true)
            : base(email, displayName, addressType)
        {
            _messageFormat = messageFormat;
            _canLookupEmailAddress = canLookupEmailAddress;
            _senderIsCreator = senderIsCreator;
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all <see cref="Property">properties</see> either as a <see cref="CFStream"/> or as a collection in
        ///     a <see cref="PropertyTags.PropertiesStreamName"/> stream, this depends on the <see cref="PropertyType"/>
        /// </summary>
        /// <remarks>
        ///     See the <see cref="Properties"/> class it's <see cref="Properties.WriteProperties"/> method for the logic
        ///     that is used to determine this
        /// </remarks>
        /// <param name="propertiesStream">The <see cref="TopLevelProperties"/></param>
        internal void WriteProperties(TopLevelProperties propertiesStream)
        {
            if (_senderIsCreator)
            {
                propertiesStream.AddProperty(PropertyTags.PR_CreatorEmailAddr_W, Email);
                propertiesStream.AddProperty(PropertyTags.PR_CreatorSimpleDispName_W, DisplayName);
                propertiesStream.AddProperty(PropertyTags.PR_CreatorAddrType_W, AddressTypeString);
            }

            var senderEntryId = new OneOffEntryId(Email, 
                                                  DisplayName, 
                                                  AddressType, 
                                                  _messageFormat, 
                                                  _canLookupEmailAddress);

            propertiesStream.AddProperty(PropertyTags.PR_SENDER_ENTRYID, senderEntryId.ToByteArray());

            propertiesStream.AddProperty(PropertyTags.PR_SENDER_EMAIL_ADDRESS_W, Email);
            propertiesStream.AddProperty(PropertyTags.PR_SENDER_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_SENDER_ADDRTYPE_W, AddressTypeString);
        }
        #endregion
    }
}
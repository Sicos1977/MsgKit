//
// ReceivingRepresenting.cs
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
    ///     Contains the e-mail address for the messaging user who is represented by the receiving user.
    /// </summary>
    /// <remarks>
    ///     These properties are examples of the address properties for the messaging user who is being represented by the
    ///     receiving user. They must be set by the incoming transport provider, which is also responsible for authorization or
    ///     verification of the delegate. If no messaging user is being represented, these properties should be set to the
    ///     e-mail address contained in the PR_RECEIVED_BY_EMAIL_ADDRESS (PidTagReceivedByEmailAddress) property.
    /// </remarks>
    public class ReceivingRepresenting : Address
    {
        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email" /></param>
        /// <param name="addressType">The <see cref="Address.AddressType" /></param>
        public ReceivingRepresenting(string email, string displayName, AddressType addressType = AddressType.Smtp)
            : base(email, displayName, addressType)
        {
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
            propertiesStream.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_EMAIL_ADDRESS_W, Email);
            propertiesStream.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_ADDRTYPE_W, AddressTypeString);
        }
        #endregion
    }
}
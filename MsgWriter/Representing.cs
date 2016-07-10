using MsgWriter.Enums;
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
    ///     Contains the e-mail address for the messaging user represented by the sender.
    /// </summary>
    /// <remarks>
    ///     These properties are examples of the address properties for the messaging user who is being represented by the
    ///     <see cref="Receiving" /> user. They must be set by the incoming transport provider, which is also responsible for
    ///     authorization or
    ///     verification of the delegate. If no messaging user is being represented, these properties should be set to the
    ///     e-mail address contained in the PR_RECEIVED_BY_EMAIL_ADDRESS (PidTagReceivedByEmailAddress) property.
    /// </remarks>
    public class Representing : Address
    {
        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email" /></param>
        /// <param name="addressType">The <see cref="Address.AddressType" /></param>
        public Representing(string email, string displayName, AddressType addressType = AddressType.Smtp)
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
            propertiesStream.AddProperty(PropertyTags.PR_SENT_REPRESENTING_EMAIL_ADDRESS_W, Email);
            propertiesStream.AddProperty(PropertyTags.PR_SENT_REPRESENTING_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_SENT_REPRESENTING_ADDRTYPE_W, AddressTypeString);
        }
        #endregion
    }
}
using MsgWriter.Enums;

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
    }
}
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
    ///     This class represents an Outlook sender (e.g. keesvanspelde@hotmail.com)
    /// </summary>
    public sealed class Sender
    {
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
        ///     The message sender's e-mail address type (default set to SMTP)
        /// </summary>
        public string AddressType { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates a new recipient object and sets all its properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email" /></param>
        /// <param name="addressType">The message sender's e-mail address type (default set to SMTP)</param>
        public Sender(string email,
            string displayName,
            string addressType = "SMTP")
        {
            Email = email;
            DisplayName = displayName;
            AddressType = addressType;
        }
        #endregion
    }
}
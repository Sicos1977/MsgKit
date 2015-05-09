using System;
using MsgWriter.Helpers;

/*
   Copyright 2015 Kees van Spelde

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
    #region Enum RecipientType
    /// <summary>
    /// The recipient type
    /// </summary>
    internal enum RecipientType : uint
    {
        /// <summary>
        ///     The recipient is an TO E-mail address
        /// </summary>
        To = 0x0001,

        /// <summary>
        ///     The recipient is a CC E-mail address
        /// </summary>
        Cc = 0x0002,

        /// <summary>
        ///     The recipient is a BCC E-mail address
        /// </summary>
        Bcc = 0x0003,

        /// <summary>
        ///     The recipient is a resource (e.g. a room)
        /// </summary>
        Resource = 0x0004,

        /// <summary>
        ///     The recipient is a room (uses PR_RECIPIENT_TYPE_EXE) needs Exchange 2007 or higher
        /// </summary>
        Room = 0x0007
    }
    #endregion

    /// <summary>
    /// This class represents an Outlook recipient
    /// </summary>
    public sealed class Recipient
    {
        #region Public enum RecipientType
        /// <summary>
        /// Recipient types
        /// </summary>
        public enum RecipientType
        {
            /// <summary>
            /// The recipient is an TO E-mail address
            /// </summary>
            To,

            /// <summary>
            /// The recipient is a CC E-mail address
            /// </summary>
            Cc,

            /// <summary>
            /// The recipient is a BCC E-mail address
            /// </summary>
            Bcc,

            /// <summary>
            /// The recipient is a resource (e.g. a room)
            /// </summary>
            Resource,

            /// <summary>
            ///     The recipient is a room (uses PR_RECIPIENT_TYPE_EXE) needs Exchange 2007 or higher
            /// </summary>
            Room
        }
        #endregion

        #region Properties
        /// <summary>
        /// The E-mail address
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// The display name
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// The <see cref="RecipientType"/>
        /// </summary>
        public RecipientType Type { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="displayName"></param>
        /// <param name="type"></param>
        internal Recipient(string email, string displayName, RecipientType type)
        {
            //if (EmailAddress.IsEmailAddressValid(tempDisplayName))
            //{
            //    // If the displayname is an emailAddress them move it
            //    Email = tempDisplayName;
            //    DisplayName = tempDisplayName;
            //}

            //if (string.Equals(tempEmail, tempDisplayName, StringComparison.InvariantCultureIgnoreCase))
            //    DisplayName = string.Empty;
        }
        #endregion
    }
}

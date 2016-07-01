using System.Collections.Generic;
using MsgWriter.Streams;
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
    #region Enum RecipientType
    /// <summary>
    /// The recipient type
    /// </summary>
    public enum RecipientType : uint
    {
        /// <summary>
        ///     The recipient is unknown/not set
        /// </summary>
        Unknown = 0x0000,

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
    /// Contains a list of <see cref="Recipients"/> objects that are added to a message
    /// </summary>
    public sealed class Recipients : List<Recipient>
    {
        #region AddRecipient
        /// <summary>
        /// Add's an <see cref="RecipientType.To"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        public void AddRecipientTo(string email, string displayName)
        {
            Add(new Recipient(email,
                              displayName,
                              RecipientType.To));
        }

        /// <summary>
        /// Add's an <see cref="RecipientType.Cc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        public void AddRecipientCc(string email, string displayName)
        {
            Add(new Recipient(email,
                              displayName,
                              RecipientType.Cc));
        }

        /// <summary>
        /// Add's an <see cref="RecipientType.Bcc"/> <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        public void AddRecipientBcc(string email, string displayName)
        {
            Add(new Recipient(email,
                              displayName,
                              RecipientType.Bcc));
        }

        /// <summary>
        /// Add's an <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="type"><see cref="RecipientType"/></param>
        public void AddRecipient(string email,
                           string displayName, 
                           RecipientType type)
        {
            Add(new Recipient(email,
                              displayName,
                              type));
        }
        #endregion

        #region AddToStorage
        /// <summary>
        ///     Add's the <see cref="Recipient"/> objects to the given <paramref name="rootStorage"/>
        ///     and it will set all the needed properties
        /// </summary>
        /// <param name="rootStorage">The root <see cref="CFStorage"/></param>
        internal void AddToStorage(CFStorage rootStorage)
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
        /// Creates a new recipient object and sets all its properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        public Recipient(string email,
                         string displayName)
        {
            Email = email;
            DisplayName = displayName;
            Type = RecipientType.Unknown;
        }

        /// <summary>
        /// Creates a new recipient object and sets all its properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="type"></param>
        internal Recipient(string email,
                           string displayName, 
                           RecipientType type)
        {
            Email = email;
            DisplayName = displayName;
            Type = type;
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
            var propertiesStream = new RecipientPropertiesStream();
            propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_TYPE, (int) Type);
            propertiesStream.AddProperty(PropertyTags.PR_EMAIL_ADDRESS_W, Email);
            propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, DisplayName);
            propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_DISPLAY_NAME_W, DisplayName);
            // TODO : Check address types
            //propertiesStream.AddProperty(PropertyTags.PR_ADDRTYPE_W, "SMTP");
            propertiesStream.WriteProperties(storage);
        }
        #endregion
    }
}

using System.Collections.Generic;
using MsgWriter.Helpers;
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
        /// Add's an <see cref="Recipient"/>
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <see cref="email"/></param>
        /// <param name="type"></param>
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
        /// This method add's the <see cref="Recipient"/> objects to the given <paramref name="rootStorage"/>
        /// and it will set all the needed properties
        /// </summary>
        /// <param name="rootStorage"></param>
        internal void AddToStorage(CFStorage rootStorage)
        {
            for (var i = 0; i < Count; i++)
            {
                //var attachment = this[i];
                //var storage = rootStorage.AddStorage("__attach_version1.0_#" + i.ToString("X8").ToUpper());
                //var stream = storage.AddStream("__substg1.0_3001001F");
                //stream.SetData(Encoding.Unicode.GetBytes(attachment.FileName));
                //stream = storage.AddStream("__substg1.0_37010102");
                //stream.SetData(attachment.Stream.ToByteArray());
            }
        }
        #endregion
    }

    /// <summary>
    /// This class represents an Outlook recipient
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
    }
}

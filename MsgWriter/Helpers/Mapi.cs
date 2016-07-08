using System;
using System.Text;

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

namespace MsgWriter.Helpers
{
    /// <summary>
    ///     This class contains MAPI related helper methods
    /// </summary>
    internal static class Mapi
    {
        #region Fields
        private static byte[] _instanceKey;
        #endregion

        #region GenerateSearchKey
        /// <summary>
        ///     A search key is used to compare the data in two objects. An object's search key is stored in its
        ///     <see cref="PropertyTags.PR_SEARCH_KEY" /> (PidTagSearchKey) property. Because a search key
        ///     represents an object's data and not the object itself, two different objects with the same data can have the same
        ///     search key. When an object is copied, for example, both the original object and its copy have the same data and the
        ///     same search key. Messages and messaging users have search keys. The search key of a message is a unique identifier
        ///     of  the message's data. Message store providers furnish a message's <see cref="PropertyTags.PR_SEARCH_KEY" />
        ///     property at message creation time.The search key of an address book entry is computed from its address type(
        ///     <see cref="PropertyTags.PR_ADDRTYPE_W" /> (PidTagAddressType)) and address
        ///     (<see cref="PropertyTags.PR_EMAIL_ADDRESS_W" /> (PidTagEmailAddress)). If the address book entry is writeable, 
        ///     its search key might not be available until the address type and address have been set by using the 
        ///     IMAPIProp::SetProps method and the entry has been saved by using the IMAPIProp::SaveChanges method.When these
        ///     address properties change, it is possible for the corresponding search key not to be synchronized with the new
        ///     values until the changes have been committed with a SaveChanges call. The value of an object's record key can be 
        ///     the same as or different than the value of its search key, depending on the service provider. Some service providers 
        ///     use the same value for an object's search key, record key, and entry identifier.Other service providers assign unique 
        ///     values for each of its objects identifiers.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateSearchKey(string addressType, string emailAddress)
        {
            if (string.IsNullOrEmpty(addressType))
                throw new ArgumentNullException("addressType");

            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException("emailAddress");

            var searchKey = addressType + emailAddress;
            return Encoding.Unicode.GetBytes(searchKey);
        }
        #endregion

        #region GenerateRecordKey
        /// <summary>
        ///     A record key is used to compare two objects. Message store and address book objects must have record keys, which
        ///     are stored in their <see cref="PropertyTags.PR_RECORD_KEY" /> (PidTagRecordKey) property. Because a record key
        ///     identifies an object and not its data, every instance of an object has a unique record key. The scope of a record
        ///     key for folders and messages is the message store. The scope for address book containers, messaging users, and
        ///     distribution lists is the set of top-level containers provided by MAPI for use in the integrated address book.
        ///     Record keys can be duplicated in another resource. For example, different messages in two different message stores
        ///     can have the same record key. This is different from long-term entry identifiers; because long-term entry
        ///     identifiers contain a reference to the service provider, they have a wider scope.A message store's record key is
        ///     similar in scope to a long-term entry identifier; it should be unique across all message store providers. To ensure
        ///     this uniqueness, message store providers typically set their record key to a value that is the combination of their
        ///     <see cref="PropertyTags.PR_MDB_PROVIDER" /> (PidTagStoreProvider) property and an identifier that is unique to the
        ///     message store.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRecordKey()
        {
            var guid = Guid.NewGuid();
            return guid.ToByteArray();
        }
        #endregion

        #region GenerateInstanceKey
        /// <summary>
        ///     This property is a binary value that uniquely identifies a row in a table view. It is a required column in most
        ///     tables. If a row is included in two views, there are two different instance keys. The instance key of a row may
        ///     differ each time the table is opened, but remains constant while the table is open. Rows added while a table is in
        ///     use do not reuse an instance key that was previously used.
        ///     message store.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateInstanceKey()
        {
            if (_instanceKey == null)
            {
                _instanceKey = new byte[4];
                Buffer.BlockCopy(Guid.NewGuid().ToByteArray(), 0, _instanceKey, 0, 4);
            }

            return _instanceKey;
        }
        #endregion

        #region GenerateInstanceKey
        /// <summary>
        ///     The PR_ENTRYID property contains a MAPI entry identifier used to open and edit properties of a particular MAPI
        ///     object.
        /// </summary>
        /// <remarks>
        ///     The PR_ENTRYID property identifies an object for OpenEntry to instantiate and provides access to all of its
        ///     properties through the appropriate derived interface of IMAPIProp. PR_ENTRYID is one of the base address properties
        ///     for all messaging users. The PR_ENTRYID for CEMAPI always contains long-term identifiers. <br/>
        ///     - Required on folder objects <br/>
        ///     - Required on message store objects <br/>
        ///     - Required on status objects  <br/>
        ///     - Changed in a copy operation <br/>
        ///     - Unique within entire world
        /// </remarks>
        /// <returns></returns>
        public static byte[] GenerateEntryId()
        {
            return Guid.NewGuid().ToByteArray();
        }
        #endregion
    }
}
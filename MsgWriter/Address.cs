using System;
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
    ///     A base class for <see cref="Sender"/>, <see cref="Recipient"/>, <see cref="Receiving"/>
    ///     and <see cref="Representing"/>
    /// </summary>
    public class Address
    {
        #region Fields
        private AddressType _addressType;
        #endregion

        #region Properties
        /// <summary>
        ///     The E-mail address
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        ///     The displayname for the <see cref="Email"/>
        /// </summary>
        public string DisplayName { get; internal set; }
        /// <summary>
        ///     Returns the messaging user's e-mail address type. Use <see cref="AddressTypeString"/>
        ///     when this property returns <see cref="Enums.AddressType.Unknown"/>
        /// </summary>
        public AddressType AddressType
        {
            get { return _addressType; }
            internal set
            {
                _addressType = value;
                switch (value)
                {
                    case AddressType.Unknown:
                        AddressTypeString = string.Empty;
                        break;

                    case AddressType.Ex:
                        AddressTypeString = "EX";
                        break;

                    case AddressType.Smtp:
                        AddressTypeString = "SMTP";
                        break;

                    case AddressType.Fax:
                        AddressTypeString = "FAX";
                        break;

                    case AddressType.Mhs:
                        AddressTypeString = "MHS";
                        break;

                    case AddressType.Profs:
                        AddressTypeString = "PROFS";
                        break;

                    case AddressType.X400:
                        AddressTypeString = "X400";
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        /// <summary>
        ///     Returns the <see cref="Enums.AddressType"/> as a string
        /// </summary>
        public string AddressTypeString { get; private set; }
        #endregion
        
        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email" /></param>
        /// <param name="addressType">The <see cref="AddressType" /></param>
        public Address(string email,
            string displayName,
            AddressType addressType = AddressType.Smtp)
        {
            Email = email;
            DisplayName = displayName;
            AddressType = addressType;
        }
        #endregion
    }
}

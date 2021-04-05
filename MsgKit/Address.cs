//
// Address.cs
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

using System;
using MsgKit.Enums;
using MsgKit.Structures;

namespace MsgKit
{
    /// <summary>
    ///     A base class for <see cref="Sender"/>, <see cref="Recipient"/>, <see cref="Receiving"/>
    ///     and <see cref="Representing"/>
    /// </summary>
    public class Address
    {
        #region Fields
        /// <summary>
        ///     The messaging user's e-mail address type
        /// </summary>
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
        ///     The original displayname for the <see cref="Email"/>
        /// </summary>
        public string OriginalDisplayName => AddressType == AddressType.Smtp ? Email : DisplayName;

        /// <summary>
        ///     Returns the messaging user's e-mail address type. Use <see cref="AddressTypeString"/>
        ///     when this property returns <see cref="Enums.AddressType.Unknown"/>
        /// </summary>
        public AddressType AddressType
        {
            get => _addressType;
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

        /// <summary>
        ///     <see cref="OneOffEntryId"/>
        /// </summary>
        internal OneOffEntryId OneOffEntryId => new OneOffEntryId(Email, DisplayName, AddressType);
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
            Email = email ?? string.Empty;
            DisplayName = string.IsNullOrWhiteSpace(displayName) ? email : displayName;

            AddressType = addressType;
        }
        #endregion
    }
}

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

using MsgWriter.Enums;

namespace MsgWriter
{
    /// <summary>
    ///     This class represents an Outlook sender (e.g. keesvanspelde@hotmail.com)
    /// </summary>
    internal sealed class Received : Address
    {
        #region Constructor
        /// <summary>
        ///     Creates a new recipient object and sets all its properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email"/></param>
        /// <param name="addressType">The <see cref="AddressType"/></param>
        internal Received(string email,
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
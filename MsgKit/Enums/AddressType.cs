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

namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains the messaging user's e-mail address type, such as SMTP.
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        ///     Unknown
        /// </summary>
        Unknown,

        /// <summary>
        ///     Exchange
        /// </summary>
        Ex,
        
        /// <summary>
        ///     Simple Mail Transfer Protocol
        /// </summary>
        Smtp,

        /// <summary>
        ///     Fax
        /// </summary>
        Fax,

        /// <summary>
        ///     MHS
        /// </summary>
        Mhs,

        /// <summary>
        ///     PROFS
        /// </summary>
        Profs,

        /// <summary>
        ///     X400
        /// </summary>
        X400
    }
}

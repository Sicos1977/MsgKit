// ReSharper disable InconsistentNaming

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

namespace MsgWriter.Enums
{
    /// <summary>
    ///     The recipient type
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc839620(v=office.15).aspx
    /// </remarks>
    public enum RecipientType : uint
    {
        Unknown = 0x0000,

        /// <summary>
        ///     The recipient is a primary (To) recipient. Clients are required to handle primary recipients. All other types are optional.
        /// </summary>
        MAPI_TO = 0x0001,

        /// <summary>
        ///     The recipient is a carbon copy (CC) recipient, a recipient that receives a message in addition to the primary recipients.
        /// </summary>
        MAPI_CC = 0x0002,

        /// <summary>
        ///     The recipient is a blind carbon copy (BCC) recipient. Primary and carbon copy recipients are unaware of the existence of BCC recipients. 
        /// </summary>
        MAPI_BCC = 0x0003,

        /// <summary>
        ///     The recipient is a resource (e.g. a room)
        /// </summary>
        Resource = 0x0004,

        /// <summary>
        ///     The recipient is a room (uses PR_RECIPIENT_TYPE_EXE) needs Exchange 2007 or higher
        /// </summary>
        Room = 0x0007
    }
}
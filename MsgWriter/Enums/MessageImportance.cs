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
    ///     Contains the relative priority of a message.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc815346(v=office.15).aspx
    /// </remarks>
    public enum MessageImportance
    {
        /// <summary>
        ///     The message has low importance.
        /// </summary>
        IMPORTANCE_LOW = 0,

        /// <summary>
        ///     The message has normal importance.
        /// </summary>
        IMPORTANCE_NORMAL = 1,

        /// <summary>
        ///     The message has high importance.
        /// </summary>
        IMPORTANCE_HIGH = 2
    }
}
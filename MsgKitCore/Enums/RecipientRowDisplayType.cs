//
// RecipientRowAddressType.cs
//
// Author: RecipientRowDisplayType and associated documentation files (the "Software"), to deal
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

namespace MsgKit.Enums
{
    /// <summary>
    ///     An enumeration. This field MUST be present when the Type field
    ///     of the RecipientFlags field is set to X500DN(0x1) and MUST NOT be present otherwise.This
    ///     value specifies the display type of this address.Valid values for this field are specified in the
    ///     following table.
    /// </summary>
    public enum RecipientRowDisplayType
    {
        /// <summary>
        ///     A messaging user
        /// </summary>
        MessagingUser = 0x00,

        /// <summary>
        ///     A distribution list
        /// </summary>
        DistributionList = 0x01,

        /// <summary>
        ///     A forum, such as a bulletin board service or a public or shared folder
        /// </summary>
        Forum = 0x02,

        /// <summary>
        ///     An automated agent
        /// </summary>
        AutomatedAgent = 0x03,

        /// <summary>
        ///     An Address Book object defined for a large group, such as helpdesk, accounting, coordinator, or
        ///     department
        /// </summary>
        AddressBook = 0x04,

        /// <summary>
        ///     A private, personally administered distribution list
        /// </summary>
        PrivateDistributionList = 0x05,

        /// <summary>
        ///     An Address Book object known to be from a foreign or remote messaging system
        /// </summary>
        RemoteAddressBook = 0x06
    }
}
//
// RecipientType.cs
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
    ///     The recipient type
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc839620(v=office.15).aspx
    /// </remarks>
    public enum RecipientType : uint
    {
        /// <summary>
        ///     The recipient is the message originator
        /// </summary>
        Originator = 0x0000,

        /// <summary>
        ///     The recipient is a primary (To) recipient. Clients are required to handle primary recipients. All other types are optional.
        /// </summary>
        To = 0x0001,

        /// <summary>
        ///     The recipient is a carbon copy (CC) recipient, a recipient that receives a message in addition to the primary recipients.
        /// </summary>
        Cc = 0x0002,

        /// <summary>
        ///     The recipient is a blind carbon copy (BCC) recipient. Primary and carbon copy recipients are unaware of the existence of BCC recipients. 
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
}
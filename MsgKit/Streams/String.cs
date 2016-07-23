//
// String.cs
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
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

namespace MsgKit.Streams
{
    /// <summary>
    ///     The string stream MUST be named "__substg1.0_00040102". It MUST consist of one entry for each string named
    ///     property, and all entries MUST be arranged consecutively, like in an array. As specified in section 2.2.3.1.2, 
    ///     the offset, in bytes, to use for a particular property is stored in the corresponding entry in the entry stream.
    ///     That is a byte offset into the string stream from where the entry for the property can be read.The strings MUST 
    ///     NOT be null-terminated. Implementers can add a terminating null character to the string after they read it from 
    ///     the stream, if one is required by the implementer's programming language.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee124409(v=exchg.80).aspx
    /// </remarks>
    internal sealed class String
    {
    }
}
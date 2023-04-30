//
// HtmlToken.cs
//
// Author: Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Copyright (c) 2015-2023 Jeffrey Stedfast <jestedfa@microsoft.com>
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

using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An abstract HTML token class.
    /// </summary>
    /// <remarks>
    ///     An abstract HTML token class.
    /// </remarks>
    internal abstract class HtmlToken
    {
        #region Properties
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlToken" />.
        /// </remarks>
        /// <param name="kind">The kind of token.</param>
        internal HtmlToken(HtmlTokenKind kind)
        {
            Kind = kind;
        }

        /// <summary>
        ///     Get the kind of HTML token that this object represents.
        /// </summary>
        /// <remarks>
        ///     Gets the kind of HTML token that this object represents.
        /// </remarks>
        /// <value>The kind of token.</value>
        internal HtmlTokenKind Kind { get; }
        #endregion

        #region WriteTo
        /// <summary>
        ///     Write the HTML token to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <remarks>
        ///     Writes the HTML token to a <see cref="System.IO.TextWriter" />.
        /// </remarks>
        /// <param name="output">The output.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="output" /> is <c>null</c>.
        /// </exception>
        public abstract void WriteTo(TextWriter output);
        #endregion

        #region ToString
        /// <summary>
        ///     Return a <see cref="System.String" /> that represents the current <see cref="HtmlToken" />.
        /// </summary>
        /// <remarks>
        ///     Returns a <see cref="System.String" /> that represents the current <see cref="HtmlToken" />.
        /// </remarks>
        /// <returns>A <see cref="System.String" /> that represents the current <see cref="HtmlToken" />.</returns>
        public override string ToString()
        {
            using (var output = new StringWriter())
            {
                WriteTo(output);

                return output.ToString();
            }
        }
        #endregion
    }
}
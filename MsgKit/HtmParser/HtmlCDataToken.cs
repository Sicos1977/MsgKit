using System;
using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML token consisting of <c>[CDATA[</c>.
    /// </summary>
    /// <remarks>
    ///     An HTML token consisting of <c>[CDATA[</c>.
    /// </remarks>
    internal class HtmlCDataToken : HtmlDataToken
    {
        #region Constructor
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlCDataToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlCDataToken" />.
        /// </remarks>
        /// <param name="data">The character data.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="data" /> is <c>null</c>.
        /// </exception>
        public HtmlCDataToken(string data) : base(HtmlTokenKind.CData, data)
        {
        }
        #endregion

        #region WriteTo
        /// <summary>
        ///     Write the HTML character data to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <remarks>
        ///     Writes the HTML character data to a <see cref="System.IO.TextWriter" />,
        ///     encoding it if it isn't already encoded.
        /// </remarks>
        /// <param name="output">The output.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="output" /> is <c>null</c>.
        /// </exception>
        public override void WriteTo(TextWriter output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            output.Write("<![CDATA[");
            output.Write(Data);
            output.Write("]]>");
        }
        #endregion
    }
}
using System;
using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML token consisting of script data.
    /// </summary>
    /// <remarks>
    ///     An HTML token consisting of script data.
    /// </remarks>
    internal class HtmlScriptDataToken : HtmlDataToken
    {
        #region Constructor
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlScriptDataToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlScriptDataToken" />.
        /// </remarks>
        /// <param name="data">The script data.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="data" /> is <c>null</c>.
        /// </exception>
        public HtmlScriptDataToken(string data) : base(HtmlTokenKind.ScriptData, data)
        {
        }
        #endregion

        #region WriteTo
        /// <summary>
        ///     Write the HTML script data to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <remarks>
        ///     Writes the HTML script data to a <see cref="System.IO.TextWriter" />,
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

            output.Write(Data);
        }
        #endregion
    }
}
using System;
using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML token consisting of character data.
    /// </summary>
    /// <remarks>
    ///     An HTML token consisting of character data.
    /// </remarks>
    internal class HtmlDataToken : HtmlToken
    {
        #region Properties
        internal bool EncodeEntities { get; set; }

        /// <summary>
        ///     Get the character data.
        /// </summary>
        /// <remarks>
        ///     Gets the character data.
        /// </remarks>
        /// <value>The character data.</value>
        public string Data { get; }

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

            if (!EncodeEntities)
            {
                output.Write(Data);
                return;
            }

            HtmlUtils.HtmlEncode(output, Data);
        }
        #endregion

        #region Constructors
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlDataToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlDataToken" />.
        /// </remarks>
        /// <param name="kind">The kind of character data.</param>
        /// <param name="data">The character data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="kind" /> is not a valid <see cref="HtmlTokenKind" />.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="data" /> is <c>null</c>.
        /// </exception>
        internal HtmlDataToken(HtmlTokenKind kind, string data) : base(kind)
        {
            switch (kind)
            {
                default: throw new ArgumentOutOfRangeException(nameof(kind));
                case HtmlTokenKind.ScriptData:
                case HtmlTokenKind.CData:
                case HtmlTokenKind.Data:
                    break;
            }

            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlDataToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlDataToken" />.
        /// </remarks>
        /// <param name="data">The character data.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="data" /> is <c>null</c>.
        /// </exception>
        public HtmlDataToken(string data) : base(HtmlTokenKind.Data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        #endregion
    }
}
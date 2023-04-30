using System;
using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML comment token.
    /// </summary>
    internal class HtmlCommentToken : HtmlToken
    {
        #region Properties
        /// <summary>
        ///     Get the comment.
        /// </summary>
        /// <remarks>
        ///     Gets the comment.
        /// </remarks>
        /// <value>The comment.</value>
        public string Comment { get; }

        /// <summary>
        ///     Get whether or not the comment is a bogus comment.
        /// </summary>
        /// <remarks>
        ///     Gets whether or not the comment is a bogus comment.
        /// </remarks>
        /// <value><c>true</c> if the comment is bogus; otherwise, <c>false</c>.</value>
        public bool IsBogusComment { get; }

        internal bool IsBangComment { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlCommentToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlCommentToken" />.
        /// </remarks>
        /// <param name="comment">The comment text.</param>
        /// <param name="bogus"><c>true</c> if the comment is bogus; otherwise, <c>false</c>.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="comment" /> is <c>null</c>.
        /// </exception>
        public HtmlCommentToken(string comment, bool bogus = false) : base(HtmlTokenKind.Comment)
        {
            IsBogusComment = bogus;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }
        #endregion

        #region WriteTo
        /// <summary>
        ///     Write the HTML comment to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <remarks>
        ///     Writes the HTML comment to a <see cref="System.IO.TextWriter" />.
        /// </remarks>
        /// <param name="output">The output.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="output" /> is <c>null</c>.
        /// </exception>
        public override void WriteTo(TextWriter output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            if (!IsBogusComment)
            {
                output.Write("<!--");
                output.Write(Comment);
                output.Write("-->");
            }
            else
            {
                output.Write('<');
                if (IsBangComment)
                    output.Write('!');
                output.Write(Comment);
                output.Write('>');
            }
        }
        #endregion
    }
}
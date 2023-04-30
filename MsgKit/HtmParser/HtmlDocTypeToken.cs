using System;
using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML DOCTYPE token.
    /// </summary>
    internal class HtmlDocTypeToken : HtmlToken
    {
        #region Fields
        private string _publicIdentifier;
        private string _systemIdentifier;
        #endregion

        #region Properties
        internal string RawTagName { get; set; }

        /// <summary>
        ///     Get whether or not quirks-mode should be forced.
        /// </summary>
        /// <remarks>
        ///     Gets whether or not quirks-mode should be forced.
        /// </remarks>
        /// <value><c>true</c> if quirks-mode should be forced; otherwise, <c>false</c>.</value>
        public bool ForceQuirksMode { get; set; }

        /// <summary>
        ///     Get or set the DOCTYPE name.
        /// </summary>
        /// <remarks>
        ///     Gets or sets the DOCTYPE name.
        /// </remarks>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Get or set the public identifier.
        /// </summary>
        /// <remarks>
        ///     Gets or sets the public identifier.
        /// </remarks>
        /// <value>The public identifier.</value>
        public string PublicIdentifier
        {
            get => _publicIdentifier;
            set
            {
                _publicIdentifier = value;
                if (value != null)
                {
                    if (PublicKeyword is null)
                        PublicKeyword = "PUBLIC";
                }
                else
                {
                    if (_systemIdentifier != null)
                        SystemKeyword = "SYSTEM";
                }
            }
        }

        /// <summary>
        ///     Get the public keyword that was used.
        /// </summary>
        /// <remarks>
        ///     Gets the public keyword that was used.
        /// </remarks>
        /// <value>The public keyword or <c>null</c> if it wasn't used.</value>
        public string PublicKeyword { get; internal set; }

        /// <summary>
        ///     Get or set the system identifier.
        /// </summary>
        /// <remarks>
        ///     Gets or sets the system identifier.
        /// </remarks>
        /// <value>The system identifier.</value>
        public string SystemIdentifier
        {
            get => _systemIdentifier;
            set
            {
                _systemIdentifier = value;
                if (value != null)
                {
                    if (_publicIdentifier is null && SystemKeyword is null)
                        SystemKeyword = "SYSTEM";
                }
                else
                {
                    SystemKeyword = null;
                }
            }
        }

        /// <summary>
        ///     Get the system keyword that was used.
        /// </summary>
        /// <remarks>
        ///     Gets the system keyword that was used.
        /// </remarks>
        /// <value>The system keyword or <c>null</c> if it wasn't used.</value>
        public string SystemKeyword { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlDocTypeToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlDocTypeToken" />.
        /// </remarks>
        public HtmlDocTypeToken() : base(HtmlTokenKind.DocType)
        {
            RawTagName = "DOCTYPE";
        }
        #endregion

        #region WriteTo
        /// <summary>
        ///     Write the DOCTYPE tag to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <remarks>
        ///     Writes the DOCTYPE tag to a <see cref="System.IO.TextWriter" />.
        /// </remarks>
        /// <param name="output">The output.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="output" /> is <c>null</c>.
        /// </exception>
        public override void WriteTo(TextWriter output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            output.Write("<!");
            output.Write(RawTagName);
            if (Name != null)
            {
                output.Write(' ');
                output.Write(Name);
            }

            if (PublicIdentifier != null)
            {
                output.Write(' ');
                output.Write(PublicKeyword);
                output.Write(" \"");
                output.Write(PublicIdentifier);
                output.Write('"');
                if (SystemIdentifier != null)
                {
                    output.Write(" \"");
                    output.Write(SystemIdentifier);
                    output.Write('"');
                }
            }
            else if (SystemIdentifier != null)
            {
                output.Write(' ');
                output.Write(SystemKeyword);
                output.Write(" \"");
                output.Write(SystemIdentifier);
                output.Write('"');
            }

            output.Write('>');
        }
        #endregion
    }
}
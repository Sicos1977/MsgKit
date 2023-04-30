using System;
using System.Collections.Generic;
using System.IO;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML tag token.
    /// </summary>
    /// <remarks>
    ///     An HTML tag token.
    /// </remarks>
    internal class HtmlTagToken : HtmlToken
    {
        #region Properties
        /// <summary>
        ///     Get the attributes.
        /// </summary>
        /// <remarks>
        ///     Gets the attributes.
        /// </remarks>
        /// <value>The attributes.</value>
        public HtmlAttributeCollection Attributes { get; }

        /// <summary>
        ///     Get the HTML tag identifier.
        /// </summary>
        /// <remarks>
        ///     Gets the HTML tag identifier.
        /// </remarks>
        /// <value>The HTML tag identifier.</value>
        public HtmlTagId Id { get; }

        /// <summary>
        ///     Get whether or not the tag is an empty element.
        /// </summary>
        /// <remarks>
        ///     Gets whether or not the tag is an empty element.
        /// </remarks>
        /// <value><c>true</c> if the tag is an empty element; otherwise, <c>false</c>.</value>
        public bool IsEmptyElement { get; internal set; }

        /// <summary>
        ///     Get whether or not the tag is an end tag.
        /// </summary>
        /// <remarks>
        ///     Gets whether or not the tag is an end tag.
        /// </remarks>
        /// <value><c>true</c> if the tag is an end tag; otherwise, <c>false</c>.</value>
        public bool IsEndTag { get; }

        /// <summary>
        ///     Get the name of the tag.
        /// </summary>
        /// <remarks>
        ///     Gets the name of the tag.
        /// </remarks>
        /// <value>The name.</value>
        public string Name { get; }
        #endregion

        #region Constructors
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlTagToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlTagToken" />.
        /// </remarks>
        /// <param name="name">The name of the tag.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="isEmptyElement"><c>true</c> if the tag is an empty element; otherwise, <c>false</c>.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <para><paramref name="name" /> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><paramref name="attributes" /> is <c>null</c>.</para>
        /// </exception>
        public HtmlTagToken(string name, IEnumerable<HtmlAttribute> attributes, bool isEmptyElement) : base(
            HtmlTokenKind.Tag)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            if (attributes is null)
                throw new ArgumentNullException(nameof(attributes));

            Attributes = new HtmlAttributeCollection(attributes);
            IsEmptyElement = isEmptyElement;
            Id = name.ToHtmlTagId();
            Name = name;
        }

        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlTagToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlTagToken" />.
        /// </remarks>
        /// <param name="name">The name of the tag.</param>
        /// <param name="isEndTag"><c>true</c> if the tag is an end tag; otherwise, <c>false</c>.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="name" /> is <c>null</c>.
        /// </exception>
        public HtmlTagToken(string name, bool isEndTag) : base(HtmlTokenKind.Tag)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            Attributes = new HtmlAttributeCollection();
            Id = name.ToHtmlTagId();
            IsEndTag = isEndTag;
            Name = name;
        }
        #endregion

        #region WriteTo
        /// <summary>
        ///     Write the HTML tag to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <remarks>
        ///     Writes the HTML tag to a <see cref="System.IO.TextWriter" />.
        /// </remarks>
        /// <param name="output">The output.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="output" /> is <c>null</c>.
        /// </exception>
        public override void WriteTo(TextWriter output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            output.Write('<');
            
            if (IsEndTag)
                output.Write('/');
            
            output.Write(Name);
            
            foreach (var t in Attributes)
            {
                output.Write(' ');
                output.Write(t.Name);
                if (t.Value == null) continue;
                output.Write('=');
                HtmlUtils.HtmlAttributeEncode(output, t.Value);
            }

            if (IsEmptyElement)
                output.Write('/');
            output.Write('>');
        }
        #endregion
    }
}
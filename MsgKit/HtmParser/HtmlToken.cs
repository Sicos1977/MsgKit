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

using System;
using System.Collections.Generic;
using System.IO;
using MimeKit.Text;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An abstract HTML token class.
    /// </summary>
    /// <remarks>
    ///     An abstract HTML token class.
    /// </remarks>
    public abstract class HtmlToken
    {
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlToken" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlToken" />.
        /// </remarks>
        /// <param name="kind">The kind of token.</param>
        protected HtmlToken(HtmlTokenKind kind)
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
        public HtmlTokenKind Kind { get; }

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
    }

    /// <summary>
    ///     An HTML comment token.
    /// </summary>
    /// <remarks>
    ///     An HTML comment token.
    /// </remarks>
    public class HtmlCommentToken : HtmlToken
    {
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
    }

    /// <summary>
    ///     An HTML token consisting of character data.
    /// </summary>
    /// <remarks>
    ///     An HTML token consisting of character data.
    /// </remarks>
    public class HtmlDataToken : HtmlToken
    {
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
        protected HtmlDataToken(HtmlTokenKind kind, string data) : base(kind)
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
    }

    /// <summary>
    ///     An HTML token consisting of <c>[CDATA[</c>.
    /// </summary>
    /// <remarks>
    ///     An HTML token consisting of <c>[CDATA[</c>.
    /// </remarks>
    public class HtmlCDataToken : HtmlDataToken
    {
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
    }

    /// <summary>
    ///     An HTML token consisting of script data.
    /// </summary>
    /// <remarks>
    ///     An HTML token consisting of script data.
    /// </remarks>
    public class HtmlScriptDataToken : HtmlDataToken
    {
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
    }

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
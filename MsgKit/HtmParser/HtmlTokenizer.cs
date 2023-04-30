//
// HtmlTokenizer.cs
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
using System.Runtime.CompilerServices;
using MimeKit.Text;
using HtmlEntityDecoder = HtmlKit.HtmlEntityDecoder;

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     An HTML tokenizer.
    /// </summary>
    /// <remarks>
    ///     Tokenizes HTML text, emitting an <see cref="HtmlToken" /> for each token it encounters.
    /// </remarks>
    public class HtmlTokenizer
    {
        #region Consts
        // Specification: https://dev.w3.org/html5/spec-LC/tokenization.html
        private const string DocType = "doctype";
        private const string CData = "[CDATA[";
        #endregion

        #region Fields
        private readonly HtmlEntityDecoder _entity = new HtmlEntityDecoder();
        private readonly CharBuffer _data = new CharBuffer(2048);
        private readonly CharBuffer _name = new CharBuffer(32);
        private readonly char[] _cdata = new char[3];
        private readonly TextReader _text;
        private HtmlDocTypeToken _doctype;
        private HtmlAttribute _attribute;
        private string _activeTagName;
        private HtmlTagToken _tag;
        private int _cdataIndex;
        private bool _isEndTag;
        private bool _bang;
        private char _quote;
        #endregion

        #region Properties
        /// <summary>
        ///     Get or set whether or not the tokenizer should decode character references.
        /// </summary>
        /// <remarks>
        ///     <para>Gets or sets whether or not the tokenizer should decode character references.</para>
        ///     <note type="warning">
        ///         Character references in attribute values will still be decoded
        ///         even if this value is set to <c>false</c>.
        ///     </note>
        /// </remarks>
        /// <value><c>true</c> if character references should be decoded; otherwise, <c>false</c>.</value>
        public bool DecodeCharacterReferences { get; set; }

        /// <summary>
        ///     Get the current HTML namespace detected by the tokenizer.
        /// </summary>
        /// <remarks>
        ///     Gets the current HTML namespace detected by the tokenizer.
        /// </remarks>
        /// <value>The html namespace.</value>
        internal HtmlNamespace HtmlNamespace { get; private set; }

        /// <summary>
        ///     Get or set whether or not the tokenizer should ignore truncated tags.
        /// </summary>
        /// <remarks>
        ///     <para>Gets or sets whether or not the tokenizer should ignore truncated tags.</para>
        ///     <para>
        ///         If <c>false</c> and the stream abruptly ends in the middle of an HTML tag, it will be
        ///         treated as an <see cref="HtmlDataToken" /> instead.
        ///     </para>
        /// </remarks>
        /// <value><c>true</c> if truncated tags should be ignored; otherwise, <c>false</c>.</value>
        public bool IgnoreTruncatedTags { get; set; }

        /// <summary>
        ///     Get the current line number.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This property is most commonly used for error reporting, but can be called
        ///         at any time. The starting value for this property is <c>1</c>.
        ///     </para>
        ///     <para>
        ///         Combined with <see cref="LinePosition" />, a value of <c>1,1</c> indicates
        ///         the start of the document.
        ///     </para>
        /// </remarks>
        /// <value>The current line number.</value>
        public int LineNumber { get; private set; }

        /// <summary>
        ///     Get the current line position.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This property is most commonly used for error reporting, but can be called
        ///         at any time. The starting value for this property is <c>1</c>.
        ///     </para>
        ///     <para>
        ///         Combined with <see cref="LineNumber" />, a value of <c>1,1</c> indicates
        ///         the start of the document.
        ///     </para>
        /// </remarks>
        /// <value>The column position of the current line.</value>
        public int LinePosition { get; private set; }

        /// <summary>
        ///     Get the current state of the tokenizer.
        /// </summary>
        /// <remarks>
        ///     Gets the current state of the tokenizer.
        /// </remarks>
        /// <value>The current state of the tokenizer.</value>
        public HtmlTokenizerState TokenizerState { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Initialize a new instance of the <see cref="HtmlTokenizer" /> class.
        /// </summary>
        /// <remarks>
        ///     Creates a new <see cref="HtmlTokenizer" />.
        /// </remarks>
        /// <param name="reader">The <see cref="TextReader" />.</param>
        public HtmlTokenizer(TextReader reader)
        {
            DecodeCharacterReferences = true;
            LinePosition = 1;
            LineNumber = 1;
            _text = reader;
        }
        #endregion

        #region CreateDocType
        /// <summary>
        ///     Create a DOCTYPE token.
        /// </summary>
        /// <remarks>
        ///     Creates a DOCTYPE token.
        /// </remarks>
        /// <returns>The DOCTYPE token.</returns>
        internal virtual HtmlDocTypeToken CreateDocType()
        {
            return new HtmlDocTypeToken();
        }
        #endregion

        #region CreateDocTypeToken
        private HtmlDocTypeToken CreateDocTypeToken(string rawTagName)
        {
            var token = CreateDocType();
            token.RawTagName = rawTagName;
            return token;
        }
        #endregion

        #region CreateCommentToken
        /// <summary>
        ///     Create an HTML comment token.
        /// </summary>
        /// <remarks>
        ///     Creates an HTML comment token.
        /// </remarks>
        /// <returns>The HTML comment token.</returns>
        /// <param name="comment">The comment.</param>
        /// <param name="bogus"><c>true</c> if the comment is bogus; otherwise, <c>false</c>.</param>
        protected virtual HtmlCommentToken CreateCommentToken(string comment, bool bogus = false)
        {
            return new HtmlCommentToken(comment, bogus);
        }
        #endregion

        #region CreateDataToken
        /// <summary>
        ///     Create an HTML character data token.
        /// </summary>
        /// <remarks>
        ///     Creates an HTML character data token.
        /// </remarks>
        /// <returns>The HTML character data token.</returns>
        /// <param name="data">The character data.</param>
        protected virtual HtmlDataToken CreateDataToken(string data)
        {
            return new HtmlDataToken(data);
        }
        #endregion

        #region CreateCDataToken
        /// <summary>
        ///     Create an HTML character data token.
        /// </summary>
        /// <remarks>
        ///     Creates an HTML character data token.
        /// </remarks>
        /// <returns>The HTML character data token.</returns>
        /// <param name="data">The character data.</param>
        protected virtual HtmlCDataToken CreateCDataToken(string data)
        {
            return new HtmlCDataToken(data);
        }
        #endregion

        #region CreateScriptDataToken
        /// <summary>
        ///     Create an HTML script data token.
        /// </summary>
        /// <remarks>
        ///     Creates an HTML script data token.
        /// </remarks>
        /// <returns>The HTML script data token.</returns>
        /// <param name="data">The script data.</param>
        protected virtual HtmlScriptDataToken CreateScriptDataToken(string data)
        {
            return new HtmlScriptDataToken(data);
        }
        #endregion

        #region CreateTagToken
        /// <summary>
        ///     Create an HTML tag token.
        /// </summary>
        /// <remarks>
        ///     Creates an HTML tag token.
        /// </remarks>
        /// <returns>The HTML tag token.</returns>
        /// <param name="name">The tag name.</param>
        /// <param name="isEndTag"><c>true</c> if the tag is an end tag; otherwise, <c>false</c>.</param>
        internal virtual HtmlTagToken CreateTagToken(string name, bool isEndTag = false)
        {
            return new HtmlTagToken(name, isEndTag);
        }
        #endregion

        #region CreateAttribute
        /// <summary>
        ///     Create an attribute.
        /// </summary>
        /// <remarks>
        ///     Creates an attribute.
        /// </remarks>
        /// <returns>The attribute.</returns>
        /// <param name="name">The attribute name.</param>
        internal virtual HtmlAttribute CreateAttribute(string name)
        {
            return new HtmlAttribute(name);
        }
        #endregion

        #region IsAlphaNumeric
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAlphaNumeric(int c)
        {
            return (uint)(c - 'A') <= 'Z' - 'A' || (uint)(c - 'a') <= 'z' - 'a' || (uint)(c - '0') <= '9' - '0';
        }
        #endregion

        #region MyRegion
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAsciiLetter(int c)
        {
            return (uint)(c - 'A') <= 'Z' - 'A' || (uint)(c - 'a') <= 'z' - 'a';
        }
        #endregion

        #region ToLower
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static char ToLower(int c)
        {
            // check if the char is within the uppercase range
            if ((uint)(c - 'A') <= 'Z' - 'A')
                return (char)(c + 0x20);

            return (char)c;
        }
        #endregion

        #region Peek
        private int Peek()
        {
            return _text.Peek();
        }
        #endregion

        #region Read
        private int Read()
        {
            int c;

            if ((c = _text.Read()) == -1)
                return -1;

            if (c == '\n')
            {
                LinePosition = 1;
                LineNumber++;
            }
            else
            {
                LinePosition++;
            }

            return c;
        }
        #endregion

        #region NameIs
        // Note: value must be lowercase
        private bool NameIs(string value)
        {
            if (_name.Length != value.Length)
                return false;

            for (var i = 0; i < _name.Length; i++)
                if (ToLower(_name[i]) != value[i])
                    return false;

            return true;
        }
        #endregion

        #region EmitTagAttribute
        private void EmitTagAttribute()
        {
            _attribute = CreateAttribute(_name.ToString());
            _tag.Attributes.Add(_attribute);
            _name.Length = 0;
        }
        #endregion

        #region EmitCommentToken
        private HtmlToken EmitCommentToken(string comment, bool bogus = false)
        {
            var token = CreateCommentToken(comment, bogus);
            token.IsBangComment = _bang;
            _data.Length = 0;
            _name.Length = 0;
            _bang = false;
            return token;
        }

        private HtmlToken EmitCommentToken(CharBuffer comment, bool bogus = false)
        {
            return EmitCommentToken(comment.ToString(), bogus);
        }
        #endregion

        #region EmitDocType
        private HtmlToken EmitDocType()
        {
            var token = _doctype;
            _data.Length = 0;
            _doctype = null;
            return token;
        }
        #endregion

        #region EmitDataToken
        private HtmlToken EmitDataToken(bool encodeEntities, bool truncated)
        {
            if (_data.Length == 0)
                return null;

            if (truncated && IgnoreTruncatedTags)
            {
                _data.Length = 0;
                return null;
            }

            var token = CreateDataToken(_data.ToString());
            token.EncodeEntities = encodeEntities;
            _data.Length = 0;

            return token;
        }
        #endregion

        #region EmitCDataToken
        private HtmlToken EmitCDataToken()
        {
            if (_data.Length == 0)
                return null;

            var token = CreateCDataToken(_data.ToString());
            _data.Length = 0;

            return token;
        }
        #endregion

        #region EmitScriptDataToken
        private HtmlToken EmitScriptDataToken()
        {
            if (_data.Length == 0)
                return null;

            var token = CreateScriptDataToken(_data.ToString());
            _data.Length = 0;

            return token;
        }
        #endregion

        #region EmitTagToken
        private HtmlToken EmitTagToken()
        {
            if (!_tag.IsEndTag && !_tag.IsEmptyElement)
                switch (_tag.Id)
                {
                    case HtmlTagId.Style:
                    case HtmlTagId.Xmp:
                    case HtmlTagId.IFrame:
                    case HtmlTagId.NoEmbed:
                    case HtmlTagId.NoFrames:
                        TokenizerState = HtmlTokenizerState.RawText;
                        _activeTagName = _tag.Name.ToLowerInvariant();
                        break;
                    case HtmlTagId.Title:
                    case HtmlTagId.TextArea:
                        TokenizerState = HtmlTokenizerState.RcData;
                        _activeTagName = _tag.Name.ToLowerInvariant();
                        break;
                    case HtmlTagId.PlainText:
                        TokenizerState = HtmlTokenizerState.PlainText;
                        break;
                    case HtmlTagId.Script:
                        TokenizerState = HtmlTokenizerState.ScriptData;
                        break;
                    case HtmlTagId.NoScript:
                        // TODO: only switch into the RawText state if scripting is enabled
                        TokenizerState = HtmlTokenizerState.RawText;
                        _activeTagName = _tag.Name.ToLowerInvariant();
                        break;
                    case HtmlTagId.Html:
                        TokenizerState = HtmlTokenizerState.Data;

                        for (var i = _tag.Attributes.Count; i > 0; i--)
                        {
                            var attr = _tag.Attributes[i - 1];

                            if (attr.Id == HtmlAttributeId.XmlNs && attr.Value != null)
                            {
                                HtmlNamespace = attr.Value.ToHtmlNamespace();
                                break;
                            }
                        }

                        break;
                    default:
                        TokenizerState = HtmlTokenizerState.Data;
                        break;
                }
            else
                TokenizerState = HtmlTokenizerState.Data;

            var token = _tag;
            _data.Length = 0;
            _tag = null;

            return token;
        }
        #endregion

        #region ReadCharacterReference
        // 8.2.4.69 Tokenizing character references
        private HtmlToken ReadCharacterReference(HtmlTokenizerState next)
        {
            var nc = Peek();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                _data.Append('&');

                return EmitDataToken(true, false);
            }

            var c = (char)nc;

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                case '<':
                case '&':
                    // no character is consumed, emit '&'
                    TokenizerState = next;
                    _data.Append('&');
                    return null;
            }

            _entity.Push('&');

            while (_entity.Push(c))
            {
                Read();

                if (c == ';')
                    break;

                if ((nc = Peek()) == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;

                    _data.Append(_entity.GetPushedInput());
                    _entity.Reset();

                    return EmitDataToken(true, false);
                }

                c = (char)nc;
            }

            TokenizerState = next;

            _data.Append(_entity.GetValue());
            _entity.Reset();

            return null;
        }
        #endregion

        #region ReadGenericRawTextLessThan
        private HtmlToken ReadGenericRawTextLessThan(HtmlTokenizerState rawText, HtmlTokenizerState rawTextEndTagOpen)
        {
            var nc = Peek();

            _data.Append('<');

            switch ((char)nc)
            {
                case '/':
                    TokenizerState = rawTextEndTagOpen;
                    _data.Append('/');
                    _name.Length = 0;
                    Read();
                    break;
                default:
                    TokenizerState = rawText;
                    break;
            }

            return null;
        }
        #endregion

        #region ReadGenericRawTextEndTagOpen
        private HtmlToken ReadGenericRawTextEndTagOpen(bool decoded, HtmlTokenizerState rawText,
            HtmlTokenizerState rawTextEndTagName)
        {
            var nc = Peek();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitDataToken(decoded, true);
            }

            var c = (char)nc;

            if (IsAsciiLetter(c))
            {
                TokenizerState = rawTextEndTagName;
                _name.Append(c);
                _data.Append(c);
                Read();
            }
            else
            {
                TokenizerState = rawText;
            }

            return null;
        }
        #endregion

        #region ReadGenericRawTextEndTagName
        private HtmlToken ReadGenericRawTextEndTagName(bool decoded, HtmlTokenizerState rawText)
        {
            var current = TokenizerState;

            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitDataToken(decoded, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        if (NameIs(_activeTagName))
                        {
                            TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                            break;
                        }

                        goto default;
                    case '/':
                        if (NameIs(_activeTagName))
                        {
                            TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                            break;
                        }

                        goto default;
                    case '>':
                        if (NameIs(_activeTagName))
                        {
                            var token = CreateTagToken(_name.ToString(), true);
                            TokenizerState = HtmlTokenizerState.Data;
                            _data.Length = 0;
                            _name.Length = 0;
                            return token;
                        }

                        goto default;
                    default:
                        if (!IsAsciiLetter(c))
                        {
                            TokenizerState = rawText;
                            return null;
                        }

                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == current);

            _tag = CreateTagToken(_name.ToString(), true);
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadData
        // 8.2.4.1 Data state
        private HtmlToken ReadData()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    break;
                }

                var c = (char)nc;

                switch (c)
                {
                    case '&':
                        if (DecodeCharacterReferences)
                        {
                            TokenizerState = HtmlTokenizerState.CharacterReferenceInData;
                            return null;
                        }

                        goto default;
                    case '<':
                        TokenizerState = HtmlTokenizerState.TagOpen;
                        break;
                    //case 0: // parse error, but emit it anyway
                    default:
                        _data.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.Data);

            return EmitDataToken(DecodeCharacterReferences, false);
        }
        #endregion

        #region ReadCharacterReferenceInData
        // 8.2.4.2 Character reference in data state
        private HtmlToken ReadCharacterReferenceInData()
        {
            return ReadCharacterReference(HtmlTokenizerState.Data);
        }
        #endregion

        #region ReadRcData
        // 8.2.4.3 RCDATA state
        private HtmlToken ReadRcData()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    break;
                }

                var c = (char)nc;

                switch (c)
                {
                    case '&':
                        if (DecodeCharacterReferences)
                        {
                            TokenizerState = HtmlTokenizerState.CharacterReferenceInRcData;
                            return null;
                        }

                        goto default;
                    case '<':
                        TokenizerState = HtmlTokenizerState.RcDataLessThan;
                        return EmitDataToken(DecodeCharacterReferences, false);
                    default:
                        _data.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.RcData);

            return EmitDataToken(DecodeCharacterReferences, false);
        }
        #endregion

        #region ReadCharacterReferenceInRcData
        // 8.2.4.4 Character reference in RCDATA state
        private HtmlToken ReadCharacterReferenceInRcData()
        {
            return ReadCharacterReference(HtmlTokenizerState.RcData);
        }
        #endregion

        #region ReadRawText
        // 8.2.4.5 RAWTEXT state
        private HtmlToken ReadRawText()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    break;
                }

                var c = (char)nc;

                switch (c)
                {
                    case '<':
                        TokenizerState = HtmlTokenizerState.RawTextLessThan;
                        return EmitDataToken(false, false);
                    default:
                        _data.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.RawText);

            return EmitDataToken(false, false);
        }
        #endregion

        #region ReadScriptData
        // 8.2.4.6 Script data state
        private HtmlToken ReadScriptData()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    break;
                }

                var c = (char)nc;

                switch (c)
                {
                    case '<':
                        TokenizerState = HtmlTokenizerState.ScriptDataLessThan;
                        break;
                    default:
                        _data.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptData);

            return EmitScriptDataToken();
        }
        #endregion

        #region ReadPlainText
        // 8.2.4.7 PLAINTEXT state
        private HtmlToken ReadPlainText()
        {
            var nc = Read();

            while (nc != -1)
            {
                var c = (char)nc;

                _data.Append(c == '\0' ? '\uFFFD' : c);
                nc = Read();
            }

            TokenizerState = HtmlTokenizerState.EndOfFile;

            return EmitDataToken(false, false);
        }
        #endregion

        #region ReadTagOpen
        // 8.2.4.8 Tag open state
        private HtmlToken ReadTagOpen()
        {
            var nc = Read();

            if (nc == -1)
            {
                var token = IgnoreTruncatedTags ? null : CreateDataToken("<");
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return token;
            }

            var c = (char)nc;

            // Note: we save the data in case we hit a parse error and have to emit a data token
            _data.Append('<');
            _data.Append(c);

            switch (c = (char)nc)
            {
                case '!':
                    TokenizerState = HtmlTokenizerState.MarkupDeclarationOpen;
                    break;
                case '?':
                    TokenizerState = HtmlTokenizerState.BogusComment;
                    _data.Length = 1;
                    _data[0] = c;
                    break;
                case '/':
                    TokenizerState = HtmlTokenizerState.EndTagOpen;
                    break;
                default:
                    if (IsAsciiLetter(c))
                    {
                        TokenizerState = HtmlTokenizerState.TagName;
                        _isEndTag = false;
                        _name.Append(c);
                    }
                    else
                    {
                        TokenizerState = HtmlTokenizerState.Data;
                    }

                    break;
            }

            return null;
        }
        #endregion

        #region ReadEndTagOpen
        // 8.2.4.9 End tag open state
        private HtmlToken ReadEndTagOpen()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitDataToken(false, true);
            }

            var c = (char)nc;

            // Note: we save the data in case we hit a parse error and have to emit a data token
            _data.Append(c);

            switch (c)
            {
                case '>': // parse error
                    TokenizerState = HtmlTokenizerState.Data;
                    _data.Length = 0; // FIXME: this is probably wrong
                    break;
                default:
                    if (IsAsciiLetter(c))
                    {
                        TokenizerState = HtmlTokenizerState.TagName;
                        _isEndTag = true;
                        _name.Append(c);
                    }
                    else
                    {
                        TokenizerState = HtmlTokenizerState.BogusComment;
                        _data.Length = 1;
                        _data[0] = c;
                    }

                    break;
            }

            return null;
        }
        #endregion

        #region ReadTagName
        // 8.2.4.10 Tag name state
        private HtmlToken ReadTagName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                        break;
                    case '/':
                        TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                        break;
                    case '>':
                        _tag = CreateTagToken(_name.ToString(), _isEndTag);
                        _data.Length = 0;
                        _name.Length = 0;

                        return EmitTagToken();
                    default:
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.TagName);

            _tag = CreateTagToken(_name.ToString(), _isEndTag);
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadRcDataLessThan
        // 8.2.4.11 RCDATA less-than sign state
        private HtmlToken ReadRcDataLessThan()
        {
            return ReadGenericRawTextLessThan(HtmlTokenizerState.RcData, HtmlTokenizerState.RcDataEndTagOpen);
        }
        #endregion

        #region ReadRcDataEndTagOpen
        // 8.2.4.12 RCDATA end tag open state
        private HtmlToken ReadRcDataEndTagOpen()
        {
            return ReadGenericRawTextEndTagOpen(DecodeCharacterReferences, HtmlTokenizerState.RcData,
                HtmlTokenizerState.RcDataEndTagName);
        }
        #endregion

        #region ReadRcDataEndTagName
        // 8.2.4.13 RCDATA end tag name state
        private HtmlToken ReadRcDataEndTagName()
        {
            return ReadGenericRawTextEndTagName(DecodeCharacterReferences, HtmlTokenizerState.RcData);
        }
        #endregion

        #region ReadRawTextLessThan
        // 8.2.4.14 RAWTEXT less-than sign state
        private HtmlToken ReadRawTextLessThan()
        {
            return ReadGenericRawTextLessThan(HtmlTokenizerState.RawText, HtmlTokenizerState.RawTextEndTagOpen);
        }
        #endregion

        #region ReadRawTextEndTagOpen
        // 8.2.4.15 RAWTEXT end tag open state
        private HtmlToken ReadRawTextEndTagOpen()
        {
            return ReadGenericRawTextEndTagOpen(false, HtmlTokenizerState.RawText,
                HtmlTokenizerState.RawTextEndTagName);
        }
        #endregion

        #region ReadGenericRawTextEndTagName
        // 8.2.4.16 RAWTEXT end tag name state
        private HtmlToken ReadRawTextEndTagName()
        {
            return ReadGenericRawTextEndTagName(false, HtmlTokenizerState.RawText);
        }
        #endregion

        #region ReadScriptDataLessThan
        // 8.2.4.17 Script data less-than sign state
        private HtmlToken ReadScriptDataLessThan()
        {
            var nc = Peek();

            _data.Append('<');

            switch ((char)nc)
            {
                case '/':
                    TokenizerState = HtmlTokenizerState.ScriptDataEndTagOpen;
                    _data.Append('/');
                    _name.Length = 0;
                    Read();
                    break;
                case '!':
                    TokenizerState = HtmlTokenizerState.ScriptDataEscapeStart;
                    _data.Append('!');
                    Read();
                    break;
                default:
                    TokenizerState = HtmlTokenizerState.ScriptData;
                    break;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataEndTagOpen
        // 8.2.4.18 Script data end tag open state
        private HtmlToken ReadScriptDataEndTagOpen()
        {
            var nc = Peek();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitScriptDataToken();
            }

            var c = (char)nc;

            if (c == 'S' || c == 's')
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEndTagName;
                _name.Append('s');
                _data.Append(c);
                Read();
            }
            else
            {
                TokenizerState = HtmlTokenizerState.ScriptData;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataEndTagName
        // 8.2.4.19 Script data end tag name state
        private HtmlToken ReadScriptDataEndTagName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        if (NameIs("script"))
                        {
                            TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                            break;
                        }

                        goto default;
                    case '/':
                        if (NameIs("script"))
                        {
                            TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                            break;
                        }

                        goto default;
                    case '>':
                        if (NameIs("script"))
                        {
                            var token = CreateTagToken(_name.ToString(), true);
                            TokenizerState = HtmlTokenizerState.Data;
                            _data.Length = 0;
                            _name.Length = 0;
                            return token;
                        }

                        goto default;
                    default:
                        if (!IsAsciiLetter(c))
                        {
                            TokenizerState = HtmlTokenizerState.ScriptData;
                            _name.Length = 0;
                            return null;
                        }

                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataEndTagName);

            _tag = CreateTagToken(_name.ToString(), true);
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadScriptDataEscapeStart
        // 8.2.4.20 Script data escape start state
        private HtmlToken ReadScriptDataEscapeStart()
        {
            var nc = Peek();

            if (nc == '-')
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEscapeStartDash;
                _data.Append('-');
                Read();
            }
            else
            {
                TokenizerState = HtmlTokenizerState.ScriptData;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataEscapeStartDash
        // 8.2.4.21 Script data escape start dash state
        private HtmlToken ReadScriptDataEscapeStartDash()
        {
            var nc = Peek();

            if (nc == '-')
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEscapedDashDash;
                _data.Append('-');
                Read();
            }
            else
            {
                TokenizerState = HtmlTokenizerState.ScriptData;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataEscaped
        // 8.2.4.22 Script data escaped state
        private HtmlToken ReadScriptDataEscaped()
        {
            HtmlToken token = null;

            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                switch (c)
                {
                    case '-':
                        TokenizerState = HtmlTokenizerState.ScriptDataEscapedDash;
                        _data.Append('-');
                        break;
                    case '<':
                        TokenizerState = HtmlTokenizerState.ScriptDataEscapedLessThan;
                        token = EmitScriptDataToken();
                        _data.Append('<');
                        break;
                    default:
                        _data.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataEscaped);

            return token;
        }
        #endregion

        #region ReadScriptDataEscapedDash
        // 8.2.4.23 Script data escaped dash state
        private HtmlToken ReadScriptDataEscapedDash()
        {
            HtmlToken token = null;
            var nc = Peek();
            char c;

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitScriptDataToken();
            }

            switch (c = (char)nc)
            {
                case '-':
                    TokenizerState = HtmlTokenizerState.ScriptDataEscapedDashDash;
                    _data.Append('-');
                    Read();
                    break;
                case '<':
                    TokenizerState = HtmlTokenizerState.ScriptDataEscapedLessThan;
                    token = EmitScriptDataToken();
                    _data.Append('<');
                    Read();
                    break;
                default:
                    TokenizerState = HtmlTokenizerState.ScriptDataEscaped;
                    _data.Append(c == '\0' ? '\uFFFD' : c);
                    Read();
                    break;
            }

            return token;
        }
        #endregion

        #region ReadScriptDataEscapedDashDash
        // 8.2.4.24 Script data escaped dash dash state
        private HtmlToken ReadScriptDataEscapedDashDash()
        {
            HtmlToken token = null;

            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                switch (c)
                {
                    case '-':
                        _data.Append('-');
                        break;
                    case '<':
                        TokenizerState = HtmlTokenizerState.ScriptDataEscapedLessThan;
                        token = EmitScriptDataToken();
                        _data.Append('<');
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.ScriptData;
                        _data.Append('>');
                        break;
                    default:
                        TokenizerState = HtmlTokenizerState.ScriptDataEscaped;
                        _data.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataEscapedDashDash);

            return token;
        }
        #endregion

        #region ReadScriptDataEscapedLessThan
        // 8.2.4.25 Script data escaped less-than sign state
        private HtmlToken ReadScriptDataEscapedLessThan()
        {
            var nc = Peek();
            var c = (char)nc;

            if (c == '/')
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEscapedEndTagOpen;
                _data.Append(c);
                _name.Length = 0;
                Read();
            }
            else if (IsAsciiLetter(c))
            {
                TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapeStart;
                _data.Append(c);
                _name.Append(c);
                Read();
            }
            else
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEscaped;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataEscapedEndTagOpen
        // 8.2.4.26 Script data escaped end tag open state
        private HtmlToken ReadScriptDataEscapedEndTagOpen()
        {
            var nc = Peek();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitScriptDataToken();
            }

            var c = (char)nc;

            if (IsAsciiLetter(c))
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEscapedEndTagName;
                _data.Append(c);
                _name.Append(c);
                Read();
            }
            else
            {
                TokenizerState = HtmlTokenizerState.ScriptDataEscaped;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataEscapedEndTagName
        // 8.2.4.27 Script data escaped end tag name state
        private HtmlToken ReadScriptDataEscapedEndTagName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        if (NameIs("script"))
                        {
                            TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                            break;
                        }

                        goto default;
                    case '/':
                        if (NameIs("script"))
                        {
                            TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                            break;
                        }

                        goto default;
                    case '>':
                        if (NameIs("script"))
                        {
                            var token = CreateTagToken(_name.ToString(), true);
                            TokenizerState = HtmlTokenizerState.Data;
                            _data.Length = 0;
                            _name.Length = 0;
                            return token;
                        }

                        goto default;
                    default:
                        if (!IsAsciiLetter(c))
                        {
                            TokenizerState = HtmlTokenizerState.ScriptData;
                            return null;
                        }

                        _name.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataEscapedEndTagName);

            _tag = CreateTagToken(_name.ToString(), true);
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadScriptDataDoubleEscapeStart
        // 8.2.4.28 Script data double escape start state
        private HtmlToken ReadScriptDataDoubleEscapeStart()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                    case '/':
                    case '>':
                        TokenizerState = NameIs("script") ? HtmlTokenizerState.ScriptDataDoubleEscaped : HtmlTokenizerState.ScriptDataEscaped;
                        _name.Length = 0;
                        break;
                    default:
                        if (!IsAsciiLetter(c))
                            TokenizerState = HtmlTokenizerState.ScriptDataEscaped;
                        else
                            _name.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataDoubleEscapeStart);

            return null;
        }
        #endregion

        #region ReadScriptDataDoubleEscaped
        // 8.2.4.29 Script data double escaped state
        private HtmlToken ReadScriptDataDoubleEscaped()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                switch (c)
                {
                    case '-':
                        TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapedDash;
                        _data.Append('-');
                        break;
                    case '<':
                        TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapedLessThan;
                        _data.Append('<');
                        break;
                    default:
                        _data.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataEscaped);

            return null;
        }
        #endregion

        #region ReadScriptDataDoubleEscapedDash
        // 8.2.4.30 Script data double escaped dash state
        private HtmlToken ReadScriptDataDoubleEscapedDash()
        {
            var nc = Read();
            char c;

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitScriptDataToken();
            }

            switch (c = (char)nc)
            {
                case '-':
                    TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapedDashDash;
                    _data.Append('-');
                    break;
                case '<':
                    TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapedLessThan;
                    _data.Append('<');
                    break;
                default:
                    TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscaped;
                    _data.Append(c == '\0' ? '\uFFFD' : c);
                    break;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataDoubleEscapedDashDash
        // 8.2.4.31 Script data double escaped dash dash state
        private HtmlToken ReadScriptDataDoubleEscapedDashDash()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitScriptDataToken();
                }

                var c = (char)nc;

                switch (c)
                {
                    case '-':
                        _data.Append('-');
                        break;
                    case '<':
                        TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapedLessThan;
                        _data.Append('<');
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.ScriptData;
                        _data.Append('>');
                        break;
                    default:
                        TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscaped;
                        _data.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataEscapedDashDash);

            return null;
        }
        #endregion

        #region ReadScriptDataDoubleEscapedLessThan
        // 8.2.4.32 Script data double escaped less-than sign state
        private HtmlToken ReadScriptDataDoubleEscapedLessThan()
        {
            var nc = Peek();

            if (nc == '/')
            {
                TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscapeEnd;
                _data.Append('/');
                Read();
            }
            else
            {
                TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscaped;
            }

            return null;
        }
        #endregion

        #region ReadScriptDataDoubleEscapeEnd
        // 8.2.4.33 Script data double escape end state
        private HtmlToken ReadScriptDataDoubleEscapeEnd()
        {
            do
            {
                var nc = Peek();
                var c = (char)nc;

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                    case '/':
                    case '>':
                        TokenizerState = NameIs("script") ? HtmlTokenizerState.ScriptDataEscaped : HtmlTokenizerState.ScriptDataDoubleEscaped;
                        _data.Append(c);
                        Read();
                        break;
                    default:
                        if (!IsAsciiLetter(c))
                        {
                            TokenizerState = HtmlTokenizerState.ScriptDataDoubleEscaped;
                        }
                        else
                        {
                            _name.Append(c);
                            _data.Append(c);
                            Read();
                        }

                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.ScriptDataDoubleEscapeEnd);

            return null;
        }
        #endregion

        #region ReadBeforeAttributeName
        // 8.2.4.34 Before attribute name state
        private HtmlToken ReadBeforeAttributeName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _tag = null;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '/':
                        TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                        return null;
                    case '>':
                        return EmitTagToken();
                    case '"':
                    case '\'':
                    case '<':
                    case '=':
                        // parse error
                        goto default;
                    default:
                        TokenizerState = HtmlTokenizerState.AttributeName;
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadAttributeName
        // 8.2.4.35 Attribute name state
        private HtmlToken ReadAttributeName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;
                    _tag = null;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        TokenizerState = HtmlTokenizerState.AfterAttributeName;
                        break;
                    case '/':
                        TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                        break;
                    case '=':
                        TokenizerState = HtmlTokenizerState.BeforeAttributeValue;
                        break;
                    case '>':
                        EmitTagAttribute();

                        return EmitTagToken();
                    default:
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.AttributeName);

            EmitTagAttribute();

            return null;
        }
        #endregion

        #region ReadAfterAttributeName
        // 8.2.4.36 After attribute name state
        private HtmlToken ReadAfterAttributeName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _tag = null;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '/':
                        TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                        return null;
                    case '=':
                        TokenizerState = HtmlTokenizerState.BeforeAttributeValue;
                        return null;
                    case '>':
                        return EmitTagToken();
                    case '"':
                    case '\'':
                    case '<':
                        // parse error
                        goto default;
                    default:
                        TokenizerState = HtmlTokenizerState.AttributeName;
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadBeforeAttributeValue
        // 8.2.4.37 Before attribute value state
        private HtmlToken ReadBeforeAttributeValue()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _tag = null;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '"':
                    case '\'':
                        TokenizerState = HtmlTokenizerState.AttributeValueQuoted;
                        _quote = c;
                        return null;
                    case '&':
                        TokenizerState = HtmlTokenizerState.CharacterReferenceInAttributeValue;
                        return null;
                    case '/':
                        TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                        return null;
                    case '>':
                        return EmitTagToken();
                    case '<':
                    case '=':
                    case '`':
                        // parse error
                        goto default;
                    default:
                        TokenizerState = HtmlTokenizerState.AttributeValueUnquoted;
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadAttributeValueQuoted
        // 8.2.4.38 Attribute value (double-quoted) state
        private HtmlToken ReadAttributeValueQuoted()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '&':
                        TokenizerState = HtmlTokenizerState.CharacterReferenceInAttributeValue;
                        return null;
                    default:
                        if (c == _quote)
                        {
                            TokenizerState = HtmlTokenizerState.AfterAttributeValueQuoted;
                            _quote = '\0';
                            break;
                        }

                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.AttributeValueQuoted);

            _attribute.Value = _name.ToString();
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadAttributeValueUnquoted
        // 8.2.4.40 Attribute value (unquoted) state
        private HtmlToken ReadAttributeValueUnquoted()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _name.Length = 0;

                    return EmitDataToken(false, true);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                        break;
                    case '&':
                        TokenizerState = HtmlTokenizerState.CharacterReferenceInAttributeValue;
                        return null;
                    case '>':
                        _attribute.Value = _name.ToString();
                        _name.Length = 0;

                        return EmitTagToken();
                    case '\'':
                    case '<':
                    case '=':
                    case '`':
                        // parse error
                        goto default;
                    default:
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.AttributeValueUnquoted);

            _attribute.Value = _name.ToString();
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadCharacterReferenceInAttributeValue
        // 8.2.4.41 Character reference in attribute value state
        private HtmlToken ReadCharacterReferenceInAttributeValue()
        {
            var additionalAllowedCharacter = _quote == '\0' ? '>' : _quote;
            var nc = Peek();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                _name.Length = 0;

                return EmitDataToken(false, true);
            }

            var c = (char)nc;

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                case '<':
                case '&':
                    // no character is consumed, emit '&'
                    _name.Append('&');
                    break;
                default:
                    if (c == additionalAllowedCharacter)
                    {
                        // this is not a character reference, nothing is consumed
                        _name.Append('&');
                        break;
                    }

                    _entity.Push('&');

                    while (_entity.Push(c))
                    {
                        Read();

                        if (c == ';')
                            break;

                        if ((nc = Peek()) == -1)
                        {
                            TokenizerState = HtmlTokenizerState.EndOfFile;
                            _data.Length--;
                            _data.Append(_entity.GetPushedInput());
                            _entity.Reset();

                            return EmitDataToken(false, true);
                        }

                        c = (char)nc;
                    }

                    var pushed = _entity.GetPushedInput();
                    string value;

                    if (c == '=' || IsAlphaNumeric(c))
                        value = pushed;
                    else
                        value = _entity.GetValue();

                    _data.Length--;
                    _data.Append(pushed);
                    _name.Append(value);
                    _entity.Reset();
                    break;
            }

            TokenizerState = _quote == '\0' ? HtmlTokenizerState.AttributeValueUnquoted : HtmlTokenizerState.AttributeValueQuoted;

            return null;
        }
        #endregion

        #region ReadAfterAttributeValueQuoted
        // 8.2.4.42 After attribute value (quoted) state
        private HtmlToken ReadAfterAttributeValueQuoted()
        {
            HtmlToken token = null;
            var nc = Peek();
            bool consume;

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitDataToken(false, true);
            }

            var c = (char)nc;

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                    TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                    _data.Append(c);
                    consume = true;
                    break;
                case '/':
                    TokenizerState = HtmlTokenizerState.SelfClosingStartTag;
                    _data.Append(c);
                    consume = true;
                    break;
                case '>':
                    token = EmitTagToken();
                    consume = true;
                    break;
                default:
                    TokenizerState = HtmlTokenizerState.BeforeAttributeName;
                    consume = false;
                    break;
            }

            if (consume)
                Read();

            return token;
        }
        #endregion

        #region ReadSelfClosingStartTag
        // 8.2.4.43 Self-closing start tag state
        private HtmlToken ReadSelfClosingStartTag()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitDataToken(false, true);
            }

            var c = (char)nc;

            if (c == '>')
            {
                _tag.IsEmptyElement = true;

                return EmitTagToken();
            }

            // parse error
            TokenizerState = HtmlTokenizerState.BeforeAttributeName;

            // Note: we save the data in case we hit a parse error and have to emit a data token
            _data.Append(c);

            return null;
        }
        #endregion

        #region ReadBogusComment
        // 8.2.4.44 Bogus comment state
        private HtmlToken ReadBogusComment()
        {
            do
            {
                int nc;
                if ((nc = Read()) == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    break;
                }

                char c;
                if ((c = (char)nc) == '>')
                    break;

                _data.Append(c == '\0' ? '\uFFFD' : c);
            } while (true);

            TokenizerState = HtmlTokenizerState.Data;

            return EmitCommentToken(_data, true);
        }
        #endregion

        #region ReadMarkupDeclarationOpen
        // 8.2.4.45 Markup declaration open state
        private HtmlToken ReadMarkupDeclarationOpen()
        {
            int count = 0, nc;
            var c = '\0';

            while (count < 2)
            {
                if ((nc = Peek()) == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitDataToken(false, true);
                }

                if ((c = (char)nc) != '-')
                    break;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);
                Read();
                count++;
            }

            if (count == 2)
            {
                // "<!--"
                TokenizerState = HtmlTokenizerState.CommentStart;
                _name.Length = 0;
                return null;
            }

            if (count == 0)
            {
                // Check for "<!DOCTYPE " or "<![CDATA["
                if (c == 'D' || c == 'd')
                {
                    // Note: we save the data in case we hit a parse error and have to emit a data token
                    _data.Append(c);
                    _name.Append(c);
                    count = 1;
                    Read();

                    while (count < 7)
                    {
                        if ((nc = Read()) == -1)
                        {
                            TokenizerState = HtmlTokenizerState.EndOfFile;
                            return EmitDataToken(false, true);
                        }

                        c = (char)nc;

                        // Note: we save the data in case we hit a parse error and have to emit a data token
                        _data.Append(c);
                        _name.Append(c);

                        if (ToLower(c) != DocType[count])
                            break;

                        count++;
                    }

                    if (count == 7)
                    {
                        _doctype = CreateDocTypeToken(_name.ToString());
                        TokenizerState = HtmlTokenizerState.DocType;
                        _name.Length = 0;
                        return null;
                    }

                    _name.Length = 0;
                }
                else if (c == '[')
                {
                    // Note: we save the data in case we hit a parse error and have to emit a data token
                    _data.Append(c);
                    count = 1;
                    Read();

                    while (count < 7)
                    {
                        if ((nc = Read()) == -1)
                        {
                            TokenizerState = HtmlTokenizerState.EndOfFile;
                            return EmitDataToken(false, true);
                        }

                        c = (char)nc;

                        // Note: we save the data in case we hit a parse error and have to emit a data token
                        _data.Append(c);

                        if (c != CData[count])
                            break;

                        count++;
                    }

                    if (count == 7)
                    {
                        TokenizerState = HtmlTokenizerState.CDataSection;
                        _data.Length = 0;
                        return null;
                    }
                }
            }

            // parse error
            TokenizerState = HtmlTokenizerState.BogusComment;

            // trim the leading "<!"
            for (var i = 0; i < _data.Length - 2; i++)
                _data[i] = _data[i + 2];
            _data.Length -= 2;
            _bang = true;

            return null;
        }
        #endregion

        #region ReadCommentStart
        // 8.2.4.46 Comment start state
        private HtmlToken ReadCommentStart()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.Data;

                return EmitCommentToken(string.Empty);
            }

            var c = (char)nc;

            _data.Append(c);

            switch (c)
            {
                case '-':
                    TokenizerState = HtmlTokenizerState.CommentStartDash;
                    break;
                case '>': // parse error
                    TokenizerState = HtmlTokenizerState.Data;
                    return EmitCommentToken(string.Empty);
                default:
                    TokenizerState = HtmlTokenizerState.Comment;
                    _name.Append(c == '\0' ? '\uFFFD' : c);
                    break;
            }

            return null;
        }
        #endregion

        #region ReadCommentStartDash
        // 8.2.4.47 Comment start dash state
        private HtmlToken ReadCommentStartDash()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.Data;
                return EmitCommentToken(_name);
            }

            var c = (char)nc;

            _data.Append(c);

            switch (c)
            {
                case '-':
                    TokenizerState = HtmlTokenizerState.CommentEnd;
                    break;
                case '>': // parse error
                    TokenizerState = HtmlTokenizerState.Data;
                    return EmitCommentToken(_name);
                default:
                    TokenizerState = HtmlTokenizerState.Comment;
                    _name.Append('-');
                    _name.Append(c == '\0' ? '\uFFFD' : c);
                    break;
            }

            return null;
        }
        #endregion

        #region ReadComment
        // 8.2.4.48 Comment state
        private HtmlToken ReadComment()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitCommentToken(_name);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '-':
                        TokenizerState = HtmlTokenizerState.CommentEndDash;
                        return null;
                    default:
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        break;
                }
            } while (true);
        }
        #endregion

        #region ReadCommentEndDash
        // 8.2.4.49 Comment end dash state
        private HtmlToken ReadCommentEndDash()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.Data;
                return EmitCommentToken(_name);
            }

            var c = (char)nc;

            _data.Append(c);

            switch (c)
            {
                case '-':
                    TokenizerState = HtmlTokenizerState.CommentEnd;
                    break;
                default:
                    TokenizerState = HtmlTokenizerState.Comment;
                    _name.Append('-');
                    _name.Append(c == '\0' ? '\uFFFD' : c);
                    break;
            }

            return null;
        }
        #endregion

        #region ReadCommentEnd
        // 8.2.4.50 Comment end state
        private HtmlToken ReadCommentEnd()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    return EmitCommentToken(_name);
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '>':
                        TokenizerState = HtmlTokenizerState.Data;
                        return EmitCommentToken(_name);
                    case '!': // parse error
                        TokenizerState = HtmlTokenizerState.CommentEndBang;
                        return null;
                    case '-':
                        _name.Append('-');
                        break;
                    default:
                        TokenizerState = HtmlTokenizerState.Comment;
                        _name.Append("--");
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadCommentEndBang
        // 8.2.4.51 Comment end bang state
        private HtmlToken ReadCommentEndBang()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                return EmitCommentToken(_name);
            }

            var c = (char)nc;

            _data.Append(c);

            switch (c)
            {
                case '-':
                    TokenizerState = HtmlTokenizerState.CommentEndDash;
                    _name.Append("--!");
                    break;
                case '>':
                    TokenizerState = HtmlTokenizerState.Data;
                    return EmitCommentToken(_name);
                default: // parse error
                    TokenizerState = HtmlTokenizerState.Comment;
                    _name.Append("--!");
                    _name.Append(c == '\0' ? '\uFFFD' : c);
                    break;
            }

            return null;
        }
        #endregion

        #region ReadDocType
        // 8.2.4.52 DOCTYPE state
        private HtmlToken ReadDocType()
        {
            var nc = Peek();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                _doctype.ForceQuirksMode = true;
                _name.Length = 0;

                return EmitDocType();
            }

            TokenizerState = HtmlTokenizerState.BeforeDocTypeName;
            var c = (char)nc;

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                    _data.Append(c);
                    Read();
                    break;
            }

            return null;
        }
        #endregion

        #region ReadBeforeDocTypeName
        // 8.2.4.53 Before DOCTYPE name state
        private HtmlToken ReadBeforeDocTypeName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.Data;
                        _doctype.ForceQuirksMode = true;
                        return EmitDocType();
                    default:
                        TokenizerState = HtmlTokenizerState.DocTypeName;
                        _name.Append(c == '\0' ? '\uFFFD' : c);
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadDocTypeName
        // 8.2.4.54 DOCTYPE name state
        private HtmlToken ReadDocTypeName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.Name = _name.ToString();
                    _doctype.ForceQuirksMode = true;
                    _name.Length = 0;

                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        TokenizerState = HtmlTokenizerState.AfterDocTypeName;
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.Data;
                        _doctype.Name = _name.ToString();
                        _name.Length = 0;

                        return EmitDocType();
                    case '\0':
                        _name.Append('\uFFFD');
                        break;
                    default:
                        _name.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.DocTypeName);

            _doctype.Name = _name.ToString();
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadAfterDocTypeName
        // 8.2.4.55 After DOCTYPE name state
        private HtmlToken ReadAfterDocTypeName()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.Data;
                        return EmitDocType();
                    default:
                        _name.Append(c);
                        if (_name.Length < 6)
                            break;

                        if (NameIs("public"))
                        {
                            TokenizerState = HtmlTokenizerState.AfterDocTypePublicKeyword;
                            _doctype.PublicKeyword = _name.ToString();
                        }
                        else if (NameIs("system"))
                        {
                            TokenizerState = HtmlTokenizerState.AfterDocTypeSystemKeyword;
                            _doctype.SystemKeyword = _name.ToString();
                        }
                        else
                        {
                            TokenizerState = HtmlTokenizerState.BogusDocType;
                        }

                        _name.Length = 0;
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadAfterDocTypePublicKeyword
        // 8.2.4.56 After DOCTYPE public keyword state
        private HtmlToken ReadAfterDocTypePublicKeyword()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                _doctype.ForceQuirksMode = true;
                return EmitDocType();
            }

            var c = (char)nc;

            // Note: we save the data in case we hit a parse error and have to emit a data token
            _data.Append(c);

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                    TokenizerState = HtmlTokenizerState.BeforeDocTypePublicIdentifier;
                    break;
                case '"':
                case '\'': // parse error
                    TokenizerState = HtmlTokenizerState.DocTypePublicIdentifierQuoted;
                    _doctype.PublicIdentifier = string.Empty;
                    _quote = c;
                    break;
                case '>': // parse error
                    TokenizerState = HtmlTokenizerState.Data;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                default: // parse error
                    TokenizerState = HtmlTokenizerState.BogusDocType;
                    _doctype.ForceQuirksMode = true;
                    break;
            }
            
            return null;
        }
        #endregion

        #region ReadBeforeDocTypePublicIdentifier
        // 8.2.4.57 Before DOCTYPE public identifier state
        private HtmlToken ReadBeforeDocTypePublicIdentifier()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '"':
                    case '\'':
                        TokenizerState = HtmlTokenizerState.DocTypePublicIdentifierQuoted;
                        _doctype.PublicIdentifier = string.Empty;
                        _quote = c;
                        return null;
                    case '>': // parse error
                        TokenizerState = HtmlTokenizerState.Data;
                        _doctype.ForceQuirksMode = true;
                        return EmitDocType();
                    default: // parse error
                        TokenizerState = HtmlTokenizerState.BogusDocType;
                        _doctype.ForceQuirksMode = true;
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadDocTypePublicIdentifierQuoted
        // 8.2.4.58 DOCTYPE public identifier (double-quoted) state
        private HtmlToken ReadDocTypePublicIdentifierQuoted()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.PublicIdentifier = _name.ToString();
                    _doctype.ForceQuirksMode = true;
                    _name.Length = 0;

                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\0': // parse error
                        _name.Append('\uFFFD');
                        break;
                    case '>': // parse error
                        TokenizerState = HtmlTokenizerState.Data;
                        _doctype.PublicIdentifier = _name.ToString();
                        _doctype.ForceQuirksMode = true;
                        _name.Length = 0;

                        return EmitDocType();
                    default:
                        if (c == _quote)
                        {
                            TokenizerState = HtmlTokenizerState.AfterDocTypePublicIdentifier;
                            _quote = '\0';
                            break;
                        }

                        _name.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.DocTypePublicIdentifierQuoted);

            _doctype.PublicIdentifier = _name.ToString();
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadAfterDocTypePublicIdentifier
        // 8.2.4.60 After DOCTYPE public identifier state
        private HtmlToken ReadAfterDocTypePublicIdentifier()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                _doctype.ForceQuirksMode = true;
                return EmitDocType();
            }

            var c = (char)nc;

            // Note: we save the data in case we hit a parse error and have to emit a data token
            _data.Append(c);

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                    TokenizerState = HtmlTokenizerState.BetweenDocTypePublicAndSystemIdentifiers;
                    break;
                case '>':
                    TokenizerState = HtmlTokenizerState.Data;
                    return EmitDocType();
                case '"':
                case '\'': // parse error
                    TokenizerState = HtmlTokenizerState.DocTypeSystemIdentifierQuoted;
                    _doctype.SystemIdentifier = string.Empty;
                    _quote = c;
                    break;
                default: // parse error
                    TokenizerState = HtmlTokenizerState.BogusDocType;
                    _doctype.ForceQuirksMode = true;
                    break;
            }

            return null;
        }
        #endregion

        #region ReadBetweenDocTypePublicAndSystemIdentifiers
        // 8.2.4.61 Between DOCTYPE public and system identifiers state
        private HtmlToken ReadBetweenDocTypePublicAndSystemIdentifiers()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.Data;
                        return EmitDocType();
                    case '"':
                    case '\'':
                        TokenizerState = HtmlTokenizerState.DocTypeSystemIdentifierQuoted;
                        _doctype.SystemIdentifier = string.Empty;
                        _quote = c;
                        return null;
                    default: // parse error
                        TokenizerState = HtmlTokenizerState.BogusDocType;
                        _doctype.ForceQuirksMode = true;
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadAfterDocTypeSystemKeyword
        // 8.2.4.62 After DOCTYPE system keyword state
        private HtmlToken ReadAfterDocTypeSystemKeyword()
        {
            var nc = Read();

            if (nc == -1)
            {
                TokenizerState = HtmlTokenizerState.EndOfFile;
                _doctype.ForceQuirksMode = true;
                return EmitDocType();
            }

            var c = (char)nc;

            // Note: we save the data in case we hit a parse error and have to emit a data token
            _data.Append(c);

            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                case '\f':
                case ' ':
                    TokenizerState = HtmlTokenizerState.BeforeDocTypeSystemIdentifier;
                    break;
                case '"':
                case '\'': // parse error
                    TokenizerState = HtmlTokenizerState.DocTypeSystemIdentifierQuoted;
                    _doctype.SystemIdentifier = string.Empty;
                    _quote = c;
                    break;
                case '>': // parse error
                    TokenizerState = HtmlTokenizerState.Data;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                default: // parse error
                    TokenizerState = HtmlTokenizerState.BogusDocType;
                    _doctype.ForceQuirksMode = true;
                    break;
            }

            return null;
        }
        #endregion

        #region ReadBeforeDocTypeSystemIdentifier
        // 8.2.4.63 Before DOCTYPE system identifier state
        private HtmlToken ReadBeforeDocTypeSystemIdentifier()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '"':
                    case '\'':
                        TokenizerState = HtmlTokenizerState.DocTypeSystemIdentifierQuoted;
                        _doctype.SystemIdentifier = string.Empty;
                        _quote = c;
                        return null;
                    case '>': // parse error
                        TokenizerState = HtmlTokenizerState.Data;
                        _doctype.ForceQuirksMode = true;
                        return EmitDocType();
                    default: // parse error
                        TokenizerState = HtmlTokenizerState.BogusDocType;
                        _doctype.ForceQuirksMode = true;
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadDocTypeSystemIdentifierQuoted
        // 8.2.4.64 DOCTYPE system identifier (double-quoted) state
        private HtmlToken ReadDocTypeSystemIdentifierQuoted()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.SystemIdentifier = _name.ToString();
                    _doctype.ForceQuirksMode = true;
                    _name.Length = 0;

                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\0': // parse error
                        _name.Append('\uFFFD');
                        break;
                    case '>': // parse error
                        TokenizerState = HtmlTokenizerState.Data;
                        _doctype.SystemIdentifier = _name.ToString();
                        _doctype.ForceQuirksMode = true;
                        _name.Length = 0;

                        return EmitDocType();
                    default:
                        if (c == _quote)
                        {
                            TokenizerState = HtmlTokenizerState.AfterDocTypeSystemIdentifier;
                            _quote = '\0';
                            break;
                        }

                        _name.Append(c);
                        break;
                }
            } while (TokenizerState == HtmlTokenizerState.DocTypeSystemIdentifierQuoted);

            _doctype.SystemIdentifier = _name.ToString();
            _name.Length = 0;

            return null;
        }
        #endregion

        #region ReadAfterDocTypeSystemIdentifier
        // 8.2.4.66 After DOCTYPE system identifier state
        private HtmlToken ReadAfterDocTypeSystemIdentifier()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                switch (c)
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\f':
                    case ' ':
                        break;
                    case '>':
                        TokenizerState = HtmlTokenizerState.Data;
                        return EmitDocType();
                    default: // parse error
                        TokenizerState = HtmlTokenizerState.BogusDocType;
                        return null;
                }
            } while (true);
        }
        #endregion

        #region ReadBogusDocType
        // 8.2.4.67 Bogus DOCTYPE state
        private HtmlToken ReadBogusDocType()
        {
            do
            {
                var nc = Read();

                if (nc == -1)
                {
                    TokenizerState = HtmlTokenizerState.EndOfFile;
                    _doctype.ForceQuirksMode = true;
                    return EmitDocType();
                }

                var c = (char)nc;

                // Note: we save the data in case we hit a parse error and have to emit a data token
                _data.Append(c);

                if (c == '>')
                {
                    TokenizerState = HtmlTokenizerState.Data;
                    return EmitDocType();
                }
            } while (true);
        }
        #endregion

        #region ReadCDataSection
        // 8.2.4.68 CDATA section state
        private HtmlToken ReadCDataSection()
        {
            var nc = Read();

            while (nc != -1)
            {
                var c = (char)nc;

                if (_cdataIndex >= 3)
                {
                    _data.Append(_cdata[0]);
                    _cdata[0] = _cdata[1];
                    _cdata[1] = _cdata[2];
                    _cdata[2] = c;

                    if (_cdata[0] == ']' && _cdata[1] == ']' && _cdata[2] == '>')
                    {
                        TokenizerState = HtmlTokenizerState.Data;
                        _cdataIndex = 0;

                        return EmitCDataToken();
                    }
                }
                else
                {
                    _cdata[_cdataIndex++] = c;
                }

                nc = Read();
            }

            TokenizerState = HtmlTokenizerState.EndOfFile;

            for (var i = 0; i < _cdataIndex; i++)
                _data.Append(_cdata[i]);

            _cdataIndex = 0;

            return EmitCDataToken();
        }
        #endregion

        #region ReadNextToken
        /// <summary>
        ///     Read the next token.
        /// </summary>
        /// <remarks>
        ///     Reads the next token.
        /// </remarks>
        /// <returns><c>true</c> if the next token was read; otherwise, <c>false</c>.</returns>
        /// <param name="token">The token that was read.</param>
        public bool ReadNextToken(out HtmlToken token)
        {
            do
            {
                switch (TokenizerState)
                {
                    case HtmlTokenizerState.Data:
                        token = ReadData();
                        break;
                    case HtmlTokenizerState.CharacterReferenceInData:
                        token = ReadCharacterReferenceInData();
                        break;
                    case HtmlTokenizerState.RcData:
                        token = ReadRcData();
                        break;
                    case HtmlTokenizerState.CharacterReferenceInRcData:
                        token = ReadCharacterReferenceInRcData();
                        break;
                    case HtmlTokenizerState.RawText:
                        token = ReadRawText();
                        break;
                    case HtmlTokenizerState.ScriptData:
                        token = ReadScriptData();
                        break;
                    case HtmlTokenizerState.PlainText:
                        token = ReadPlainText();
                        break;
                    case HtmlTokenizerState.TagOpen:
                        token = ReadTagOpen();
                        break;
                    case HtmlTokenizerState.EndTagOpen:
                        token = ReadEndTagOpen();
                        break;
                    case HtmlTokenizerState.TagName:
                        token = ReadTagName();
                        break;
                    case HtmlTokenizerState.RcDataLessThan:
                        token = ReadRcDataLessThan();
                        break;
                    case HtmlTokenizerState.RcDataEndTagOpen:
                        token = ReadRcDataEndTagOpen();
                        break;
                    case HtmlTokenizerState.RcDataEndTagName:
                        token = ReadRcDataEndTagName();
                        break;
                    case HtmlTokenizerState.RawTextLessThan:
                        token = ReadRawTextLessThan();
                        break;
                    case HtmlTokenizerState.RawTextEndTagOpen:
                        token = ReadRawTextEndTagOpen();
                        break;
                    case HtmlTokenizerState.RawTextEndTagName:
                        token = ReadRawTextEndTagName();
                        break;
                    case HtmlTokenizerState.ScriptDataLessThan:
                        token = ReadScriptDataLessThan();
                        break;
                    case HtmlTokenizerState.ScriptDataEndTagOpen:
                        token = ReadScriptDataEndTagOpen();
                        break;
                    case HtmlTokenizerState.ScriptDataEndTagName:
                        token = ReadScriptDataEndTagName();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapeStart:
                        token = ReadScriptDataEscapeStart();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapeStartDash:
                        token = ReadScriptDataEscapeStartDash();
                        break;
                    case HtmlTokenizerState.ScriptDataEscaped:
                        token = ReadScriptDataEscaped();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapedDash:
                        token = ReadScriptDataEscapedDash();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapedDashDash:
                        token = ReadScriptDataEscapedDashDash();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapedLessThan:
                        token = ReadScriptDataEscapedLessThan();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapedEndTagOpen:
                        token = ReadScriptDataEscapedEndTagOpen();
                        break;
                    case HtmlTokenizerState.ScriptDataEscapedEndTagName:
                        token = ReadScriptDataEscapedEndTagName();
                        break;
                    case HtmlTokenizerState.ScriptDataDoubleEscapeStart:
                        token = ReadScriptDataDoubleEscapeStart();
                        break;
                    case HtmlTokenizerState.ScriptDataDoubleEscaped:
                        token = ReadScriptDataDoubleEscaped();
                        break;
                    case HtmlTokenizerState.ScriptDataDoubleEscapedDash:
                        token = ReadScriptDataDoubleEscapedDash();
                        break;
                    case HtmlTokenizerState.ScriptDataDoubleEscapedDashDash:
                        token = ReadScriptDataDoubleEscapedDashDash();
                        break;
                    case HtmlTokenizerState.ScriptDataDoubleEscapedLessThan:
                        token = ReadScriptDataDoubleEscapedLessThan();
                        break;
                    case HtmlTokenizerState.ScriptDataDoubleEscapeEnd:
                        token = ReadScriptDataDoubleEscapeEnd();
                        break;
                    case HtmlTokenizerState.BeforeAttributeName:
                        token = ReadBeforeAttributeName();
                        break;
                    case HtmlTokenizerState.AttributeName:
                        token = ReadAttributeName();
                        break;
                    case HtmlTokenizerState.AfterAttributeName:
                        token = ReadAfterAttributeName();
                        break;
                    case HtmlTokenizerState.BeforeAttributeValue:
                        token = ReadBeforeAttributeValue();
                        break;
                    case HtmlTokenizerState.AttributeValueQuoted:
                        token = ReadAttributeValueQuoted();
                        break;
                    case HtmlTokenizerState.AttributeValueUnquoted:
                        token = ReadAttributeValueUnquoted();
                        break;
                    case HtmlTokenizerState.CharacterReferenceInAttributeValue:
                        token = ReadCharacterReferenceInAttributeValue();
                        break;
                    case HtmlTokenizerState.AfterAttributeValueQuoted:
                        token = ReadAfterAttributeValueQuoted();
                        break;
                    case HtmlTokenizerState.SelfClosingStartTag:
                        token = ReadSelfClosingStartTag();
                        break;
                    case HtmlTokenizerState.BogusComment:
                        token = ReadBogusComment();
                        break;
                    case HtmlTokenizerState.MarkupDeclarationOpen:
                        token = ReadMarkupDeclarationOpen();
                        break;
                    case HtmlTokenizerState.CommentStart:
                        token = ReadCommentStart();
                        break;
                    case HtmlTokenizerState.CommentStartDash:
                        token = ReadCommentStartDash();
                        break;
                    case HtmlTokenizerState.Comment:
                        token = ReadComment();
                        break;
                    case HtmlTokenizerState.CommentEndDash:
                        token = ReadCommentEndDash();
                        break;
                    case HtmlTokenizerState.CommentEnd:
                        token = ReadCommentEnd();
                        break;
                    case HtmlTokenizerState.CommentEndBang:
                        token = ReadCommentEndBang();
                        break;
                    case HtmlTokenizerState.DocType:
                        token = ReadDocType();
                        break;
                    case HtmlTokenizerState.BeforeDocTypeName:
                        token = ReadBeforeDocTypeName();
                        break;
                    case HtmlTokenizerState.DocTypeName:
                        token = ReadDocTypeName();
                        break;
                    case HtmlTokenizerState.AfterDocTypeName:
                        token = ReadAfterDocTypeName();
                        break;
                    case HtmlTokenizerState.AfterDocTypePublicKeyword:
                        token = ReadAfterDocTypePublicKeyword();
                        break;
                    case HtmlTokenizerState.BeforeDocTypePublicIdentifier:
                        token = ReadBeforeDocTypePublicIdentifier();
                        break;
                    case HtmlTokenizerState.DocTypePublicIdentifierQuoted:
                        token = ReadDocTypePublicIdentifierQuoted();
                        break;
                    case HtmlTokenizerState.AfterDocTypePublicIdentifier:
                        token = ReadAfterDocTypePublicIdentifier();
                        break;
                    case HtmlTokenizerState.BetweenDocTypePublicAndSystemIdentifiers:
                        token = ReadBetweenDocTypePublicAndSystemIdentifiers();
                        break;
                    case HtmlTokenizerState.AfterDocTypeSystemKeyword:
                        token = ReadAfterDocTypeSystemKeyword();
                        break;
                    case HtmlTokenizerState.BeforeDocTypeSystemIdentifier:
                        token = ReadBeforeDocTypeSystemIdentifier();
                        break;
                    case HtmlTokenizerState.DocTypeSystemIdentifierQuoted:
                        token = ReadDocTypeSystemIdentifierQuoted();
                        break;
                    case HtmlTokenizerState.AfterDocTypeSystemIdentifier:
                        token = ReadAfterDocTypeSystemIdentifier();
                        break;
                    case HtmlTokenizerState.BogusDocType:
                        token = ReadBogusDocType();
                        break;
                    case HtmlTokenizerState.CDataSection:
                        token = ReadCDataSection();
                        break;
                    case HtmlTokenizerState.EndOfFile:
                    default:
                        token = null;
                        return false;
                }
            } while (token is null);

            return true;
        }
        #endregion
    }
}
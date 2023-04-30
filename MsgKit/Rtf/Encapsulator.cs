using System.IO;
using MsgKit.HtmParser;
// ReSharper disable UnusedMember.Global

namespace MsgKit.Rtf
{
    #region Destination
    /// <summary>
    ///     The Destination flag defines where the HTML content was located relative to the
    ///     &lt;HTML&gt;, &lt;HEAD&gt;, and &lt;BODY&gt; elements. The following table specifies
    /// the values for the Destination flag.
    /// </summary>
    internal enum Destination
    { 
        /// <summary>
        ///     The corresponding fragment of original HTML SHOULD appear inside of a &lt;BODY&gt; HTML element.
        /// </summary>
        InBody = 0x0000,

        /// <summary>
        ///     The corresponding fragment of original HTML SHOULD appear inside of a &lt;HEAD&gt; HTML element.
        /// </summary>
        InHead = 0x0001,

        /// <summary>
        ///     The corresponding fragment of original HTML SHOULD appear inside of an &lt;HTML&gt; HTML element.
        /// </summary>
        InHtml = 0x0002,

        /// <summary>
        ///     The corresponding fragment of original HTML SHOULD appear outside of an &lt;HTML&gt; HTML element.
        /// </summary>
        OutHtml = 0x0003
    }
    #endregion

    #region TagType
    /// <summary>
    ///     The TagType flag defines the type of HTML content that is stored in the CONTENT HTML fragment in an
    ///     \*\htmltag destination group. The following table specifies the values for the TagType flag.
    /// </summary>
    internal enum TagType
    {
        /// <summary>
        ///     This group encapsulates a text fragment rather than any HTML tags.
        /// </summary>
        Text = 0x0000,

        /// <summary>
        ///     The corresponding fragment of the original HTML SHOULD appear inside a paragraph HTML element.
        /// </summary>
        InPar = 0x0004,

        /// <summary>
        ///     This is a closing tag.
        /// </summary>
        Close = 0x0008,

        /// <summary>
        ///     This group encapsulates the &lt;HTML&gt; HTML element.
        /// </summary>
        Html = 0x0010,

        /// <summary>
        ///     This group encapsulates the &lt;HEAD&gt; HTML element.
        /// </summary>
        Head = 0x0020,

        /// <summary>
        ///     This group encapsulates the &lt;BODY&gt; HTML element.
        /// </summary>
        Body = 0x0030,

        /// <summary>
        ///     This group encapsulates the &lt;P&gt; HTML element.
        /// </summary>
        P = 0x0040,

        /// <summary>
        ///     This group encapsulates an HTML tag that starts a paragraph other than the &lt;P&gt; HTML element.
        /// </summary>
        StartP = 0x0050,

        /// <summary>
        ///     This group encapsulates an HTML tag that ends a paragraph other than the &lt;P&gt; HTML element.
        /// </summary>
        EndP = 0x0060,

        /// <summary>
        ///     This group encapsulates the &lt;BR&gt; HTML element.
        /// </summary>
        Br = 0x0070,

        /// <summary>
        ///     This group encapsulates the &lt;PRE&gt; HTML element.
        /// </summary>
        Pre = 0x0080,

        /// <summary>
        ///     This group encapsulates the &lt;FONT&gt; HTML element.
        /// </summary>
        Font = 0x0090,

        /// <summary>
        ///     This group encapsulates MIME Encapsulation of Aggregate HTML Documents
        ///     (MHTML); that is, an HTML tag with a rewritable URL parameter. For more
        ///     details about the MHTMLTAG destination group, see section 2.1.3.1.5.
        /// </summary>
        Mhtml = 0x0100,

        /// <summary>
        ///     This group encapsulates heading HTML tags such as &lt;H1&gt;, &lt;H2&gt;, and so on.
        /// </summary>
        Header = 0x00A0,

        /// <summary>
        ///     This group encapsulates the &lt;TITLE&gt; HTML element.
        /// </summary>
        Title = 0x00B0,

        /// <summary>
        ///     This group encapsulates the &lt;PLAIN&gt; HTML element.
        /// </summary>
        Plain = 0x00C0,

        /// <summary>
        ///     Reserved, MUST be ignored.
        /// </summary>
        Reserved1 = 0x00D0,

        /// <summary>
        ///     Reserved, MUST be ignored.
        /// </summary>
        Reserved2 = 0x00E0,

        /// <summary>
        ///    This group encapsulates any other HTML tag.
        /// </summary>
        Unk = 0x00F0
    }
    #endregion

    /// <summary>
    ///     A class used to encapsulate HTML into RTF
    /// </summary>
    internal static class Encapsulator
    {
        #region GetEscapedRtf

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        internal static string EscapeHtml(string html)
        {
            // TODO: Figure out if this is correct

            return html.Replace(@"\par", "%x0D.0A")
                .Replace(@"\tab", "%x09")
                .Replace(@"\{", "%x7B")
                .Replace(@"\}", "%x7D")
                .Replace(@"\\", "%x5C")
                .Replace(@"\lquote", "&lsquo;")
                .Replace(@"\rquote", "&rsquo;")
                .Replace(@"\ldblquote", "&ldquo;")
                .Replace(@"\rdblquote", "&rdquo;")
                .Replace(@"\bullet", "&bull;")
                .Replace(@"\endash", "&ndash;")
                .Replace(@"\emdash", "&mdash;")
                .Replace(@"~", "&nbsp;")
                .Replace(@"\_", "&shy;")
                .Replace(@"\'HH", "%xHH")
                .Replace(@"\u[-]NNNNN", "&#xHHHH;")
                .Replace(@"\uc", "");
        }

        internal static string Encapsulate(string html)
        {
            var tokenizer = new HtmlTokenizer(new StringReader(html));

            while (tokenizer.ReadNextToken(out var token))
            {
                if (token is HtmlTagToken tagToken)
                {
                    switch (tagToken.Id)
                    {
                        case HtmlTagId.Html:
                            break;

                        case HtmlTagId.Head:
                            break;

                        case HtmlTagId.Body:
                            break;

                        case HtmlTagId.P:
                            break;

                        case HtmlTagId.Br:
                            break;

                        case HtmlTagId.Pre:
                            break;

                        case HtmlTagId.Font:
                            break;

                        case HtmlTagId.Header:
                            break;

                        case HtmlTagId.Title:
                            break;

                        case HtmlTagId.PlainText:
                            break;

                        // This group encapsulates any other HTML tag
                        default:
                            break;

                    }
                }
            }

            //// Convert Unicode string to RTF according to specification
            //var rtfEscaped = new StringBuilder();
            //var escapedChars = new int[] { '{', '}', '\\' };
            //foreach (var @char in str)
            //{
            //    var intChar = Convert.ToInt32(@char);

            //    // Ignore control characters
            //    if (intChar <= 31) continue;

            //    if (intChar <= 127)
            //    {
            //        if (escapedChars.Contains(intChar))
            //            rtfEscaped.Append('\\');
            //        rtfEscaped.Append(@char);
            //    }
            //    else if (intChar <= 255)
            //    {
            //        rtfEscaped.Append("\\'" + intChar.ToString("x2"));
            //    }
            //    else
            //    {
            //        rtfEscaped.Append("\\u");
            //        rtfEscaped.Append(intChar);
            //        rtfEscaped.Append('?');
            //    }
            //}

            //return "{\\rtf1\\ansi\\ansicpg1252\\fromhtml1 {\\*\\htmltag1 " + rtfEscaped + " }}";
            ////return "{\\rtf1\\ansi\\ansicpg1252\\fromhtml1 " + rtfEscaped + "}";

            return null;
        }
    }
}

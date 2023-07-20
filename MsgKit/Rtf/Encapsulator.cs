using System;
using System.Linq;
using System.Text;
// ReSharper disable UnusedMember.Global

namespace MsgKit.Rtf
{
    /// <summary>
    ///     A class used to encapsulate HTML into RTF
    /// </summary>
    internal static class Encapsulator
    {
        /// <summary>
        ///     Encapsulates the given <paramref name="html"/> into RTF
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        internal static string Encapsulate(string html)
        {
            // Convert Unicode string to RTF according to specification
            var rtf = new StringBuilder();

            rtf.AppendLine($@"{{\rtf1\ANSI\ansicpg{Encoding.Default.CodePage}\fromhtml1 \deff0");
            //rtf.AppendLine(@"{\fonttbl {\f0\fmodern Courier New;}}");
            //rtf.AppendLine(@"{\colortbl\red0\green0\blue0;\red0\green0\blue255;}");
            rtf.AppendLine(@"{\*\htmltag64}");
            rtf.Append(@"{\*\htmltag ");

            //var matches = Regex.Matches(html, @"(?<=\\u-?)\d{5}\b", RegexOptions.Compiled);
            //foreach (var match in matches)
            //{
            //    var value = int.Parse(match.ToString());
            //    html = html.Replace($@"\u-{value}", $"&#x{value:X4};")
            //        .Replace($@"\u{value}", $"&#x{value:X4};");
            //}

            var escapedChars = new int[] { '{', '}', '\\' };

            foreach (var chr in html)
            {
                var intChar = Convert.ToInt32(chr);

                switch (intChar)
                {
                    case 9:
                        rtf.Append(@"\tab ");
                        continue;
                    
                    case 13:
                        rtf.AppendLine(@"\par");
                        continue;
                  
                    default:
                    {
                        if (intChar < 31)
                            continue;

                        break;
                    }
                }

                if (intChar <= 127)
                {
                    if (escapedChars.Contains(intChar))
                        rtf.Append('\\');

                    rtf.Append(chr);
                }
                else if (intChar <= 255)
                    rtf.Append("\\'" + intChar.ToString("X2"));
                else
                {
                    rtf.Append("\\u");
                    rtf.Append(intChar);
                    rtf.Append('?');
                }
            }
            
            rtf.AppendLine(" }}");
            return rtf.ToString();
        }
    }
}

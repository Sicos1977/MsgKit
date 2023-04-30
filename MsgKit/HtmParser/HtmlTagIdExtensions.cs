using System;
using System.Collections.Generic;
// ReSharper disable UnusedMember.Global

namespace MsgKit.HtmParser
{
    /// <summary>
    ///     <see cref="HtmlTagId" /> extension methods.
    /// </summary>
    /// <remarks>
    ///     <see cref="HtmlTagId" /> extension methods.
    /// </remarks>
    internal static class HtmlTagIdExtensions
    {
        #region Fields
        private static readonly Dictionary<string, HtmlTagId> TagNameToId;
        #endregion

        #region Constructor
        static HtmlTagIdExtensions()
        {
            var values = (HtmlTagId[])Enum.GetValues(typeof(HtmlTagId));

            TagNameToId =
                new Dictionary<string, HtmlTagId>(values.Length - 1, OptimizedOrdinalIgnoreCaseComparer.Comparer);

            for (var i = 0; i < values.Length - 1; i++)
                TagNameToId.Add(values[i].ToHtmlTagName(), values[i]);
        }
        #endregion

        #region ToHtmlTagName
        /// <summary>
        ///     Converts the enum value into the equivalent tag name.
        /// </summary>
        /// <remarks>
        ///     Converts the enum value into the equivalent tag name.
        /// </remarks>
        /// <returns>The tag name.</returns>
        /// <param name="value">The enum value.</param>
        public static string ToHtmlTagName(this HtmlTagId value)
        {
            if (value == HtmlTagId.Comment)
                return "!";

            var name = value.ToString();
            var field = typeof(HtmlTagId).GetField(name);
            var attrs = field.GetCustomAttributes(typeof(HtmlTagNameAttribute), false);

            return attrs.Length == 1 ? ((HtmlTagNameAttribute)attrs[0]).Name : name.ToLowerInvariant();
        }
        #endregion

        #region ToHtmlTagId
        /// <summary>
        ///     Converts the tag name into the equivalent tag id.
        /// </summary>
        /// <remarks>
        ///     Converts the tag name into the equivalent tag id.
        /// </remarks>
        /// <returns>The tag id.</returns>
        /// <param name="name">The tag name.</param>
        internal static HtmlTagId ToHtmlTagId(this string name)
        {
            if (string.IsNullOrEmpty(name))
                return HtmlTagId.Unknown;

            if (name[0] == '!')
                return HtmlTagId.Comment;

            return !TagNameToId.TryGetValue(name, out var value) ? HtmlTagId.Unknown : value;
        }
        #endregion

        #region IsEmptyElement
        /// <summary>
        ///     Determines whether or not the HTML tag is an empty element.
        /// </summary>
        /// <remarks>
        ///     Determines whether or not the HTML tag is an empty element.
        /// </remarks>
        /// <returns><c>true</c> if the tag is an empty element; otherwise, <c>false</c>.</returns>
        /// <param name="id">Identifier.</param>
        public static bool IsEmptyElement(this HtmlTagId id)
        {
            switch (id)
            {
                case HtmlTagId.Area:
                case HtmlTagId.Base:
                case HtmlTagId.Br:
                case HtmlTagId.Col:
                case HtmlTagId.Command:
                case HtmlTagId.Embed:
                case HtmlTagId.HR:
                case HtmlTagId.Image:
                case HtmlTagId.Input:
                case HtmlTagId.Keygen:
                case HtmlTagId.Link:
                case HtmlTagId.Meta:
                case HtmlTagId.Param:
                case HtmlTagId.Source:
                case HtmlTagId.Track:
                case HtmlTagId.Wbr:
                    return true;
                default:
                    return false;
            }
        }
        #endregion

        #region IsFormattingElement
        /// <summary>
        ///     Determines whether or not the HTML tag is a formatting element.
        /// </summary>
        /// <remarks>
        ///     Determines whether or not the HTML tag is a formatting element.
        /// </remarks>
        /// <returns><c>true</c> if the HTML tag is a formatting element; otherwise, <c>false</c>.</returns>
        /// <param name="id">The HTML tag identifier.</param>
        public static bool IsFormattingElement(this HtmlTagId id)
        {
            switch (id)
            {
                case HtmlTagId.A:
                case HtmlTagId.B:
                case HtmlTagId.Big:
                case HtmlTagId.Code:
                case HtmlTagId.EM:
                case HtmlTagId.Font:
                case HtmlTagId.I:
                case HtmlTagId.NoBr:
                case HtmlTagId.S:
                case HtmlTagId.Small:
                case HtmlTagId.Strike:
                case HtmlTagId.Strong:
                case HtmlTagId.TT:
                case HtmlTagId.U:
                    return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}
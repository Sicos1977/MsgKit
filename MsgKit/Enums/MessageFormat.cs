namespace MsgKit.Enums
{
    /// <summary>
    ///     The messageformat to use
    /// </summary>
    public enum MessageFormat
    {
        /// <summary>
        ///     Send a plain text message body.
        /// </summary>
        TextOnly,

        /// <summary>
        ///     Send an HTML message body.
        /// </summary>
        HtmlOnly,

        /// <summary>
        ///     Send a multipart / alternative body with both plain text and HTML.
        /// </summary>
        TextAndHtml
    }
}

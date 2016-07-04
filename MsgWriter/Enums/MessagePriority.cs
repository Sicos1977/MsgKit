// ReSharper disable InconsistentNaming
namespace MsgWriter.Enums
{
    /// <summary>
    ///     Contains a value that indicates the message sender's opinion of the importance of a message. 
    /// </summary>
    public enum MessagePriority
    {
        /// <summary>
        ///     The message has low importance.
        /// </summary>
        IMPORTANCE_LOW = 0,

        /// <summary>
        ///     The message has normal importance.
        /// </summary>
        IMPORTANCE_NORMAL = 1,

        /// <summary>
        ///     The message has high importance.
        /// </summary>
        IMPORTANCE_HIGH = 2
    }
}
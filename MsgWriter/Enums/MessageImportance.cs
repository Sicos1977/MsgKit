// ReSharper disable InconsistentNaming
namespace MsgWriter.Enums
{
    /// <summary>
    ///     Contains the relative priority of a message.
    /// </summary>
    public enum MessageImportance
    {
        /// <summary>
        ///     The message is not urgent.
        /// </summary>
        PRIO_NONURGENT = 0,

        /// <summary>
        ///     The message has normal priority.
        /// </summary>
        PRIO_NORMAL = 1,

        /// <summary>
        ///     The message is urgent.
        /// </summary>
        PRIO_URGENT = 2
    }
}
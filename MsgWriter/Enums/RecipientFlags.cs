using System;

namespace MsgWriter.Enums
{
    /// <summary>
    ///     Specifies a bit field that describes the recipient status.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc815629.aspx
    /// </remarks>
    [Flags]
    public enum RecipientFlags : uint
    {
        /// <summary>
        ///     The recipient is a Sendable Attendee. This flag is only used in the dispidApptUnsendableRecips
        ///     (PidLidAppointmentUnsendableRecipients) property.
        /// </summary>
        RecipSendable = 0x00000001,

        /// <summary>
        ///     The RecipientRow on which this flag is set represents the meeting Organizer.
        /// </summary>
        RecipOrganizer = 0x0000002,

        /// <summary>
        ///     Indicates that the attendee gave a response for the exception on which this RecipientRow resides. This flag is only
        ///     used in a RecipientRow of an exception embedded message object of the organizer’s meeting object.
        /// </summary>
        RecipExceptionalResponse = 0x00000010,

        /// <summary>
        ///     Indicates that although the RecipientRow exists, it should be treated as if the corresponding recipient does not.
        ///     This flag is only used in a RecipientRow of an exception embedded message object of the organizer’s meeting object.
        /// </summary>
        RecipExceptionalDeleted = 0x00000020,

        /// <summary>
        ///     Indicates the recipient is an original attendee. This flag is only used in the dispidApptUnsendableRecips property.
        /// </summary>
        RecipOriginal = 0x00000100
    }
}
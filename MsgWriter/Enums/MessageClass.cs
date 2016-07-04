// ReSharper disable InconsistentNaming
namespace MsgWriter.Enums
{
    /// <summary>
    ///     The MessageClass element is an optional element that specifies the message class of this e-mail message.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee200767(v=exchg.80).aspx
    /// </remarks>
    public enum MessageClass
    {
        /// <summary>
        ///     The message type is unknown
        /// </summary>
        Unknown,

        /// <summary>
        ///     Normal e-mail message.
        /// </summary>
        IPM_Note,

        /// <summary>
        ///     The message is encrypted and can also be signed.
        /// </summary>
        IPM_Note_SMIME,

        /// <summary>
        ///     The message is clear signed.
        /// </summary>
        IPM_Note_SMIME_MultipartSigned,

        /// <summary>
        ///     The message is a secure read receipt.
        /// </summary>
        IPM_Note_Receipt_SMIME,

        /// <summary>
        ///     An InfoPath form, as specified by [MS-IPFFX].
        /// </summary>
        IPM_InfoPathForm,

        /// <summary>
        ///     Meeting request.
        /// </summary>
        IPM_Schedule_Meeting,

        /// <summary>
        ///     Meeting notification.
        /// </summary>
        IPM_Notification_Meeting,

        /// <summary>
        ///     Post.
        /// </summary>
        IPM_Post,

        /// <summary>
        ///     Octel voice message.
        /// </summary>
        IPM_Octel_Voice,

        /// <summary>
        ///     Electronic voice notes.
        /// </summary>
        IPM_Voicenotes,

        /// <summary>
        ///     Shared message.
        /// </summary>
        IPM_Sharing,

        /// <summary>
        ///     Non-delivery report for a standard message.
        /// </summary>
        REPORT_IPM_NOTE_NDR,

        /// <summary>
        ///     Delivery receipt for a standard message.
        /// </summary>
        REPORT_IPM_NOTE_DR,

        /// <summary>
        ///     Delivery receipt for a delayed message.
        /// </summary>
        REPORT_IPM_NOTE_DELAYED,

        /// <summary>
        ///     Read receipt for a standard message.
        /// </summary>
        REPORT_IPM_NOTE_IPNRN,

        /// <summary>
        ///     Non-read receipt for a standard message.
        /// </summary>
        REPORT_IPM_NOTE_IPNNRN,

        /// <summary>
        ///     Non-delivery report for a meeting request.
        /// </summary>
        REPORT_IPM_SCHEDULE_MEETING_REQUEST_NDR,

        /// <summary>
        ///     Non-delivery report for a positive meeting response (accept).
        /// </summary>
        REPORT_IPM_SCHEDULE_MEETING_RESP_POS_NDR,

        /// <summary>
        ///     Non-delivery report for a Tentative meeting response.
        /// </summary>
        REPORT_IPM_SCHEDULE_MEETING_RESP_TENT_NDR,

        /// <summary>
        ///     Non-delivery report for a cancelled meeting notification.
        /// </summary>
        REPORT_IPM_SCHEDULE_MEETING_CANCELED_NDR,

        /// <summary>
        ///     Non-delivery report for a Secure MIME (S/MIME) encrypted and opaque-signed message.
        /// </summary>
        REPORT_IPM_NOTE_SMIME_NDR,

        /// <summary>
        ///     Delivery receipt for an S/MIME encrypted and opaque-signed message.
        /// </summary>
        REPORT_IPM_NOTE_SMIME_DR,

        /// <summary>
        ///     Non-delivery report for an S/MIME clear-signed message.
        /// </summary>
        REPORT_IPM_NOTE_SMIME_MULTIPARTSIGNED_NDR,

        /// <summary>
        ///     Delivery receipt for an S/MIME clear-signed message.
        /// </summary>
        REPORT_IPM_NOTE_SMIME_MULTIPARTSIGNED_DR
    }
}
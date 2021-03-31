//
// MessageClass.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2021 Magic-Sessions. (www.magic-sessions.com)
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

// ReSharper disable InconsistentNaming
namespace MsgKit.Enums
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
        REPORT_IPM_NOTE_SMIME_MULTIPARTSIGNED_DR,

        /// <summary>
        ///     An appointment
        /// </summary>
        IPM_Appointment,

        /// <summary>
        ///     Task
        /// </summary>
        IPM_Task,

        /// <summary>
        ///     A contact
        /// </summary>
        IPM_Contact
    }
}
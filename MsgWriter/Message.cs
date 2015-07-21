using System;
using System.IO;
using CompoundFileStorage;

namespace MsgWriter
{
    /// <summary>
    /// The base class for all the different types of Outlook MSG files
    /// </summary>
    public class Message : IDisposable
    {
        #region Public enum MessageType
        /// <summary>
        /// The message types
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// The message type is unknown
            /// </summary>
            Unknown,

            /// <summary>
            /// The message is a normal E-mail
            /// </summary>
            Email,

            /// <summary>
            /// Non-delivery report for a standard E-mail (REPORT.IPM.NOTE.NDR)
            /// </summary>
            EmailNonDeliveryReport,

            /// <summary>
            /// Delivery receipt for a standard E-mail (REPORT.IPM.NOTE.DR)
            /// </summary>
            EmailDeliveryReport,

            /// <summary>
            /// Delivery receipt for a delayed E-mail (REPORT.IPM.NOTE.DELAYED)
            /// </summary>
            EmailDelayedDeliveryReport,

            /// <summary>
            /// Read receipt for a standard E-mail (REPORT.IPM.NOTE.IPNRN)
            /// </summary>
            EmailReadReceipt,

            /// <summary>
            /// Non-read receipt for a standard E-mail (REPORT.IPM.NOTE.IPNNRN)
            /// </summary>
            EmailNonReadReceipt,

            /// <summary>
            /// The message in an E-mail that is encrypted and can also be signed (IPM.Note.SMIME)
            /// </summary>
            EmailEncryptedAndMeabySigned,

            /// <summary>
            /// Non-delivery report for a Secure MIME (S/MIME) encrypted and opaque-signed E-mail (REPORT.IPM.NOTE.SMIME.NDR)
            /// </summary>
            EmailEncryptedAndMeabySignedNonDelivery,

            /// <summary>
            /// Delivery report for a Secure MIME (S/MIME) encrypted and opaque-signed E-mail (REPORT.IPM.NOTE.SMIME.DR)
            /// </summary>
            EmailEncryptedAndMeabySignedDelivery,

            /// <summary>
            /// The message is an E-mail that is clear signed (IPM.Note.SMIME.MultipartSigned)
            /// </summary>
            EmailClearSigned,

            /// <summary>
            /// The message is a secure read receipt for an E-mail (IPM.Note.Receipt.SMIME)
            /// </summary>
            EmailClearSignedReadReceipt,

            /// <summary>
            /// Non-delivery report for an S/MIME clear-signed E-mail (REPORT.IPM.NOTE.SMIME.MULTIPARTSIGNED.NDR)
            /// </summary>
            EmailClearSignedNonDelivery,

            /// <summary>
            /// Delivery receipt for an S/MIME clear-signed E-mail (REPORT.IPM.NOTE.SMIME.MULTIPARTSIGNED.DR)
            /// </summary>
            EmailClearSignedDelivery,

            /// <summary>
            /// The message is an appointment (IPM.Appointment)
            /// </summary>
            Appointment,

            /// <summary>
            /// The message is a notification for an appointment (IPM.Notification.Meeting)
            /// </summary>
            AppointmentNotification,

            /// <summary>
            /// The message is a schedule for an appointment (IPM.Schedule.Meeting)
            /// </summary>
            AppointmentSchedule,

            /// <summary>
            /// The message is a request for an appointment (IPM.Schedule.Meeting.Request)
            /// </summary>
            AppointmentRequest,

            /// <summary>
            /// The message is a request for an appointment (REPORT.IPM.SCHEDULE.MEETING.REQUEST.NDR)
            /// </summary>
            AppointmentRequestNonDelivery,

            /// <summary>
            /// The message is a response to an appointment (IPM.Schedule.Response)
            /// </summary>
            AppointmentResponse,

            /// <summary>
            /// The message is a positive response to an appointment (IPM.Schedule.Resp.Pos)
            /// </summary>
            AppointmentResponsePositive,

            /// <summary>
            /// Non-delivery report for a positive meeting response (accept) (REPORT.IPM.SCHEDULE.MEETING.RESP.POS.NDR)
            /// </summary>
            AppointmentResponsePositiveNonDelivery,

            /// <summary>
            /// The message is a negative response to an appointment (IPM.Schedule.Resp.Neg)
            /// </summary>
            AppointmentResponseNegative,

            /// <summary>
            /// Non-delivery report for a negative meeting response (declinet) (REPORT.IPM.SCHEDULE.MEETING.RESP.NEG.NDR)
            /// </summary>
            AppointmentResponseNegativeNonDelivery,

            /// <summary>
            /// The message is a response to tentatively accept the meeting request (IPM.Schedule.Meeting.Resp.Tent)
            /// </summary>
            AppointmentResponseTentative,


            /// <summary>
            /// Non-delivery report for a Tentative meeting response (REPORT.IPM.SCHEDULE.MEETING.RESP.TENT.NDR)
            /// </summary>
            AppointmentResponseTentativeNonDelivery,

            /// <summary>
            /// The message is a cancelation an appointment (IPM.Schedule.Meeting.Canceled)
            /// </summary>
            AppointmentResponseCanceled,

            /// <summary>
            /// Non-delivery report for a cancelled meeting notification (REPORT.IPM.SCHEDULE.MEETING.CANCELED.NDR)
            /// </summary>
            AppointmentResponseCanceledNonDelivery,

            /// <summary>
            /// The message is a contact card (IPM.Contact)
            /// </summary>
            Contact,

            /// <summary>
            /// The message is a task (IPM.Task)
            /// </summary>
            Task,

            /// <summary>
            /// The message is a task request accept (IPM.TaskRequest.Accept)
            /// </summary>
            TaskRequestAccept,

            /// <summary>
            /// The message is a task request decline (IPM.TaskRequest.Decline)
            /// </summary>
            TaskRequestDecline,

            /// <summary>
            /// The message is a task request update (IPM.TaskRequest.Update)
            /// </summary>
            TaskRequestUpdate,

            /// <summary>
            /// The message is a sticky note (IPM.StickyNote)
            /// </summary>
            StickyNote
        }
        #endregion

        #region MessageImportance
        /// <summary>
        /// The importancy of the message
        /// </summary>
        public enum MessageImportance
        {
            /// <summary>
            /// Low
            /// </summary>
            Low = 0,

            /// <summary>
            /// Normal
            /// </summary>
            Normal = 1,

            /// <summary>
            /// High
            /// </summary>
            High = 2
        }
        #endregion

        #region Properties
        /// <summary>
        /// The <see cref="CompoundFileStorage.CompoundFile"/>
        /// </summary>
        internal readonly CompoundFile CompoundFile;
        #endregion

        internal Message()
        {
            CompoundFile = new CompoundFile();
        }

        /// <summary>
        /// Saves the message to the given <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName"></param>
        internal void Save(string fileName)
        {
            CompoundFile.Save(fileName);
        }

        /// <summary>
        /// Saves the message to the given <paramref name="stream"/>
        /// </summary>
        /// <param name="stream"></param>
        internal void Save(Stream stream)
        {
            CompoundFile.Save(stream);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MsgWriter.Exceptions;
using MsgWriter.Streams;
using OpenMcdf;

/*
   Copyright 2015 Kees van Spelde

   Licensed under The Code Project Open License (CPOL) 1.02;
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.codeproject.com/info/cpol10.aspx

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace MsgWriter
{
    /// <summary>
    /// The base class for all the different types of Outlook MSG files
    /// </summary>
    public class Message : IDisposable
    {
        #region MessagePropertyEncoding
        /// <summary>
        /// The prefered encoding to use when reading or writing a <see cref="PropertyTag"/>
        /// </summary>
        public enum MessagePropertyEncoding
        {
            /// <summary>
            /// Prefered UNICODE values
            /// </summary>
            Unicode,

            /// <summary>
            /// Prefered ANSI values
            /// </summary>
            Ansi
        }
        #endregion
        
        #region Public enum MessageClass
        /// <summary>
        /// The message class
        /// </summary>
        public enum MessageClass
        {
            /// <summary>
            /// The message type is unknown
            /// </summary>
            Unknown,

            /// <summary>
            /// The message is a normal E-mail (IPM.Note)
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

        #region Public enum MessageImportance
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

        #region Fields
        /// <summary>
        /// The <see cref="OpenMcdf.CompoundFile"/>
        /// </summary>
        internal readonly CompoundFile CompoundFile;

        /// <summary>
        /// The message class
        /// </summary>
        internal MessageClass Class;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates this object and sets all it's properties
        /// </summary>
        internal Message()
        {
            CompoundFile = new CompoundFile();
        }
        #endregion
        
        #region Save
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
        #endregion

        #region GetString
        /// <summary>
        /// Returns the string value for the given <param name="propertyTag">. 
        /// <c>null</c> is returned when the property does not exists or no valid value is found</param>
        /// </summary>
        /// <param name="propertyTag"><see cref="PropertyTag"/></param>
        /// <returns></returns>
        /// <exception cref="MWInvalidProperty">Raised when the <paramref name="propertyTag"/> is not of the type 
        /// <see cref="PropertyType.PT_STRING8"/> or <see cref="PropertyType.PT_UNICODE"/></exception>
        internal string GetString(PropertyTag propertyTag)
        {
            return GetString(new List<PropertyTag> {propertyTag});
        }

        /// <summary>
        /// Returns the string value from the first item in the list of <param name="propertyTags"> that gives
        /// back a valid value. <c>null</c> is returned when the property does not exists or no valid value is found</param>
        /// </summary>
        /// <param name="propertyTags">List of <see cref="PropertyTag"/></param>
        /// <returns></returns>
        /// <exception cref="MWInvalidProperty">Raised when the <paramref name="propertyTags"/> is not of the type 
        /// <see cref="PropertyType.PT_STRING8"/> or <see cref="PropertyType.PT_UNICODE"/></exception>
        internal string GetString(List<PropertyTag> propertyTags)
        {
            string result = null;

            foreach (var propertyTag in propertyTags)
            {
                var stream = CompoundFile.RootStorage.TryGetStream(propertyTag.Name);
                if (stream != null)
                {
                    switch (propertyTag.Type)
                    {
                        case PropertyType.PT_STRING8:
                            result =
                                Encoding.Default.GetString(stream.GetData());
                            break;

                        case PropertyType.PT_UNICODE:
                            result =
                                Encoding.UTF8.GetString(CompoundFile.RootStorage.GetStream(propertyTag.Name).GetData());
                            break;

                        default:
                            throw new MWInvalidProperty("The property is not of the type PT_STRING8 or PT_UNICODE");
                    }
                }

                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return null;
        }
        #endregion

        #region AddString
        /// <summary>
        /// Adds the given single value <param name="propertyTag"/> to the message, any already existing <see cref="PropertyTag"/> is
        /// overwritten.
        /// </summary>
        /// <param name="propertyTag"><see cref="PropertyTag"/></param>
        /// <param name="value">The value</param>
        /// <returns></returns>
        /// <exception cref="MWInvalidProperty">Raised when the <paramref name="propertyTag"/> is not of the type 
        /// <see cref="PropertyType.PT_STRING8"/> or <see cref="PropertyType.PT_UNICODE"/></exception>
        internal void AddString(PropertyTag propertyTag, string value)
        {
            AddString(propertyTag, new List<string> {value});
        }

        /// <summary>
        /// Adds the given multivalue <param name="propertyTag"/> to the message, any already existing <see cref="PropertyTag"/> is
        /// overwritten.
        /// </summary>
        /// <param name="propertyTag">List of <see cref="PropertyTag"/></param>
        /// <param name="values">The values</param>
        /// <returns></returns>
        /// <exception cref="MWInvalidProperty">Raised when the <paramref name="propertyTag"/> is not of the type 
        /// <see cref="PropertyType.PT_MV_STRING8"/> or <see cref="PropertyType.PT_MV_UNICODE"/></exception>
        internal void AddString(PropertyTag propertyTag, List<string> values)
        {
            var stream = CompoundFile.RootStorage.TryGetStream(propertyTag.Name);
            if (stream != null)
            {
                switch (propertyTag.Type)
                {
                    case PropertyType.PT_MV_STRING8:
                    case PropertyType.PT_MV_UNICODE:
                        stream = CompoundFile.RootStorage.GetStream(propertyTag.Name);
                        break;

                    default:
                        throw new MWInvalidProperty("The property is not of the type PT_MV_STRING8 or PT_MV_UNICODE");
                }
            }

            if (stream == null)
            {
                // TODO: Multivalue support
            }

        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
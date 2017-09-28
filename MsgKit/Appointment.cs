//
// Email.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com> and Travis Semple
//
// Copyright (c) 2015-2017 Magic-Sessions. (www.magic-sessions.com)
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
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MsgKit.Enums;
using MsgKit.Helpers;
using MsgKit.Streams;
using OpenMcdf;
using Stream = System.IO.Stream;

namespace MsgKit
{
    /// <summary>
    ///     Inherits from Email, because it has quite a few of the same fields
    /// </summary>
    public class Appointment : Email
    {
        #region Properties
        /// <summary>
        ///     Holds the location for the Appointment
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        ///     This property specifies whether or not the event is an all-day event, as 
        ///     specified by the user. A value of <c>true</c> indicates that the event is an all-day 
        ///     event, in which case the start time and end time must be midnight so that the 
        ///     duration is a multiple of 24 hours and is at least 24 hours. A value of <c>false</c> 
        ///     or the absence of this property indicates the event is not an all-day event. The 
        ///     client or server must not infer the value as TRUE when a user happens to create an 
        ///     event that is 24 hours, even if the event starts and ends at midnight.
        /// </summary>
        public bool AllDay { get; set; }

        /// <summary>
        ///     Holds meeting information for the appointment
        /// </summary>
        public DateTime MeetingStart { get; set; }

        /// <summary>
        ///     The end of the meeting
        /// </summary>
        public DateTime MeetingEnd { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        ///     Sends an appointment with sender, representing, subject, draft.
        /// </summary>
        /// <param name="sender"> Contains sender name and email. </param>
        /// <param name="representing">Contains who this appointment is representing. </param>
        /// <param name="subject"> Contains the subject for this appointment. </param>
        /// <param name="draft"> Is this a draft?</param>
        public Appointment(Sender sender,
            Representing representing,
            string subject,
            bool draft = false) : base(sender, representing, subject, draft)
        {
        }

        /// <summary>
        ///     Used to send without the representing structure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="subject"></param>
        /// <param name="draft"></param>
        public Appointment(Sender sender,
            string subject,
            bool draft = false) : base(sender, subject, draft)
        {
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes all the properties that are part of the <see cref="Appointment"/> object either as <see cref="CFStorage"/>'s
        ///     or <see cref="CFStream"/>'s to the <see cref="CompoundFile.RootStorage"/>
        /// </summary>
        private void WriteToStorage()
        {
            var rootStorage = CompoundFile.RootStorage;
            long messageSize = 0;

            messageSize += Recipients.WriteToStorage(rootStorage);
            messageSize += Attachments.WriteToStorage(rootStorage);

            var recipientCount = Recipients.Count;
            var attachmentCount = Attachments.Count;
            var propertiesStream = new TopLevelProperties(recipientCount,
                                                          attachmentCount,
                                                          recipientCount,
                                                          attachmentCount);

            if (!string.IsNullOrEmpty(InternetMessageId))
                propertiesStream.AddProperty(PropertyTags.PR_INTERNET_MESSAGE_ID_W, InternetMessageId);

            propertiesStream.AddProperty(PropertyTags.PR_ENTRYID, Mapi.GenerateEntryId());
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey());
            propertiesStream.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_STORE_UNICODE_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_ALTERNATE_RECIPIENT_ALLOWED, true, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_HASATTACH, attachmentCount > 0);

            var messageFlags = MessageFlags.MSGFLAG_UNMODIFIED;

            if (Draft)
            {
                messageFlags |= MessageFlags.MSGFLAG_UNSENT | MessageFlags.MSGFLAG_FROMME;
                IconIndex = MessageIconIndex.UnsentMail;
            }

            if (attachmentCount > 0)
                messageFlags |= MessageFlags.MSGFLAG_HASATTACH;

            if (!SentOn.HasValue)
                SentOn = DateTime.UtcNow;

            propertiesStream.AddProperty(PropertyTags.PR_CLIENT_SUBMIT_TIME, SentOn);
            propertiesStream.AddProperty(PropertyTags.PR_MESSAGE_FLAGS, messageFlags);
            propertiesStream.AddProperty(PropertyTags.PR_ACCESS, MapiAccess.MAPI_ACCESS_DELETE | MapiAccess.MAPI_ACCESS_MODIFY | MapiAccess.MAPI_ACCESS_READ);
            propertiesStream.AddProperty(PropertyTags.PR_ACCESS_LEVEL, MapiAccess.MAPI_ACCESS_MODIFY);
            propertiesStream.AddProperty(PropertyTags.PR_OBJECT_TYPE, MapiObjectType.MAPI_MESSAGE);

            SetSubject();
            propertiesStream.AddProperty(PropertyTags.PR_SUBJECT_W, Subject);
            propertiesStream.AddProperty(PropertyTags.PR_NORMALIZED_SUBJECT_W, SubjectNormalized);
            propertiesStream.AddProperty(PropertyTags.PR_SUBJECT_PREFIX_W, SubjectPrefix);
            propertiesStream.AddProperty(PropertyTags.PR_CONVERSATION_TOPIC_W, SubjectNormalized);

            // http://www.meridiandiscovery.com/how-to/e-mail-conversation-index-metadata-computer-forensics/
            // http://stackoverflow.com/questions/11860540/does-outlook-embed-a-messageid-or-equivalent-in-its-email-elements
            //propertiesStream.AddProperty(PropertyTags.PR_CONVERSATION_INDEX, Subject);

            // TODO: Change modification time when this message is opened and only modified
            var utcNow = DateTime.UtcNow;
            propertiesStream.AddProperty(PropertyTags.PR_CREATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_MESSAGE_CLASS_W, "IPM.Appointment");
            propertiesStream.AddProperty(PropertyTags.PR_PRIORITY, Priority);
            propertiesStream.AddProperty(PropertyTags.PR_IMPORTANCE, Importance);
            propertiesStream.AddProperty(PropertyTags.PR_MESSAGE_LOCALE_ID, CultureInfo.CurrentCulture.LCID);
            propertiesStream.AddProperty(PropertyTags.PR_ICON_INDEX, IconIndex);

            if (Sender != null) Sender.WriteProperties(propertiesStream);
            if (Receiving != null) Receiving.WriteProperties(propertiesStream);
            if (Representing != null) Representing.WriteProperties(propertiesStream);
            if (ReceivingRepresenting != null) ReceivingRepresenting.WriteProperties(propertiesStream);

            if (recipientCount > 0)
            {
                var displayTo = new List<string>();
                var displayCc = new List<string>();
                var displayBcc = new List<string>();

                foreach (var recipient in Recipients)
                    switch (recipient.RecipientType)
                    {
                        case RecipientType.To:
                            if (!string.IsNullOrWhiteSpace(recipient.DisplayName))
                                displayTo.Add(recipient.DisplayName);
                            else if (!string.IsNullOrWhiteSpace(recipient.Email))
                                displayTo.Add(recipient.Email);
                            break;

                        case RecipientType.Cc:
                            if (!string.IsNullOrWhiteSpace(recipient.DisplayName))
                                displayCc.Add(recipient.DisplayName);
                            else if (!string.IsNullOrWhiteSpace(recipient.Email))
                                displayCc.Add(recipient.Email);
                            break;

                        case RecipientType.Bcc:
                            if (!string.IsNullOrWhiteSpace(recipient.DisplayName))
                                displayBcc.Add(recipient.DisplayName);
                            else if (!string.IsNullOrWhiteSpace(recipient.Email))
                                displayBcc.Add(recipient.Email);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_TO_W, string.Join(";", displayTo), PropertyFlags.PROPATTR_READABLE);
                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_CC_W, string.Join(";", displayCc), PropertyFlags.PROPATTR_READABLE);
                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_BCC_W, string.Join(";", displayBcc), PropertyFlags.PROPATTR_READABLE);
            }

            propertiesStream.AddProperty(PropertyTags.PR_INTERNET_CPID, Encoding.UTF8.CodePage);


            var nps = new NamedProperties(propertiesStream); //Uses the top level properties. 
            nps.AddProperty(NamedPropertyTags.PidLidLocation, Location);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentStartWhole, MeetingStart);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentEndWhole, MeetingEnd);
            nps.AddProperty(NamedPropertyTags.PidLidMeetingType, MeetingType.mtgRequest);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentSubType, AllDay);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentStateFlags, AppointmentState.asfMeeting);

            nps.WriteProperties(rootStorage);

            propertiesStream.WriteProperties(rootStorage, messageSize);
        }
        #endregion

        #region Save
        /// <summary>
        ///     Saves the message to the given <paramref name="stream" />
        /// </summary>
        /// <param name="stream"></param>
        public new void Save(Stream stream)
        {
            WriteToStorage();
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        public new void Save(string fileName)
        {
            WriteToStorage();
            CompoundFile.Save(fileName);
        }
        #endregion
    }
}
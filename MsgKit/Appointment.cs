using MsgKit.Enums;
using MsgKit.Helpers;
using MsgKit.Streams;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MsgKit
{
    /// <summary>
    /// Inherits from Email, because it has quite a few of the same fields
    /// </summary>
    public class Appointment : Email
    {
        /// <summary>
        /// Holds the location for the Appointment
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Contains the checked All Day, converts appointment into Event. 
        /// </summary>
        public bool AllDay { get; set; }
        /// <summary>
        /// Holds meeting information for the appointment
        /// </summary>
        public DateTime MeetingStart { get; set; }
        /// 
        public DateTime MeetingEnd { get; set; }

        /// <summary>
        /// Sends an appointment with sender, representing, subject, draft. 
        /// </summary>
        /// <param name="sender"> Contains sender name and email. </param>
        /// <param name="representing">Contains who this appointment is representing. </param>
        /// <param name="subject"> Contains the subject for this appointment. </param>
        /// <param name="draft"> Is this a draft?</param>
        public Appointment(Sender sender,
                     Representing representing,
                     string subject,
                     bool draft = false) : base(sender,representing, subject,draft)
        {

        }

        /// <summary>
        /// Used to send without the representing structure. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="subject"></param>
        /// <param name="draft"></param>
        public Appointment(Sender sender,
                     string subject,
                     bool draft = false) : base(sender,subject, draft)
        {

        }

        private new void WriteToStorage()
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
                {
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
            nps.AddProperty(NamedPropertyTags.PidLidMeetingType, 0x00000001);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentSubType, AllDay);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentStateFlags, 1);

            //Testing
            /*
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentSequence, 0);
            nps.AddProperty(NamedPropertyTags.PidLidBusyStatus, 0);
            nps.AddProperty(NamedPropertyTags.PidLidAppointmentAuxiliaryFlags, 0);
            nps.AddProperty(NamedPropertyTags.PidLidResponseStatus, 1);
            nps.AddProperty(NamedPropertyTags.PidLidTaskMode, 0);
            nps.AddProperty(NamedPropertyTags.PidLidTimeZoneDescription, "(UTC-08:00) Pacific Time (US & Canada)");
            nps.AddProperty(NamedPropertyTags.PidLidDirectory, "");
            nps.AddProperty(NamedPropertyTags.PidLidPrivate,false);
            nps.AddProperty(NamedPropertyTags.PidLidSendMeetingAsIcal, false);
            nps.AddProperty(NamedPropertyTags.PidLidRecurring, false);
            nps.AddProperty(NamedPropertyTags.PidLidConferencingType, 0);

            nps.AddProperty(NamedPropertyTags.PidLidReminderSet, false);*/


            nps.WriteProperties(rootStorage);

            propertiesStream.WriteProperties(rootStorage, messageSize);
        }

        #region Save
        /// <summary>
        ///     Saves the message to the given <paramref name="stream" />
        /// </summary>
        /// <param name="stream"></param>
        public new void Save(System.IO.Stream stream)
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

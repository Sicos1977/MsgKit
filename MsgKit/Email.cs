﻿//
// Email.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MsgKit.Enums;
using MsgKit.Helpers;
using OpenMcdf;
using Stream = System.IO.Stream;

namespace MsgKit
{
    /// <summary>
    ///     A class used to make a new Outlook E-mail MSG file
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc979231.aspx
    /// </remarks>
    public class Email : Message
    {
        #region Fields
        /// <summary>
        ///     The <see cref="Regex" /> to find the prefix in a subject
        /// </summary>
        private static readonly Regex SubjectPrefixRegex = new Regex(@"^(\D{1,3}:\s)(.*)$");

        /// <summary>
        ///     The E-mail <see cref="Recipients" />
        /// </summary>
        private Recipients _recipients;

        /// <summary>
        ///     The E-mail <see cref="Attachments" />
        /// </summary>
        private Attachments _attachments;

        /// <summary>
        ///     The subject of the E-mail
        /// </summary>
        private string _subject;
        #endregion

        #region Properties
        /// <summary>
        ///     Returns the sender of the E-mail from the <see cref="Recipients" />
        /// </summary>
        public Sender Sender { get; private set; }

        /// <summary>
        ///     Contains the e-mail address for the messaging user represented by the <see cref="Sender"/>.
        /// </summary>
        /// <remarks>
        ///     These properties are examples of the address properties for the messaging user who is being represented by the
        ///     <see cref="Receiving" /> user. They must be set by the incoming transport provider, which is also responsible for
        ///     authorization or verification of the delegate. If no messaging user is being represented, these properties should
        ///     be set to the e-mail address contained in the PR_RECEIVED_BY_EMAIL_ADDRESS (PidTagReceivedByEmailAddress) property.
        /// </remarks>
        public Representing Representing { get; private set; }

        /// <summary>
        ///     Returns the E-mail <see cref="Recipients" />
        /// </summary>
        public Recipients Recipients
        {
            get { return _recipients ?? (_recipients = new Recipients()); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user who receives the message.
        /// </summary>
        /// <remarks>
        ///     These properties are examples of the address properties for the messaging user who receives the message. They must
        ///     be set by the incoming transport provider.
        /// </remarks>
        public Receiving Receiving { get; set; }

        /// <summary>
        ///     Contains the e-mail address for the messaging user who is represented by the <see cref="Receiving"/> user.
        /// </summary>
        /// <remarks>
        ///     These properties are examples of the address properties for the messaging user who is being represented by the
        ///     <see cref="Receiving" /> user. They must be set by the incoming transport provider, which is also responsible for 
        ///     authorization or verification of the delegate. If no messaging user is being represented, these properties should 
        ///     be set to the e-mail address contained in the PR_RECEIVED_BY_EMAIL_ADDRESS (PidTagReceivedByEmailAddress) property.
        /// </remarks>
        public ReceivingRepresenting ReceivingRepresenting { get; internal set; }

        /// <summary>
        ///     Returns the subject prefix of the E-mail
        /// </summary>
        public string SubjectPrefix { get; private set; }

        /// <summary>
        ///     Returns or sets the subject of the E-mail
        /// </summary>
        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                SetSubject();
            }
        }

        /// <summary>
        ///     Returns the normalized subject of the E-mail
        /// </summary>
        public string SubjectNormalized { get; private set; }

        /// <summary>
        ///     Returns or sets the <see cref="MessagePriority"/>
        /// </summary>
        public MessagePriority Priority { get; set; }

        /// <summary>
        ///     Returns or sets the <see cref="MessageImportance"/>
        /// </summary>
        public MessageImportance Importance { get; set; }

        /// <summary>
        ///     Returns or sets the text body of the E-mail
        /// </summary>
        public string BodyText { get; set; }

        /// <summary>
        ///     Returns or sets the html body of the E-mail
        /// </summary>
        public string BodyHtml { get; set; }
        
        /// <summary>
        ///     The compressed RTF body part
        /// </summary>
        public string BodyRtf { get; set; }

        /// <summary>
        ///     Returns or set to <c>true</c> when <see cref="BodyRtf"/> is compressed
        /// </summary>
        public bool BodyRtfCompressed { get; set; }

        /// <summary>
        ///     The E-mail <see cref="Attachments" />
        /// </summary>
        public Attachments Attachments
        {
            get { return _attachments ?? (_attachments = new Attachments()); }
        }

        /// <summary>
        ///     Returns or sets the UTC date and time the <see cref="Sender"/> has submitted the 
        ///     <see cref="Message"/>
        /// </summary>
        /// <remarks>
        ///     This property has to be set to UTC datetime
        /// </remarks>
        public DateTime? SentOn { get; set; }

        /// <summary>
        ///     Returns the UTC date and time when the <see cref="Message"/> was received
        /// </summary>
        /// <remarks>
        ///     This property has to be set to UTC datetime
        /// </remarks>
        public DateTime? ReceivedOn { get; private set; }

        /// <summary>
        ///     Returns or sets the Internet Message Id
        /// </summary>
        /// <remarks>
        ///     Corresponds to the message ID field as specified in [RFC2822].
        /// </remarks>
        public string InternetMessageId { get; set; }

        /// <summary>
        ///     Returns or sets the transport message headers. These are only present when
        ///     the message has been sent outside an Exchange environment to another mailserver
        ///     <c>null</c> will be returned when not present
        /// </summary>
        public string TransportMessageHeaders { get; set; }

        /// <summary>
        ///     Returns <c>true</c> when the message is set as a draft message
        /// </summary>
        public bool Draft { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all the needed properties
        /// </summary>
        /// <param name="sender">The <see cref="Sender"/> of the E-mail</param>
        /// <param name="subject">The subject of the E-mail</param>
        /// <param name="draft">Set to <c>true</c> to save the E-mail as a draft message</param>
        public Email(Sender sender, 
                     string subject,
                     bool draft = false)
        {
            Sender = sender;
            Subject = subject;
            Importance = MessageImportance.IMPORTANCE_NORMAL;
            IconIndex = MessageIconIndex.NewMail;
            Draft = draft;
        }

        /// <summary>
        ///     Creates this object and sets all the needed properties
        /// </summary>
        /// <param name="sender">The <see cref="Sender"/> of the E-mail</param>
        /// <param name="representing">The <see cref="MsgKit.Representing"/> sender of the E-mail</param>
        /// <param name="subject">The subject of the E-mail</param>
        /// <param name="draft">Set to <c>true</c> to save the E-mail as a draft message</param>
        public Email(Sender sender,
                     Representing representing,
                     string subject,
                     bool draft = false)
        {
            Sender = sender;
            Representing = representing;
            Subject = subject;
            Importance = MessageImportance.IMPORTANCE_NORMAL;
            IconIndex = MessageIconIndex.NewMail;
            Draft = draft;
        }
        #endregion

        #region SetSubject
        /// <summary>
        ///     These properties are computed by message store or transport providers from the PR_SUBJECT (PidTagSubject) 
        ///     and PR_SUBJECT_PREFIX (PidTagSubjectPrefix) properties in the following manner. If the PR_SUBJECT_PREFIX 
        ///     is present and is an initial substring of PR_SUBJECT, PR_NORMALIZED_SUBJECT and associated properties are 
        ///     set to the contents of PR_SUBJECT with the prefix removed. If PR_SUBJECT_PREFIX is present, but it is not 
        ///     an initial substring of PR_SUBJECT, PR_SUBJECT_PREFIX is deleted and recalculated from PR_SUBJECT using 
        ///     the following rule: If the string contained in PR_SUBJECT begins with one to three non-numeric characters 
        ///     followed by a colon and a space, then the string together with the colon and the blank becomes the prefix.
        ///     Numbers, blanks, and punctuation characters are not valid prefix characters. If PR_SUBJECT_PREFIX is not 
        ///     present, it is calculated from PR_SUBJECT using the rule outlined in the previous step.This property then 
        ///     is set to the contents of PR_SUBJECT with the prefix removed.
        /// </summary>
        /// <remarks>
        ///     When PR_SUBJECT_PREFIX is an empty string, PR_SUBJECT and PR_NORMALIZED_SUBJECT are the same. Ultimately, 
        ///     this property should be the part of PR_SUBJECT following the prefix. If there is no prefix, this property 
        ///     becomes the same as PR_SUBJECT.
        /// </remarks>
        protected void SetSubject()
        {
            if (!string.IsNullOrEmpty(SubjectPrefix) && !string.IsNullOrEmpty(Subject))
            {
                if (Subject.StartsWith(SubjectPrefix))
                {
                    SubjectNormalized = Subject.Substring(SubjectPrefix.Length);
                }
                else
                {
                    var matches = SubjectPrefixRegex.Matches(Subject);
                    if (matches.Count > 0)
                    {
                        SubjectPrefix = matches.OfType<Match>().First().Groups[1].Value;
                        SubjectNormalized = matches.OfType<Match>().First().Groups[2].Value;
                    }
                }
            }
            else if (!string.IsNullOrEmpty(Subject))
            {
                var matches = SubjectPrefixRegex.Matches(Subject);
                if (matches.Count > 0)
                {
                    SubjectPrefix = matches.OfType<Match>().First().Groups[1].Value;
                    SubjectNormalized = matches.OfType<Match>().First().Groups[2].Value;
                }
                else
                    SubjectNormalized = Subject;
            }
            else
                SubjectNormalized = Subject;

            if (SubjectPrefix == null) SubjectPrefix = string.Empty;
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes all the properties that are part of the <see cref="Email"/> object either as <see cref="CFStorage"/>'s
        ///     or <see cref="CFStream"/>'s to the <see cref="CompoundFile.RootStorage"/>
        /// </summary>
        internal void WriteToStorage()
        {
            var rootStorage = CompoundFile.RootStorage;

            Class = MessageClass.IPM_Note;
            MessageSize += Recipients.WriteToStorage(rootStorage);
            MessageSize += Attachments.WriteToStorage(rootStorage);

            var recipientCount = Recipients.Count;
            var attachmentCount = Attachments.Count;
            TopLevelProperties.RecipientCount = recipientCount;
            TopLevelProperties.AttachmentCount = attachmentCount;
            TopLevelProperties.NextRecipientId = recipientCount; 
            TopLevelProperties.NextAttachmentId = attachmentCount;

            if (!string.IsNullOrEmpty(InternetMessageId))
                TopLevelProperties.AddProperty(PropertyTags.PR_INTERNET_MESSAGE_ID_W, InternetMessageId);

            TopLevelProperties.AddProperty(PropertyTags.PR_ENTRYID, Mapi.GenerateEntryId());
            TopLevelProperties.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey());
            TopLevelProperties.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);
            TopLevelProperties.AddProperty(PropertyTags.PR_STORE_UNICODE_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);
            TopLevelProperties.AddProperty(PropertyTags.PR_ALTERNATE_RECIPIENT_ALLOWED, true, PropertyFlags.PROPATTR_READABLE);
            TopLevelProperties.AddProperty(PropertyTags.PR_HASATTACH, attachmentCount > 0);
            TopLevelProperties.AddProperty(PropertyTags.PR_TRANSPORT_MESSAGE_HEADERS_W, TransportMessageHeaders);

            var messageFlags = MessageFlags.MSGFLAG_UNMODIFIED;

            if (attachmentCount > 0)
                messageFlags |= MessageFlags.MSGFLAG_HASATTACH;

            TopLevelProperties.AddProperty(PropertyTags.PR_INTERNET_CPID, Encoding.UTF8.CodePage);

            TopLevelProperties.AddProperty(PropertyTags.PR_BODY_W, BodyText);
            if (!string.IsNullOrEmpty(BodyHtml))
                TopLevelProperties.AddProperty(PropertyTags.PR_HTML, BodyHtml);

            if (Draft)
            {
                messageFlags |= MessageFlags.MSGFLAG_UNSENT | MessageFlags.MSGFLAG_FROMME;
                IconIndex = MessageIconIndex.UnsentMail;

                if (string.IsNullOrWhiteSpace(BodyRtf) && !string.IsNullOrWhiteSpace(BodyHtml))
                {
                    BodyRtf = Strings.GetEscapedRtf(BodyHtml);
                    BodyRtfCompressed = true;
                }
            }

            if (!SentOn.HasValue)
                SentOn = DateTime.UtcNow;

            TopLevelProperties.AddProperty(PropertyTags.PR_CLIENT_SUBMIT_TIME, SentOn.Value.ToUniversalTime());
            TopLevelProperties.AddProperty(PropertyTags.PR_MESSAGE_FLAGS, messageFlags);
            TopLevelProperties.AddProperty(PropertyTags.PR_ACCESS, MapiAccess.MAPI_ACCESS_DELETE | MapiAccess.MAPI_ACCESS_MODIFY | MapiAccess.MAPI_ACCESS_READ);
            TopLevelProperties.AddProperty(PropertyTags.PR_ACCESS_LEVEL, MapiAccess.MAPI_ACCESS_MODIFY);
            TopLevelProperties.AddProperty(PropertyTags.PR_OBJECT_TYPE, MapiObjectType.MAPI_MESSAGE);

            SetSubject();
            TopLevelProperties.AddProperty(PropertyTags.PR_SUBJECT_W, Subject);
            TopLevelProperties.AddProperty(PropertyTags.PR_NORMALIZED_SUBJECT_W, SubjectNormalized);
            TopLevelProperties.AddProperty(PropertyTags.PR_SUBJECT_PREFIX_W, SubjectPrefix);
            TopLevelProperties.AddProperty(PropertyTags.PR_CONVERSATION_TOPIC_W, SubjectNormalized);

            // http://www.meridiandiscovery.com/how-to/e-mail-conversation-index-metadata-computer-forensics/
            // http://stackoverflow.com/questions/11860540/does-outlook-embed-a-messageid-or-equivalent-in-its-email-elements
            //propertiesStream.AddProperty(PropertyTags.PR_CONVERSATION_INDEX, Subject);

            // TODO: Change modification time when this message is opened and only modified
            var utcNow = DateTime.UtcNow;
            TopLevelProperties.AddProperty(PropertyTags.PR_CREATION_TIME, utcNow);
            TopLevelProperties.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, utcNow);
            TopLevelProperties.AddProperty(PropertyTags.PR_PRIORITY, Priority);
            TopLevelProperties.AddProperty(PropertyTags.PR_IMPORTANCE, Importance);
            TopLevelProperties.AddProperty(PropertyTags.PR_MESSAGE_LOCALE_ID, CultureInfo.CurrentCulture.LCID);
            TopLevelProperties.AddProperty(PropertyTags.PR_ICON_INDEX, IconIndex);

            if (Sender != null) Sender.WriteProperties(TopLevelProperties);
            if (Receiving != null) Receiving.WriteProperties(TopLevelProperties);
            if (Representing != null) Representing.WriteProperties(TopLevelProperties);
            if (ReceivingRepresenting != null) ReceivingRepresenting.WriteProperties(TopLevelProperties);

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

                TopLevelProperties.AddProperty(PropertyTags.PR_DISPLAY_TO_W, string.Join(";", displayTo), PropertyFlags.PROPATTR_READABLE);
                TopLevelProperties.AddProperty(PropertyTags.PR_DISPLAY_CC_W, string.Join(";", displayCc), PropertyFlags.PROPATTR_READABLE);
                TopLevelProperties.AddProperty(PropertyTags.PR_DISPLAY_BCC_W, string.Join(";", displayBcc), PropertyFlags.PROPATTR_READABLE);
            }

            if (!string.IsNullOrEmpty(BodyRtf) && BodyRtfCompressed)
            {
                TopLevelProperties.AddProperty(PropertyTags.PR_RTF_COMPRESSED, RtfCompressor.Compress(Encoding.ASCII.GetBytes(BodyRtf)));
                TopLevelProperties.AddProperty(PropertyTags.PR_RTF_IN_SYNC, true);
            }
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
            base.Save(stream);
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        public new void Save(string fileName)
        {
            WriteToStorage();
            base.Save(fileName);
        }
        #endregion

        #region Dispose
        /// <summary>
        ///     Disposes all the attachment streams
        /// </summary>
        public new void Dispose()
        {
            foreach (var attachment in _attachments)
                attachment.Stream.Dispose();

            base.Dispose();
        }
        #endregion
    }
}
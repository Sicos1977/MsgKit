using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MsgWriter.Streams;
using MsgWriter.Structures;
using OpenMcdf;

/*
   Copyright 2015 - 2016 Kees van Spelde

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
    ///     A class used to make a new Outlook E-mail MSG files
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc979231.aspx
    /// </remarks>
    public class Email : Message
    {
        #region Fields
        /// <summary>
        ///     The E-mail <see cref="Recipients" />
        /// </summary>
        private Recipients _recipients;

        /// <summary>
        ///     The E-mail <see cref="Attachments" />
        /// </summary>
        private Attachments _attachments;
        #endregion

        #region Properties
        /// <summary>
        ///     Returns the sender of the E-mail from the <see cref="Recipients" />
        /// </summary>
        public Sender Sender { get; private set; }

        /// <summary>
        ///     The E-mail <see cref="Recipients" />
        /// </summary>
        public Recipients Recipients
        {
            get { return _recipients ?? (_recipients = new Recipients()); }
        }

        /// <summary>
        ///     Returns or sets the subject prefix of the E-mail
        /// </summary>
        public string SubjectPrefix { get; set; }

        /// <summary>
        ///     Returns or sets the subject of the E-mail
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     Returns the normalized subject of the E-mail
        /// </summary>
        public string SubjectNormalized { get; internal set; }

        /// <summary>
        ///     Returns or sets the text body of the E-mail
        /// </summary>
        public string TextBody { get; set; }

        /// <summary>
        ///     Returns or sets the html body of the E-mail
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        ///     The E-mail <see cref="Attachments" />
        /// </summary>
        public Attachments Attachments
        {
            get { return _attachments ?? (_attachments = new Attachments()); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates this object and sets all the needed properties
        /// </summary>
        /// <param name="sender">The <see cref="Sender"/> of the E-mail</param>
        public Email(Sender sender)
        {
            Sender = sender;
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
        ///     Note  When PR_SUBJECT_PREFIX is an empty string, PR_SUBJECT and PR_NORMALIZED_SUBJECT are the same. Ultimately, 
        ///     this property should be the part of PR_SUBJECT following the prefix. If there is no prefix, this property 
        ///     becomes the same as PR_SUBJECT. PR_SUBJECT_PREFIX and this property should be computed as part of the 
        ///     IMAPIProp::SaveChanges implementation. A client application should not prompt the IMAPIProp::GetProps 
        ///     method for their values until they have been committed by an IMAPIProp::SaveChanges call.
        /// </remarks>
        private void SetSubject(Properties propertiesStream)
        {
            if (!string.IsNullOrEmpty(SubjectPrefix))
            {
                if (Subject.Contains(SubjectPrefix))
                    SubjectNormalized = Subject.Replace(SubjectPrefix, string.Empty);
                else
                {
                    var prefix = Subject.Substring(5);
                    if (prefix.Contains(": ") && !prefix.Any(char.IsDigit))
                    {
                        SubjectPrefix = prefix;
                        SubjectNormalized = Subject.Replace(prefix, string.Empty);
                    }
                }
            }
            else
            {
                var prefix = Subject.Substring(5);
                if (prefix.Contains(": ") && !prefix.Any(char.IsDigit))
                {
                    SubjectPrefix = prefix;
                    SubjectNormalized = Subject.Replace(prefix, string.Empty);
                }
                else
                    SubjectNormalized = Subject;
            }

            if (SubjectPrefix == null) SubjectPrefix = string.Empty;

            propertiesStream.AddProperty(PropertyTags.PR_SUBJECT_W, Subject);
            propertiesStream.AddProperty(PropertyTags.PR_NORMALIZED_SUBJECT_W, Subject);
            propertiesStream.AddProperty(PropertyTags.PR_SUBJECT_PREFIX_W, SubjectPrefix);
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes all the properties that are part of the <see cref="Email"/> object either as <see cref="CFStorage"/>'s
        ///     or <see cref="CFStream"/>'s to the <see cref="CompoundFile.RootStorage"/>
        /// </summary>
        private void WriteToStorage()
        {
            var rootStorage = CompoundFile.RootStorage;

            Recipients.WriteToStorage(rootStorage);
            Attachments.WriteToStorage(rootStorage);

            var recipientCount = Recipients.Count;
            var attachmentCount = Attachments.Count;
            var propertiesStream = new TopLevelProperties(recipientCount,
                                                          attachmentCount, 
                                                          recipientCount, 
                                                          attachmentCount);

            // Indicates that alle the string properties are written in UNICODE format
            var storeSupportMask = StoreSupportMask.STORE_ATTACH_OK |
                                   StoreSupportMask.STORE_CATEGORIZE_OK |
                                   StoreSupportMask.STORE_CREATE_OK |
                                   StoreSupportMask.STORE_ENTRYID_UNIQUE |
                                   StoreSupportMask.STORE_MODIFY_OK |
                                   StoreSupportMask.STORE_MV_PROPS_OK |
                                   StoreSupportMask.STORE_OLE_OK |
                                   StoreSupportMask.STORE_RTF_OK |
                                   StoreSupportMask.STORE_UNICODE_OK;
            
            propertiesStream.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, storeSupportMask, PropertyFlag.PROPATTR_READABLE);
            SetSubject(propertiesStream);

            //throw new Exception("Datum tijd goed zetten");
            var utcNow = DateTime.Now;
            propertiesStream.AddProperty(PropertyTags.PR_CREATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_MESSAGE_CLASS_W, "IPM.Note");
            propertiesStream.AddProperty(PropertyTags.PR_MESSAGE_LOCALE_ID, CultureInfo.CurrentCulture.LCID);

            if (Sender != null)
            {
                propertiesStream.AddProperty(PropertyTags.PR_SENDER_EMAIL_ADDRESS_W, Sender.Email);
                propertiesStream.AddProperty(PropertyTags.PR_SENDER_NAME_W, Sender.DisplayName);
                propertiesStream.AddProperty(PropertyTags.PR_SENDER_ADDRTYPE_W, Sender.AddressType);
            }

            if (recipientCount > 0)
            {
                var displayTo = new List<string>();
                var displayCc = new List<string>();
                var displayBcc = new List<string>();

                foreach (var recipient in Recipients)
                {
                    switch (recipient.Type)
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

                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_TO_W, string.Join(";", displayTo));
                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_CC_W, string.Join(";", displayCc));
                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_BCC_W, string.Join(";", displayBcc));
            }

            propertiesStream.AddProperty(PropertyTags.PR_BODY_W, TextBody);
            propertiesStream.WriteProperties(rootStorage);
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

        public void Test()
        {
            using (var stream = File.OpenRead("d:\\message.msg"))
            using (var cf = new CompoundFile(stream))
            {
                var st = cf.RootStorage.GetStream("__properties_version1.0");
                var p = new TopLevelProperties(st);
                cf.RootStorage.VisitEntries(item =>
                {
                    if (item.IsStream)
                    {
                        var cfStream = item as CFStream;
                        if (cfStream != null && cfStream.Name.StartsWith("__substg1.0_"))
                            p.AddProperty(cfStream);
                    }
                }, false);

                //var pr = p.Find(m => m.IdAsString == "0E1D");
            }
        }
    }
}
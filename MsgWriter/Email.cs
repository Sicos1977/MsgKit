using System.Collections.Generic;
using System.IO;
using System.Text;
using MsgWriter.Streams;
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
        private string _subject;

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
        ///     The recipient(s) of the E-mail or null when not available
        /// </summary>
        public List<Recipient> To { get; private set; }

        /// <summary>
        ///     The blind recipient(s) of the E-mail or null when not available
        /// </summary>
        public List<Recipient> Bcc { get; private set; }

        /// <summary>
        ///     Returns or sets the subject of the E-mail
        /// </summary>
        public string Subject
        {
            get
            {
                if (_subject != null)
                    return _subject;

                _subject = GetString(new List<PropertyTag> {PropertyTags.PR_SUBJECT_W, PropertyTags.PR_SUBJECT_A});
                return _subject;
            }
            set { _subject = value; }
        }

        /// <summary>
        ///     The E-mail <see cref="Recipients" />
        /// </summary>
        public Recipients Recipients
        {
            get { return _recipients ?? (_recipients = new Recipients()); }
        }

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
            var stream = CompoundFile.RootStorage.AddStream(PropertyTags.PR_MESSAGE_CLASS_W.Name);
            stream.SetData(Encoding.Unicode.GetBytes("IPM.Note"));
            Sender = sender;
        }
        #endregion

        #region AddProperties
        /// <summary>
        /// Adds all the properties to the <see cref="Message"/>
        /// </summary>
        private void AddProperties()
        {
            Attachments.AddToStorage(CompoundFile.RootStorage);

            AddString(PropertyTags.PR_SUBJECT_W, _subject);
            //AddProperty(PropertyTags.PR_CREATION_TIME.Name, _subject);

            if (Sender != null)
            {
                AddString(PropertyTags.PR_SENDER_EMAIL_ADDRESS_W, Sender.Email);
                AddString(PropertyTags.PR_SENDER_NAME_W, Sender.DisplayName);
                AddString(PropertyTags.PR_SENDER_ADDRTYPE_W, Sender.AddressType);
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
            AddProperties();
            base.Save(stream);
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        public new void Save(string fileName)
        {
            AddProperties();
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

        /*
            // Because the properties to be set are known in advance, 
            // most of the structures involved can be statically declared 
            // to minimize expensive MAPIAllocateBuffer calls.
            SPropValue spvProps[NUM_PROPS] = {0};
            spvProps[p_PR_MESSAGE_CLASS_W].ulPropTag          = PR_MESSAGE_CLASS_W;
            spvProps[p_PR_ICON_INDEX].ulPropTag                 = PR_ICON_INDEX;
            spvProps[p_PR_SUBJECT_W].ulPropTag                = PR_SUBJECT_W;
            spvProps[p_PR_CONVERSATION_TOPIC_W].ulPropTag     = PR_CONVERSATION_TOPIC_W;
            spvProps[p_PR_BODY_W].ulPropTag                   = PR_BODY_W;
            spvProps[p_PR_IMPORTANCE].ulPropTag               = PR_IMPORTANCE;
            spvProps[p_PR_READ_RECEIPT_REQUESTED].ulPropTag   = PR_READ_RECEIPT_REQUESTED;
            spvProps[p_PR_MESSAGE_FLAGS].ulPropTag             = PR_MESSAGE_FLAGS;
            spvProps[p_PR_MSG_EDITOR_FORMAT].ulPropTag         = PR_MSG_EDITOR_FORMAT;
            spvProps[p_PR_MESSAGE_LOCALE_ID].ulPropTag         = PR_MESSAGE_LOCALE_ID;
            spvProps[p_PR_INETMAIL_OVERRIDE_FORMAT].ulPropTag = PR_INETMAIL_OVERRIDE_FORMAT;
            spvProps[p_PR_DELETE_AFTER_SUBMIT].ulPropTag      = PR_DELETE_AFTER_SUBMIT;
            spvProps[p_PR_INTERNET_CPID].ulPropTag            = PR_INTERNET_CPID;
            spvProps[p_PR_CONVERSATION_INDEX].ulPropTag         = PR_CONVERSATION_INDEX;
            spvProps[p_PR_MESSAGE_CLASS_W].Value.lpszW = L"IPM.Note";
            spvProps[p_PR_ICON_INDEX].Value.l = 0x103; // Unsent Mail
            spvProps[p_PR_SUBJECT_W].Value.lpszW = szSubject;
            spvProps[p_PR_CONVERSATION_TOPIC_W].Value.lpszW = szSubject;
            spvProps[p_PR_BODY_W].Value.lpszW = szBody;
            spvProps[p_PR_IMPORTANCE].Value.l = bHighImportance?IMPORTANCE_HIGH:IMPORTANCE_NORMAL;
            spvProps[p_PR_READ_RECEIPT_REQUESTED].Value.b = bReadReceipt?true:false;
            spvProps[p_PR_MESSAGE_FLAGS].Value.l = MSGFLAG_UNSENT;
            spvProps[p_PR_MSG_EDITOR_FORMAT].Value.l = EDITOR_FORMAT_PLAINTEXT;
            spvProps[p_PR_MESSAGE_LOCALE_ID].Value.l = 1033; // (en-us)
            spvProps[p_PR_INETMAIL_OVERRIDE_FORMAT].Value.l = NULL; // Mail system chooses default encoding scheme
            spvProps[p_PR_DELETE_AFTER_SUBMIT].Value.b = bDeleteAfterSubmit?true:false;
            spvProps[p_PR_INTERNET_CPID].Value.l = cpidASCII;

            hRes = BuildConversationIndex(
            &spvProps[p_PR_CONVERSATION_INDEX].Value.bin.cb,
            &spvProps[p_PR_CONVERSATION_INDEX].Value.bin.lpb);
        */

        public void Test()
        {
            using (var stream = File.OpenRead("d:\\email1.msg"))
            using (var cf = new CompoundFile(stream))
            {
                var st = cf.RootStorage.GetStream("__properties_version1.0");
                var p = new TopLevelPropertiesStream(st);
                cf.RootStorage.VisitEntries(item =>
                {
                    if (item.IsStream)
                    {
                        var cfStream = item as CFStream;
                        if (cfStream != null && cfStream.Name.StartsWith("__substg1.0_"))
                            p.AddProperty(cfStream);
                    }
                }, false);

                var pr = p.Find(m => m.IdAsString == "0E1D");
            }
        }
    }
}
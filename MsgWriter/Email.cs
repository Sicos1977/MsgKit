using System.Collections.Generic;
using System.IO;
using System.Text;
using CompoundFileStorage;
using MsgWriter.Streams;

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
        public Recipient From { get; private set; }

        /// <summary>
        ///     The recipient(s) of the E-mail or null when not available
        /// </summary>
        public List<Recipient> To { get; private set; }

        /// <summary>
        ///     The blind recipient(s) of the E-mail or null when not available
        /// </summary>
        public List<Recipient> Bcc { get; private set; }

        public string Subject
        {
            get
            {
                if (_subject != null)
                    return _subject;

                _subject = GetString(new List<PropertyTag> {PropertyTags.PR_SUBJECT_W, PropertyTags.PR_SUBJECT_A});
                return _subject;
            }
            set
            {
                // Todo set value
            }
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
        public Email()
        {
            var stream = CompoundFile.RootStorage.AddStream(PropertyTags.PR_MESSAGE_CLASS_W.Name);
            stream.SetData(Encoding.Unicode.GetBytes("IPM.Note"));
            Class = MessageClass.Email;
        }
        #endregion

        #region Save
        /// <summary>
        ///     Saves the message to the given <paramref name="stream" />
        /// </summary>
        /// <param name="stream"></param>
        public new void Save(Stream stream)
        {
            Attachments.AddToStorage(CompoundFile.RootStorage);
            base.Save(stream);
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        public new void Save(string fileName)
        {
            Attachments.AddToStorage(CompoundFile.RootStorage);
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
                var p = new TopLevelPropertiesStream(st);
                foreach (var child in cf.RootStorage.Children)
                {
                    if (child.IsStream)
                    {
                        var cfStream = child as CFStream;
                        if (cfStream == null) continue;

                        if (cfStream.Name.StartsWith("__substg1.0_"))
                            p.AddProperty(cfStream);
                    }
                }
                var pr = p.Find(m => m.IdAsString == "0E1D");
            }
        }
    }
}
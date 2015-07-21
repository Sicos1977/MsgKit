using System.Collections.Generic;
using System.IO;
using CompoundFileStorage;

namespace MsgWriter
{
    /// <summary>
    /// A class used to make a new Outlook E-mail MSG files
    /// </summary>
    public class Email : Message
    {
        #region Fields
        /// <summary>
        /// The E-mail <see cref="Attachments"/>
        /// </summary>
        private Attachments _attachments;

        /// <summary>
        /// The E-mail <see cref="Recipients"/>
        /// </summary>
        private Recipients _recipients; 
        #endregion

        #region Properties
        /// <summary>
        /// Returns the sender of the E-mail from the <see cref="Recipients"/>
        /// </summary>
        public Recipient From { get; private set; }

        /// <summary>
        /// The recipient(s) of the E-mail or null when not available
        /// </summary>
        public List<Recipient> To { get; private set; }

        /// <summary>
        /// The blind recipient(s) of the E-mail or null when not available
        /// </summary>
        public List<Recipient> Bcc { get; private set; }

        /// <summary>
        /// The E-mail <see cref="Recipients"/>
        /// </summary>
        public Recipients Recipients
        {
            get { return _recipients ?? (_recipients = new Recipients()); }
        }
        
        /// <summary>
        /// The E-mail <see cref="Attachments"/>
        /// </summary>
        public Attachments Attachments
        {
            get { return _attachments ?? (_attachments = new Attachments()); }
        }
        #endregion

        #region Save
        /// <summary>
        /// Saves the message to the given <paramref name="stream"/>
        /// </summary>
        /// <param name="stream"></param>
        public new void Save(Stream stream)
        {
            Attachments.AddToStorage(CompoundFile.RootStorage);
            base.Save(stream);
        }

        /// <summary>
        /// Saves the message to the given <paramref name="fileName"/>
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
        /// Disposes all the attachment streams
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
            using (var stream = File.OpenRead("d:\\test.msg"))
            using (var cf = new CompoundFile(stream))
            {
                //var st = cf.RootStorage.GetStream("__properties_version1.0");
                //var p = new Streams.TopLevelPropertiesStream(st.GetData());
                //foreach (var child in cf.RootStorage.Children)
                //{
                //    if (child.IsStream)
                //    {
                //        var cfStream = child as CFStream;
                //        if (cfStream == null) continue;

                //        if (cfStream.Name.StartsWith("__substg1.0_"))
                //            p.AddProperty(cfStream);
                //    }
                //}
                //var pr = p.Find(m => m.IdAsString == "0E1D");
            }
        }
    }
}

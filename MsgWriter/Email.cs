using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CompoundFileStorage;
using MsgWriter.Exceptions;

namespace MsgWriter
{
    /// <summary>
    /// A class used to make a new Outlook E-mail MSG files
    /// </summary>
    public class Email : IDisposable
    {
        #region Fields
        /// <summary>
        /// Contains all the recipients
        /// </summary>
        private List<Recipient> _recipient = new List<Recipient>(); 

        /// <summary>
        /// Contains all the attachments
        /// </summary>
        private Attachments _attachments; 
        #endregion

        #region Properties
        public Attachments Attachments
        {
            get { return _attachments ?? (_attachments = new Attachments()); }
        }
        #endregion

        /// <summary>
        /// Saves the message to the given <paramref name="stream"/>
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {

        }

        /// <summary>
        /// Saves the message to the given <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            var message = new Message();
            message.AddAttachments(_attachments);
            message.Save(fileName);
        }

        public void Dispose()
        {
            foreach(var attachment in _attachments)
                attachment.Stream.Dispose();
        }

        public void Test()
        {
            using (var stream = File.OpenRead("d:\\test.msg"))
            using (var cf = new CompoundFile(stream))
            {
                var st = cf.RootStorage.GetStream("__properties_version1.0");
                var p = new Streams.TopLevelPropertiesStream(st.GetData());
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

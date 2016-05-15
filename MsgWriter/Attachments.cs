using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MsgWriter.Exceptions;
using MsgWriter.Helpers;
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
    #region Enum AttachmentType
    /// <summary>
    /// The type of the attachment
    /// </summary>
    internal enum AttachmentType : uint
    {
        /// <summary>
        ///     There is no attachment
        /// </summary>
        NoAttachment = 0x0000,
        
        /// <summary>
        ///     The PR_ATTACH_DATA_BIN property contains the attachment data
        /// </summary>
        AttachByValue = 0x0001,

        /// <summary>
        ///     The PR_ATTACH_PATHNAME or PR_ATTACH_LONG_PATHNAME property contains a fully qualified path 
        ///     identifying the attachment to recipients with access to a common file server
        /// </summary>
        AttachByReference = 0x0002,

        /// <summary>
        ///     The PR_ATTACH_PATHNAME or PR_ATTACH_LONG_PATHNAME property contains a fully qualified path identifying the attachment
        /// </summary>
        AttachByRefResolve = 0x0003,

        /// <summary>
        ///     The PR_ATTACH_PATHNAME or PR_ATTACH_LONG_PATHNAME property contains a fully qualified path identifying the attachment
        /// </summary>
        AttachByRefOnly = 0x0004,

        /// <summary>
        ///     The attachment is a msg file
        /// </summary>
        AttachEmbeddedMsg = 0x0005,

        /// <summary>
        ///     The attachment in an OLE object
        /// </summary>
        AttachOle = 0x0006
    }
    #endregion

    /// <summary>
    /// Contains a list of <see cref="Attachment"/> objects that are added to a message
    /// </summary>
    public sealed class Attachments : List<Attachment>
    {
        #region AddAttachment
        /// <summary>
        /// Checks if the <paramref name="fileName"/> already exists in this object
        /// </summary>
        /// <param name="fileName"></param>
        private void CheckAttachmentFileName(string fileName)
        {
            var file = Path.GetFileName(fileName);

            if (this.Any(
                attachment => attachment.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase)))
                throw new MWAttachmentExists("The attachment with the name '" + file + "' already exists");
        }

        /// <summary>
        /// Add's an <see cref="Attachment"/>
        /// </summary>
        /// <param name="fileName">The file to add with full path</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline"/> is set to true</param>
        /// <exception cref="FileNotFoundException">Raised when the <paramref name="fileName"/> could not be found</exception>
        /// <exception cref="MWAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="isInline"/> is set to true and
        /// <paramref name="contentId"/> is null, white space or empty</exception>
        public void AddAttachment(string fileName, bool isInline = false, string contentId = "")
        {
            CheckAttachmentFileName(fileName);
            var file = new FileInfo(fileName);
            Add(new Attachment(file.OpenRead(),
                               fileName,
                               file.CreationTime,
                               file.LastAccessTime,
                               isInline,
                               contentId));
        }

        /// <summary>
        /// Add's an attachment
        /// </summary>
        /// <param name="stream">The stream to the attachment</param>
        /// <param name="fileName">The name for the attachment</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline"/> is set to true</param>
        /// <exception cref="ArgumentNullException">Raised when the stream is null</exception>
        /// <exception cref="MWAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="isInline"/> is set to true and
        /// <paramref name="contentId"/> is null, white space or empty</exception>
        public void AddAttachment(Stream stream, string fileName, bool isInline = false, string contentId = "")
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            CheckAttachmentFileName(fileName);
            var dateTime = DateTime.Now;
            Add(new Attachment(stream,
                               fileName,
                               dateTime,
                               dateTime,
                               isInline,
                               contentId));
        }
        #endregion

        #region AddToStorage
        /// <summary>
        /// This method add's the <see cref="Attachment"/> objects to the given <paramref name="rootStorage"/>
        /// and sets all the needed properties
        /// </summary>
        /// <param name="rootStorage"></param>
        internal void AddToStorage(CFStorage rootStorage)
        {
            for (var i = 0; i < Count; i++)
            {
                var attachment = this[i];
                var storage = rootStorage.AddStorage(PropertyTags.AttachmentStoragePrefix + i.ToString("X8").ToUpper());

                var stream = storage.AddStream(PropertyTags.PR_RECORD_KEY.Name);
                stream.SetData(BitConverter.GetBytes(i));

                stream = storage.AddStream(PropertyTags.PR_DISPLAY_NAME_W.Name);
                stream.SetData(Encoding.Unicode.GetBytes(attachment.FileName));
                
                if (!string.IsNullOrEmpty(attachment.FileName))
                {
                    stream = storage.AddStream(PropertyTags.PR_ATTACH_EXTENSION_W.Name);
                    stream.SetData(Encoding.Unicode.GetBytes(Path.GetExtension(attachment.FileName)));
                }
                    
                stream = storage.AddStream(PropertyTags.PR_ATTACH_DATA_BIN.Name);
                stream.SetData(attachment.Stream.ToByteArray());
            }
        }
        #endregion
    }

    /// <summary>
    /// This class represents a message attachment
    /// </summary>
    public sealed class Attachment
    {
        #region Properties
        /// <summary>
        /// The stream to the attachment
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// The filename of the attachment
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// The content id for an inline attachment
        /// </summary>
        public string ContentId { get; private set; }

        /// <summary>
        /// True when the attachment is inline
        /// </summary>
        public bool IsInline { get; private set; }

        /// <summary>
        /// Tthe date and time when the attachment was created
        /// </summary>
        public DateTime CreationTime { get; private set; }

        /// <summary>
        /// The date and time when the attachment was last modified
        /// </summary>
        public DateTime LastModificationTime { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new attachment object and sets all its properties
        /// </summary>
        /// <param name="stream">The stream to the attachment</param>
        /// <param name="fileName">The attachment filename</param>
        /// <param name="creationTime">The date and time when the attachment was created</param>
        /// <param name="lastModificationTime">The date and time when the attachment was last modified</param>
        /// <param name="isInline">True when the attachment is inline</param>
        /// <param name="contentId">The id for the attachment when <paramref name="isInline"/> is set to true</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="isInline"/> is set to true and
        /// <paramref name="contentId"/> is null, white space or empty</exception>
        internal Attachment(Stream stream, 
                            string fileName,
                            DateTime creationTime,
                            DateTime lastModificationTime,
                            bool isInline = false, 
                            string contentId = "")
        {
            Stream = stream;
            FileName = Path.GetFileName(fileName);
            CreationTime = creationTime;
            LastModificationTime = lastModificationTime;
            IsInline = isInline;
            ContentId = contentId;

            if (isInline && string.IsNullOrWhiteSpace(contentId))
                throw new ArgumentNullException("contentId", "The content id cannot be empty when isInline is set to true");
        }
        #endregion
    }
}


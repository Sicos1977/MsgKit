using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MsgWriter.Enums;
using MsgWriter.Exceptions;
using MsgWriter.Helpers;
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
    ///     Contains a list of <see cref="Attachment" /> objects that are added to a <see cref="Message" />
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc842285.aspx
    /// </remarks>
    public class Attachments : List<Attachment>
    {
        #region CheckAttachmentFileName
        /// <summary>
        ///     Checks if the <paramref name="fileName" /> already exists in this object
        /// </summary>
        /// <param name="fileName"></param>
        private void CheckAttachmentFileName(string fileName)
        {
            var file = Path.GetFileName(fileName);

            if (this.Any(
                attachment => attachment.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase)))
                throw new MWAttachmentExists("The attachment with the name '" + file + "' already exists");
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes the <see cref="Attachment" /> objects to the given <paramref name="rootStorage" />
        ///     and it will set all the needed properties
        /// </summary>
        /// <param name="rootStorage">The root <see cref="CFStorage" /></param>
        internal void WriteToStorage(CFStorage rootStorage)
        {
            for (var index = 0; index < Count; index++)
            {
                var attachment = this[index];
                var storage = rootStorage.AddStorage(PropertyTags.AttachmentStoragePrefix + index.ToString("X8").ToUpper());
                attachment.WriteProperties(storage, index);
            }
        }
        #endregion

        #region AddAttachment
        /// <summary>
        ///     Add's an <see cref="Attachment" /> by <see cref="AttachmentType.ATTACH_BY_VALUE" /> (default)
        /// </summary>
        /// <param name="fileName">The file to add with it's full path</param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="FileNotFoundException">Raised when the <paramref name="fileName" /> could not be found</exception>
        /// <exception cref="MWAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        public void AddAttachment(string fileName, 
                                  long renderingPosition = -1,
                                  bool isInline = false, 
                                  string contentId = "")
        {
            CheckAttachmentFileName(fileName);
            var file = new FileInfo(fileName);

            Add(new Attachment(file,
                AttachmentType.ATTACH_BY_VALUE,
                renderingPosition,
                isInline,
                contentId));
        }

        /// <summary>
        ///     Add's an <see cref="Attachment" /> stream by <see cref="AttachmentType.ATTACH_BY_VALUE" /> (default)
        /// </summary>
        /// <param name="stream">The stream to the attachment</param>
        /// <param name="fileName">The name for the attachment</param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="ArgumentNullException">Raised when the stream is null</exception>
        /// <exception cref="MWAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        public void AddAttachment(System.IO.Stream stream, 
                                  string fileName, 
                                  long renderingPosition = -1,
                                  bool isInline = false, 
                                  string contentId = "")
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            CheckAttachmentFileName(fileName);
            var dateTime = DateTime.Now;

            Add(new Attachment(stream,
                fileName,
                dateTime,
                dateTime,
                AttachmentType.ATTACH_BY_VALUE,
                renderingPosition,
                isInline,
                contentId));
        }
        #endregion

        #region AddAttachmentLink
        /// <summary>
        ///     Add's an <see cref="Attachment" /> by <see cref="AttachmentType.ATTACH_BY_REF_ONLY" /> as a link
        /// </summary>
        /// <param name="fileName">The file to link with it's fully qualified path</param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="FileNotFoundException">Raised when the <paramref name="fileName" /> could not be found</exception>
        /// <exception cref="MWAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        /// <remarks>
        ///     Universal naming convention (UNC) names are recommended for fully-qualified paths, which should be used with 
        ///     <see cref="AttachmentType.ATTACH_BY_REF_ONLY" />. 
        /// </remarks>
        public void AddAttachmentLink(string fileName, 
                                      long renderingPosition = -1,
                                      bool isInline = false, 
                                      string contentId = "")
        {
            CheckAttachmentFileName(fileName);
            var file = new FileInfo(fileName);

            Add(new Attachment(file,
                AttachmentType.ATTACH_BY_REF_ONLY,
                renderingPosition,
                isInline,
                contentId));
        }
        #endregion
    }

    /// <summary>
    ///     This class represents an attachment
    /// </summary>
    public class Attachment
    {
        #region Fields
        private readonly FileInfo _file;
        #endregion

        #region Properties
        /// <summary>
        ///     The stream to the attachment
        /// </summary>
        public System.IO.Stream Stream { get; }

        /// <summary>
        ///     The filename of the attachment
        /// </summary>
        public string FileName { get; }

        /// <summary>
        ///     The <see cref="AttachmentType"/>
        /// </summary>
        public AttachmentType Type { get; }

        /// <summary>
        ///     Indicates how an attachment should be displayed in a rich text message. It can be set to an 
        ///     offset in characters, with the first character of the message content as stored in the <see cref="PropertyTags.PR_BODY_W" /> 
        ///     (PidTagBody) property being offset 0, or to -1 (0xFFFFFFFF), indicating that the attachment should 
        ///     not be rendered within the message text at all.
        /// </summary>
        public long RenderingPosition { get; }

        /// <summary>
        ///     True when the attachment is inline
        /// </summary>
        public bool IsInline { get; private set; }

        /// <summary>
        ///     The content id for an inline attachment
        /// </summary>
        public string ContentId { get; private set; }

        /// <summary>
        ///     Returns <c>true</c> when the attachment is a contact photo
        /// </summary>
        /// <remarks>
        ///     Only valid when the message is a contact card, otherwise always <c>false</c>
        /// </remarks>
        public bool IsContactPhoto { get; private set; }

        /// <summary>
        ///     Tthe date and time when the attachment was created
        /// </summary>
        public DateTime CreationTime { get; private set; }

        /// <summary>
        ///     The date and time when the attachment was last modified
        /// </summary>
        public DateTime LastModificationTime { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates a new attachment object and sets all its properties
        /// </summary>
        /// <param name="stream">The stream to the attachment</param>
        /// <param name="fileName">The attachment filename with it's full path</param>
        /// <param name="creationTime">The date and time when the attachment was created</param>
        /// <param name="lastModificationTime">The date and time when the attachment was last modified</param>
        /// <param name="type">The <see cref="AttachmentType"/></param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">True when the attachment is inline</param>
        /// <param name="contentId">The id for the attachment when <paramref name="isInline" /> is set to true</param>
        /// <param name="isContactPhoto">Set to <c>true</c> when the attachment is a contact photo</param>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        internal Attachment(System.IO.Stream stream,
            string fileName,
            DateTime creationTime,
            DateTime lastModificationTime,
            AttachmentType type = AttachmentType.ATTACH_BY_VALUE,
            long renderingPosition = -1,
            bool isInline = false,
            string contentId = "",
            bool isContactPhoto = false)
        {
            Stream = stream;
            FileName = Path.GetFileName(fileName);
            CreationTime = creationTime;
            LastModificationTime = lastModificationTime;
            Type = type;
            RenderingPosition = renderingPosition;
            IsInline = isInline;
            ContentId = contentId;
            IsContactPhoto = isContactPhoto;

            if (isInline && string.IsNullOrWhiteSpace(contentId))
                throw new ArgumentNullException("contentId", "The content id cannot be empty when isInline is set to true");
        }

        /// <summary>
        ///     Creates a new attachment object and sets all its properties
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="type">The <see cref="AttachmentType"/></param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">True when the attachment is inline</param>
        /// <param name="contentId">The id for the attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        internal Attachment(FileInfo file,
            AttachmentType type = AttachmentType.ATTACH_BY_VALUE,
            long renderingPosition = -1,
            bool isInline = false,
            string contentId = "")
        {
            if (!file.Exists)
                throw new FileNotFoundException("The file '" + file.FullName + "' does not exist");

            _file = file;
            Stream = file.OpenRead();
            FileName = file.Name;
            CreationTime = file.CreationTime;
            LastModificationTime = file.LastWriteTime;
            Type = type;
            RenderingPosition = renderingPosition;
            IsInline = isInline;
            ContentId = contentId;

            if (isInline && string.IsNullOrWhiteSpace(contentId))
                throw new ArgumentNullException("contentId", "The content id cannot be empty when isInline is set to true");
        }
        #endregion

        #region GetShortFileName
        /// <summary>
        ///     This method will convert a long filename to a short dos 8.3 one
        /// </summary>
        /// <param name="fileName">The long filename</param>
        /// <returns></returns>
        private static string GetShortFileName(string fileName)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            var extension = Path.GetExtension(fileName);

            if (name != null) name = name.Substring(0, 6).ToUpperInvariant() + "~1";
            if (extension != null) name += "." + extension.Substring(1, 3).ToUpperInvariant();
            return name;
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all the string and binary <see cref="Structures.Property">properties</see> as a <see cref="CFStream" /> to the
        ///     given <paramref name="storage" />
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage" /></param>
        /// <param name="index">The <see cref="Attachment"/> index</param>
        internal void WriteProperties(CFStorage storage, int index)
        {
            var propertiesStream = new AttachmentProperties();

            // https://msdn.microsoft.com/en-us/library/office/cc842285.aspx
            propertiesStream.AddProperty(PropertyTags.PR_ATTACH_NUM, index, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RECORD_KEY, Mapi.GenerateRecordKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RENDERING_POSITION, RenderingPosition, PropertyFlags.PROPATTR_READABLE);

            if (!string.IsNullOrEmpty(FileName))
            {
                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, FileName);
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FILENAME_W, GetShortFileName(FileName));
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_FILENAME_W, FileName);
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_EXTENSION_W, Path.GetExtension(FileName));
            }

            propertiesStream.AddProperty(PropertyTags.PR_ATTACH_METHOD, Type);

            switch (Type)
            {
                case AttachmentType.ATTACH_BY_VALUE:
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, Stream.ToByteArray());
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, Stream.Length);
                    break;

                case AttachmentType.ATTACH_BY_REF_ONLY:
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, new byte[0]);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, _file.Length);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_PATHNAME_W, _file.FullName);
                    break;

                case AttachmentType.ATTACH_EMBEDDED_MSG:
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, new byte[0]);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_OBJ, Stream.ToByteArray());
                    break;

                case AttachmentType.ATTACH_BY_REFERENCE:
                case AttachmentType.ATTACH_BY_REF_RESOLVE:
                case AttachmentType.NO_ATTACHMENT:
                case AttachmentType.ATTACH_OLE:
                    throw new NotSupportedException("AttachByReference, AttachByRefResolve, NoAttachment and AttachOle are not supported");
            }
            
            var utcNow = DateTime.UtcNow;
            propertiesStream.AddProperty(PropertyTags.PR_CREATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, StoreSupportMaskConst.storeSupportMask, PropertyFlags.PROPATTR_READABLE);

            propertiesStream.WriteProperties(storage);
        }
        #endregion
    }
}
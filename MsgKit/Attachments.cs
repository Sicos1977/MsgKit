//
// Attachments.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2021 Magic-Sessions. (www.magic-sessions.com)
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
// FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MsgKit.Enums;
using MsgKit.Exceptions;
using MsgKit.Helpers;
using MsgKit.Streams;
using MsgKit.Structures;
using OpenMcdf;
using Stream = System.IO.Stream;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace MsgKit
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
        /// <param name="contentId"></param>
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void CheckAttachmentFileName(string fileName, string contentId)
        {
            var file = Path.GetFileName(fileName);

            if (this.Any(
                attachment => attachment.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(attachment.ContentId, contentId, StringComparison.InvariantCultureIgnoreCase)))
                throw new MKAttachmentExists($"The attachment with the name '{file}' already exists");
        }
        #endregion

        #region WriteToStorage
        /// <summary>
        ///     Writes the <see cref="Attachment" /> objects to the given <paramref name="rootStorage" />
        ///     and it will set all the needed properties
        /// </summary>
        /// <param name="rootStorage">The root <see cref="CFStorage" /></param>
        /// <returns>
        ///     Total size of the written <see cref="Attachment"/> objects and it's <see cref="Properties"/>
        /// </returns>
        internal long WriteToStorage(CFStorage rootStorage)
        {
            long size = 0;

            for (var index = 0; index < Count; index++)
            {
                var attachment = this[index];
                var storage = rootStorage.AddStorage(PropertyTags.AttachmentStoragePrefix + index.ToString("X8").ToUpper());
                size += attachment.WriteProperties(storage, index);
            }

            return size;
        }
        #endregion

        #region AddAttachment
        /// <summary>
        ///     Adds an <see cref="Attachment" /> by <see cref="AttachmentType.ATTACH_BY_VALUE" /> (default)
        /// </summary>
        /// <param name="fileName">The file to add with it's full path</param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="FileNotFoundException">Raised when the <paramref name="fileName" /> could not be found</exception>
        /// <exception cref="MKAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        public void Add(string fileName, 
                        long renderingPosition = -1,
                        bool isInline = false, 
                        string contentId = "")
        {
            if (Count >= 2048)
                throw new MKAttachment("To many attachments, an msg file can have a maximum of 2048 attachment");

            CheckAttachmentFileName(fileName, contentId);
            var file = new FileInfo(fileName);
            var stream = file.OpenRead();

            Add(new Attachment(stream,
                file.Name,
                file.CreationTime,
                file.LastWriteTime,
                AttachmentType.ATTACH_BY_VALUE,
                renderingPosition,
                isInline,
                contentId));
        }

        /// <summary>
        ///     Adds an <see cref="Attachment" /> stream by <see cref="AttachmentType.ATTACH_BY_VALUE" /> (default)
        /// </summary>
        /// <param name="stream">The stream to the attachment</param>
        /// <param name="fileName">The name for the attachment</param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="ArgumentNullException">Raised when the stream is null</exception>
        /// <exception cref="MKAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        public void Add(Stream stream, 
                        string fileName, 
                        long renderingPosition = -1,
                        bool isInline = false, 
                        string contentId = "")
        {
            if (Count >= 2048)
                throw new MKAttachment("To many attachments, an msg file can have a maximum of 2048 attachment");

            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            CheckAttachmentFileName(fileName, contentId);
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

        /// <summary>
        ///     Adds an <see cref="Attachment" /> stream by <see cref="AttachmentType.ATTACH_BY_VALUE" /> (default)
        /// </summary>
        /// <param name="stream">The stream to the attachment</param>
        /// <param name="fileName">The name for the attachment</param>
        /// <exception cref="ArgumentNullException">Raised when the stream is null</exception>
        /// <exception cref="MKAttachmentExists">Raised when an attachment with the same name already exists</exception>
        internal void AddContactPhoto(Stream stream, string fileName)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var dateTime = DateTime.Now;

            Add(new Attachment(stream,
                fileName,
                dateTime,
                dateTime,
                AttachmentType.ATTACH_BY_VALUE,
                -1,
                false,
                string.Empty,
                true));
        }

        #endregion

        #region AddLink
        /// <summary>
        ///     Adds an <see cref="Attachment" /> by <see cref="AttachmentType.ATTACH_BY_REF_ONLY" /> as a link
        /// </summary>
        /// <param name="file">The <see cref="FileInfo"/></param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">Set to true to add the attachment inline</param>
        /// <param name="contentId">The id for the inline attachment when <paramref name="isInline" /> is set to true</param>
        /// <exception cref="FileNotFoundException">Raised when the <paramref name="file" /> could not be found</exception>
        /// <exception cref="MKAttachmentExists">Raised when an attachment with the same name already exists</exception>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        /// <remarks>
        ///     Universal naming convention (UNC) names are recommended for fully-qualified paths, which should be used with 
        ///     <see cref="AttachmentType.ATTACH_BY_REF_ONLY" />. 
        /// </remarks>
        public void AddLink(FileInfo file, 
                            long renderingPosition = -1,
                            bool isInline = false, 
                            string contentId = "")
        {
            CheckAttachmentFileName(file.Name, contentId);

            Add(new Attachment(
                file,
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
        public Stream Stream { get; }

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
        public bool IsInline { get; }

        /// <summary>
        ///     The content id for an inline attachment
        /// </summary>
        public string ContentId { get; }

        /// <summary>
        ///     Returns <c>true</c> when the attachment is a contact photo
        /// </summary>
        /// <remarks>
        ///     Only valid when the message is a contact card, otherwise always <c>false</c>
        /// </remarks>
        public bool IsContactPhoto { get; }

        /// <summary>
        ///     The date and time when the attachment was created
        /// </summary>
        public DateTime CreationTime { get; }

        /// <summary>
        ///     The date and time when the attachment was last modified
        /// </summary>
        public DateTime LastModificationTime { get; }
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
        internal Attachment(Stream stream,
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
            Type =  type;
            RenderingPosition = renderingPosition;
            IsInline = isInline;
            ContentId = contentId;
            IsContactPhoto = isContactPhoto;

            if (isInline && string.IsNullOrWhiteSpace(contentId))
                throw new ArgumentNullException(nameof(contentId), "The content id cannot be empty when isInline is set to true");
        }

        /// <summary>
        ///     Creates a new attachment object and sets all its properties
        /// </summary>
        /// <param name="file">The <see cref="FileInfo"/></param>
        /// <param name="type">The <see cref="AttachmentType"/></param>
        /// <param name="renderingPosition">Indicates how an attachment should be displayed in a rich text message</param>
        /// <param name="isInline">True when the attachment is inline</param>
        /// <param name="contentId">The id for the attachment when <paramref name="isInline" /> is set to true</param>
        /// <param name="isContactPhoto">Set to <c>true</c> when the attachment is a contact photo</param>
        /// <exception cref="ArgumentNullException">
        ///     Raised when <paramref name="isInline" /> is set to true and
        ///     <paramref name="contentId" /> is null, white space or empty
        /// </exception>
        internal Attachment(FileInfo file,
            AttachmentType type = AttachmentType.ATTACH_BY_VALUE,
            long renderingPosition = -1,
            bool isInline = false,
            string contentId = "",
            bool isContactPhoto = false)
        {
            _file = file;
            Stream = file.OpenRead();
            FileName = file.Name;
            CreationTime = file.CreationTime;
            LastModificationTime = file.LastWriteTime;
            Type = type;
            RenderingPosition = renderingPosition;
            IsInline = isInline;
            ContentId = contentId;
            IsContactPhoto = isContactPhoto;

            if (isInline && string.IsNullOrWhiteSpace(contentId))
                throw new ArgumentNullException(nameof(contentId), "The content id cannot be empty when isInline is set to true");
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

            if (name != null)
                name = (name.Length > 8 ? name.Substring(0, 6) + "~1" : name).ToUpperInvariant();

            if (extension != null)
                name += "." +
                        (extension.Length > 3 ? extension.Substring(1, 3) : extension.TrimStart('.')).ToUpperInvariant();

            return name;
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all the string and binary <see cref="Property">properties</see> as a <see cref="CFStream" /> to the
        ///     given <paramref name="storage" />
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage" /></param>
        /// <param name="index">The <see cref="Attachment"/> index</param>
        /// <returns>
        ///     Total size of the written <see cref="Attachment"/> object and it's <see cref="Properties"/>
        /// </returns>
        internal long WriteProperties(CFStorage storage, int index)
        {
            var propertiesStream = new AttachmentProperties();

            propertiesStream.AddProperty(PropertyTags.PR_ATTACH_NUM, index, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RECORD_KEY, Mapi.GenerateRecordKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RENDERING_POSITION, RenderingPosition, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_OBJECT_TYPE, MapiObjectType.MAPI_ATTACH);
            
            if (IsContactPhoto)
                propertiesStream.AddProperty(PropertyTags.PR_ATTACHMENT_CONTACTPHOTO, true, PropertyFlags.PROPATTR_READABLE);
                
            if (!string.IsNullOrEmpty(FileName))
            {
                propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, FileName);
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FILENAME_W, GetShortFileName(FileName));
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_FILENAME_W, FileName);
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_EXTENSION_W, Path.GetExtension(FileName));

                if (!string.IsNullOrEmpty(ContentId))
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_CONTENT_ID_W, ContentId);

                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_MIME_TAG_W, MimeTypes.GetMimeType(FileName));
            }

            propertiesStream.AddProperty(PropertyTags.PR_ATTACH_METHOD, Type);

            switch (Type)
            {
                case AttachmentType.ATTACH_BY_VALUE:
                case AttachmentType.ATTACH_EMBEDDED_MSG:
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, Stream.ToByteArray());
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, Stream.Length);
                    break;

                case AttachmentType.ATTACH_BY_REF_ONLY:
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, new byte[0]);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, _file.Length);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_PATHNAME_W, _file.FullName);
                    break;

                //case AttachmentType.ATTACH_EMBEDDED_MSG:
                //    var msgStorage = storage.AddStorage(PropertyTags.PR_ATTACH_DATA_BIN.Name);
                //    var cf = new CompoundFile(Stream);
                //    Storage.Copy(cf.RootStorage, msgStorage);
                //    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, Stream.Length);
                //    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_ENCODING, 0);
                //    break;

                case AttachmentType.ATTACH_BY_REFERENCE:
                case AttachmentType.ATTACH_BY_REF_RESOLVE:
                case AttachmentType.NO_ATTACHMENT:
                case AttachmentType.ATTACH_OLE:
                    throw new NotSupportedException("AttachByReference, AttachByRefResolve, NoAttachment and AttachOle are not supported");
            }

            if (IsInline)
            {
                propertiesStream.AddProperty(PropertyTags.PR_ATTACHMENT_HIDDEN, true);
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FLAGS, AttachmentFlags.ATT_MHTML_REF);
            }

            var utcNow = DateTime.UtcNow;
            propertiesStream.AddProperty(PropertyTags.PR_CREATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, utcNow);
            propertiesStream.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);

            return propertiesStream.WriteProperties(storage);
        }
        #endregion
    }
}
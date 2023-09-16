﻿//
// EmbeddedMessageProperties.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2023 Magic-Sessions. (www.magic-sessions.com)
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
using System.IO;
using MsgKit.Structures;
using OpenMcdf;

namespace MsgKit.Streams
{
    /// <summary>
    ///     The properties stream contained inside an Embedded Message storage object
    /// </summary>
    internal sealed class EmbeddedMessageProperties : Properties
    {
        #region Properties
        /// <summary>
        ///     The ID to use for naming the next Recipient object storage if one is created inside the .msg file
        /// </summary>
        internal int NextRecipientId { get; }

        /// <summary>
        ///     The ID to use for naming the next Attachment object storage if one is created inside the .msg file
        /// </summary>
        internal int NextAttachmentId { get; }

        /// <summary>
        ///     The number of Recipient objects
        /// </summary>
        internal int RecipientCount { get; }

        /// <summary>
        ///     The number of Attachment objects
        /// </summary>
        internal int AttachmentCount { get; }
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates this object and sets all its properties
        /// </summary>
        /// <param name="nextRecipientId">
        ///     The ID to use for naming the next Recipient object storage if one is created inside the
        ///     .msg file. If no Recipient object storages are contained in the .msg file, this field MUST be set to 0
        /// </param>
        /// <param name="nextAttachmentId">
        ///     The ID to use for naming the next Attachment object storage if one is created inside the
        ///     .msg file. If no Attachment object storages are contained in the .msg file, this field MUST be set to 0
        /// </param>
        /// <param name="recipientCount">The number of Recipient objects</param>
        /// <param name="attachmentCount">The number of Attachment objects</param>
        internal EmbeddedMessageProperties(int nextRecipientId,
            int nextAttachmentId,
            int recipientCount,
            int attachmentCount)
        {
            NextRecipientId = nextRecipientId;
            NextAttachmentId = nextAttachmentId;
            RecipientCount = recipientCount;
            AttachmentCount = attachmentCount;
        }

        /// <summary>
        ///     Create this object and reads all the <see cref="Property">properties</see> from 
        ///     the given <see cref="CFStream"/>
        /// </summary>
        /// <param name="stream">The <see cref="CFStream"/></param>
        internal EmbeddedMessageProperties(CFStream stream)
        {
            using (var memoryStream = new MemoryStream(stream.GetData()))
            using (var binaryReader = new BinaryReader(memoryStream))
            {
                binaryReader.ReadBytes(8);
                NextRecipientId = Convert.ToInt32(binaryReader.ReadUInt32());
                NextAttachmentId = Convert.ToInt32(binaryReader.ReadUInt32());
                RecipientCount = Convert.ToInt32(binaryReader.ReadUInt32());
                AttachmentCount = Convert.ToInt32(binaryReader.ReadUInt32());
                ReadProperties(binaryReader);
            }
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all <see cref="Property">properties</see> either as a <see cref="CFStream"/> or as a collection in
        ///     a <see cref="PropertyTags.PropertiesStreamName"/> stream to the given <paramref name="storage"/>, this depends 
        ///     on the <see cref="Enums.PropertyType"/>
        /// </summary>
        /// <remarks>
        ///     See the <see cref="Properties"/> class it's <see cref="Properties.WriteProperties"/> method for the logic
        ///     that is used to determine this
        /// </remarks>
        /// <param name="storage">The <see cref="CFStorage"/></param>
        /// <returns>
        ///     Total size of the written <see cref="Properties"/>
        /// </returns>
        internal long WriteProperties(CFStorage storage)
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                // Reserved(8 bytes): This field MUST be set to zero when writing a .msg file and MUST be 
                // ignored when reading a.msg file.
                binaryWriter.Write(new byte[8]);
                // Next Recipient ID(4 bytes): The ID to use for naming the next Recipient object storage 
                // if one is created inside the .msg file. The naming convention to be used is specified in 
                // section 2.2.1.
                binaryWriter.Write(Convert.ToUInt32(NextRecipientId));
                // Next Attachment ID (4 bytes): The ID to use for naming the next Attachment object storage 
                // if one is created inside the .msg file. The naming convention to be used is specified in section 2.2.2.
                binaryWriter.Write(Convert.ToUInt32(NextAttachmentId));
                // Recipient Count(4 bytes): The number of Recipient objects.
                binaryWriter.Write(Convert.ToUInt32(RecipientCount));
                // Attachment Count (4 bytes): The number of Attachment objects.
                binaryWriter.Write(Convert.ToUInt32(AttachmentCount));
                return WriteProperties(storage, binaryWriter);
            }
        }
        #endregion
    }
}
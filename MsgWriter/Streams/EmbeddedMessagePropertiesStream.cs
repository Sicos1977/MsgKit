using System;
using System.IO;

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

namespace MsgWriter.Streams
{
    /// <summary>
    ///     The properties stream contained inside an Embedded Message storage object
    /// </summary>
    internal sealed class EmbeddedMessagePropertiesStream : Properties
    {
        #region Properties
        /// <summary>
        ///     The ID to use for naming the next Recipient object storage if one is created inside the .msg file
        /// </summary>
        internal int NextRecipientId { get; private set; }

        /// <summary>
        ///     The ID to use for naming the next Attachment object storage if one is created inside the .msg file
        /// </summary>
        internal int NextAttachmentId { get; private set; }

        /// <summary>
        ///     The number of Recipient objects
        /// </summary>
        internal int RecipientCount { get; private set; }

        /// <summary>
        ///     The number of Attachment objects
        /// </summary>
        internal int AttachmentCount { get; private set; }
        #endregion

        #region Constructor
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
        internal EmbeddedMessagePropertiesStream(int nextRecipientId,
            int nextAttachmentId,
            int recipientCount,
            int attachmentCount)
        {
            NextRecipientId = nextRecipientId;
            NextAttachmentId = nextAttachmentId;
            RecipientCount = recipientCount;
            AttachmentCount = attachmentCount;
        }
        #endregion

        #region FromByteArray
        /// <summary>
        ///     Reads the Embedded message property stream from a byte array
        /// </summary>
        /// <param name="byteArray"></param>
        internal void FromByteArray(byte[] byteArray)
        {
            using (var memoryStream = new MemoryStream(byteArray))
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

        #region ToByteArray
        /// <summary>
        ///     Returns the Embedded message property stream as a byte array
        /// </summary>
        /// <returns></returns>
        internal byte[] ToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                binaryWriter.Write(new byte[8]);
                binaryWriter.Write((uint) NextRecipientId);
                binaryWriter.Write((uint) NextAttachmentId);
                binaryWriter.Write((uint) RecipientCount);
                binaryWriter.Write((uint) AttachmentCount);
                //WriteProperties(binaryWriter);
                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}
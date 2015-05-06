using System.IO;

namespace MsgWriter.PropertiesStream
{
    /// <summary>
    ///     The property stream contained inside the top level of the .msg file, which represents the Message object itself.
    /// </summary>
    internal sealed class TopLevel : Properties
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
        internal TopLevel(int nextRecipientId,
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

        #region ToByteArray
        /// <summary>
        ///     Returns the Top level property stream as a byte array
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
                binaryWriter.Write(new byte[8]);
                WriteProperties(binaryWriter);
                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}
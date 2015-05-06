using System.IO;

namespace MsgWriter.PropertiesStream
{
    /// <summary>
    /// The property stream contained inside an Attachment object storage or a Recipient object storage
    /// </summary>
    internal sealed class AttachmentOrRecipient : Properties
    {
        #region ToByteArray
        /// <summary>
        ///     Returns the property stream contained inside an Attachment object storage or a Recipient 
        ///     object storage as a byte array
        /// </summary>
        /// <returns></returns>
        internal byte[] ToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                binaryWriter.Write(new byte[8]);
                WriteProperties(binaryWriter);
                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}

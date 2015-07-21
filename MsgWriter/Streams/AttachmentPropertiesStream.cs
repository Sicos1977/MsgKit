using System.IO;

namespace MsgWriter.Streams
{
    /// <summary>
    ///     The properties stream contained inside an Attachment storage object
    /// </summary>
    internal sealed class AttachmentPropertiesStream : Properties
    {
        #region FromByteArray
        /// <summary>
        ///     Reads the property stream contained inside an Attachment object storage or a Recipient 
        ///     object storage
        /// </summary>
        /// <param name="byteArray"></param>
        internal void FromByteArray(byte[] byteArray)
        {
            using (var memoryStream = new MemoryStream(byteArray))
            using (var binaryReader = new BinaryReader(memoryStream))
            {
                binaryReader.ReadBytes(8);
                ReadProperties(binaryReader);
            }
        }
        #endregion

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
                //WriteProperties(binaryWriter);
                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}

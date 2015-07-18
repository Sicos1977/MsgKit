using System.IO;

namespace MsgWriter.Helpers
{
    internal static class StreamHelpers
    {
        #region ToByteArray
        /// <summary>
        ///     Returns the stream as an byte array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static byte[] ToByteArray(this Stream input)
        {
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        #endregion

        #region Eos
        /// <summary>
        ///     Returns true when the end of the <see cref="BinaryReader.BaseStream" /> has been reached
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        internal static bool Eos(this BinaryReader binaryReader)
        {
            try
            {
                return binaryReader.BaseStream.Position >= binaryReader.BaseStream.Length;
            }
            catch (IOException)
            {
                return true;
            }
        }
        #endregion
    }
}
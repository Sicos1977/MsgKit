using System;
using System.IO;

namespace MsgWriter.Helpers
{
    internal static class StreamHelpers
    {
        /// <summary>
        /// Returns the stream as an byte array
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
    }
}

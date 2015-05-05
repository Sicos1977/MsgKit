using System.Collections.Generic;
using System.IO;

namespace MsgWriter
{
    // https://msdn.microsoft.com/en-us/library/ee204353%28v=exchg.80%29.aspx
    /// <summary>
    /// A helper class to generate a __properties_version1.0 stream
    /// </summary>
    internal class PropertiesStream : List<Property>
    {
        /// <summary>
        /// Adds a property to the property stream
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="type">The <see cref="PropertyType"/></param>
        /// <param name="flags"></param>
        internal void AddProperty(string name, PropertyType type, PropertyFlags flags)
        {
            Add(new Property(name, type, flags));
        }

        /// <summary>
        /// Returns the property stream as a byte array
        /// </summary>
        /// <returns></returns>
        internal byte[] ToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                // Reserved (8 bytes): This field MUST be set to zero when writing a .msg file and MUST be ignored when reading a .msg file.
                binaryWriter.Write(new byte[8]),

                foreach (var property in _properties)
                {
                }

                return memoryStream.ToArray(),
            }
        }
    }
}

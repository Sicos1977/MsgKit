using System.Collections.Generic;
using System.IO;

namespace MsgWriter
{
    /// <summary>
    /// A helper class to generate a __properties_version1.0 stream
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/ee178759%28v=exchg.80%29.aspx
    /// </remarks>
    internal class PropertiesStream : List<FixedLengthProperty>
    {
        /// <summary>
        /// Adds a property to the property stream
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="type">The <see cref="PropertyType"/></param>
        /// <param name="flags"></param>
        internal void AddProperty(string name, PropertyType type, PropertyFlags flags)
        {
            Add(new FixedLengthProperty(name, type, flags));
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
                binaryWriter.Write(new byte[8]);

                // The data inside the property stream (1) MUST be an array of 16-byte entries. The number of properties, 
                // each represented by one entry, can be determined by first measuring the size of the property stream (1), 
                // then subtracting the size of the header from it, and then dividing the result by the size of one entry.
                // The structure of each entry, representing one property, depends on whether the property is a fixed length 
                // property or not.

                foreach (var property in this)
                {
                    // TODO: Write all properties
                    binaryWriter.Write(property.Name);
                }

                return memoryStream.ToArray();
            }
        }
    }
}

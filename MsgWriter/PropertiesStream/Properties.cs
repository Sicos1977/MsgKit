using System.Collections.Generic;
using System.IO;

namespace MsgWriter.PropertiesStream
{
    /// <summary>
    ///     A helper class to generate a __properties_version1.0 stream
    /// </summary>
    /// <remarks>
    ///     https://msdn.microsoft.com/en-us/library/ee178759%28v=exchg.80%29.aspx
    /// </remarks>
    internal class Properties : List<FixedLengthProperty>
    {
        #region AddProperty
        /// <summary>
        ///     Adds a property to the property stream
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlags.PROPATTR_READABLE"/> 
        ///     and <see cref="PropertyFlags.PROPATTR_WRITABLE"/>
        /// </param>
        internal void AddProperty(string name, 
                                  PropertyType type, 
                                  PropertyFlags flags = PropertyFlags.PROPATTR_READABLE & PropertyFlags.PROPATTR_WRITABLE)
        {
            Add(new FixedLengthProperty(name, type, flags));
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all the <see cref="FixedLengthProperty" /> objects to the given <paramref name="binaryWriter" />
        /// </summary>
        /// <param name="binaryWriter"></param>
        internal void WriteProperties(BinaryWriter binaryWriter)
        {
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
        }
        #endregion
    }
}
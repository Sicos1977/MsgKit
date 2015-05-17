using System;
using System.Collections.Generic;
using System.IO;
using CompoundFileStorage;
using MsgWriter.Helpers;

namespace MsgWriter.Streams
{
    /// <summary>
    ///     The properties inside an msg file
    /// </summary>
    /// <remarks>
    ///     https://msdn.microsoft.com/en-us/library/ee178759%28v=exchg.80%29.aspx
    /// </remarks>
    internal class Properties : List<Property>
    {
        #region AddProperty
        /// <summary>
        ///     Adds a property
        /// </summary>
        /// <param name="mapiTag">The <see cref="MapiTag"/></param>
        /// <param name="data">The value for the mapi tag</param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlag.PROPATTR_READABLE"/> 
        ///     and <see cref="PropertyFlag.PROPATTR_WRITABLE"/>
        /// </param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="data"/> is <c>null</c></exception>
        internal void AddProperty(MapiTag mapiTag,
                                  byte[] data,
                                  PropertyFlag flags = PropertyFlag.PROPATTR_READABLE & PropertyFlag.PROPATTR_WRITABLE)
        {
            if (data == null)
                throw new ArgumentNullException("mapiTag", "Data can not be null");

            Add(new Property(mapiTag.Id, mapiTag.Type, flags, data));
        }

        /// <summary>
        ///     Adds a property that has been read from the propertiesstream
        /// </summary>
        /// <param name="id">The id of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="data"></param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlag.PROPATTR_READABLE"/> 
        ///     and <see cref="PropertyFlag.PROPATTR_WRITABLE"/>
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">Raised when <paramref name="data"/> is not 8 bytes</exception>
        internal void AddProperty(ushort id, 
                                  PropertyType type, 
                                  byte[] data,
                                  PropertyFlag flags = PropertyFlag.PROPATTR_READABLE & PropertyFlag.PROPATTR_WRITABLE)
        {
            if (data.Length != 8)
                throw new ArgumentOutOfRangeException("data", "The data should always have an 8 byte size");

            Add(new Property(id, type, flags, data));
        }

        /// <summary>
        ///     Adds a CFStream and converts it to a property
        /// </summary>
        /// <param name="cfStream">The <see cref="CFStream"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Raised when the <see cref="CFStream.Name"/> does not start with "__substg1.0_"</exception>
        internal void AddProperty(CFStream cfStream)
        {
            if (!cfStream.Name.StartsWith("__substg1.0_"))
                throw new ArgumentOutOfRangeException("cfStream", "The stream name needs to start with '__substg1.0_'");

            var id = cfStream.Name.Substring(12, 4);
            var type = cfStream.Name.Substring(16, 4);
            var uId = ushort.Parse(id, System.Globalization.NumberStyles.AllowHexSpecifier);
            var uType = ushort.Parse(type, System.Globalization.NumberStyles.AllowHexSpecifier);
            Add(new Property(uId, (PropertyType)uType, PropertyFlag.PROPATTR_READABLE, cfStream.GetData()));
        }
        #endregion

        #region ReadProperties
        /// <summary>
        ///     Reads all the <see cref="Property" /> objects from the given <paramref name="binaryReader" />
        /// </summary>
        /// <param name="binaryReader"></param>
        internal void ReadProperties(BinaryReader binaryReader)
        {
            // The data inside the property stream (1) MUST be an array of 16-byte entries. The number of properties, 
            // each represented by one entry, can be determined by first measuring the size of the property stream (1), 
            // then subtracting the size of the header from it, and then dividing the result by the size of one entry.
            // The structure of each entry, representing one property, depends on whether the property is a fixed length 
            // property or not.

            while (!binaryReader.Eos())
            {
                // property tag: A 32-bit value that contains a property type and a property ID. The low-order 16 bits 
                // represent the property type. The high-order 16 bits represent the property ID.
                var type = (PropertyType) binaryReader.ReadUInt16();
                var id = binaryReader.ReadUInt16();
                var flags = binaryReader.ReadUInt32();
                // 8 bytes for the data
                var data = binaryReader.ReadBytes(8);

                Add(new Property(id, type, flags, data));
            }
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all the string and binary <see cref="Property">properties</see> as a <see cref="CFStream"/> to the 
        ///     given <paramref name="cfStorage" />, all other properties are written to an byte array and returned to the caller
        /// </summary>
        /// <param name="cfStorage"></param>
        internal byte[] WriteProperties(CFStorage cfStorage)
        {
            // The data inside the property stream (1) MUST be an array of 16-byte entries. The number of properties, 
            // each represented by one entry, can be determined by first measuring the size of the property stream (1), 
            // then subtracting the size of the header from it, and then dividing the result by the size of one entry.
            // The structure of each entry, representing one property, depends on whether the property is a fixed length 
            // property or not.
            using (var propertiesStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(propertiesStream))
            {
                foreach (var property in this)
                {
                    switch (property.Type)
                    {
                        case PropertyType.PT_ACTIONS:
                        case PropertyType.PT_APPTIME:
                        case 
                        // property tag: A 32-bit value that contains a property type and a property ID. The low-order 16 bits 
                        // represent the property type. The high-order 16 bits represent the property ID.
                            binaryWriter.Write(property.Id);
                            binaryWriter.Write(Convert.ToUInt16(property.Type));
                            binaryWriter.Write(Convert.ToUInt32(property.Flags));
                            binaryWriter.Write(property.Data);
                    }
                }

                return propertiesStream.ToArray();
            }
        }
        #endregion
    }
}
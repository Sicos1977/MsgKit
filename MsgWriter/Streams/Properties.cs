using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MsgWriter.Helpers;
using OpenMcdf;

/*
   Copyright 2015 - 2016 Kees van Spelde

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
        /// <param name="mapiTag">The <see cref="PropertyTag"/></param>
        /// <param name="obj">The value for the mapi tag</param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlag.PROPATTR_READABLE"/> 
        ///     and <see cref="PropertyFlag.PROPATTR_WRITABLE"/>
        /// </param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="obj"/> is <c>null</c></exception>
        internal void AddProperty(PropertyTag mapiTag,
                                  object obj,
                                  PropertyFlag flags = PropertyFlag.PROPATTR_READABLE & PropertyFlag.PROPATTR_WRITABLE)
        {
            if (obj == null)
                throw new ArgumentNullException("mapiTag", "Obj can not be null");

            var data = new byte[] {};

            switch (mapiTag.Type)
            {
                case PropertyType.PT_APPTIME:
                case PropertyType.PT_SYSTIME:
                    break;

                case PropertyType.PT_SHORT:
                    data = BitConverter.GetBytes((short) obj);
                    break;

                case PropertyType.PT_ERROR:
                case PropertyType.PT_LONG:
                    data = BitConverter.GetBytes((int)obj);
                    break;

                case PropertyType.PT_FLOAT:
                    data = BitConverter.GetBytes((float)obj);
                    break;

                case PropertyType.PT_DOUBLE:
                    data = BitConverter.GetBytes((double)obj);
                    break;

                case PropertyType.PT_CURRENCY:
                    break;

                case PropertyType.PT_BOOLEAN:
                    data = BitConverter.GetBytes((bool)obj);
                    break;

                case PropertyType.PT_I8:
                    data = BitConverter.GetBytes((long) obj);
                    break;

                case PropertyType.PT_UNICODE:
                    data = Encoding.UTF8.GetBytes((string)obj);
                    break;

                case PropertyType.PT_STRING8:
                    data = Encoding.Default.GetBytes((string)obj);
                    break;

                case PropertyType.PT_CLSID:
                    break;

                case PropertyType.PT_SVREID:
                    break;

                case PropertyType.PT_SRESTRICT:
                    break;

                case PropertyType.PT_BINARY:

                    switch (Type.GetTypeCode(obj.GetType()))
                    {
                        case TypeCode.Boolean:
                            data = BitConverter.GetBytes((bool) obj);
                            break;
                        case TypeCode.Char:
                            data = BitConverter.GetBytes((char)obj);
                            break;
                        case TypeCode.SByte:
                            data = BitConverter.GetBytes((sbyte)obj);
                            break;
                        case TypeCode.Byte:
                            data = BitConverter.GetBytes((byte)obj);
                            break;
                        case TypeCode.Int16:
                            data = BitConverter.GetBytes((short)obj);
                            break;
                        case TypeCode.UInt16:
                            data = BitConverter.GetBytes((uint)obj);
                            break;
                        case TypeCode.Int32:
                            data = BitConverter.GetBytes((int) obj);
                            break;
                        case TypeCode.UInt32:
                            data = BitConverter.GetBytes((uint)obj);
                            break;
                        case TypeCode.Int64:
                            data = BitConverter.GetBytes((long)obj);
                            break;
                        case TypeCode.UInt64:
                            data = BitConverter.GetBytes((ulong)obj);
                            break;
                        case TypeCode.Single:
                            data = BitConverter.GetBytes((float)obj);
                            break;
                        case TypeCode.Double:
                            data = BitConverter.GetBytes((double)obj);
                            break;
                        case TypeCode.Decimal:
                            //data = BitConverter.GetBytes((decimal)obj);
                            break;
                        case TypeCode.DateTime:
                            //data = BitConverter.GetBytes((DateTime)obj);
                            break;
                        case TypeCode.String:
                            //data = BitConverter.GetBytes((string)obj);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;

                case PropertyType.PT_UNSPECIFIED:
                    break;

                case PropertyType.PT_NULL:
                    break;

                case PropertyType.PT_OBJECT:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

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
        internal void AddProperty(ushort id, PropertyType type, byte[] data, PropertyFlag flags = PropertyFlag.PROPATTR_READABLE & PropertyFlag.PROPATTR_WRITABLE)
        {
            if (data.Length != 8)
                throw new ArgumentOutOfRangeException("data", "The data should always have an 8 byte size");

            Add(new Property(id, type, flags, data));
        }

        /// <summary>
        ///     Adds a CFStream and converts it to a property
        /// </summary>
        /// <param name="stream">The <see cref="CFStream"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Raised when the <see cref="CFStream.Name"/> does not start with "__substg1.0_"</exception>
        internal void AddProperty(CFStream stream)
        {
            if (!stream.Name.StartsWith("__substg1.0_"))
                throw new ArgumentOutOfRangeException("stream", "The stream name needs to start with '__substg1.0_'");

            var id = stream.Name.Substring(12, 4);
            var type = stream.Name.Substring(16, 4);
            var uId = ushort.Parse(id, System.Globalization.NumberStyles.AllowHexSpecifier);
            var uType = ushort.Parse(type, System.Globalization.NumberStyles.AllowHexSpecifier);
            Add(new Property(uId, (PropertyType) uType, PropertyFlag.PROPATTR_READABLE, stream.GetData()));
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
        ///     given <paramref name="storage" />
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage"/></param>
        internal void WriteProperties(CFStorage storage)
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
                    // property tag: A 32-bit value that contains a property type and a property ID. The low-order 16 bits 
                    // represent the property type. The high-order 16 bits represent the property ID.
                    binaryWriter.Write(Convert.ToUInt16(property.Type));
                    binaryWriter.Write(Convert.ToUInt32(property.Flags));

                    switch (property.Type)
                    {
                        case PropertyType.PT_ACTIONS:
                        case PropertyType.PT_APPTIME:
                            binaryWriter.Write(property.Data);
                            break;

                        case PropertyType.PT_SHORT:
                            break;

                        case PropertyType.PT_LONG:
                            break;

                        case PropertyType.PT_FLOAT:
                            break;

                        case PropertyType.PT_DOUBLE:
                            break;

                        case PropertyType.PT_CURRENCY:
                            break;

                        case PropertyType.PT_ERROR:
                            break;

                        case PropertyType.PT_BOOLEAN:
                            break;

                        case PropertyType.PT_I8:
                            // PropertyType.PT_LONGLONG:
                            break;

                        case PropertyType.PT_UNICODE:
                            storage.AddStream(property.Name).SetData(property.Data);
                            break;

                        case PropertyType.PT_STRING8:
                            storage.AddStream(property.Name).SetData(property.Data);
                            break;

                        case PropertyType.PT_SYSTIME:
                            break;

                        case PropertyType.PT_CLSID:
                            break;

                        case PropertyType.PT_SVREID:
                            break;

                        case PropertyType.PT_SRESTRICT:
                            break;

                        case PropertyType.PT_BINARY:
                            storage.AddStream(property.Name).SetData(property.Data);
                            break;

                        case PropertyType.PT_MV_SHORT:
                            break;
                        case PropertyType.PT_MV_LONG:
                            break;

                        case PropertyType.PT_MV_FLOAT:
                            break;

                        case PropertyType.PT_MV_DOUBLE:
                            break;

                        case PropertyType.PT_MV_CURRENCY:
                            break;

                        case PropertyType.PT_MV_APPTIME:
                            break;

                        case PropertyType.PT_MV_I8:
                            break;

                        case PropertyType.PT_MV_UNICODE:
                            // PropertyType.PT_MV_TSTRING
                            break;

                        case PropertyType.PT_MV_STRING8:
                            break;

                        case PropertyType.PT_MV_SYSTIME:
                            break;

                        case PropertyType.PT_MV_CLSID:
                            break;

                        case PropertyType.PT_MV_BINARY:
                            break;

                        case PropertyType.PT_UNSPECIFIED:
                            break;

                        case PropertyType.PT_NULL:
                            break;

                        case PropertyType.PT_OBJECT:
                            break;
                    }
                }

                // Make the properties stream
                storage.AddStream(PropertyTags.PropertiesStreamName).SetData(propertiesStream.ToArray());
            }
        }
        #endregion
    }
}
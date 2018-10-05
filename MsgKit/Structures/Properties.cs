//
// Properties.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2018 Magic-Sessions. (www.magic-sessions.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using MsgKit.Enums;
using MsgKit.Helpers;
using OpenMcdf;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The properties inside an msg file
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee178759%28v=exchg.80%29.aspx
    /// </remarks>
    internal class Properties : List<Property>
    {
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
        ///     Writes all <see cref="Property">properties</see> either as a <see cref="CFStream"/> or as a collection in
        ///     a <see cref="PropertyTags.PropertiesStreamName"/> stream to the given <paramref name="storage"/>, this depends 
        ///     on the <see cref="PropertyType"/>
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage"/></param>
        /// <param name="binaryWriter">The <see cref="BinaryWriter" /></param>
        /// <param name="messageSize">Used to calculate the exact size of the <see cref="Message"/></param>
        /// <returns>
        ///     Total size of the written <see cref="Properties"/>
        /// </returns>
        internal long WriteProperties(CFStorage storage, BinaryWriter binaryWriter, long? messageSize = null)
        {
            long size = 0;

            // The data inside the property stream (1) MUST be an array of 16-byte entries. The number of properties, 
            // each represented by one entry, can be determined by first measuring the size of the property stream (1), 
            // then subtracting the size of the header from it, and then dividing the result by the size of one entry.
            // The structure of each entry, representing one property, depends on whether the property is a fixed length 
            // property or not.
            foreach (var property in this)
            {
                // property tag: A 32-bit value that contains a property type and a property ID. The low-order 16 bits 
                // represent the property type. The high-order 16 bits represent the property ID.
                binaryWriter.Write(Convert.ToUInt16(property.Type)); // 2 bytes
                binaryWriter.Write(Convert.ToUInt16(property.Id)); // 2 bytes
                binaryWriter.Write(Convert.ToUInt32(property.Flags)); // 4 bytes

                switch (property.Type)
                {
                    //case PropertyType.PT_ACTIONS:
                    //    break;

                    case PropertyType.PT_APPTIME:
                    case PropertyType.PT_SYSTIME:
                    case PropertyType.PT_DOUBLE:
                    case PropertyType.PT_I8:
                        binaryWriter.Write(property.Data);
                        break;

                    case PropertyType.PT_ERROR:
                    case PropertyType.PT_LONG:
                    case PropertyType.PT_FLOAT:
                        binaryWriter.Write(property.Data);
                        binaryWriter.Write(new byte[4]);
                        break;

                    case PropertyType.PT_SHORT:
                        binaryWriter.Write(property.Data);
                        binaryWriter.Write(new byte[6]);
                        break;

                    case PropertyType.PT_BOOLEAN:
                        binaryWriter.Write(property.Data);
                        binaryWriter.Write(new byte[7]);
                        break;

                    //case PropertyType.PT_CURRENCY:
                    //    binaryWriter.Write(property.Data);
                    //    break;

                    case PropertyType.PT_UNICODE:
                        // Write the length of the property to the propertiesstream
                        binaryWriter.Write(property.Data.Length + 2);
                        binaryWriter.Write(new byte[4]);
                        storage.AddStream(property.Name).SetData(property.Data);
                        size += property.Data.LongLength;
                        break;

                    case PropertyType.PT_STRING8:
                        // Write the length of the property to the propertiesstream
                        binaryWriter.Write(property.Data.Length + 1);
                        binaryWriter.Write(new byte[4]);
                        storage.AddStream(property.Name).SetData(property.Data);
                        size += property.Data.LongLength;
                        break;

                    case PropertyType.PT_CLSID:
                        binaryWriter.Write(property.Data);
                        break;

                    //case PropertyType.PT_SVREID:
                    //    break;

                    //case PropertyType.PT_SRESTRICT:
                    //    storage.AddStream(property.Name).SetData(property.Data);
                    //    break;

                    case PropertyType.PT_BINARY:
                        // Write the length of the property to the propertiesstream
                        binaryWriter.Write(property.Data.Length);
                        binaryWriter.Write(new byte[4]);
                        storage.AddStream(property.Name).SetData(property.Data);
                        size += property.Data.LongLength;
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

                    case PropertyType.PT_MV_LONGLONG:
                        break;

                    case PropertyType.PT_MV_UNICODE:
                        // PropertyType.PT_MV_TSTRING
                        break;

                    case PropertyType.PT_MV_STRING8:
                        break;

                    case PropertyType.PT_MV_SYSTIME:
                        break;

                    //case PropertyType.PT_MV_CLSID:
                    //    break;

                    case PropertyType.PT_MV_BINARY:
                        break;

                    case PropertyType.PT_UNSPECIFIED:
                        break;

                    case PropertyType.PT_NULL:
                        break;

                    case PropertyType.PT_OBJECT:
                        // TODO: Adding new MSG file
                        break;
                }
            }

            if (messageSize.HasValue)
            {
                binaryWriter.Write(Convert.ToUInt16(PropertyTags.PR_MESSAGE_SIZE.Type));  // 2 bytes
                binaryWriter.Write(Convert.ToUInt16(PropertyTags.PR_MESSAGE_SIZE.Id));    // 2 bytes
                binaryWriter.Write(Convert.ToUInt32(PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)); // 4 bytes
                var totalSize = messageSize.Value + size + 8;
                var bytes = BitConverter.GetBytes(totalSize);
                binaryWriter.Write(bytes);
                binaryWriter.Write(new byte[4]);
            }
            
            // Make the properties stream
            binaryWriter.BaseStream.Position = 0;
            var propertiesStream = storage.TryGetStream(PropertyTags.PropertiesStreamName) ?? storage.AddStream(PropertyTags.PropertiesStreamName);
            propertiesStream.SetData(binaryWriter.BaseStream.ToByteArray());
            return size + binaryWriter.BaseStream.Length;
        }
        #endregion

        #region AddProperty
        /// <summary>
        ///     Adds a property
        /// </summary>
        /// <param name="mapiTag">The <see cref="PropertyTag" /></param>
        /// <param name="obj">The value for the mapi tag</param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlags.PROPATTR_READABLE" />
        ///     and <see cref="PropertyFlags.PROPATTR_WRITABLE" />
        /// </param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="obj" /> is <c>null</c></exception>
        internal void AddProperty(PropertyTag mapiTag,
            object obj,
            PropertyFlags flags = PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)
        {
            if (obj == null)
                return;
                //throw new ArgumentNullException("mapiTag", "Obj can not be null");

            var data = new byte[] {};

            switch (mapiTag.Type)
            {
                case PropertyType.PT_APPTIME:
                    var oaDate = ((DateTime) obj).ToOADate();
                    data = BitConverter.GetBytes(oaDate);
                    break;

                case PropertyType.PT_SYSTIME:
                    var fileTime = ((DateTime) obj).ToFileTimeUtc();
                    data = BitConverter.GetBytes(fileTime);
                    break;

                case PropertyType.PT_SHORT:
                    data = BitConverter.GetBytes(Convert.ToInt16(obj));
                    break;

                case PropertyType.PT_ERROR:
                case PropertyType.PT_LONG:
                    data = BitConverter.GetBytes(Convert.ToInt32(obj));
                    break;

                case PropertyType.PT_FLOAT:
                    data = BitConverter.GetBytes((float) (int) obj);
                    break;

                case PropertyType.PT_DOUBLE:
                    data = BitConverter.GetBytes((double) obj);
                    break;

                //case PropertyType.PT_CURRENCY:
                //    data = (byte[]) obj;
                //    break;

                case PropertyType.PT_BOOLEAN:
                    data = BitConverter.GetBytes((bool) obj);
                    break;

                case PropertyType.PT_I8:
                    data = BitConverter.GetBytes((long) obj);
                    break;

                case PropertyType.PT_UNICODE:
                    data = Encoding.Unicode.GetBytes((string) obj);
                    break;

                case PropertyType.PT_STRING8:
                    data = Encoding.Default.GetBytes((string) obj);
                    break;

                case PropertyType.PT_CLSID:
                    data = ((Guid) obj).ToByteArray();
                    break;

                case PropertyType.PT_BINARY:

                    switch (Type.GetTypeCode(obj.GetType()))
                    {
                        case TypeCode.Boolean:
                            data = BitConverter.GetBytes((bool) obj);
                            break;

                        case TypeCode.Char:
                            data = BitConverter.GetBytes((char) obj);
                            break;

                        case TypeCode.SByte:
                            data = BitConverter.GetBytes((sbyte) obj);
                            break;

                        case TypeCode.Byte:
                            data = BitConverter.GetBytes((byte) obj);
                            break;
                        case TypeCode.Int16:
                            data = BitConverter.GetBytes((short) obj);
                            break;

                        case TypeCode.UInt16:
                            data = BitConverter.GetBytes((uint) obj);
                            break;

                        case TypeCode.Int32:
                            data = BitConverter.GetBytes((int) obj);
                            break;

                        case TypeCode.UInt32:
                            data = BitConverter.GetBytes((uint) obj);
                            break;

                        case TypeCode.Int64:
                            data = BitConverter.GetBytes((long) obj);
                            break;

                        case TypeCode.UInt64:
                            data = BitConverter.GetBytes((ulong) obj);
                            break;

                        case TypeCode.Single:
                            data = BitConverter.GetBytes((float) obj);
                            break;

                        case TypeCode.Double:
                            data = BitConverter.GetBytes((double) obj);
                            break;

                        case TypeCode.DateTime:
                            data = BitConverter.GetBytes(((DateTime) obj).Ticks);
                            break;

                        case TypeCode.String:
                            data = Encoding.UTF8.GetBytes((string) obj);
                            break;

                        case TypeCode.Object:
                            data = (byte[]) obj;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;

                case PropertyType.PT_NULL:
                    break;

                case PropertyType.PT_ACTIONS:
                    throw new NotSupportedException("PT_ACTIONS property type is not supported");

                case PropertyType.PT_UNSPECIFIED:
                    throw new NotSupportedException("PT_UNSPECIFIED property type is not supported");

                case PropertyType.PT_OBJECT:
                    // TODO: Add support for MSG
                    break;

                case PropertyType.PT_SVREID:
                    throw new NotSupportedException("PT_SVREID property type is not supported");

                case PropertyType.PT_SRESTRICT:
                    throw new NotSupportedException("PT_SRESTRICT property type is not supported");

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
        /// <param name="flagses">
        ///     the flags to set on the property, default <see cref="PropertyFlags.PROPATTR_READABLE" />
        ///     and <see cref="PropertyFlags.PROPATTR_WRITABLE" />
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">Raised when <paramref name="data" /> is not 8 bytes</exception>
        internal void AddProperty(ushort id, PropertyType type, byte[] data,
            PropertyFlags flagses = PropertyFlags.PROPATTR_READABLE & PropertyFlags.PROPATTR_WRITABLE)
        {
            if (data.Length != 8)
                throw new ArgumentOutOfRangeException(nameof(data), "The data should always have an 8 byte size");

            Add(new Property(id, type, flagses, data));
        }

        /// <summary>
        ///     Adds a CFStream and converts it into a property
        /// </summary>
        /// <param name="stream">The <see cref="CFStream" /></param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Raised when the <paramref name="stream"/> does not start with
        ///     "__substg1.0_"
        /// </exception>
        internal void AddProperty(CFStream stream)
        {
            if (!stream.Name.StartsWith("__substg1.0_"))
                throw new ArgumentOutOfRangeException(nameof(stream), "The stream name needs to start with '__substg1.0_'");

            var id = stream.Name.Substring(12, 4);
            var type = stream.Name.Substring(16, 4);
            var uId = ushort.Parse(id, NumberStyles.AllowHexSpecifier);
            var uType = ushort.Parse(type, NumberStyles.AllowHexSpecifier);
            Add(new Property(uId, (PropertyType) uType, PropertyFlags.PROPATTR_READABLE, stream.GetData()));
        }
        #endregion

        #region AddOrReplaceProperty
        /// <summary>
        ///     Adds a property when it not exists, otherwise it is replaced
        /// </summary>
        /// <param name="mapiTag">The <see cref="PropertyTag" /></param>
        /// <param name="obj">The value for the mapi tag</param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlags.PROPATTR_READABLE" />
        ///     and <see cref="PropertyFlags.PROPATTR_WRITABLE" />
        /// </param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="obj" /> is <c>null</c></exception>
        internal void AddOrReplaceProperty(PropertyTag mapiTag,
            object obj,
            PropertyFlags flags = PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)
        {
            var index = FindIndex(m => m.Id == mapiTag.Id);
            if (index >= 0)
                RemoveAt(index);

            AddProperty(mapiTag, obj, flags);
        }
        #endregion
    }
}
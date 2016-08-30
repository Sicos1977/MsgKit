//
// Entry.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2016 Magic-Sessions. (www.magic-sessions.com)
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
using System.IO;
using MsgKit.Helpers;
using MsgKit.Structures;
using OpenMcdf;

namespace MsgKit.Streams
{
    #region Enum EntryStreamKind
    /// <summary>
    /// Kind (1 byte): The possible values for the Kind field are in the following table.
    /// </summary>
    public enum EntryStreamKind
    {
        /// <summary>
        /// The property is identified by the LID field.
        /// </summary>
        Lid = 0x00,

        /// <summary>
        /// The property is identified by the Name field.
        /// </summary>
        Name = 0x01,

        /// <summary>
        /// The property does not have an associated PropertyName field.
        /// </summary>
        NotAssociated = 0xFF
    }
    #endregion

    /// <summary>
    /// The entry stream MUST be named "__substg1.0_00030102" and consist of 8-byte entries, one for each 
    /// named property being stored. The properties are assigned unique numeric IDs (distinct from any property 
    /// ID assignment) starting from a base of 0x8000. The IDs MUST be numbered consecutively, like an array. 
    /// In this stream, there MUST be exactly one entry for each named property of the Message object or any of 
    /// its subobjects. The index of the entry for a particular ID is calculated by subtracting 0x8000 from it. 
    /// For example, if the ID is 0x8005, the index for the corresponding 8-byte entry would be 0x8005 – 0x8000 = 5.
    ///  The index can then be multiplied by 8 to get the actual byte offset into the stream from where to start 
    /// reading the corresponding entry.
    /// </summary>
    /// <remarks>
    /// See https://msdn.microsoft.com/en-us/library/ee159689(v=exchg.80).aspx
    /// </remarks>
    internal sealed class Entry
    {
        #region Properties
        /// <summary>
        /// Name Identifier/String Offset (4 bytes): If this property is a numerical named property (as specified by 
        /// the Property Kind subfield of the Index and Kind Information field), this value is the LID part of the 
        /// PropertyName structure, as specified in [MS-OXCDATA] section 2.6.1. If this property is a string named 
        /// property, this value is the offset in bytes into the strings stream where the value of the Name field of 
        /// the PropertyName structure is located.
        /// </summary>
        public int NameIdentifier { get; set; }

        /// <summary>
        /// <see cref="EntryStreamKind"/>
        /// </summary>
        public EntryStreamKind Kind { get; private set; }

        /// <summary>
        /// The GUID that identifies the property set for the named property.
        /// </summary>
        /// <remarks>
        /// The GUID field is treated as a FlatUID structure, as specified in section 2.5.1, and consequently is always in little-endian byte order. Client code on big-endian systems is therefore required to place GUID fields in little-endian byte order in the request buffer.
        /// </remarks>
        public Guid Guid { get; private set; }

        /// <summary>
        /// An unsigned integer that identifies the named property within its property set.
        /// </summary>
        /// <remarks>
        /// This field is present only if the value of the <see cref="EntryStreamKind"/> field is equal to <see cref="EntryStreamKind.Lid"/>. 
        ///  </remarks>
        public uint Lid { get; private set; }

        /// <summary>
        /// The value of this field is equal to the number of bytes in the Name string that follows it.
        /// </summary>
        /// <remarks>
        /// This field is present only if the value of the <see cref="EntryStreamKind"/> field is equal to <see cref="EntryStreamKind.Name"/>. 
        ///  </remarks>
        public short NameSize { get; private set; }

        /// <summary>
        /// The value of this field is equal to the number of bytes in the Name string that follows it.
        /// </summary>
        /// <remarks>
        /// This field is present only if the value of the <see cref="EntryStreamKind"/> field is equal to <see cref="EntryStreamKind.Name"/>. 
        /// </remarks>
        public string Name { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates this object
        /// </summary>
        internal Entry()
        {
            
        }
        #endregion

        #region ReadProperties
        /// <summary>
        ///     Reads all the <see cref="Property" /> objects from the given <paramref name="binaryReader" />
        /// </summary>
        /// <param name="binaryReader"></param>
        internal void ReadProperties(BinaryReader binaryReader)
        {
            while (!binaryReader.Eos())
            {
                Kind = (EntryStreamKind) binaryReader.ReadByte();
                Guid = new Guid(binaryReader.ReadBytes(16));

                switch (Kind)
                {
                    case EntryStreamKind.Lid:
                        Lid = binaryReader.ReadUInt32();
                        break;

                    case EntryStreamKind.Name:
                        NameSize = binaryReader.ReadByte();
                        break;

                    case EntryStreamKind.NotAssociated:
                        Name = Strings.ReadNullTerminatedUnicodeString(binaryReader);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all the string and binary <see cref="PropertyTags">properties</see> as a <see cref="CFStream" /> to the
        ///     given <paramref name="storage" />
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage" /></param>
        /// <param name="binaryWriter">The <see cref="BinaryWriter" /></param>
        internal void WriteProperties(CFStorage storage, BinaryWriter binaryWriter)
        {
            // TODO: Write properties
            //binaryWriter.BaseStream.Position = 0;
            //storage.AddStream(PropertyTags.PropertiesStreamName).SetData(binaryWriter.BaseStream.ToByteArray());
        }
        #endregion
    }
}

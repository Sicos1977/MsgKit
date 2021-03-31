//
// Entry.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com> and Travis Semple
//
// Copyright (c) 2015-2021 Magic-Sessions. (www.magic-sessions.com)
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
// FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MsgKit.Enums;
using MsgKit.Helpers;
using OpenMcdf;

namespace MsgKit.Streams
{
    /// <summary>
    ///     The entry stream MUST be named "__substg1.0_00030102" and consist of 8-byte entries, one for each
    ///     named property being stored. The properties are assigned unique numeric IDs (distinct from any property
    ///     ID assignment) starting from a base of 0x8000. The IDs MUST be numbered consecutively, like an array.
    ///     In this stream, there MUST be exactly one entry for each named property of the Message object or any of
    ///     its subobjects. The index of the entry for a particular ID is calculated by subtracting 0x8000 from it.
    ///     For example, if the ID is 0x8005, the index for the corresponding 8-byte entry would be 0x8005 – 0x8000 = 5.
    ///     The index can then be multiplied by 8 to get the actual byte offset into the stream from where to start
    ///     reading the corresponding entry.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee159689(v=exchg.80).aspx
    /// </remarks>
    internal sealed class EntryStream : List<EntryStreamItem>
    {
        #region Constructors
        /// <summary>
        ///     Creates this object
        /// </summary>
        internal EntryStream()
        {
            
        }

        /// <summary>
        ///     Creates this object and reads all the <see cref="EntryStreamItem" /> objects from 
        ///     the given <paramref name="storage"/>
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage"/> that containts the <see cref="PropertyTags.EntryStream"/></param>
        internal EntryStream(CFStorage storage)
        {
            if (!storage.TryGetStream(PropertyTags.EntryStream, out var stream)) 
                stream = storage.AddStream(PropertyTags.EntryStream);

            using (var memoryStream = new MemoryStream(stream.GetData()))
            using (var binaryReader = new BinaryReader(memoryStream))
                while (!binaryReader.Eos())
                {
                    var entryStreamItem = new EntryStreamItem(binaryReader);
                    Add(entryStreamItem);
                }
        }
        #endregion

        #region Write
        /// <summary>
        ///     Writes all the <see cref="EntryStreamItem"/>'s as a <see cref="CFStream" /> to the
        ///     given <paramref name="storage" />
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage" /></param>
        internal void Write(CFStorage storage)
        {
            var stream = storage.GetStream(PropertyTags.EntryStream);
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                foreach (var entryStreamItem in this)
                    entryStreamItem.Write(binaryWriter);

                stream.SetData(memoryStream.ToArray());
            }
        }
        internal void Write(CFStorage storage, string streamName)
        {
            if(!storage.TryGetStream(streamName, out var stream))
                stream = storage.AddStream(streamName);

            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                foreach (var entryStreamItem in this)
                    entryStreamItem.Write(binaryWriter);

                stream.SetData(memoryStream.ToArray());
            }
        }

        #endregion
    }

    /// <summary>
    ///     Represents one item in the <see cref="EntryStream"/> stream
    /// </summary>
    internal sealed class EntryStreamItem
    {
        #region Properties
        /// <summary>
        ///     Name Identifier/String Offset (4 bytes): If this property is a numerical named property (as specified by
        ///     the Property Kind subfield of the Index and Kind Information field), this value is the LID part of the
        ///     PropertyName structure, as specified in [MS-OXCDATA] section 2.6.1. If this property is a string named
        ///     property, this value is the offset in bytes into the strings stream where the value of the Name field of
        ///     the PropertyName structure is located.
        /// </summary>
        public uint NameIdentifierOrStringOffset { get; }

        /// <summary>
        /// 
        /// </summary>
        public string NameIdentifierOrStringOffsetHex { get; }

        /// <summary>
        ///     The following structure specifies the stream indexes and whether the property is a numerical named
        ///     property or a string named property
        /// </summary>
        public IndexAndKindInformation IndexAndKindInformation { get; }
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates this object and reads all the properties from the given <paramref name="binaryReader" />
        /// </summary>
        /// <param name="binaryReader">The <see cref="BinaryReader"/></param>
        internal EntryStreamItem(BinaryReader binaryReader)
        {
            NameIdentifierOrStringOffset = binaryReader.ReadUInt16();
            NameIdentifierOrStringOffsetHex = $"{NameIdentifierOrStringOffset:X}";
            IndexAndKindInformation = new IndexAndKindInformation(binaryReader);
        }

        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="nameIdentifierOrStringOffset"><see cref="NameIdentifierOrStringOffset"/></param>
        /// <param name="indexAndKindInformation"><see cref="IndexAndKindInformation"/></param>
        internal EntryStreamItem(ushort nameIdentifierOrStringOffset,
                                 IndexAndKindInformation indexAndKindInformation)
        {
            NameIdentifierOrStringOffset = nameIdentifierOrStringOffset;
            NameIdentifierOrStringOffsetHex = $"{nameIdentifierOrStringOffset:X}";
            IndexAndKindInformation = indexAndKindInformation;
        }
        #endregion

        #region Write
        /// <summary>
        ///     Writes all the internal properties to the given <paramref name="binaryWriter" />
        /// </summary>
        /// <param name="binaryWriter"></param>
        internal void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(NameIdentifierOrStringOffset);
            binaryWriter.Write((ushort)((IndexAndKindInformation.GuidIndex<<1) | (ushort) IndexAndKindInformation.PropertyKind));
            binaryWriter.Write(IndexAndKindInformation.PropertyIndex); //Doesn't seem to be the case in the spec. 
            // Fortunately section 3.2 clears this up. 
        }
        #endregion
    }

    /// <summary>
    ///     2.2.3.1.2.1 Index and Kind Information
    ///     The following structure specifies the stream indexes and whether the property is a numerical named
    ///     property or a string named property.
    /// </summary>
    internal sealed class IndexAndKindInformation
    {
        #region Properties
        /// <summary>
        ///     Sequentially increasing, zero-based index. This MUST be 0 for the first
        ///     named property, 1 for the second, and so on.
        /// </summary>
        public UInt16 PropertyIndex { get; }

        /// <summary>
        ///     Index into the GUID stream. The possible values are shown in the following table.<br/>
        ///     - 1 Always use the PS_MAPI property set, as specified in [MS-OXPROPS] section 1.3.2. No GUID is stored in<br/>
        ///         the GUID stream.<br/>
        ///     - 2 Always use the PS_PUBLIC_STRINGS property set, as specified in [MS-OXPROPS]<br/>
        ///         section 1.3.2. No GUID is stored in the GUID stream.<br/>
        ///     - >= 3 Use Value minus 3 as the index of the GUID into the GUID stream.For example, if the GUID index is 5,<br/>
        ///         the third GUID(5 minus 3, resulting in a zero-based index of 2) is used as the GUID for the name<br/>
        ///         property being derived.
        /// </summary>
        public UInt16 GuidIndex { get; }

        /// <summary>
        ///     Bit indicating the type of the property; zero (0) if numerical named property
        ///     and 1 if string named property.
        /// </summary>
        public PropertyKind PropertyKind { get; }
        #endregion

        #region GetUIntFromBitArray
        /// <summary>
        /// Converts the given <paramref name="bitArray"/> to an unsigned integer
        /// </summary>
        /// <param name="bitArray"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static uint GetUIntFromBitArray(BitArray bitArray, int offset, int count)
        {
            uint value = 0;

            for (var i = offset; i < count + offset; i++)
            {
                if (bitArray[i])
                    value += Convert.ToUInt16(Math.Pow(2, i));
            }

            return value;
        }
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates this object and reads all the properties from the given <paramref name="binaryReader" />
        /// </summary>
        /// <param name="binaryReader">The <see cref="BinaryReader"/></param>
        internal IndexAndKindInformation(BinaryReader binaryReader)
        {
            PropertyIndex = binaryReader.ReadUInt16();
            var bits = new BitArray(binaryReader.ReadBytes(2));
            GuidIndex = (ushort)GetUIntFromBitArray(bits, 1, 15);
            PropertyKind = (PropertyKind)GetUIntFromBitArray(bits, 0, 1);
        }

        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="propertyIndex"><see cref="PropertyIndex"/></param>
        /// <param name="guidIndex"><see cref="GuidIndex"/></param>
        /// <param name="propertyKind"><see cref="PropertyKind"/></param>
        internal IndexAndKindInformation(ushort propertyIndex,
                                         ushort guidIndex,
                                         PropertyKind propertyKind)
        {
            PropertyIndex = propertyIndex;
            GuidIndex = guidIndex;
            PropertyKind = propertyKind;
        }
        #endregion

        #region Write
        /// <summary>
        ///     Writes all the internal properties to the given <paramref name="binaryWriter" />
        /// </summary>
        /// <param name="binaryWriter"></param>
        internal void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(PropertyIndex);
            binaryWriter.Write(GuidIndex + (uint) PropertyKind);
        }
        #endregion
    }
}
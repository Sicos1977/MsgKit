// NamedProperties.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2017 Magic-Sessions. (www.magic-sessions.com)
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
using MsgKit.Enums;
using MsgKit.Streams;
using OpenMcdf;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The named properties inside an msg file
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee178582(v=exchg.80).aspx
    /// </remarks>
    public class NamedProperties : List<NamedProperty>
    {
        #region Constructors
        /// <summary>
        ///     Creates this object
        /// </summary>
        internal NamedProperties()
        {
            
        }

        /// <summary>
        ///     Creates this object and reads all the <see cref="NamedProperty" /> objects from the streams
        ///     <see cref="EntryStream"/>, <see cref="StringStream"/> and <see cref="GuidStream"/> in the
        ///     given <paramref name="storage"/>
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage"/> that contains the <see cref="EntryStream"/>, <see cref="StringStream"/>
        /// and <see cref="GuidStream"/> stream </param>
        public NamedProperties(CFStorage storage)
        {
            var entryStream = new EntryStream(storage);
            var stringStream = new StringStream(storage);
            var guidStream = new GuidStream(storage);

            foreach (var entryStreamItem in entryStream)
            {
                var propertyKind = entryStreamItem.IndexAndKindInformation.PropertyKind;
                var propertyIndex = (int) entryStreamItem.IndexAndKindInformation.PropertyIndex - 1;
                var guidIndex = (int) entryStreamItem.IndexAndKindInformation.GuidIndex;

                switch (propertyKind)
                {
                    case PropertyKind.Lid:
                        var namedPropertyTag = new NamedPropertyTag((ushort) entryStreamItem.NameIdentifierOrStringOffset,
                                                                    stringStream[propertyIndex].Name,
                                                                    guidStream[guidIndex], PropertyType.PT_STRING8);
                        break;
                    case PropertyKind.Name:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        #endregion

        #region WriteProperties
        /// <summary>
        ///     Writes all <see cref="NamedProperty"/>'s to the given <paramref name="storage"/>
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage"/></param>
        internal void WriteProperties(CFStorage storage)
        {
            throw new NotImplementedException("Not yet done");

            var entryStream = new EntryStream();
            var stringStream = new StringStream();
            var guidStream = new GuidStream();

            foreach (var namedProperty in this)
            {
                // TODO: Workout code
            }
        }
        #endregion

        #region AddProperty
        /// <summary>
        ///     Adds a property
        /// </summary>
        /// <param name="mapiTag">The <see cref="NamedPropertyTag" /></param>
        /// <param name="obj">The value for the mapi tag</param>
        /// <param name="flags">
        ///     the flags to set on the property, default <see cref="PropertyFlags.PROPATTR_READABLE" />
        ///     and <see cref="PropertyFlags.PROPATTR_WRITABLE" />
        /// </param>
        internal void AddProperty(NamedPropertyTag mapiTag)
        {
            throw new NotImplementedException("Not yet done");

        }
        #endregion
    }
}

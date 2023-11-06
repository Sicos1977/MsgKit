﻿//
// NamedProperties.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com> and Travis Semple
//
// Copyright (c) 2015-2023 Magic-Sessions. (www.magic-sessions.com)
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
using System.Collections.Generic;
using System.Linq;
using MsgKit.Enums;
using MsgKit.Structures;
using OpenMcdf;

namespace MsgKit.Streams;

internal sealed class NamedProperties : List<NamedProperty>
{
    #region Fields
    /// <summary>
    ///     <see cref="TopLevelProperties" />
    /// </summary>
    private readonly TopLevelProperties _topLevelProperties;

    /// <summary>
    ///     The offset index for a <see cref="NamedProperty"/>
    /// </summary>
    private ushort _namedPropertyIndex;
    #endregion

    #region Constructor
    /// <summary>
    ///     Creates this object
    /// </summary>
    /// <param name="topLevelProperties">
    ///     <see cref="TopLevelProperties" />
    /// </param>
    public NamedProperties(TopLevelProperties topLevelProperties)
    {
        _topLevelProperties = topLevelProperties;
    }
    #endregion

    #region AddProperty
    /// <summary>
    ///     Adds a <see cref="NamedPropertyTag" />
    /// </summary>
    /// <remarks>
    ///     Only support for properties by ID for now.
    /// </remarks>
    /// <param name="mapiTag"></param>
    /// <param name="obj"></param>
    internal void AddProperty(NamedPropertyTag mapiTag, object obj)
    {
        // Named property field 0000. 0x8000 + property offset
        _topLevelProperties.AddProperty(new PropertyTags.PropertyTag((ushort)(0x8000 + _namedPropertyIndex++), mapiTag.Type), obj);

        Add(new NamedProperty
        {
            NameIdentifier = mapiTag.Id,
            Guid = mapiTag.Guid,
            Kind = PropertyKind.Lid
        });
    }
    #endregion

    #region WriteProperties
    /// <summary>
    ///     Writes the properties to the <see cref="CFStorage" />
    /// </summary>
    /// <param name="storage"></param>
    /// <remarks>
    ///     Unfortunately this is going to have to be used after we already written the top level properties.
    /// </remarks>
    internal void WriteProperties(CFStorage storage)
    {
        // Grab the nameIdStorage, 3.1 on the SPEC
        storage = storage.GetStorage(PropertyTags.NameIdStorage);

        var entryStream = new EntryStream(storage);
        var stringStream = new StringStream(storage);
        var guidStream = new GuidStream(storage);
        var entryStream2 = new EntryStream(storage);

        ushort propertyIndex = 0;
        var guids = this.Select(x => x.Guid).Distinct().ToList();

        foreach (var guid in guids)
            guidStream.Add(guid);

        foreach (var namedProperty in this)
        {
            var guidIndex = (ushort)(guids.IndexOf(namedProperty.Guid) + 3);

            // Depending on the property type. This is doing name. 
            entryStream.Add(new EntryStreamItem(namedProperty.NameIdentifier,
                new IndexAndKindInformation(propertyIndex, guidIndex, PropertyKind.Lid))); //+3 as per spec.
            entryStream2.Add(new EntryStreamItem(namedProperty.NameIdentifier,
                new IndexAndKindInformation(propertyIndex, guidIndex, PropertyKind.Lid)));

            //3.2.2 of the SPEC [MS-OXMSG]
            entryStream2.Write(storage,
                GenerateStreamString(namedProperty.NameIdentifier, guidIndex, namedProperty.Kind));

            // 3.2.2 of the SPEC Needs to be written, because the stream changes as per named object.
            entryStream2.Clear();
            propertyIndex++;
        }

        guidStream.Write(storage);
        entryStream.Write(storage);
        stringStream.Write(storage);
    }

    #region GenerateStreamString
    /// <summary>
    ///     Generates the stream strings
    /// </summary>
    /// <param name="nameIdentifier"></param>
    /// <param name="guidTarget"></param>
    /// <param name="propertyKind"></param>
    /// <returns></returns>
    private string GenerateStreamString(uint nameIdentifier, uint guidTarget, PropertyKind propertyKind)
    {
        switch (propertyKind)
        {
            case PropertyKind.Lid:
                return "__substg1.0_" +
                       (((4096 + (nameIdentifier ^ (guidTarget << 1)) % 0x1F) << 16) | 0x00000102).ToString("X")
                       .PadLeft(8, '0');
            default:
                throw new NotImplementedException();
        }
    }
    #endregion
    #endregion
}
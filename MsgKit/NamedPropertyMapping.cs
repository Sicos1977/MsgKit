//
// NamedPropertyMapping.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
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

namespace MsgKit
{
    /// <summary>
    ///     A process that converts PropertyName structures to property IDs and vice-versa. Named properties can be referred to
    ///     by their PropertyName. However, before accessing the property on a specific message store, named properties need to
    ///     be mapped to property IDs that are valid for that message store. The reverse is also true. When properties need to
    ///     be copied across message stores, property IDs that are valid for the source message store need to be mapped to
    ///     their PropertyName structures before they can be sent to the destination message store.
    /// </summary>
    internal class NamedPropertyMapping
    {
        /*
        3.2.1.1 Fetching the Name Identifier
         * 
        In this example, property ID 0x8005 has to be mapped to its property name. First, the entry index into the entry stream (1) is determined:
        Property ID – 0x8000
        =0x8005 – 0x8000
        =0x0005
        Then, the offset for the corresponding 8-byte entry is determined:
        Entry index * size of entry
        = 0x05 * 0x08
        = 0x28
        The offset is then used to fetch the entry from the entry stream (1) ("__substg1.0_00030102"), which is contained inside the named property 
        mapping storage ("__nameid_version1.0"). In this case, bytes 40 – 47 are fetched from the stream (1). Then, the structure specified in the 
        entry stream (1) section is applied to those bytes, taking into consideration that the data is stored in little-endian format.
           
         */
    }
}
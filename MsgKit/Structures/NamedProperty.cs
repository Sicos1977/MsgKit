//
// NamedProperty.cs
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
using MsgKit.Enums;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The PropertyName Structure
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee158295(v=exchg.80).aspx
    /// </remarks>
    internal class NamedProperty
    {
        #region Properties
        /// <summary>
        ///     This should be the ID of the built in property name we are attaching to.
        /// </summary>
        public ushort NameIdentifier { get; internal set; }

        /// <summary>
        ///     The possible values for the Kind field are in the following table.
        /// </summary>
        public PropertyKind Kind { get; internal set; }

        /// <summary>
        ///     The value of this field is equal to the number of bytes in the Name string that follows it. This field is present
        ///     only if the value of the <see cref="Kind" /> field is equal to <see cref="PropertyKind.Name" />
        /// </summary>
        /// <remarks>
        ///     Optional
        /// </remarks>
        public uint NameSize { get; internal set; }

        /// <summary>
        ///     This field is present only if <see cref="Kind" /> is equal to <see cref="PropertyKind.Name" />. The value is a
        ///     Unicode (UTF-16 format) string, followed by two zero bytes as terminating null characters, that identifies the
        ///     property within its property set.
        /// </summary>
        /// <remarks>
        ///     Optional
        /// </remarks>
        public string Name { get; internal set; }

        /// <summary>
        ///     A <see cref="Guid" />
        /// </summary>
        public Guid Guid { get; internal set; }
        #endregion
    }
}
//
// NamedProperty.cs
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

using MsgKit.Enums;

namespace MsgKit.Structures
{
    /// <summary>
    ///     A named property inside the MSG file
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc765864.aspx
    /// </remarks>
    public class NamedProperty : Property
    {
        /// <summary>
        ///     Creates this object and sets all its propertues
        /// </summary>
        /// <param name="id">The id of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="data">The property data</param>
        /// <param name="multiValue">Set to <c>true</c> to indicate that this property is part of a
        /// multivalue property</param>
        public NamedProperty(ushort id, PropertyType type, byte[] data, bool multiValue = false) : base(id, type, data, multiValue)
        {
        }

        /// <summary>
        ///     Creates this object and sets all its propertues
        /// </summary>
        /// <param name="id">The id of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="flags">The <see cref="PropertyFlags" /></param>
        /// <param name="data">The property data</param>
        /// <param name="multiValue">Set to <c>true</c> to indicate that this property is part of a
        /// multivalue property</param>
        public NamedProperty(ushort id, PropertyType type, PropertyFlags flags, byte[] data, bool multiValue = false) : base(id, type, flags, data, multiValue)
        {
        }

        /// <summary>
        ///     Creates this object and sets all its propertues
        /// </summary>
        /// <param name="id">The id of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="flags">The <see cref="PropertyFlags" /></param>
        /// <param name="data">The property data</param>
        /// <param name="multiValue">Set to <c>true</c> to indicate that this property is part of a
        /// multivalue property</param>
        public NamedProperty(ushort id, PropertyType type, uint flags, byte[] data, bool multiValue = false) : base(id, type, flags, data, multiValue)
        {
        }
    }
}

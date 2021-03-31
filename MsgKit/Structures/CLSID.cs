//
// CSLID.cs
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

using System;
using System.IO;
using System.Linq;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The packet version of the CLSID structure represents a class identifier (CLSID) in a serialized manner.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal class CLSID
    {
        #region Properties
        /// <summary>
        ///     Data1 (4 bytes): This MUST be identical in meaning to the Data1 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data1 { get; }

        /// <summary>
        ///     Data2 (2 bytes): This MUST be identical in meaning to the Data2 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data2 { get; }

        /// <summary>
        ///     Data3 (2 bytes): This MUST be identical in meaning to the Data3 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data3 { get; }

        /// <summary>
        ///     Data4 (8 bytes): This MUST be identical in meaning to the Data4 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data4 { get; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creatis this object and sets all it properties
        /// </summary>
        /// <param name="binaryReader"></param>
        internal CLSID(BinaryReader binaryReader)
        {
            Data1 = binaryReader.ReadBytes(4).Reverse().ToArray();
            Data2 = binaryReader.ReadBytes(2).Reverse().ToArray();
            Data3 = binaryReader.ReadBytes(2).Reverse().ToArray();
            Data4 = binaryReader.ReadBytes(8).Reverse().ToArray();
        }
        #endregion

        #region ToGuid
        /// <summary>
        ///     Returns <see cref="Data1" />, <see cref="Data2" />, <see cref="Data3" />, <see cref="Data4" /> as
        ///     a <see cref="Guid" />
        /// </summary>
        public Guid ToGuid()
        {
            return new Guid(Data1.Concat(Data2).Concat(Data3).Concat(Data4).ToArray());
        }
        #endregion
    }
}
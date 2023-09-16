﻿//
// MapiAccess.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
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
// ReSharper disable InconsistentNaming

namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains a bitmask of flags indicating the operations that are available to the client for the object.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc979218.aspx
    ///     This property is read-only for the client. It must be a bitwise OR of zero or more values from the following table.
    /// </remarks>
    [Flags]
    public enum MapiAccess : uint
    {
        /// <summary>
        ///     Write
        /// </summary>
        MAPI_ACCESS_MODIFY = 0x00000001,

        /// <summary>
        ///     Read
        /// </summary>
	    MAPI_ACCESS_READ = 0x00000002,

        /// <summary>
        ///     Delete
        /// </summary>
        MAPI_ACCESS_DELETE = 0x00000004,

        /// <summary>
        ///     Create subfolders in the folder hierarchy
        /// </summary>
        MAPI_ACCESS_CREATE_HIERARCHY = 0x00000008,

        /// <summary>
        ///     Create content messages
        /// </summary>
        MAPI_ACCESS_CREATE_CONTENTS = 0x00000010,

        /// <summary>
        ///     Create associated content messages
        /// </summary>
        MAPI_ACCESS_CREATE_ASSOCIATED = 0x00000020
    }
}

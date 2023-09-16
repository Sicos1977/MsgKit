﻿// ReSharper disable InconsistentNaming

//
// AttachmentType.cs
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

namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains a bitmask of flags for an attachment.
    /// </summary>
    /// <remarks>
    ///     See https://docs.microsoft.com/en-us/previous-versions/office/developer/office-2007/cc765876(v=office.12)
    /// </remarks>
    public enum AttachmentFlags : uint
    {
        /// <summary>
        ///     Indicates that this attachment is not available to HTML rendering applications and should be ignored in
        ///     Multipurpose Internet Mail Extensions (MIME) processing.
        /// </summary>
        ATT_INVISIBLE_IN_HTML = 0x00000001,

        /// <summary>
        ///     Indicates that this attachment is not available to applications rendering in Rich Text Format (RTF) and should be
        ///     ignored by MAPI.
        /// </summary>
        ATT_INVISIBLE_IN_RTF = 0x00000002,

        /// <summary>
        ///     The Attachment object is referenced and rendered within the HTML body of the associated Message object.
        /// </summary>
        ATT_MHTML_REF = 0x00000004
    }
}
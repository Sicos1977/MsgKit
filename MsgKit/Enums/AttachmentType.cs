// ReSharper disable InconsistentNaming

//
// AttachmentType.cs
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

namespace MsgKit.Enums
{
    /// <summary>
    ///     The type of the attachment
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc815439.aspx
    /// </remarks>
    public enum AttachmentType : uint
    {
        /// <summary>
        ///     There is no attachment
        /// </summary>
        NO_ATTACHMENT = 0x00000000,

        /// <summary>
        ///     The  <see cref="PropertyTags.PR_ATTACH_DATA_BIN" /> property contains the attachment data
        /// </summary>
        ATTACH_BY_VALUE = 0x00000001,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment to recipients with access to a common file server
        /// </summary>
        ATTACH_BY_REFERENCE = 0x0002,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment
        /// </summary>
        ATTACH_BY_REF_RESOLVE = 0x0003,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment
        /// </summary>
        ATTACH_BY_REF_ONLY = 0x0004,

        /// <summary>
        ///     The  <see cref="PropertyTags.PR_ATTACH_DATA_OBJ" /> (PidTagAttachDataObject) property contains an embedded object
        ///     that supports the IMessage interface
        /// </summary>
        ATTACH_EMBEDDED_MSG = 0x0005,

        /// <summary>
        ///     The attachment is an embedded OLE object
        /// </summary>
        ATTACH_OLE = 0x0006,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" /> property contains a fully qualified path identifying the attachment.
        ///     The <see cref="PropertyTags.PR_NAME_A" /> PidNameAttachmentProviderType defines the web service API manipulating the attachment.
        /// </summary>
        ATTACH_BY_WEB_REFERENCE = 0x0007
    }
}
//
// MapiObjectType.cs
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

// ReSharper disable InconsistentNaming

namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains the type of an object.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc815487.aspx
    ///     The object type contained in this property corresponds to the primary interface available for an object accessible
    ///     through the OpenEntry interface. It is usually obtained by consulting the lpulObjType parameter returned by the
    ///     appropriate OpenEntry method. When the interface is obtained in other ways, call IMAPIProp::GetProps to obtain the
    ///     value for this property.
    /// </remarks>
    [Flags]
    public enum MapiObjectType : uint
    {
        /// <summary>
        ///     Address book container object
        /// </summary>
        MAPI_ABCONT = 4,
        
        /// <summary>
        ///     Address book object
        /// </summary>
        MAPI_ADDRBOOK = 2,
        
        /// <summary>
        ///     Message attachment object
        /// </summary>
        MAPI_ATTACH = 7,

        /// <summary>
        ///     Distribution list object
        /// </summary>
        MAPI_DISTLIST = 8,

        /// <summary>
        ///     Folder object
        /// </summary>
        MAPI_FOLDER = 3,

        /// <summary>
        ///     Form object
        /// </summary>
        MAPI_FORMINFO = 12,

        /// <summary>
        ///     Messaging user object
        /// </summary>
        MAPI_MAILUSER = 6,

        /// <summary>
        ///     Message object
        /// </summary>
        MAPI_MESSAGE = 5,

        /// <summary>
        ///     Profile section object
        /// </summary>
        MAPI_PROFSECT = 9,

        /// <summary>
        ///     Session object
        /// </summary>
        MAPI_SESSION = 11,

        /// <summary>
        ///     Status object
        /// </summary>
        MAPI_STATUS = 10,

        /// <summary>
        ///     Message store object
        /// </summary>
        MAPI_STORE = 1
    }
}
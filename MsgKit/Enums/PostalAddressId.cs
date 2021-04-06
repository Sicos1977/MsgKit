// ReSharper disable InconsistentNaming

//
// PostalAddressId.cs
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
    ///     Specifies which physical address is the contact's mailing address
    /// </summary>
    /// <remarks>
    ///     See https://docs.microsoft.com/en-us/office/client-developer/outlook/mapi/pidlidpostaladdressid-canonical-property
    /// </remarks>
    public enum PostalAddressId : uint
    {
        /// <summary>
        ///     No address is selected as the mailing address
        /// </summary>
        NO_ADDRESS = 0x00000000,

        /// <summary>
        ///     The Home Address is the mailing address
        /// </summary>
        HOME_ADDRESS = 0x00000001,

        /// <summary>
        ///     The Work Address is the mailing address.
        /// </summary>
        WORK_ADDRESS = 0x00000002,

        /// <summary>
        ///     The Other Address is the mailing address
        /// </summary>
        OTHER_ADDRESS = 0x00000003,
    }
}

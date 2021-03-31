//
// RecipientRowAddressType.cs
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

using MsgKit.Structures;

namespace MsgKit.Enums
{
    /// <summary>
    ///     The <see cref="RecipientRow.RecipientRowDisplayType" />
    /// </summary>
    public enum RecipientRowAddressType
    {
        /// <summary>
        ///     No type is set
        /// </summary>
        NoType = 0x0,

        /// <summary>
        ///     X500DN
        /// </summary>
        X500Dn = 0x1,

        /// <summary>
        ///     Ms mail
        /// </summary>
        MsMail = 0x2,

        /// <summary>
        ///     SMTP
        /// </summary>
        Smtp = 0x3,

        /// <summary>
        ///     Fax
        /// </summary>
        Fax = 0x4,

        /// <summary>
        ///     Professional office system
        /// </summary>
        ProfessionalOfficeSystem = 0x5,

        /// <summary>
        ///     Personal distribution list 1
        /// </summary>
        PersonalDistributionList1 = 0x6,

        /// <summary>
        ///     Personal distribution list 2
        /// </summary>
        PersonalDistributionList2 = 0x7
    }
}
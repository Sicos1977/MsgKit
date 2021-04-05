//
// ContactWork.cs
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

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace MsgKit
{
    /// <summary>
    ///     Placeholder for a <see cref="Contact"/> work address
    /// </summary>
    public class ContactWork : ContactCommon
    {
        #region Properties
        /// <summary>
        ///     The way the work address is displayed in the contact card<br/>
        ///     Some Street<br/>
        ///     Zip code Place<br/>
        ///     Some land<br/>
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     The post office box for the address
        /// </summary>
        public string PostOfficeBox { get; set; }

        /// <summary>
        ///     The country code for the address
        /// </summary>
        public string CountryCode { get; set; }
        #endregion
    }
}

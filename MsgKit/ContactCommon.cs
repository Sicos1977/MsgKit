//
// ContactCommon.cs
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
    ///     A placeholder for the <see cref="ContactWork"/>, <see cref="ContactOther"/> and <see cref="ContactBusiness"/> common properties
    /// </summary>
    public class ContactCommon
    {
        #region Properties
        /// <summary>
        ///     The street for the address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///     The country for the address
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     The postal code for the address
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     The city for the address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     The telephone number
        /// </summary>
        public string TelephoneNumber { get; set; }
        #endregion
    }
}

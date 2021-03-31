//
// AddressBookEntryIdType.cs
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
    ///     An integer representing the type of the object. It MUST be one of the values from the following table.
    /// </summary>
    public enum AddressBookEntryIdType
    {
        /// <summary>
        /// A local mail user
        /// </summary>
        LocalMailUser = 0x00000000,

        /// <summary>
        /// A distribution list
        /// </summary>
        DistributionList = 0x00000001,

        /// <summary>
        /// A bulletinboard or public folder
        /// </summary>
        BulletinBoardOrPublicFolder = 0x00000002,

        /// <summary>
        /// An automated mailbox
        /// </summary>
        AutomatedMailBox = 0x00000003,

        /// <summary>
        /// An organiztional mailbox
        /// </summary>
        OrganizationalMailBox = 0x00000004,

        /// <summary>
        /// A private distribtion list
        /// </summary>
        PrivateDistributionList = 0x00000005,

        /// <summary>
        /// A remote mail user
        /// </summary>
        RemoteMailUser = 0x00000006,

        /// <summary>
        /// A container
        /// </summary>
        Container = 0x00000100,

        /// <summary>
        /// A template
        /// </summary>
        Template = 0x00000101,

        /// <summary>
        /// One off user
        /// </summary>
        OneOffUser = 0x00000102,

        /// <summary>
        /// Search
        /// </summary>
        Search = 0x00000200
    }
}
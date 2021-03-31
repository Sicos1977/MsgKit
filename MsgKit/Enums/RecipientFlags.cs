//
// RecipientFlags.cs
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

namespace MsgKit.Enums
{
    /// <summary>
    ///     Specifies a bit field that describes the recipient status.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc815629.aspx
    /// </remarks>
    [Flags]
    public enum RecipientFlags : uint
    {
        /// <summary>
        ///     The recipient is a Sendable Attendee. This flag is only used in the dispidApptUnsendableRecips
        ///     (PidLidAppointmentUnsendableRecipients) property.
        /// </summary>
        RecipSendable = 0x00000001,

        /// <summary>
        ///     The RecipientRow on which this flag is set represents the meeting Organizer.
        /// </summary>
        RecipOrganizer = 0x0000002,

        /// <summary>
        ///     Indicates that the attendee gave a response for the exception on which this RecipientRow resides. This flag is only
        ///     used in a RecipientRow of an exception embedded message object of the organizer’s meeting object.
        /// </summary>
        RecipExceptionalResponse = 0x00000010,

        /// <summary>
        ///     Indicates that although the RecipientRow exists, it should be treated as if the corresponding recipient does not.
        ///     This flag is only used in a RecipientRow of an exception embedded message object of the organizer’s meeting object.
        /// </summary>
        RecipExceptionalDeleted = 0x00000020,

        /// <summary>
        ///     Indicates the recipient is an original attendee. This flag is only used in the dispidApptUnsendableRecips property.
        /// </summary>
        RecipOriginal = 0x00000100
    }
}
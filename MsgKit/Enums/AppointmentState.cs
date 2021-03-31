// ReSharper disable InconsistentNaming

//
// AppointmentState.cs
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
    ///     Valid values for the <see cref="NamedPropertyTags.PidLidAppointmentStateFlags "/> property
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc815362(v=office.15).aspx
    /// </remarks>
    public enum AppointmentState : uint
    {
        /// <summary>
        ///     This flag indicates that the object is a meeting object or a meeting-related object.
        /// </summary>
        asfMeeting = 0x00000001,

        /// <summary>
        ///     This flag indicates that the represented object was received from someone else.
        /// </summary>
        asfReceived = 0x00000002,

        /// <summary>
        ///     This flag indicates that the meeting object represented by the object has been canceled.
        /// </summary>
        asfCanceled = 0x00000004,

        /// <summary>
        ///     Full update.
        /// </summary>
        mtgInfo = 0x00020000,

        /// <summary>
        ///     A newer meeting request or meeting update was received after this one.
        /// </summary>
        mtgOutOfDate = 0x00080000,

        /// <summary>
        ///     This is set on the delegator’s copy when a delegate handles meeting-related objects.
        /// </summary>
        mtgDelegatorCopy = 0x00100000
    }
}
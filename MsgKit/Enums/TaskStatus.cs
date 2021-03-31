// ReSharper disable InconsistentNaming

//
// TaskAcceptanceState.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com> and Nicolas Fournier <nic_rf@hotmail.com>
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
    ///     Valid values for the <see cref="NamedPropertyTags.PidLidTaskStatus" /> property
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee159828(v=exchg.80).aspx
    /// </remarks>
    public enum TaskStatus : uint
    {
        /// <summary>
        ///     The user has not started work on the Task object. If the property is set to this value, the value of the
        ///     PidLidPercentComplete property (section 2.2.2.2.3) MUST be 0.0.
        /// </summary>
        NotStarted = 0x00000000,

        /// <summary>
        ///     The user's work on this Task object is in progress. If the property is set to this value, the value of the
        ///     PidLidPercentComplete property MUST be greater than 0.0 and less than 1.0.
        /// </summary>
        InProgress = 0x00000001,

        /// <summary>
        ///     The user's work on this Task object is complete. If the property is set to this value, the value of the
        ///     PidLidPercentComplete property MUST be 1.0, the value of the PidLidTaskDateCompleted property (section 2.2.2.2.9)
        ///     MUST be the current date, and the value of the PidLidTaskComplete property (section 2.2.2.2.20) MUST be 0x01.
        /// </summary>
        Completed = 0x00000002,

        /// <summary>
        ///     The user is waiting on somebody else.
        /// </summary>
        Waiting = 0x00000003,

        /// <summary>
        ///     The user has deferred work on the Task object.
        /// </summary>
        Deferred = 0x00000004
    }
}
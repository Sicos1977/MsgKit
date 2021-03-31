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
    ///     Valid values for the <see cref="NamedPropertyTags.PidLidTaskState" /> property
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc765590(v=office.12).aspx
    /// </remarks>
    public enum TaskState : uint
    {
        /// <summary>
        ///     This task was created to correspond to a task that was embedded in a task rejection but could not be found locally.
        /// </summary>
        NotFound = 0x00000000,

        /// <summary>
        ///     The task is not assigned.
        /// </summary>
        NotAssigned = 0x00000001,

        /// <summary>
        ///     The task is the task assignee’s copy of an assigned task.
        /// </summary>
        AssigneeCopy = 0x00000002,

        /// <summary>
        ///     The task is the task assigner’s copy of an assigned task.
        /// </summary>
        AssignerCopy = 0x00000003,

        /// <summary>
        ///     The task is the task assigner’s copy of a rejected task.
        /// </summary>
        AssignerCopyRejected = 0x00000004
    }
}
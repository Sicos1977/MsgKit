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
    ///     Valid values for the <see cref="NamedPropertyTags.PidLidTaskOwnership" /> property
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee204243(v=EXCHG.80).aspx
    /// </remarks>
    public enum TaskOwnership : uint
    {
        /// <summary>
        ///     The Task object is not assigned.
        /// </summary>
        NotAssigned = 0x00000000,

        /// <summary>
        ///     The Task object is the task assigner's copy of the Task object.
        /// </summary>
        Assigner = 0x00000001,

        /// <summary>
        ///     The Task object is the task assignee's copy of the Task object.
        /// </summary>
        Assignee = 0x00000002
    }
}
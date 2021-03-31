//
// MessagePriority.cs
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

// ReSharper disable InconsistentNaming
namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains a value that indicates the message sender's opinion of the importance of a message. 
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc765646(v=office.15).aspx
    /// </remarks>
    public enum MessagePriority
    {
        /// <summary>
        ///     The message is not urgent.
        /// </summary>
        PRIO_NONURGENT = 0,

        /// <summary>
        ///     The message has normal priority.
        /// </summary>
        PRIO_NORMAL = 1,

        /// <summary>
        ///     The message is urgent.
        /// </summary>
        PRIO_URGENT = 2
    }
}
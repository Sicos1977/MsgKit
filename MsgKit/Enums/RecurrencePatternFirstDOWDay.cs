//
// RecurrencePatternFirstDOWDay.cs
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
    /// An integer that specifies the day on which the calendar week begins. The default value is Sunday (0x00000000). 
    /// This field MUST be set to one of the values listed in the following table.
    /// </summary>
    /// <remarks>
    /// See https://msdn.microsoft.com/en-us/library/ee203303(v=exchg.80).aspx
    /// </remarks>
    public enum RecurrencePatternFirstDOWDay
    {
        /// <summary>
        /// Sunday
        /// </summary>
        Sunday = 0x00000000,

        /// <summary>
        /// Monday
        /// </summary>
        Monday = 0x00000001,

        /// <summary>
        /// Tuesday
        /// </summary>
        Tuesday = 0x00000002,

        /// <summary>
        /// Wednesday
        /// </summary>
        Wednesday = 0x00000003,

        /// <summary>
        /// Thursday
        /// </summary>
        Thursday = 0x00000004,

        /// <summary>
        /// Friday
        /// </summary>
        Friday = 0x00000005,

        /// <summary>
        /// Saterday
        /// </summary>
        Saturday = 0x00000006
    }
}

//
// RecurrencePatternPatternType.cs
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
    ///     PatternType (2 bytes): An integer that specifies the type of recurrence pattern. The valid recurrence pattern types
    ///     are listed in the following table.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee203303(v=exchg.80).aspx
    /// </remarks>
    public enum RecurrencePatternPatternType
    {
        /// <summary>
        ///     The event has a daily recurrence.
        /// </summary>
        Day = 0x0000,

        /// <summary>
        ///     The event has a weekly recurrence.
        /// </summary>
        Week = 0x0001,

        /// <summary>
        ///     The event has a monthly recurrence.
        /// </summary>
        Month = 0x0002,

        /// <summary>
        ///     The event has a month-end recurrence.
        /// </summary>
        MonthEnd = 0x0004,

        /// <summary>
        ///     The event has an every nth month pattern.
        /// </summary>
        MonthNth = 0x0003,

        /// <summary>
        ///     The event has a monthly recurrence in the Hijri calendar. For this value in the PatternType field, the value of the
        ///     CalendarType field MUST be set to 0x0000.
        /// </summary>
        HjMonth = 0x0000A,

        /// <summary>
        ///     The event has an every nth month pattern in the Hijri calendar. For this value in the PatternType field, the value
        ///     of the CalendarType field MUST be set to 0x0000.
        /// </summary>
        HjMonthNth = 0x000B,

        /// <summary>
        ///     The event has a month end recurrence in the Hijri calendar. For this value in the PatternType field, the value of
        ///     the CalendarType field MUST be set to 0x0000.
        /// </summary>
        HjMonthEnd = 0x000C
    }
}
//
// RecurrencePatternCalendarType.cs
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
    ///     An integer that specifies the type of calendar that is used. The acceptable values for the calendar type are listed
    ///     in the following table.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee203303(v=exchg.80).aspx
    /// </remarks>
    public enum RecurrencePatternCalendarType
    {
        /// <summary>
        ///     The default value for the calendar type is Gregorian.
        ///     If the value of the PatternType field is HjMonth, HjMonthNth, or HjMonthEnd and the value of the CalendarType field
        ///     is Default, this recurrence uses the Hijri calendar.
        /// </summary>
        Default = 0x0000,

        /// <summary>
        ///     Gregorian (localized) calendar
        /// </summary>
        CAL_GREGORIAN = 0x0001,

        /// <summary>
        ///     Gregorian (U.S.) calendar
        /// </summary>
        CAL_GREGORIAN_US = 0x0002,

        /// <summary>
        ///     Japanese Emperor era calendar
        /// </summary>
        CAL_JAPAN = 0x0003,

        /// <summary>
        ///     Taiwan calendar
        /// </summary>
        CAL_TAIWAN = 0x0004,

        /// <summary>
        ///     Korean Tangun era calendar
        /// </summary>
        CAL_KOREA = 0x0005,

        /// <summary>
        ///     Hijri (Arabic Lunar) calendar
        /// </summary>
        CAL_HIJRI = 0x0006,

        /// <summary>
        ///     Thai calendar
        /// </summary>
        CAL_THAI = 0x0007,

        /// <summary>
        ///     Hebrew lunar calendar
        /// </summary>
        CAL_HEBREW = 0x0008,

        /// <summary>
        ///     Gregorian Middle East French calendar
        /// </summary>
        CAL_GREGORIAN_ME_FRENCH = 0x0009,

        /// <summary>
        ///     Gregorian Arabic calendar
        /// </summary>
        CAL_GREGORIAN_ARABIC = 0x000A,

        /// <summary>
        ///     Gregorian transliterated English calendar
        /// </summary>
        CAL_GREGORIAN_XLIT_ENGLISH = 0x000B,

        /// <summary>
        ///     Gregorian transliterated French calendar
        /// </summary>
        CAL_GREGORIAN_XLIT_FRENCH = 0x000C,

        /// <summary>
        ///     Japanese lunar calendar
        /// </summary>
        CAL_LUNAR_JAPANESE = 0x000E,

        /// <summary>
        ///     Chinese lunar calendar
        /// </summary>
        CAL_CHINESE_LUNAR = 0x000F,

        /// <summary>
        ///     Saka era calendar
        /// </summary>
        CAL_SAKA = 0x0010,

        /// <summary>
        ///     Lunar ETO Chinese calendar
        /// </summary>
        CAL_LUNAR_ETO_CHN = 0x0011,

        /// <summary>
        ///     Lunar ETO Korean calendar
        /// </summary>
        CAL_LUNAR_ETO_KOR = 0x0012,

        /// <summary>
        ///     Lunar Rokuyou calendar
        /// </summary>
        CAL_LUNAR_ROKUYOU = 0x0013,

        /// <summary>
        ///     Korean lunar calendar
        /// </summary>
        CAL_LUNAR_KOREAN = 0x0014,

        /// <summary>
        ///     Um Al Qura calendar
        /// </summary>
        CAL_UMALQURA = 0x0017
    }
}
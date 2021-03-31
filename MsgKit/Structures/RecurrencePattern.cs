//
// RecurrencePattern.cs
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

using System;
using System.IO;
using MsgKit.Enums;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The RecurrencePattern structure specifies a recurrence pattern. The fields of this structure are stored in
    ///     little-endian byte order.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee203303(v=exchg.80).aspx
    /// </remarks>
    public class RecurrencePattern
    {
        #region Properties
        /// <summary>
        ///     <see cref="RecurrencePatternFrequency" />
        /// </summary>
        public RecurrencePatternFrequency RecurFrequency { get; set; }

        /// <summary>
        ///     <see cref="RecurrencePatternPatternType" />
        /// </summary>
        public RecurrencePatternPatternType PatternType { get; set; }

        /// <summary>
        ///     <see cref="RecurrencePatternCalendarType" />
        /// </summary>
        public RecurrencePatternCalendarType CalendarType { get; set; }

        /// <summary>
        ///     An integer that specifies the first ever day, week, or month of a recurring series, dating back to a reference date, which is January 1, 1601, for a Gregorian calendar. The value and its meaning depend on the value of the RecurFrequency field. The value of the FirstDateTime field is used to determine the valid dates of a recurring series, as specified in section 2.2.1.44.1.2.
        /// </summary>
        public DateTime FirstDateTime { get; set; }

        /// <summary>
        ///     An integer that specifies the interval at which the meeting pattern specified in PatternTypeSpecific field repeats.
        ///     The Period value MUST be between 1 and the maximum recurrence interval, which is 999 days for daily recurrences, 99
        ///     weeks for weekly recurrences, and 99 months for monthly recurrences. The following table lists the values for this
        ///     field based on the recurrence frequency, which is specified in the RecurFrequency field.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        ///     TODO: Make structure
        ///     PatternTypeSpecific (variable):  A structure that specifies the details of the recurrence pattern. The structure
        ///     varies according to the value of the PatternType field, as specified in sections 2.2.1.44.1.3, 2.2.1.44.1.4,
        ///     2.2.1.44.1.5, and 2.2.1.44.1.6.
        /// </summary>
        public string PatternTypeSpecific { get; set; }

        /// <summary>
        ///     <see cref="RecurrencePatternRecurrenceRangeType" />
        /// </summary>
        public RecurrencePatternRecurrenceRangeType EndType { get; set; }

        /// <summary>
        ///     An integer that specifies the number of occurrences in a recurrence.
        /// </summary>
        /// <remarks>
        ///     When the EndType of the pattern is "End after date", this value always has to be computed. Although the value of
        ///     this field is always set, its value has no meaning on a recurring series that has no end date. This value can be
        ///     set to 0x0000000A for a recurring series with no end date
        /// </remarks>
        public int OccurenceCount { get; set; }

        /// <summary>
        ///     <see cref="RecurrencePatternFirstDOWDay" />
        /// </summary>
        public RecurrencePatternFirstDOWDay FirstDOW { get; set; }

        /// <summary>
        ///     An integer that specifies the date of the first occurrence. The value is the number of minutes between midnight,
        ///     January 1, 1601, and midnight of the date of the first occurrence.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     An integer that specifies the ending date for the recurrence. The value is the number of minutes between midnight,
        ///     January 1, 1601, and midnight of the date of the last occurrence. When the value of the EndType field is 0x00002022
        ///     (end after n occurrences), this value is calculated based on the number of occurrences If the recurrence does not
        ///     have an end date, the value of the EndDate field MUST be set to 0x5AE980DF.
        /// </summary>
        public DateTime EndDate { get; set; }
        #endregion

        #region ToByteArray
        /// <summary>
        ///     Returns this class as a byte array
        /// </summary>
        internal byte[] ToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                // ReaderVersion (2 bytes):  This field MUST be set to 0x3004.
                binaryWriter.Write((ushort)0x3004);
                // WriterVersion (2 bytes):  This field MUST be set to 0x3004.
                binaryWriter.Write(0x3004);
                // RecurFrequency (2 bytes):  An integer that specifies the frequency of the recurring series
                binaryWriter.Write((ushort)RecurFrequency);
                // PatternType (2 bytes): An integer that specifies the type of recurrence pattern
                binaryWriter.Write((ushort)PatternType);
                //CalendarType (2 bytes): An integer that specifies the type of calendar that is used
                binaryWriter.Write((ushort) CalendarType);
                // FirstDateTime (4 bytes):  An integer that specifies the first ever day, week, or month of a recurring series, dating back to a reference date, which is January 1, 1601, for a Gregorian calendar. The value and its meaning depend on the value of the RecurFrequency field. The value of the FirstDateTime field is used to determine the valid dates of a recurring series, as specified in section 2.2.1.44.1.2.
                binaryWriter.Write((int) FirstDateTime.ToFileTime());

                // TODO : Write the rest of the properties https://msdn.microsoft.com/en-us/library/ee203303(v=exchg.80).aspx

                //if (BitConverter.IsLittleEndian)
                //{
                //    bits = bits.Reverse().ToArray();
                //    binaryWriter.Write(bits);
                //}
                //else
                //    binaryWriter.Write(bits);

                //Strings.WriteNullTerminatedUnicodeString(binaryWriter, DisplayName);
                //Strings.WriteNullTerminatedUnicodeString(binaryWriter, AddressTypeString);
                //Strings.WriteNullTerminatedUnicodeString(binaryWriter, Email);

                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}
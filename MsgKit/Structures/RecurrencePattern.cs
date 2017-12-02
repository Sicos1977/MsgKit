//
// RecurrencePattern.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2017 Magic-Sessions. (www.magic-sessions.com)
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
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
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
        ///     <see cref="RecurrencePatternFrequency" />
        /// </summary>
        public RecurrencePatternFrequency FirstDateTime { get; set; }

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
//
// NamedPropertyTags.cs
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

using System;
using MsgKit.Enums;
using MsgKit.Structures;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable InconsistentNaming

namespace MsgKit
{
    /// <summary>
    ///     A class that holds all the known named mapi tags
    /// </summary>
    internal static class NamedPropertyTags
    {
        /// <summary>
        ///     Specifies the date and time at which the meeting-related object was sent
        /// </summary>
        internal static NamedPropertyTag PidLidAttendeeCriticalChange
        {
            get
            {
                return new NamedPropertyTag(0x0001, "PidLidAttendeeCriticalChange",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Contains the value of the PidLidLocation property (section 2.159) from the associated
        ///     Meeting object.
        /// </summary>
        internal static NamedPropertyTag PidLidWhere
        {
            get
            {
                return new NamedPropertyTag(0x002, "PidLidWhere", new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"),
                    PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Contains the value of the PidLidGlobalObjectId property (section 2.142) for an object
        ///     that represents an Exception object to a recurring series, where the Year, Month, and Day fields are
        ///     all zero.
        /// </summary>
        internal static NamedPropertyTag PidLidGlobalObjectId
        {
            get
            {
                return new NamedPropertyTag(0x0003, "PidLidGlobalObjectId",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_BINARY);
            }
        }

        /// <summary>
        ///     Indicates whether the user did not include any text in the body of the Meeting Response
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidIsSilent
        {
            get
            {
                return new NamedPropertyTag(0x004, "PidLidIsSilent", new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"),
                    PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Specifies whether the object is associated with a recurring series.
        /// </summary>
        internal static NamedPropertyTag PidLidIsRecurring
        {
            get
            {
                return new NamedPropertyTag(0x0005, "PidLidIsRecurring",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Identifies required attendees for the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidRequiredAttendees
        {
            get
            {
                return new NamedPropertyTag(0x0006, "PidLidRequiredAttendees",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies optional attendees.
        /// </summary>
        internal static NamedPropertyTag PidLidOptionalAttendees
        {
            get
            {
                return new NamedPropertyTag(0x0007, "PidLidOptionalAttendees",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Identifies resource attendees for the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidResourceAttendees
        {
            get
            {
                return new NamedPropertyTag(0x0008, "PidLidResourceAttendees",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Indicates whether a delegate responded to the meeting request.
        /// </summary>
        internal static NamedPropertyTag PidLidDelegateMail
        {
            get
            {
                return new NamedPropertyTag(0x0009, "PidLidDelegateMail",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Indicates whether the object represents an exception (including an orphan instance).
        /// </summary>
        internal static NamedPropertyTag PidLidIsException
        {
            get
            {
                return new NamedPropertyTag(0x000A, "PidLidIsException",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Deprecated
        /// </summary>
        internal static NamedPropertyTag PidLidSingleInvite
        {
            get
            {
                return new NamedPropertyTag(0x000B, "PidLidSingleInvite",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Contains a stream that maps to the persisted format of a TZREG structure, which describes the time zone to be used
        ///     for the start and end time of a recurring appointment or meeting request.
        /// </summary>
        internal static NamedPropertyTag PidLidTimeZone
        {
            get
            {
                return new NamedPropertyTag(0x8233, "PidLidTimeZone", new Guid("6ED8DA90-450B-101B-98DA-00AA003F130"),
                    PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Identifies the start date of the recurrence pattern.
        /// </summary>
        internal static NamedPropertyTag PidLidStartRecurrenceDate
        {
            get
            {
                return new NamedPropertyTag(0x000D, "PidLidStartRecurrenceDate",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Identifies the start time of the recurrence pattern.
        /// </summary>
        internal static NamedPropertyTag PidLidStartRecurrenceTime
        {
            get
            {
                return new NamedPropertyTag(0x0003, "PidLidStartRecurrenceTime",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Identifies the end date of the recurrence range
        /// </summary>
        internal static NamedPropertyTag PidLidEndRecurrenceDate
        {
            get
            {
                return new NamedPropertyTag(0x000F, "PidLidEndRecurrenceDate",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Identifies the end time of the recurrence range.
        /// </summary>
        internal static NamedPropertyTag PidLidEndRecurrenceTime
        {
            get
            {
                return new NamedPropertyTag(0x0001, "PidLidEndRecurrenceTime",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Identifies the day interval for the recurrence pattern.
        /// </summary>
        internal static NamedPropertyTag PidLidDayInterval
        {
            get
            {
                return new NamedPropertyTag(0x0011, "PidLidDayInterval",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SHORT);
            }
        }

        /// <summary>
        ///     Identifies the number of weeks that occur between each meeting
        /// </summary>
        internal static NamedPropertyTag PidLidWeekInterval
        {
            get
            {
                return new NamedPropertyTag(0x0012, "PidLidWeekInterval",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SHORT);
            }
        }

        /// <summary>
        ///     Indicates the monthly interval of the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidMonthInterval
        {
            get
            {
                return new NamedPropertyTag(0x0013, "PidLidMonthInterval",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SHORT);
            }
        }

        /// <summary>
        ///     Indicates the monthly interval of the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidYearInterval
        {
            get
            {
                return new NamedPropertyTag(0x0014, "PidLidYearInterval",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SHORT);
            }
        }

        /// <summary>
        /// </summary>
        internal static NamedPropertyTag PidLidMonthOfYearMask
        {
            get
            {
                return new NamedPropertyTag(0x0017, "PidLidMonthOfYearMask",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Indicates the month of the year in which the appointment or meeting occurs.
        /// </summary>
        internal static NamedPropertyTag PidLidOldRecurrenceType
        {
            get
            {
                return new NamedPropertyTag(0x0018, "PidLidOldRecurrenceType",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SHORT);
            }
        }

        /// <summary>
        ///     Specifies the date and time at which a Meeting Request object was sent by the
        ///     organizer.
        /// </summary>
        internal static NamedPropertyTag PidLidOwnerCriticalChange
        {
            get
            {
                return new NamedPropertyTag(0x001A, "PidLidOwnerCriticalChange",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Contains the value of the CalendarType field from the PidLidAppointmentRecur
        ///     property(section 2.22).
        /// </summary>
        internal static NamedPropertyTag PidLidCalendarType
        {
            get
            {
                return new NamedPropertyTag(0x001C, "PidLidCalendarType",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Deprecated
        /// </summary>
        internal static NamedPropertyTag PidLidAllAttendeesList
        {
            get
            {
                return new NamedPropertyTag(0x001D, "PidLidAllAttendeesList",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Contains the value of the PidLidGlobalObjectId property (section 2.142) for an object
        ///     that represents an Exception object to a recurring series, where the Year, Month, and Day fields are
        ///     all zero.
        /// </summary>
        internal static NamedPropertyTag PidLidCleanGlobalObjectId
        {
            get
            {
                return new NamedPropertyTag(0x0023, "PidLidCleanGlobalObjectId",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_BINARY);
            }
        }

        /// <summary>
        ///     Indicates the message class of the Meeting object to be generated from the Meeting
        ///     Request object.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentMessageClass
        {
            get
            {
                return new NamedPropertyTag(0x0024, "PidLidAppointmentMessageClass",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        /// </summary>
        internal static NamedPropertyTag PidLidMeetingType
        {
            get
            {
                return new NamedPropertyTag(0x0026, "PidLidMeetingType",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Indicates the type of Meeting Request object or Meeting Update object.
        /// </summary>
        internal static NamedPropertyTag PidLidOldLocation
        {
            get
            {
                return new NamedPropertyTag(0x0028, "PidLidOldLocation",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Indicates the original value of the PidLidAppointmentStartWhole property (section2.29) before a meeting update.
        /// </summary>
        internal static NamedPropertyTag PidLidOldWhenStartWhole
        {
            get
            {
                return new NamedPropertyTag(0x0029, "PidLidOldWhenStartWhole",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Indicates the original value of the PidLidAppointmentEndWhole property (section2.14) before a meeting update.
        /// </summary>
        internal static NamedPropertyTag PidLidOldWhenEndWhole
        {
            get
            {
                return new NamedPropertyTag(0x002A, "PidLidOldWhenStartWhole",
                    new Guid("6ED8DA90-450B-101B-98DA-00AA003F1305"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Specifies the name under which to file a contact when displaying a list of contacts.
        /// </summary>
        internal static NamedPropertyTag PidLidFileUnder
        {
            get
            {
                return new NamedPropertyTag(0x8005, "PidLidFileUnder", new Guid("00062004-0000-0000-C000-000000000046"),
                    PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies how to generate and recompute the value of the PidLidFileUnder property
        ///     (section 2.132) when other contact name properties change.
        /// </summary>
        internal static NamedPropertyTag PidLidFileUnderId
        {
            get
            {
                return new NamedPropertyTag(0x8006, "PidLidFileUnderId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the visible fields in the application's user interface that are used to help display
        ///     the contact information.
        /// </summary>
        internal static NamedPropertyTag PidLidContactItemData
        {
            get
            {
                return new NamedPropertyTag(0x8007, "PidLidContactItemData",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_MV_LONG);
            }
        }

        /// <summary>
        ///     Deprecated
        /// </summary>
        internal static NamedPropertyTag PidLidReferredBy
        {
            get
            {
                return new NamedPropertyTag(0x800E, "PidLidReferredBy", new Guid("00062004-0000-0000-C000-000000000046"),
                    PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     This property is ignored by the server and is set to an empty string by the client
        /// </summary>
        internal static NamedPropertyTag PidLidDepartment
        {
            get
            {
                return new NamedPropertyTag(0x8010, "PidLidDepartment", new Guid("00062004-0000-0000-C000-000000000046"),
                    PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies whether the attachment has a picture.
        /// </summary>
        internal static NamedPropertyTag PidLidHasPicture
        {
            get
            {
                return new NamedPropertyTag(0x8015, "PidLidHasPicture", new Guid("00062004-0000-0000-C000-000000000046"),
                    PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     The PidLidSmartNoAttach property ([MS-OXPROPS] section 2.301) is set to TRUE (0x01)
        ///     if the Message object has no attachments that are visible to the end user. If this
        ///     property is unset, a default value of FALSE (0x00) is used
        /// </summary>
        internal static NamedPropertyTag PidLidSmartNoAttach
        {
            get
            {
                return new NamedPropertyTag(0x8514, "PidLidSmartNoAttach", new Guid("00062008-0000-0000-C000-000000000046"),
                    PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Specifies the complete address of the home address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidHomeAddress
        {
            get
            {
                return new NamedPropertyTag(0x801A, "PidLidHomeAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the complete address of the work address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddress
        {
            get
            {
                return new NamedPropertyTag(0x801B, "PidLidWorkAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the complete address of the contact’s other address.
        /// </summary>
        internal static NamedPropertyTag PidLidOtherAddress
        {
            get
            {
                return new NamedPropertyTag(0x801C, "PidLidOtherAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies which physical address is the contact's mailing address..
        /// </summary>
        internal static NamedPropertyTag PidLidPostalAddressId
        {
            get
            {
                return new NamedPropertyTag(0x8022, "PidLidPostalAddressId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the character set used for this contact.
        /// </summary>
        internal static NamedPropertyTag PidLidContactCharacterSet
        {
            get
            {
                return new NamedPropertyTag(0x8023, "PidLidContactCharacterSet",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the character set used for a Contact object.
        /// </summary>
        internal static NamedPropertyTag PidLidAutoLog
        {
            get
            {
                return new NamedPropertyTag(0x8025, "PidLidAutoLog", new Guid("00062004-0000-0000-C000-000000000046"),
                    PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Specifies a list of possible values for the PidLidFileUnderId property (section 2.133)
        /// </summary>
        internal static NamedPropertyTag PidLidFileUnderList
        {
            get
            {
                return new NamedPropertyTag(0x8026, "PidLidFileUnderList",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_MV_LONG);
            }
        }

        /// <summary>
        ///     The value of this property is ignored.
        /// </summary>
        internal static NamedPropertyTag PidLidEmailList
        {
            get
            {
                return new NamedPropertyTag(0x8027, "PidLidEmailList",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_MV_LONG);
            }
        }

        /// <summary>
        ///     Specifies which electronic address properties are set on the Contact object.
        /// </summary>
        internal static NamedPropertyTag PidLidAddressBookProviderEmailList
        {
            get
            {
                return new NamedPropertyTag(0x8028, "PidLidAddressBookProviderEmailList", 
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_MV_LONG);
            }
        }

        /// <summary>
        /// </summary>
        internal static NamedPropertyTag PidLidAddressBookProviderArrayType
        {
            get
            {
                return new NamedPropertyTag(0x8029, "PidLidAddressBookProviderArrayType", 
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the state of the electronic addresses of the contact and represents a set of bit
        ///     flags.
        /// </summary>
        internal static NamedPropertyTag PidLidHtml
        {
            get { return new NamedPropertyTag(0x802B, "PidLidHtml", new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the phonetic pronunciation of the given name of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidYomiFirstName
        {
            get { return new NamedPropertyTag(0x802C, "PidLidYomiFirstName", new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the phonetic pronunciation of the surname of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidYomiLastName
        {
            get { return new NamedPropertyTag(0x802D, "PidLidYomiLastName", new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the phonetic pronunciation of the company name of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidYomiCompanyName
        {
            get { return new NamedPropertyTag(0x802E, "PidLidYomiCompanyName", new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains user customization details for displaying a contact as a business card.
        /// </summary>
        internal static NamedPropertyTag PidLidBusinessCardDisplayDefinition
        {
            get
            {
                return new NamedPropertyTag(0x8040, "PidLidBusinessCardDisplayDefinition",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY);
            }
        }

        /// <summary>
        ///     Contains the image to be used on a business card.
        /// </summary>
        internal static NamedPropertyTag PidLidBusinessCardCardPicture
        {
            get
            {
                return new NamedPropertyTag(0x8041, "PidLidBusinessCardCardPicture",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY);
            }
        }

        /// <summary>
        ///     Specifies the street portion of the work address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddressStreet
        {
            get
            {
                return new NamedPropertyTag(0x8045, "PidLidWorkAddressStreet",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the city or locality portion of the work address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddressCity
        {
            get
            {
                return new NamedPropertyTag(0x8046, "PidLidWorkAddressCity",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        /// Specifies the postal code (ZIP code) portion of the work address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddressPostalCode
        {
            get
            {
                return new NamedPropertyTag(0x8048, "PidLidWorkAddressPostalCode",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the country code portion of the work address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddressCountry
        {
            get
            {
                return new NamedPropertyTag(0x8049, "PidLidWorkAddressCountry",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///      Specifies the post office box portion of the contact's work address.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddressPostOfficeBox
        {
            get
            {
                return new NamedPropertyTag(0x804A, "PidLidWorkAddressPostOfficeBox",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the 32-bit cyclic redundancy check (CRC) polynomial checksum, as
        ///     specified in [ISO/IEC8802-3], calculated on the value of the PidLidDistributionListMembers
        ///     property(section 2.96).
        /// </summary>
        internal static NamedPropertyTag PidLidDistributionListChecksum
        {
            get
            {
                return new NamedPropertyTag(0x804C, "PidLidDistributionListChecksum",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the EntryID of an optional Appointment object that represents the birthday of
        ///     the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidBirthdayEventEntryId
        {
            get { return new NamedPropertyTag(0x804D, "PidLidBirthdayEventEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies the EntryID of the Appointment object that represents an anniversary of
        ///     the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidAnniversaryEventEntryId
        {
            get
            {
                return new NamedPropertyTag(0x804E, "PidLidAnniversaryEventEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY);
            }
        }

        /// <summary>
        ///     Contains text used to add custom text to a business card representation of a Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidContactUserField1
        {
            get
            {
                return new NamedPropertyTag(0x804F, "PidLidContactUserField1",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Contains text used to add custom text to a business card representation of a Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidContactUserField2
        {
            get
            {
                return new NamedPropertyTag(0x8050, "PidLidContactUserField2",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Contains text used to add custom text to a business card representation of a Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidContactUserField3
        {
            get { return new NamedPropertyTag(0x8051, "PidLidContactUserField3",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains text used to add custom text to a business card representation of a Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidContactUserField4
        {
            get
            {
                return new NamedPropertyTag(0x8052, "PidLidContactUserField4",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the name of the personal distribution list.
        /// </summary>
        internal static NamedPropertyTag PidLidDistributionListName
        {
            get
            {
                return new NamedPropertyTag(0x8053, "PidLidDistributionListName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the list of one-off EntryIDs corresponding to the members of the personal
        ///     distribution list.
        /// </summary>
        internal static NamedPropertyTag PidLidDistributionListOneOffMembers
        {
            get
            {
                return new NamedPropertyTag(0x8054, "PidLidDistributionListOneOffMembers",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_MV_BINARY);
            }
        }

        /// <summary>
        ///     Specifies the 32-bit cyclic redundancy check (CRC) polynomial checksum, as
        ///     specified in [ISO/IEC8802-3], calculated on the value of PidLidDistributionListMembers(section 2.91)
        /// </summary>
        internal static NamedPropertyTag PidLidDistributionListMembers
        {
            get
            {
                return new NamedPropertyTag(0x8055, "PidLidDistributionListMembers",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_MV_BINARY);
            }
        }

        /// <summary>
        ///     Specifies the contact's instant messaging address.
        /// </summary>
        internal static NamedPropertyTag PidLidInstantMessagingAddress
        {
            get
            {
                return new NamedPropertyTag(0x8062, "PidLidInstantMessagingAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the list of EntryIds and one-off EntryIds corresponding to the members of
        ///     the personal distribution list.
        /// </summary>
        internal static NamedPropertyTag PidLidDistributionListStream
        {
            get
            {
                return new NamedPropertyTag(0x8064, "PidLidDistributionListStream",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the user-readable display name for the email address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail1DisplayName
        {
            get
            {
                return new NamedPropertyTag(0x8080, "PidLidEmail1DisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE);
            }
        }

        /// <summary>
        ///     Specifies the address type of an electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail1AddressType
        {
            get { return new NamedPropertyTag(0x8082, "PidLidEmail1AddressType",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the email address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail1EmailAddress
        {
            get { return new NamedPropertyTag(0x8083, "PidLidEmail1EmailAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the SMTP email address that corresponds to the email address for the Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail1OriginalDisplayName
        {
            get { return new NamedPropertyTag(0x8084, "PidLidEmail1OriginalDisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the EntryID of the object corresponding to this electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail1OriginalEntryId
        {
            get { return new NamedPropertyTag(0x8085, "PidLidEmail1OriginalEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Returns true when the E-mail is stored in RTF format
        /// </summary>
        internal static NamedPropertyTag PidLidEmail1RichTextFormat
        {
            get { return new NamedPropertyTag(0x8086, "PidLidEmail1RichTextFormat",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the user-readable display name for the e-mail address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2DisplayName
        {
            get { return new NamedPropertyTag(0x8090, "PidLidEmail2DisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the EntryID of the object corresponding to this electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2EntryId
        {
            get { return new NamedPropertyTag(0x8091, "PidLidEmail2EntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies the address type of an electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2AddressType
        {
            get { return new NamedPropertyTag(0x8092, "PidLidEmail2AddressType",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the email address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2EmailAddress
        {
            get { return new NamedPropertyTag(0x8093, "PidLidEmail2EmailAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the SMTP email address that corresponds to the email address for the Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2OriginalDisplayName
        {
            get { return new NamedPropertyTag(0x8094, "PidLidEmail2OriginalDisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the EntryID of the object corresponding to this electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2OriginalEntryId
        {
            get { return new NamedPropertyTag(0x8095, "PidLidEmail2OriginalEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Returns true when the E-mail is stored in RTF format
        /// </summary>
        internal static NamedPropertyTag PidLidEmail2RichTextFormat
        {
            get { return new NamedPropertyTag(0x8096, "PidLidEmail2RichTextFormat",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the user-readable display name for the e-mail address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3DisplayName
        {
            get { return new NamedPropertyTag(0x80A0, "PidLidEmail3DisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the EntryID of the object corresponding to this electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3EntryId
        {
            get { return new NamedPropertyTag(0x80A1, "PidLidEmail3EntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies the address type of an electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3AddressType
        {
            get { return new NamedPropertyTag(0x80A2, "PidLidEmail3AddressType",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the email address of the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3EmailAddress
        {
            get { return new NamedPropertyTag(0x80A3, "PidLidEmail3EmailAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the SMTP email address that corresponds to the email address for the Contact
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3OriginalDisplayName
        {
            get { return new NamedPropertyTag(0x80A4, "PidLidEmail3OriginalDisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the EntryID of the object corresponding to this electronic address.
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3OriginalEntryId
        {
            get { return new NamedPropertyTag(0x80A5, "PidLidEmail3OriginalEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Returns true when the E-mail is stored in RTF format
        /// </summary>
        internal static NamedPropertyTag PidLidEmail3RichTextFormat
        {
            get { return new NamedPropertyTag(0x80A6, "PidLidEmail3RichTextFormat",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the string value "FAX".
        /// </summary>
        internal static NamedPropertyTag PidLidFax1AddressType
        {
            get { return new NamedPropertyTag(0x80B2, "PidLidFax1AddressType",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a user-readable display name, followed by the "@" character, followed by a
        ///     fax number.
        /// </summary>
        internal static NamedPropertyTag PidLidFax1EmailAddress
        {
            get { return new NamedPropertyTag(0x80B3, "PidLidFax1EmailAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the same value as PidTagNormalizedSubject (section 2.907).
        /// </summary>
        internal static NamedPropertyTag PidLidFax1OriginalDisplayName
        {
            get { return new NamedPropertyTag(0x80B4, "PidLidFax1OriginalDisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies a one-off EntryId corresponding to this fax address.
        /// </summary>
        internal static NamedPropertyTag PidLidFax1OriginalEntryId
        {
            get { return new NamedPropertyTag(0x80B5, "PidLidFax1OriginalEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the string value "FAX".
        /// </summary>
        internal static NamedPropertyTag PidLidFax2AddressType
        {
            get { return new NamedPropertyTag(0x80C2, "PidLidFax2AddressType",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a user-readable display name, followed by the "@" character, followed by a
        ///     fax number.
        /// </summary>
        internal static NamedPropertyTag PidLidFax2EmailAddress
        {
            get { return new NamedPropertyTag(0x80C3, "PidLidFax2EmailAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the same value as PidTagNormalizedSubject (section 2.907).
        /// </summary>
        internal static NamedPropertyTag PidLidFax2OriginalDisplayName
        {
            get { return new NamedPropertyTag(0x80C4, "PidLidFax2OriginalDisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies a one-off EntryId corresponding to this fax address.
        /// </summary>
        internal static NamedPropertyTag PidLidFax2OriginalEntryId
        {
            get { return new NamedPropertyTag(0x80C5, "PidLidFax2OriginalEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the string value "FAX".
        /// </summary>
        internal static NamedPropertyTag PidLidFax3AddressType
        {
            get { return new NamedPropertyTag(0x80D2, "PidLidFax3AddressType",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a user-readable display name, followed by the "@" character, followed by a
        ///     fax number. 
        /// </summary>
        internal static NamedPropertyTag PidLidFax3EmailAddress
        {
            get { return new NamedPropertyTag(0x80D3, "PidLidFax3EmailAddress",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the same value as PidTagNormalizedSubject (section 2.907).
        /// </summary>
        internal static NamedPropertyTag PidLidFax3OriginalDisplayName
        {
            get { return new NamedPropertyTag(0x80D4, "PidLidFax3OriginalDisplayName",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies a one-off EntryId corresponding to this fax address.
        /// </summary>
        internal static NamedPropertyTag PidLidFax3OriginalEntryId
        {
            get { return new NamedPropertyTag(0x80D5, "PidLidFax3OriginalEntryId",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies a URL path from which a client can retrieve free/busy status information
        ///     for the contact.
        /// </summary>
        internal static NamedPropertyTag PidLidFreeBusyLocation
        {
            get { return new NamedPropertyTag(0x80D8, "PidLidFreeBusyLocation",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the country code portion of the contact's home address.
        /// </summary>
        internal static NamedPropertyTag PidLidHomeAddressCountryCode
        {
            get { return new NamedPropertyTag(0x80DA, "PidLidHomeAddressCountryCode",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Specifies the country code portion of the contact's work address.
        /// </summary>
        internal static NamedPropertyTag PidLidWorkAddressCountryCode
        {
            get { return new NamedPropertyTag(0x80DB, "PidLidWorkAddressCountryCode",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Specifies the country code portion of the contact's other address.
        /// </summary>
        internal static NamedPropertyTag PidLidOtherAddressCountryCode
        {
            get { return new NamedPropertyTag(0x80DC, "PidLidOtherAddressCountryCode",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the birthday of a contact.
        /// </summary>
        internal static NamedPropertyTag PidLidBirthdayLocal
        {
            get { return new NamedPropertyTag(0x80DE, "PidLidBirthdayLocal",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the country code portion of the contact's mailing address.
        /// </summary>
        internal static NamedPropertyTag PidLidAddressCountryCode
        {
            get { return new NamedPropertyTag(0x80DD, "PidLidAddressCountryCode",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the wedding anniversary of the contact, at 0:00 in the client's local time
        ///     zone and it is saved without any time zone conversions.
        /// </summary>
        internal static NamedPropertyTag PidLidWeddingAnniversaryLocal
        {
            get { return new NamedPropertyTag(0x80DF, "PidLidWeddingAnniversaryLocal",
                    new Guid("00062004-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Specifies the status of a task.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskStatus
        {
            get { return new NamedPropertyTag(0x8101, "PidLidTaskStatus",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates whether a time-flagged Message object is completed or not.
        /// </summary>
        internal static NamedPropertyTag PidLidPercentComplete
        {
            get { return new NamedPropertyTag(0x8102, "PidLidPercentComplete",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_DOUBLE); }
        }

        /// <summary>
        ///     Specifies if the task is for a team
        /// </summary>
        internal static NamedPropertyTag PidLidTeamTask
        {
            get { return new NamedPropertyTag(0x8103, "PidLidTeamTask",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///      Specifies the date on which the user expects work on the task to begin.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskStartDate
        {
            get { return new NamedPropertyTag(0x8104, "PidLidTaskStartDate",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Specifies the date by which the user expects work on the task to be complete.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskDueDate
        {
            get { return new NamedPropertyTag(0x8105, "PidLidTaskDueDate",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Indicates whether future instances of recurring tasks need reminders, even though
        ///     <see cref="PidLidReminderSet" />(section 2.220) is 0x00.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskResetReminder
        {
            get { return new NamedPropertyTag(0x8107, "PidLidTaskResetReminder",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates whether a task assignee has replied to a task request for this Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskAccepted
        {
            get { return new NamedPropertyTag(0x8108, "PidLidTaskAccepted",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///      Indicates whether new occurrences remain to be generated.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskDeadOccurrence
        {
            get { return new NamedPropertyTag(0x8109, "PidLidTaskDeadOccurrence",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the date when the user completed work on the task.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskDateCompleted
        {
            get { return new NamedPropertyTag(0x810F, "PidLidTaskDateCompleted",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Indicates the number of minutes that the user actually spent working on a task.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskActualEffort
        {
            get { return new NamedPropertyTag(0x8110, "PidLidTaskActualEffort",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates the number of minutes that the user expects to work on a task.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskEstimatedEffort
        {
            get { return new NamedPropertyTag(0x8111, "PidLidTaskEstimatedEffort",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates which copy is the latest update of a Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskVersion
        {
            get { return new NamedPropertyTag(0x8112, "PidLidTaskVersion",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the current assignment state of the Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskState
        {
            get { return new NamedPropertyTag(0x8113, "PidLidTaskState",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the date and time of the most recent change made to the Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskLastUpdate
        {
            get { return new NamedPropertyTag(0x8115, "PidLidTaskLastUpdate",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a RecurrencePattern structure that provides information about recurring
        ///     tasks.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskRecurrence
        {
            get { return new NamedPropertyTag(0x8116, "PidLidTaskRecurrence",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///      Contains a stack of entries, each representing a task assigner.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskAssigners
        {
            get { return new NamedPropertyTag(0x8117, "PidLidTaskAssigners",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///      Indicates whether the task assignee has been requested to send an e-mail message
        ///     update when the task assignee completes the assigned task.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskStatusOnComplete
        {
            get { return new NamedPropertyTag(0x8119, "PidLidTaskStatusOnComplete",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///      Indicates the type of change that was last made to the Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskHistory
        {
            get { return new NamedPropertyTag(0x811A, "PidLidTaskHistory",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates whether the task assignee has been requested to send a task update when
        ///     the assigned Task object changes.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskUpdates
        {
            get { return new NamedPropertyTag(0x811B, "PidLidTaskUpdates",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates that the task has been completed.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskComplete
        {
            get { return new NamedPropertyTag(0x811C, "PidLidTaskComplete",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates that the Task object was originally created by the action of the current user
        ///     or user agent instead of by the processing of a task request.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskFCreator
        {
            get { return new NamedPropertyTag(0x811E, "PidLidTaskFCreator",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the name of the task owner.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskOwner
        {
            get { return new NamedPropertyTag(0x811F, "PidLidTaskOwner",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Provides optimization hints about the recipients of a Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskMultipleRecipients
        {
            get { return new NamedPropertyTag(0x8120, "PidLidTaskMultipleRecipients",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the name of the user that last assigned the task.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskAssigner
        {
            get { return new NamedPropertyTag(0x8121, "PidLidTaskAssigner",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of the most recent user to have been the task owner.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskLastUser
        {
            get { return new NamedPropertyTag(0x8122, "PidLidTaskLastUser",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Provides an aid to custom sorting of Task objects
        /// </summary>
        internal static NamedPropertyTag PidLidTaskOrdinal
        {
            get { return new NamedPropertyTag(0x8123, "PidLidTaskOrdinal",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Not used. The client can set this property, but it has no impact on the Task-Related
        ///     Objects protocol and is ignored by the server.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskNoCompute
        {
            get { return new NamedPropertyTag(0x8124, "PidLidTaskNoCompute",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the name of the user who most recently assigned the task, or the user to
        ///     whom it was most recently assigned.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskLastDelegate
        {
            get { return new NamedPropertyTag(0x8125, "PidLidTaskLastDelegate",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Indicates whether the task includes a recurrence pattern.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskFRecurring
        {
            get { return new NamedPropertyTag(0x8126, "PidLidTaskFRecurring",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Not used. The client can set this property, but it has no impact on the Task-Related
        ///     Objects protocol and is ignored by the server.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskRole
        {
            get { return new NamedPropertyTag(0x8127, "PidLidTaskRole",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Indicates the role of the current user relative to the Task object.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskOwnership
        {
            get { return new NamedPropertyTag(0x8129, "PidLidTaskOwnership",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     The acceptance state of the task
        /// </summary>
        internal static NamedPropertyTag PidLidAcceptanceState
        {
            get { return new NamedPropertyTag(0x812A, "PidLidAcceptanceState",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates the accuracy of PidLidTaskOwner (section 2.326).
        /// </summary>
        internal static NamedPropertyTag PidLidTaskFFixOffline
        {
            get { return new NamedPropertyTag(0x812C, "PidLidTaskFFixOffline",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     The client can set this property, but it has no impact on the Task-Related Objects
        ///     protocol and is ignored by the server.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskCustomFlags
        {
            get { return new NamedPropertyTag(0x8139, "PidLidTaskCustomFlags",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     The client can set this property, but it has no impact on the Task-Related Objects
        ///     protocol and is ignored by the server.
        /// </summary>
        internal static NamedPropertyTag PidLidTaskMode
        {
            get
            {
                return new NamedPropertyTag(0x8518, "PidLidTaskMode",
                  new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }


        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidTrustRecipientHighlights
        {
            get { return new NamedPropertyTag(0x823E, "PidLidTrustRecipientHighlights",
                    new Guid("00062003-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidSendMeetingAsIcal
        {
            get { return new NamedPropertyTag(0x8200, "PidLidSendMeetingAsIcal",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the sequence number of a Meeting object.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentSequence
        {
            get { return new NamedPropertyTag(0x8201, "PidLidAppointmentSequence",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates the date and time at which the property PidLidAppointmentSequence
        ///     (section 2.25) was last modified.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentSequenceTime
        {
            get { return new NamedPropertyTag(0x8202, "PidLidAppointmentSequence",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Indicates to the organizer the last sequence number that was sent to any attendee.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentLastSequence
        {
            get { return new NamedPropertyTag(0x8203, "PidLidAppointmentSequence",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies a bit field that indicates how the Meeting object has changed.
        /// </summary>
        internal static NamedPropertyTag PidLidChangeHighlight
        {
            get { return new NamedPropertyTag(0x8204, "PidLidChangeHighlight",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the availability of a user for the event described by the object.
        /// </summary>
        internal static NamedPropertyTag PidLidBusyStatus
        {
            get { return new NamedPropertyTag(0x8205, "PidLidBusyStatus",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates that the Exception Embedded Message object has a body that differs from the
        ///     Recurring Calendar object.
        /// </summary>
        internal static NamedPropertyTag PidLidFExceptionalBody
        {
            get { return new NamedPropertyTag(0x8206, "PidLidFExceptionalBody",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies a bit field that describes the auxiliary state of the object.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentAuxiliaryFlags
        {
            get { return new NamedPropertyTag(0x8207, "PidLidAppointmentAuxiliaryFlags",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates whether the value of the <see cref="PidLidLocation"/> property (section 2.159) is set to
        ///     the PidTagDisplayName property(section 2.667).
        /// </summary>
        internal static NamedPropertyTag PidLidLocation
        {
            get { return new NamedPropertyTag(0x8208, "PidLidLocation",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the URL of the Meeting Workspace that is associated with a Calendar object.
        /// </summary>
        internal static NamedPropertyTag PidLidMeetingWorkspaceUrl
        {
            get { return new NamedPropertyTag(0x8209, "PidLidMeetingWorkspaceUrl",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Indicates whether the Meeting Request object represents an exception to a recurring
        ///     series, and whether it was forwarded(even when forwarded by the organizer) rather than being an
        ///     invitation sent by the organizer.
        /// </summary>
        internal static NamedPropertyTag PidLidForwardInstance
        {
            get { return new NamedPropertyTag(0x820A, "PidLidForwardInstance",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates whether the user did not include any text in the body of the Meeting Response
        ///     object.
        /// </summary>
        internal static NamedPropertyTag PidLidLinkedTaskItems
        {
            get { return new NamedPropertyTag(0x820C, "PidLidLinkedTaskItems",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_MV_BINARY); }
        }

        /// <summary>
        ///     Specifies time zone information that indicates the time zone of the
        ///     <see cref="PidLidAppointmentStartWhole"/> property(section 2.29).
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentStartWhole
        {
            get { return new NamedPropertyTag(0x820D, "PidLidAppointmentStartWhole",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }

        }

        /// <summary>
        ///     Specifies time zone information that indicates the time zone of the
        ///     <see cref="PidLidAppointmentEndWhole"/> property(section 2.14).
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentEndWhole
        {
            get { return new NamedPropertyTag(0x820E, "PidLidAppointmentEndWhole",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Identifies the time that the appointment starts.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentStartTime
        {
            get { return new NamedPropertyTag(0x820F, "PidLidAppointmentStartTime",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Indicates the time that the appointment ends.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentEndTime
        {
            get { return new NamedPropertyTag(0x8210, "PidLidAppointmentEndTime",
                    new Guid("00062002-0000-0000-C000-000000000046"),PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Indicates the date that the appointment ends.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentEndDate
        {
            get
            {
                return new NamedPropertyTag(0x8211, "PidLidAppointmentEndDate",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Identifies the date that the appointment starts.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentStartDate
        {
            get
            {
                return new NamedPropertyTag(0x8212, "PidLidAppointmentStartDate",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Specifies the length of the event, in minutes.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentDuration
        {
            get
            {
                return new NamedPropertyTag(0x8213, "PidLidAppointmentDuration",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///      Specifies the color to be used when displaying the Calendar object.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentColor
        {
            get
            {
                return new NamedPropertyTag(0x8214, "PidLidAppointmentColor",
                    new Guid("00062002 -0000-0000-C000-000000"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies whether the event is an all-day event.
        /// </summary>
        /// <remarks>
        ///     This property specifies whether or not the event is an all-day event, as 
        ///     specified by the user. A value of <c>true</c> indicates that the event is an all-day 
        ///     event, in which case the start time and end time must be midnight so that the 
        ///     duration is a multiple of 24 hours and is at least 24 hours. A value of <c>false</c> 
        ///     or the absence of this property indicates the event is not an all-day event. The 
        ///     client or server must not infer the value as TRUE when a user happens to create an 
        ///     event that is 24 hours, even if the event starts and ends at midnight.
        /// </remarks>
        internal static NamedPropertyTag PidLidAppointmentSubType
        {
            get
            {
                return new NamedPropertyTag(0x8215, "PidLidAppointmentSubType",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Contains the value of the CalendarType field from the PidLidAppointmentRecur
        ///     property(section 2.22).
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentRecur
        {
            get
            {
                return new NamedPropertyTag(0x8216, "PidLidAppointmentRecur", new Guid("00062002-0000-0000-C000-000000000046"),
                    PropertyType.PT_BINARY);
            }
        }

        /// <summary>
        ///      Specifies a bit field that describes the state of the object.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentStateFlags
        {
            get
            {
                return new NamedPropertyTag(0x8217, "PidLidAppointmentStateFlags",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the response status of an attendee.
        /// </summary>
        internal static NamedPropertyTag PidLidResponseStatus
        {
            get
            {
                return new NamedPropertyTag(0x8218, "PidLidResponseStatus", new Guid("00062002-0000-0000-C000-000000000046"),
                    PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Specifies the date and time at which the attendee responded to a received meeting
        ///     request or Meeting Update object.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentReplyTime
        {
            get
            {
                return new NamedPropertyTag(0x8220, "PidLidAppointmentReplyTime",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Specifies whether the object represents a recurring series.
        /// </summary>
        internal static NamedPropertyTag PidLidRecurring
        {
            get
            {
                return new NamedPropertyTag(0x8223, "PidLidRecurring", 
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Contains the value of the PidLidBusyStatus property (section 2.47) on the Meeting
        ///     object in the organizer's calendar at the time the Meeting Request object or Meeting 
        ///     Update object was sent.
        /// </summary>
        internal static NamedPropertyTag PidLidIntendedBusyStatus
        {
            get { return new NamedPropertyTag(0x8224, "PidLidIntendedBusyStatus",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the time at which the appointment was last updated.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentUpdateTime
        {
            get { return new NamedPropertyTag(0x8226, "PidLidAppointmentUpdateTime",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the date and time, in UTC, within a recurrence pattern that an exception will
        ///     replace.
        /// </summary>
        internal static NamedPropertyTag PidLidExceptionReplaceTime
        {
            get { return new NamedPropertyTag(0x8228, "PidLidExceptionReplaceTime",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Indicates whether invitations have been sent for the meeting that this Meeting object
        ///     represents.
        /// </summary>
        internal static NamedPropertyTag PidLidFInvited
        {
            get { return new NamedPropertyTag(0x8229, "PidLidFInvited",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates that the object is a Recurring Calendar object with one or more
        ///     exceptions, and at least one of the Exception Embedded Message objects has at least 
        ///     one RecipientRow.
        /// </summary>
        internal static NamedPropertyTag PidLidFExceptionalAttendees
        {
            get { return new NamedPropertyTag(0x822B, "PidLidFExceptionalAttendees",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates the name of the owner of the mailbox.
        /// </summary>
        internal static NamedPropertyTag PidLidOwnerName
        {
            get { return new NamedPropertyTag(0x822E, "PidLidOwnerName",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Indicates whether the Calendar folder from which the meeting was opened is
        ///     another user's calendar.
        /// </summary>
        internal static NamedPropertyTag PidLidFOthersAppointment
        {
            get { return new NamedPropertyTag(0x822F, "PidLidFOthersAppointment",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///      Specifies the user who last replied to the meeting request or meeting update.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentReplyName
        {
            get { return new NamedPropertyTag(0x8230, "PidLidAppointmentReplyName",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the recurrence type of the recurring series.
        /// </summary>
        internal static NamedPropertyTag PidLidRecurrenceType
        {
            get { return new NamedPropertyTag(0x8231, "PidLidRecurrenceType",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies a description of the recurrence pattern of the Calendar object.
        /// </summary>
        internal static NamedPropertyTag PidLidRecurrencePattern
        {
            get { return new NamedPropertyTag(0x8232, "PidLidRecurrencePattern",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies a human-readable description of the time zone that is represented by the
        ///     data in the <see cref="PidLidTimeZoneStruct"/> property(section 2.340).
        /// </summary>
        internal static NamedPropertyTag PidLidTimeZoneStruct
        {
            get { return new NamedPropertyTag(0x8233, "PidLidTimeZoneStruct",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies a human-readable description of the time zone that is represented by the
        ///     data in the PidLidTimeZoneStruct property(section 2.340).
        /// </summary>
        internal static NamedPropertyTag PidLidTimeZoneDescription
        {
            get { return new NamedPropertyTag(0x8234, "PidLidTimeZoneDescription",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the start date and time of the event in UTC.
        /// </summary>
        internal static NamedPropertyTag PidLidClipStart
        {
            get { return new NamedPropertyTag(0x8235, "PidLidClipStart",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the end date and time of the event in UTC.
        /// </summary>
        internal static NamedPropertyTag PidLidClipEnd
        {
            get { return new NamedPropertyTag(0x8236, "PidLidClipEnd",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     The original store id
        /// </summary>
        internal static NamedPropertyTag PidLidOriginalStoreEntryId
        {
            get { return new NamedPropertyTag(0x8237, "PidLidOriginalStoreEntryId",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies a list of all the attendees except for the organizer, including resources and
        ///     unsendable attendees.
        /// </summary>
        internal static NamedPropertyTag PidLidAllAttendeesString
        {
            get { return new NamedPropertyTag(0x8238, "PidLidAllAttendeesString",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Indicates whether the value of the <see cref="PidLidLocation"/> property (section 2.157) 
        ///     is set to the <see cref="PropertyTags.PR_DISPLAY_NAME_W"/> property(section 2.746)
        /// </summary>
        internal static NamedPropertyTag PidLidAutoFillLocation
        {
            get { return new NamedPropertyTag(0x823A, "PidLidAutoFillLocation",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///      Contains a list of all the sendable attendees who are also required attendees.
        /// </summary>
        internal static NamedPropertyTag PidLidToAttendeesString
        {
            get { return new NamedPropertyTag(0x823B, "PidLidToAttendeesString",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains a list of all the sendable attendees who are also optional attendees.
        /// </summary>
        internal static NamedPropertyTag PidLidCcAttendeesString
        {
            get { return new NamedPropertyTag(0x823C, "PidLidCcAttendeesString",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     When set to TRUE (0x00000001), the PidLidConferencingCheck property ([MS-OXPROPS] section 2.65) 
        ///     indicates that the associated meeting is one of the following types:
        ///     -   "Windows Media Services"
        ///     -   "Windows NetMeeting"
        ///     -   "Exchange Conferencing"
        ///
        ///     If this property is set, <see cref="PidLidConferencingType"/> (section 2.2.1.51.3) is also to 
        ///     be set. This property is set to TRUE only on Meeting objects or meeting-related objects.
        /// </summary>
        internal static NamedPropertyTag PidLidConferencingCheck
        {
            get { return new NamedPropertyTag(0x8240, "PidLidConferencingCheck",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the type of the meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidConferencingType
        {
            get { return new NamedPropertyTag(0x8241, "PidLidConferencingType",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the directory server to be used with NetMeeting.
        /// </summary>
        internal static NamedPropertyTag PidLidDirectory
        {
            get { return new NamedPropertyTag(0x8242, "PidLidDirectory",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the e-mail address of the organizer.
        /// </summary>
        internal static NamedPropertyTag PidLidOrganizerAlias
        {
            get { return new NamedPropertyTag(0x8243, "PidLidOrganizerAlias",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies whether or not to automatically start the conferencing application when a
        ///     reminder for the meeting fires.
        /// </summary>
        internal static NamedPropertyTag PidLidAutoStartCheck
        {
            get { return new NamedPropertyTag(0x8244, "PidLidAutoStartCheck",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidAutoStartWhen
        {
            get { return new NamedPropertyTag(0x8245, "PidLidAutoStartWhen",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     This property is set to TRUE
        /// </summary>
        internal static NamedPropertyTag PidLidAllowExternalCheck
        {
            get { return new NamedPropertyTag(0x8246, "PidLidAllowExternalCheck",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the document to be launched when the user joins the meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidCollaborateDoc
        {
            get { return new NamedPropertyTag(0x8247, "PidLidCollaborateDoc",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Specifies the URL to be launched when the user joins the meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidNetShowUrl
        {
            get { return new NamedPropertyTag(0x8248, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the password for a meeting on which the <see cref="PidLidConferencingType"/> property
        ///     (section 2.66) has the value 0x00000002.
        /// </summary>
        internal static NamedPropertyTag PidLidOnlinePassword
        {
            get { return new NamedPropertyTag(0x8249, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the proposed value for the <see cref="PidLidAppointmentStartWhole"/> 
        ///     property (section 2.29) for a counter proposal.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentProposedStartWhole
        {
            get { return new NamedPropertyTag(0x8250, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the proposed value for the <see cref="PidLidAppointmentEndWhole"/> property (section 2.14) 
        ///     for a counter proposal.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentProposedEndWhole
        {
            get { return new NamedPropertyTag(0x8251, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Indicates the proposed value for the <see cref="PidLidAppointmentDuration"/> property (section 2.11) 
        ///     for a counter proposal.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentProposedDuration
        {
            get { return new NamedPropertyTag(0x8256, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates whether a Meeting Response object is a counter proposal.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentCounterProposal
        {
            get { return new NamedPropertyTag(0x8257, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the number of attendees who have sent counter proposals that have not been
        ///     accepted or rejected by the organizer.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentProposalNumber
        {
            get { return new NamedPropertyTag(0x8259, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates whether attendees are not allowed to propose a new date and/or time for the
        ///     meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentNotAllowPropose
        {
            get { return new NamedPropertyTag(0x825A, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a list of unsendable attendees.
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentUnsendableRecipients
        {
            get { return new NamedPropertyTag(0x825D, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies time zone information that indicates the time zone of the
        ///     <see cref="PidLidAppointmentStartWhole"/> property(section 2.29).
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentTimeZoneDefinitionStartDisplay
        {
            get { return new NamedPropertyTag(0x825E, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentTimeZoneDefinitionEndDisplay
        {
            get { return new NamedPropertyTag(0x825F, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies time zone information that indicates the time zone of the
        ///     <see cref="PidLidAppointmentEndWhole"/> property(section 2.14).
        /// </summary>
        internal static NamedPropertyTag PidLidAppointmentTimeZoneDefinitionRecur
        {
            get { return new NamedPropertyTag(0x8260, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of <see cref="RecipientRow"/> structures, as described in [MS-OXCDATA] section 2.8.3,
        ///     that indicate the <see cref="Recipients"/> of a meeting forward.
        /// </summary>
        internal static NamedPropertyTag PidLidForwardNotificationRecipients
        {
            get { return new NamedPropertyTag(0x8261, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the contents of the iCalendar MIME part of the original MIME message.
        /// </summary>
        internal static NamedPropertyTag PidLidInboundICalStream
        {
            get { return new NamedPropertyTag(0x827A, "",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies the interval, in minutes, between the time at which the reminder first
        ///     becomes overdue and the start time of the Calendar object.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderDelta
        {
            get { return new NamedPropertyTag(0x8501, "PidLidReminderDelta",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the filename of the sound that a client is to play when the reminder for that
        ///     object becomes overdue.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderFileParameter
        {
            get { return new NamedPropertyTag(0x851F, "PidLidReminderFileParameter",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies whether the client is to respect the values PidLidReminderPlaySound (section
        ///     2.219) and <see cref="PidLidReminderFileParameter" /> (section 2.217), or use the default 
        ///     values for those properties.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderOverride
        {
            get { return new NamedPropertyTag(0x851C, "PidLidReminderOverride",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies whether the client is to play a sound when the reminder becomes overdue.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderPlaySound
        {
            get { return new NamedPropertyTag(0x851E, "PidLidReminderPlaySound",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies whether a reminder is set on the object.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderSet
        {
            get { return new NamedPropertyTag(0x8503, "PidLidReminderSet",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies the point in time when a reminder transitions from pending to overdue.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderSignalTime
        {
            get { return new NamedPropertyTag(0x8560, "PidLidReminderSignalTime",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the initial signal time for non-Calendar objects.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderTime
        {
            get { return new NamedPropertyTag(0x8502, "PidLidReminderTime",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Indicates the time and date of the reminder for the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderTimeDate
        {
            get { return new NamedPropertyTag(0x8505, "PidLidReminderTimeDate",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Indicates the time of the reminder for the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderTimeTime
        {
            get { return new NamedPropertyTag(0x8504, "PidLidReminderTimeTime",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      This property is not set and if set, is ignored.
        /// </summary>
        internal static NamedPropertyTag PidLidReminderType
        {
            get { return new NamedPropertyTag(0x851D, "PidLidReminderType",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidSingleBodyIcal
        {
            get { return new NamedPropertyTag(0x827B, "PidLidSingleBodyIcal",
                    new Guid("00062002-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///      Identifies the day of the month for the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidDayOfMonth
        {
            get { return new NamedPropertyTag(0x1000, "PidLidDayOfMonth",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the contact’s business web page URL.
        /// </summary>
        internal static NamedPropertyTag PidLidICalendarDayOfWeekMask
        {
            get { return new NamedPropertyTag(0x1001, "PidLidICalendarDayOfWeekMask",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the number of occurrences in the recurring appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidOccurrences
        {
            get { return new NamedPropertyTag(0x1005, "PidLidOccurrences",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the number of occurrences in the recurring appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidMonthOfYear
        {
            get { return new NamedPropertyTag(0x1006, "PidLidMonthOfYear",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Indicates whether the recurrence pattern has an end date.
        /// </summary>
        internal static NamedPropertyTag PidLidNoEndDateFlag
        {
            get { return new NamedPropertyTag(0x100B, "PidLidNoEndDateFlag",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Identifies the length, in minutes, of the appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidLidRecurrenceDuration
        {
            get { return new NamedPropertyTag(0x100D, "PidLidRecurrenceDuration",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the remote status of the calendar item.
        /// </summary>
        internal static NamedPropertyTag PidLidRemoteStatus
        {
            get { return new NamedPropertyTag(0x8511, "PidLidRemoteStatus",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry ID for the destination folder.
        /// </summary>
        internal static NamedPropertyTag PidLidConversationActionMoveFolderEid
        {
            get { return new NamedPropertyTag(0x85C6, "PidLidConversationActionMoveFolderEid",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry ID for a move to a folder in a different store.
        /// </summary>
        internal static NamedPropertyTag PidLidConversationActionMoveStoreEid
        {
            get { return new NamedPropertyTag(0x85C7, "PidLidConversationActionMoveStoreEid",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the maximum value of <see cref="PropertyTags.PR_MESSAGE_DELIVERY_TIME"/> (section 2.886) of all the
        ///     E-mail objects modified in response to the last time the user changed a conversation action on the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidConversationActionMaxDeliveryTime
        {
            get { return new NamedPropertyTag(0x85C8, "PidLidConversationActionMaxDeliveryTime",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the time (in UTC) that an E-mail object was last received in the
        ///     conversation, or the last time that the user modified the conversation action, whichever occurs
        ///     later.
        /// </summary>
        internal static NamedPropertyTag PidLidConversationProcessed
        {
            get { return new NamedPropertyTag(0x85C9, "PidLidConversationProcessed",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the time (in UTC) that an E-mail object was last received in the
        ///     conversation, or the last time that the user modified the conversation action, whichever occurs
        ///     later.
        /// </summary>
        internal static NamedPropertyTag PidLidConversationActionLastAppliedTime
        {
            get { return new NamedPropertyTag(0x85CA, "PidLidConversationActionLastAppliedTime",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the version of the conversation action FAI message.
        /// </summary>
        internal static NamedPropertyTag PidLidConversationActionVersion
        {
            get { return new NamedPropertyTag(0x85CB, "PidLidConversationActionVersion",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Briefly describes the activity that is being recorded.
        /// </summary>
        internal static NamedPropertyTag PidLidLogType
        {
            get { return new NamedPropertyTag(0x8700, "PidLidLogType",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the time at which the activity began.
        /// </summary>
        internal static NamedPropertyTag PidLidLogStart
        {
            get { return new NamedPropertyTag(0x8706, "PidLidLogStart",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the duration in minutes of the activity.
        /// </summary>
        internal static NamedPropertyTag PidLidLogDuration
        {
            get { return new NamedPropertyTag(0x8707, "PidLidLogDuration",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidLogEnd
        {
            get { return new NamedPropertyTag(0x8708, "PidLidLogEnd",
                    new Guid("00062008-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the time at which the activity ended.
        /// </summary>
        internal static NamedPropertyTag PidLidLogFlags
        {
            get { return new NamedPropertyTag(0x870C, "PidLidLogFlags",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates whether the document was printed during journaling.
        /// </summary>
        internal static NamedPropertyTag PidLidDocumentPrinted
        {
            get { return new NamedPropertyTag(0x870E, "PidLidDocumentPrinted",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates whether the document was saved during journaling.
        /// </summary>
        internal static NamedPropertyTag PidLidDocumentSaved
        {
            get { return new NamedPropertyTag(0x870F, "PidLidDocumentSaved",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates whether the document was routed during journaling.
        /// </summary>
        internal static NamedPropertyTag PidLidDocumentRouted
        {
            get { return new NamedPropertyTag(0x8710, "PidLidDocumentRouted",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Indicates whether the document was posted during journaling.
        /// </summary>
        internal static NamedPropertyTag PidLidDocumentPosted
        {
            get { return new NamedPropertyTag(0x8711, "PidLidDocumentPosted",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Describes the activity that is being recorded.
        /// </summary>
        internal static NamedPropertyTag PidLidLogTypeDesc
        {
            get { return new NamedPropertyTag(0x8712, "PidLidLogTypeDesc",
                    new Guid("0006200A-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the URL of the RSS or Atom feed that the XML file came from.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssChannelLink
        {
            get { return new NamedPropertyTag(0x8900, "PidLidPostRssChannelLink",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the URL of the link from the item.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssItemLink
        {
            get { return new NamedPropertyTag(0x8901, "PidLidPostRssItemLink",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a hash of the feed XML computed by using an implementation-dependent
        ///     algorithm.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssItemHash
        {
            get { return new NamedPropertyTag(0x8902, "PidLidPostRssItemHash",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a unique identifier for the RSS object.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssItemGuid
        {
            get { return new NamedPropertyTag(0x8903, "PidLidPostRssItemGuid",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the contents of the title field from the XML of the Atom feed or RSS channel.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssChannel
        {
            get { return new NamedPropertyTag(0x8904, "PidLidPostRssChannel",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the item element and all its sub-elements from an RSS feed, or the entry
        ///     element and all its sub-elements from an Atom feed.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssItemXml
        {
            get { return new NamedPropertyTag(0x8905, "PidLidPostRssItemXml",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the user's preferred name for the subscription.
        /// </summary>
        internal static NamedPropertyTag PidLidPostRssSubscription
        {
            get { return new NamedPropertyTag(0x8906, "PidLidPostRssSubscription",
                    new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }


        /// <summary>
        ///     Indicates whether the end-user wants this message object hidden from other users who have access to the message object.
        /// </summary>
        internal static NamedPropertyTag PidLidPrivate
        {
            get
            {
                return new NamedPropertyTag(0x8506, "PidLidPrivate",
                  new Guid("00062041-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN);
            }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingStatus
        {
            get { return new NamedPropertyTag(0x8A00, "PidLidSharingStatus",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Contains the value "%xAE.F0.06.00.00.00.00.00.C0.00.00.00.00.00.00.46".
        /// </summary>
        internal static NamedPropertyTag PidLidSharingProviderGuid
        {
            get { return new NamedPropertyTag(0x8A01, "PidLidSharingProviderGuid",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a user-displayable name of the sharing provider identified by the
        ///     <see cref="PidLidSharingProviderGuid"/> property(section 2.266).
        /// </summary>
        internal static NamedPropertyTag PidLidSharingProviderName
        {
            get { return new NamedPropertyTag(0x8A02, "PidLidSharingProviderName",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a URL related to the sharing provider identified by the
        ///     <see cref="PidLidSharingProviderGuid"/> property(section 2.266).
        /// </summary>
        internal static NamedPropertyTag PidLidSharingProviderUrl
        {
            get { return new NamedPropertyTag(0x8A03, "PidLidSharingProviderUrl",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemotePath
        {
            get { return new NamedPropertyTag(0x8A04, "PidLidSharingRemotePath",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the PidLidSharingRemoteName property (section 2.277).
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteName
        {
            get { return new NamedPropertyTag(0x8A05, "PidLidSharingRemoteName",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the EntryID of the folder being shared. 
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteUid
        {
            get { return new NamedPropertyTag(0x8A06, "PidLidSharingRemoteUid",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the value of the PidTagDisplayName property(section 2.667) from the
        ///     Address Book object identified by the <see cref="PidLidSharingInitiatorEntryId"/>
        ///     property(section 2.248).
        /// </summary>
        internal static NamedPropertyTag PidLidSharingInitiatorName
        {
            get { return new NamedPropertyTag(0x8A07, "PidLidSharingInitiatorName",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the value of the PidTagSmtpAddress property (section 2.1010) from the
        ///     Address Book object identified by the <see cref="PidLidSharingInitiatorEntryId"/>
        ///     property(section 2.248).   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingInitiatorSmtp
        {
            get { return new NamedPropertyTag(0x8A08, "PidLidSharingInitiatorSmtp",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the value of the PidTagEntryId property (section 2.674) for 
        ///     the Address Book object of the currently logged-on user.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingInitiatorEntryId
        {
            get { return new NamedPropertyTag(0x8A09, "PidLidSharingInitiatorEntryId",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingFlags
        {
            get { return new NamedPropertyTag(0x8A0A, "PidLidSharingFlags",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingProviderExtension
        {
            get { return new NamedPropertyTag(0x8A0B, "PidLidSharingProviderExtension",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteUser
        {
            get { return new NamedPropertyTag(0x8A0C, "PidLidSharingRemoteUser",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemotePass
        {
            get { return new NamedPropertyTag(0x8A0D, "PidLidSharingRemotePass",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client. 
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalPath
        {
            get { return new NamedPropertyTag(0x8A0E, "PidLidSharingLocalPath",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalName
        {
            get { return new NamedPropertyTag(0x8A0F, "PidLidSharingLocalName",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.     
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalUid
        {
            get { return new NamedPropertyTag(0x8A10, "PidLidSharingLocalUid",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingFilter
        {
            get { return new NamedPropertyTag(0x8A13, "PidLidSharingFilter",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client. 
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalType
        {
            get { return new NamedPropertyTag(0x8A14, "PidLidSharingLocalType",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingFolderEntryId
        {
            get { return new NamedPropertyTag(0x8A15, "PidLidSharingFolderEntryId",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingCapabilities
        {
            get { return new NamedPropertyTag(0x8A17, "PidLidSharingCapabilities",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingFlavor
        {
            get { return new NamedPropertyTag(0x8A18, "PidLidSharingFlavor",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingAnonymity
        {
            get { return new NamedPropertyTag(0x8A19, "PidLidSharingAnonymity",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingReciprocation
        {
            get { return new NamedPropertyTag(0x8A1A, "PidLidSharingReciprocation",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingPermissions
        {
            get { return new NamedPropertyTag(0x8A1B, "PidLidSharingPermissions",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingInstanceGuid
        {
            get { return new NamedPropertyTag(0x8A1C, "PidLidSharingInstanceGuid",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteType
        {
            get { return new NamedPropertyTag(0x8A1D, "PidLidSharingRemoteType",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingParticipants
        {
            get { return new NamedPropertyTag(0x8A1E, "PidLidSharingParticipants",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLastSyncTime
        {
            get { return new NamedPropertyTag(0x8A1F, "PidLidSharingLastSyncTime",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingExtensionXml
        {
            get { return new NamedPropertyTag(0x8A21, "PidLidSharingExtensionXml",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteLastModificationTime
        {
            get { return new NamedPropertyTag(0x8A22, "PidLidSharingRemoteLastModificationTime",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalLastModificationTime
        {
            get { return new NamedPropertyTag(0x8A23, "PidLidSharingLocalLastModificationTime",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Contains a zero-length string.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingConfigurationUrl
        {
            get { return new NamedPropertyTag(0x8A24, "PidLidSharingConfigurationUrl",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingStart
        {
            get { return new NamedPropertyTag(0x8A25, "PidLidSharingStart",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingStop
        {
            get { return new NamedPropertyTag(0x8A26, "PidLidSharingStop",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.     
        /// </summary>
        internal static NamedPropertyTag PidLidSharingResponseType
        {
            get { return new NamedPropertyTag(0x8A27, "PidLidSharingResponseType",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Contains the time at which the recipient of the sharing request sent a sharing response.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingResponseTime
        {
            get { return new NamedPropertyTag(0x8A28, "PidLidSharingResponseTime",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingOriginalMessageEntryId
        {
            get { return new NamedPropertyTag(0x8A29, "PidLidSharingOriginalMessageEntryId",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.     
        /// </summary>
        internal static NamedPropertyTag PidLidSharingSyncInterval
        {
            get { return new NamedPropertyTag(0x8A2A, "PidLidSharingSyncInterval",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingDetail
        {
            get { return new NamedPropertyTag(0x8A2B, "PidLidSharingDetail",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingTimeToLive
        {
            get { return new NamedPropertyTag(0x8A2C, "PidLidSharingTimeToLive",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingBindingEntryId
        {
            get { return new NamedPropertyTag(0x8A2D, "PidLidSharingBindingEntryId",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingIndexEntryId
        {
            get { return new NamedPropertyTag(0x8A2E, "PidLidSharingIndexEntryId",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteComment
        {
            get { return new NamedPropertyTag(0x8A2F, "PidLidSharingRemoteComment",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingWorkingHoursStart
        {
            get { return new NamedPropertyTag(0x8A40, "PidLidSharingWorkingHoursStart",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.   
        /// </summary>
        internal static NamedPropertyTag PidLidSharingWorkingHoursEnd
        {
            get { return new NamedPropertyTag(0x8A41, "PidLidSharingWorkingHoursEnd",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.      
        /// </summary>
        internal static NamedPropertyTag PidLidSharingWorkingHoursDays
        {
            get { return new NamedPropertyTag(0x8A42, "PidLidSharingWorkingHoursDays",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingWorkingHoursTimeZone
        {
            get { return new NamedPropertyTag(0x8A43, "PidLidSharingWorkingHoursTimeZone",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.     
        /// </summary>
        internal static NamedPropertyTag PidLidSharingDataRangeStart
        {
            get { return new NamedPropertyTag(0x8A44, "PidLidSharingDataRangeStart",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.    
        /// </summary>
        internal static NamedPropertyTag PidLidSharingDataRangeEnd
        {
            get { return new NamedPropertyTag(0x8A45, "PidLidSharingDataRangeEnd",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRangeStart
        {
            get { return new NamedPropertyTag(0x8A46, "PidLidSharingRangeStart",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRangeEnd
        {
            get { return new NamedPropertyTag(0x8A47, "PidLidSharingRangeEnd",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a hexadecimal string representation of the value of the PidTagStoreEntryId
        ///     property(section 2.1018) on the folder being shared.
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteStoreUid
        {
            get { return new NamedPropertyTag(0x8A48, "PidLidSharingRemoteStoreUid",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalStoreUid
        {
            get { return new NamedPropertyTag(0x8A49, "PidLidSharingLocalStoreUid",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteByteSize
        {
            get { return new NamedPropertyTag(0x8A4B, "PidLidSharingRemoteByteSize",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteCrc
        {
            get { return new NamedPropertyTag(0x8A4C, "PidLidSharingRemoteCrc",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLocalComment
        {
            get { return new NamedPropertyTag(0x8A4D, "PidLidSharingLocalComment",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRoamLog
        {
            get { return new NamedPropertyTag(0x8A4E, "PidLidSharingRoamLog",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteMessageCount
        {
            get { return new NamedPropertyTag(0x8A4F, "PidLidSharingRemoteMessageCount",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingBrowseUrl
        {
            get { return new NamedPropertyTag(0x8A51, "PidLidSharingBrowseUrl",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.  
        /// </summary>
        internal static NamedPropertyTag PidLidSharingLastAutoSyncTime
        {
            get { return new NamedPropertyTag(0x8A55, "PidLidSharingLastAutoSyncTime",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.      
        /// </summary>
        internal static NamedPropertyTag PidLidSharingTimeToLiveAuto
        {
            get { return new NamedPropertyTag(0x8A56, "PidLidSharingTimeToLiveAuto",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.       
        /// </summary>
        internal static NamedPropertyTag PidLidSharingRemoteVersion
        {
            get { return new NamedPropertyTag(0x8A5B, "PidLidSharingRemoteVersion",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.      
        /// </summary>
        internal static NamedPropertyTag PidLidSharingParentBindingEntryId
        {
            get { return new NamedPropertyTag(0x8A5C, "PidLidSharingParentBindingEntryId",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.      
        /// </summary>
        internal static NamedPropertyTag PidLidSharingSyncFlags
        {
            get { return new NamedPropertyTag(0x8A60, "PidLidSharingSyncFlags",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the suggested background color of the Note object.
        /// </summary>
        internal static NamedPropertyTag PidLidNoteColor
        {
            get { return new NamedPropertyTag(0x8B00, "PidLidNoteColor",
                    new Guid("0006200E-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies the width of the visible message window in pixels.
        /// </summary>
        internal static NamedPropertyTag PidLidNoteWidth
        {
            get { return new NamedPropertyTag(0x8B02, "PidLidNoteWidth",
                    new Guid("0006200E-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the height of the visible message window in pixels.
        /// </summary>
        internal static NamedPropertyTag PidLidNoteHeight
        {
            get { return new NamedPropertyTag(0x8B03, "PidLidNoteHeight",
                    new Guid("0006200E-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the distance, in pixels, from the left edge of the screen that a user interface
        ///     displays a Note object.
        /// </summary>
        internal static NamedPropertyTag PidLidNoteX
        {
            get { return new NamedPropertyTag(0x8B04, "PidLidNoteX",
                    new Guid("0006200E-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the distance, in pixels, from the top edge of the screen that a user interface
        ///     displays a Note object.
        /// </summary>
        internal static NamedPropertyTag PidLidNoteY
        {
            get { return new NamedPropertyTag(0x8B05, "PidLidNoteY",
                    new Guid("0006200E-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the array of text labels assigned to this Message object.
        /// </summary>
        internal static NamedPropertyTag PidLidCategories
        {
            get { return new NamedPropertyTag(0x9000, "PidLidCategories",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_MV_STRING8); }
        }

        /// <summary>
        ///      Specifies the application used to open the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameApplicationName
        {
            get { return new NamedPropertyTag(0x0000, "PidNameApplicationName",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Specifies the author of the file attached to the Document object
        /// </summary>
        internal static NamedPropertyTag PidNameAuthor
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAuthor",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the size, in bytes, of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameByteCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameByteCount",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the role of the attendee.
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarAttendeeRole
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarAttendeeRole",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies whether the attendee is busy at the time of an appointment on their calendar.
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarBusyStatus
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarBusyStatus",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Identifies the name of a contact who is an attendee of a meeting.
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarContact
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarContact",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Identifies the URL where you can access contact information in HTML format
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarContactUrl
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarContactUrl",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Identifies the date and time, in UTC, when the organizer created the appointment or
        ///     meeting.
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarCreated
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarCreated",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the URL of a resource that contains a description of an appointment or
        ///     meeting.
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarDescriptionUrl
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarDescriptionUrl",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Identifies the duration, in seconds, of an appointment or meeting.
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarDuration
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarDuration",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Identifies a list of dates that are exceptions to a recurring appointment
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarExceptionDate
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarExceptionDate",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_MV_SYSTIME); }
        }

        /// <summary>
        ///     Specifies an exception rule for a recurring appointment
        /// </summary>
        internal static NamedPropertyTag PidNameCalendarExceptionRule
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCalendarExceptionRule",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_MV_UNICODE); }
        }

        /// <summary>
        ///     Specifies the category of the file attached to the Document object
        /// </summary>
        internal static NamedPropertyTag PidNameCategory
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCategory",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the character count of the file attached to the Document object
        /// </summary>
        internal static NamedPropertyTag PidNameCharacterCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCharacterCount",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the comments of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameComments
        {
            get { return new NamedPropertyTag(0x0000, "PidNameComments",
                    new Guid("00062040-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        /// Specifies the company for which the file was created.
        /// </summary>
        internal static NamedPropertyTag PidNameCompany
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCompany",
                    new Guid("00062039-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the time, in UTC, that the file was first created.
        /// </summary>
        internal static NamedPropertyTag PidNameCreateDateTimeReadOnly
        {
            get
            {
                return new NamedPropertyTag(0x0000, "PidNameCreateDateTimeReadOnly",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME);
            }
        }

        /// <summary>
        ///     Specifies the value used to cache the Use License for the rights-managed email
        ///     message.
        /// </summary>
        internal static NamedPropertyTag PidNameRightsManagementLicense
        {
            get { return new NamedPropertyTag(0x0000, "PidNameRightsManagementLicense",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_MV_BINARY); }
        }

        /// <summary>
        ///     Specifies the time that the file was last edited.
        /// </summary>
        internal static NamedPropertyTag PidNameEditTime
        {
            get { return new NamedPropertyTag(0x0000, "PidNameEditTime",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Specifies the hidden value of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameHiddenCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameHiddenCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains keywords or categories for the Message object.
        /// </summary>
        internal static NamedPropertyTag PidNameKeywords
        {
            get { return new NamedPropertyTag(0x0000, "PidNameKeywords",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_MV_STRING8); }
        }

        /// <summary>
        ///     Specifies the most recent author of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameLastAuthor
        {
            get { return new NamedPropertyTag(0x0000, "PidNameLastAuthor",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the time, in UTC, that the file was last printed.
        /// </summary>
        internal static NamedPropertyTag PidNameLastPrinted
        {
            get { return new NamedPropertyTag(0x0000, "PidNameLastPrinted",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the time, in UTC, that the file was last saved.
        /// </summary>
        internal static NamedPropertyTag PidNameLastSaveDateTime
        {
            get { return new NamedPropertyTag(0x0000, "PidNameLastSaveDateTime",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Specifies the number of lines in the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameLineCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameLineCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies the manager of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameManager
        {
            get { return new NamedPropertyTag(0x0000, "PidNameManager",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the number of multimedia clips in the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameMultimediaClipCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameMultimediaClipCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the number of notes in the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameNoteCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameNoteCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the GUID of the SMS account used to deliver the message.
        /// </summary>
        internal static NamedPropertyTag PidNameOMSAccountGuid
        {
            get { return new NamedPropertyTag(0x0000, "PidNameOMSAccountGuid",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Indicates the model of the mobile device used to send the SMS or MMS message.
        /// </summary>
        internal static NamedPropertyTag PidNameOMSMobileModel
        {
            get { return new NamedPropertyTag(0x0000, "PidNameOMSMobileModel",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the time, in UTC, at which the client requested that the service provider send
        ///     the SMS or MMS message. 
        /// </summary>
        internal static NamedPropertyTag PidNameOMSGScheduleTime
        {
            get { return new NamedPropertyTag(0x0000, "PidNameOMSGScheduleTime",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///      Contains the type of service used to send an SMS or MMS message.
        /// </summary>
        internal static NamedPropertyTag PidNameOMSServiceType
        {
            get { return new NamedPropertyTag(0x0000, "PidNameOMSServiceType",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Contains the source of an SMS or MMS message.
        /// </summary>
        internal static NamedPropertyTag PidNameOMSSourceType
        {
            get { return new NamedPropertyTag(0x0000, "PidNameOMSSourceType",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates whether a message is likely to be phishing.
        /// </summary>
        internal static NamedPropertyTag PidNamePhishingStamp
        {
            get { return new NamedPropertyTag(0x0000, "PidNamePhishingStamp",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates whether a message is likely to be spoofing.
        /// </summary>
        internal static NamedPropertyTag PidNameSpoofingStamp
        {
            get { return new NamedPropertyTag(0x0000, "PidNameSpoofingStamp",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies the page count of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNamePageCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNamePageCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies the number of paragraphs in the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameParagraphCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameParagraphCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Specifies the presentation format of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNamePresentationFormat
        {
            get { return new NamedPropertyTag(0x0000, "PidNamePresentationFormat",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the security level of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameSecurity
        {
            get { return new NamedPropertyTag(0x0000, "PidNameSecurity",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the number of slides in the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameSlideCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameSlideCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the subject of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameSubject
        {
            get { return new NamedPropertyTag(0x0000, "PidNameSubject",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the template of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameTemplate
        {
            get { return new NamedPropertyTag(0x0000, "PidNameTemplate",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Specifies the title of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameTitle
        {
            get { return new NamedPropertyTag(0x0000, "PidNameTitle",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the word count of the file attached to the Document object.
        /// </summary>
        internal static NamedPropertyTag PidNameWordCount
        {
            get { return new NamedPropertyTag(0x0000, "PidNameWordCount",
                    new Guid("00020329-0000-0000-C000-000000000046"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///      Contains the value of the MIME Accept-Language header.
        /// </summary>
        internal static NamedPropertyTag PidNameAcceptLanguage
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAcceptLanguage",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the address of the moderator that approved and posted a message.
        /// </summary>
        internal static NamedPropertyTag PidNameApproved
        {
            get { return new NamedPropertyTag(0x0000, "PidNameApproved",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameApprovalAllowedDescisionMakers
        {
            get { return new NamedPropertyTag(0x0000, "PidNameApprovalAllowedDescisionMakers",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameApprovalRequestor
        {
            get { return new NamedPropertyTag(0x0000, "PidNameApprovalRequestor",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameAuthenticatedAs
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAuthenticatedAs",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameAuthenticatedDomain
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAuthenticatedDomain",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameAuthenticatedMechanism
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAuthenticatedMechanism",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameAuthenticatedSource
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAuthenticatedSource",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the blind carbon copy addressees of the message. This property
        ///     SHOULD be directly imported from and exported to the bcc header that is specified in
        ///     [RFC822].
        /// </summary>
        internal static NamedPropertyTag PidNameBcc
        {
            get { return new NamedPropertyTag(0x0000, "PidNameBcc",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the carbon copy addressees of the message. This property SHOULD
        ///     be directly imported from and exported to the cc header that is specified in [RFC822].
        /// </summary>
        internal static NamedPropertyTag PidNameCc
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCc",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies the value of the MIME Content-Base header, which defines the base URI for
        ///     resolving relative URLs contained within the message body.
        /// </summary>
        internal static NamedPropertyTag PidNameContentBase
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentBase",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a string that identifies the type of content of a Message object.
        /// </summary>
        internal static NamedPropertyTag PidNameContentClass
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentClass",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the intended disposition of the body part.
        /// </summary>
        internal static NamedPropertyTag PidNameContentDisposition
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentDisposition",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies a unique identifier for the body part.
        /// </summary>
        internal static NamedPropertyTag PidNameContentID
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentID",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///    This property specifies the language identifier for the text content of the body part. 
        /// </summary>
        internal static NamedPropertyTag PidNameContentLanguage
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentLanguage",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the Uniform Resource Identifier (URI) that corresponds to the content
        ///     of the body part. 
        /// </summary>
        internal static NamedPropertyTag PidNameContentLocation
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentLocation",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the encoding mechanism used to encode the content of the body part.
        /// </summary>
        internal static NamedPropertyTag PidNameContentTransferEncoding
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentTransferEncoding",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property specifies the type of the body part's content.
        /// </summary>
        internal static NamedPropertyTag PidNameContentType
        {
            get { return new NamedPropertyTag(0x0000, "PidNameContentType",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidNameCrossReference
        {
            get { return new NamedPropertyTag(0x0000, "PidNameCrossReference",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingBrowseUrl
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingBrowseUrl",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains a string representation of the value of the <see cref="PidLidSharingCapabilities"/>
        ///     property(section 2.237).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingCapabilities
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingCapabilities",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the <see cref="PidLidSharingConfigurationUrl"/> property (section 2.238).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingConfigUrl
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingConfigUrl",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingExtendedCaps
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingExtendedCaps",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a hexadecimal string representation of the value of the PidLidSharingFlavor
        ///     property(section 2.245).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingFlavor
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingFlavor",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingInstanceGuid
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingInstanceGuid",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingLocalType
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingLocalType",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the same value as the PidLidSharingLocalType property (section 2.259).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingProviderGuid
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingProviderGuid",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the <see cref="PidLidSharingProviderName"/> property (section 2.267).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingProviderName
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingProviderName",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the <see cref="PidLidSharingProviderUrl"/> property (section 2.268).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingProviderUrl
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingProviderUrl",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the same value as the <see cref="PidLidSharingRemoteName"/> property (section 2.277).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingRemoteName
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingRemoteName",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that is ignored by the server no matter what value is generated by the
        ///     client.
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingRemotePath
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingRemotePath",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the <see cref="PidLidSharingRemoteStoreUid"/> property (section 2.282).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingRemoteStoreUid
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingRemoteStoreUid",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the <see cref="PidLidSharingRemoteType"/> property (section 2.281).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingRemoteType
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingRemoteType",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the same value as the <see cref="PidLidSharingRemoteUid"/> property (section 2.282).
        /// </summary>
        internal static NamedPropertyTag PidNameXSharingRemoteUid
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSharingRemoteUid",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameXSieve
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXSieve",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        internal static NamedPropertyTag PidNameXVirusScanned
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXVirusScanned",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Indicates what actions the user has taken on this Meeting object.
        /// </summary>
        internal static NamedPropertyTag PidLidClientIntent
        {
            get { return new NamedPropertyTag(0x0015, "PidLidClientIntent",
                    new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates whether the Meeting Request object or Meeting Update object has been 
        ///     processed.
        /// </summary>
        internal static NamedPropertyTag PidLidServerProcessed
        {
            get { return new NamedPropertyTag(0x85CC, "PidLidServerProcessed",
                    new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidLidServerProcessingActions
        {
            get { return new NamedPropertyTag(0x85CD, "PidLidServerProcessingActions",
                    new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the Content-Type of the Mac attachment.
        /// </summary>
        internal static NamedPropertyTag PidNameAttachmentMacContentType
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAttachmentMacContentType",
                    new Guid("96357F7F-59E1-47D0-99A7-46515C183B54"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///      Contains the headers and resource fork data associated with the Mac attachment.
        /// </summary>
        internal static NamedPropertyTag PidNameAttachmentMacInfo
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAttachmentMacInfo",
                    new Guid("96357F7F-59E1-47D0-99A7-46515C183B54"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     
        /// </summary>
        internal static NamedPropertyTag PidNameAudioNotes
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAudioNotes",
                    new Guid("00020386-0000-0000-C000-000000000046"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains textual annotations to a voice message after it has been delivered to the user's
        ///      mailbox.
        /// </summary>
        internal static NamedPropertyTag PidNameAutomaticSpeechRecognitionData
        {
            get { return new NamedPropertyTag(0x0000, "PidNameAutomaticSpeechRecognitionData",
                    new Guid("4442858E-A9E3-4E80-B900-317A210CC15B"), PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Outlook protection rule timestamp
        /// </summary>
        internal static NamedPropertyTag PidNameOutlookProtectionRuleTimestamp
        {
            get { return new NamedPropertyTag(0x0000, "PidNameOutlookProtectionRuleTimestamp",
                    new Guid("4442858E-A9E3-4E80-B900-317A210CC15B"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///    X-Unified messaging partner assigned id
        /// </summary>
        internal static NamedPropertyTag PidNameXUnifiedMessagingPartnerAssignedId
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXUnifiedMessagingPartnerAssignedId",
                    new Guid("4442858E-A9E3-4E80-B900-317A210CC15B"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     X-Unified messaging partner content
        /// </summary>
        internal static NamedPropertyTag PidNameXUnifiedMessagingPartnerContent
        {
            get { return new NamedPropertyTag(0x0000, "PidNameXUnifiedMessagingPartnerContent",
                    new Guid("4442858E-A9E3-4E80-B900-317A210CC15B"), PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     The spam confidence level
        /// </summary>
        internal static NamedPropertyTag PidNameOriginalSpamConfidenceLevel
        {
            get
            {
                return new NamedPropertyTag(0x0000, "PidNameOriginalSpamConfidenceLevel", 
                    new Guid("4442858E-A9E3-4E80-B900-317A210CC15B"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Indicates the transfer size, in bytes, for a remote item.
        /// </summary>
        internal static NamedPropertyTag PidLidRemoteTransferSize
        {
            get
            {
                return new NamedPropertyTag(0x8F05, "PidLidRemoteTransferSize",
                    new Guid("00062014-0000-0000-C000-000000000046"), PropertyType.PT_LONG);
            }
        }

        /// <summary>
        ///     Indicates whether a remote item has an attachment associated with it.
        /// </summary>
        internal static NamedPropertyTag PidLidRemoteAttachment
        {
            get
            {
                return new NamedPropertyTag(0x8F07, "PidLidRemoteAttachment",
                    new Guid("00062014-0000-0000-C000-000000000046"), PropertyType.PT_BOOLEAN);
            }
        }
    }

    /// <summary>
    ///     Used to hold exactly one named property tag
    /// </summary>
    internal class NamedPropertyTag
    {
        #region Properties
        /// <summary>
        ///     The 2 byte identifier
        /// </summary>
        public ushort Id { get; }

        /// <summary>
        ///     The name of the property
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The <see cref="Guid" />
        /// </summary>
        public Guid Guid { get; }

        /// <summary>
        ///     The 2 byte <see cref="PropertyType" />
        /// </summary>
        public PropertyType Type { get; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all its properties
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name of the property</param>
        /// <param name="guid">The property <see cref="Guid" /></param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        internal NamedPropertyTag(ushort id, string name, Guid guid, PropertyType type)
        {
            Id = id;
            Name = name;
            Guid = guid;
            Type = type;
        }
        #endregion
    }
}
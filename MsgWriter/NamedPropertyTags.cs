/*
   Copyright 2015 - 2016 Kees van Spelde

   Licensed under The Code Project Open License (CPOL) 1.02;
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.codeproject.com/info/cpol10.aspx

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using MsgKit.Enums;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable InconsistentNaming

namespace MsgKit
{
    /// <summary>
    ///     A class that holds all the known named mapi tags
    /// </summary>
    internal static class NamedPropertyTags
    {
        internal static PropertyTag PidLidAttendeeCriticalChange
        {
            get { return new PropertyTag(0x0001, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidWhere
        {
            get { return new PropertyTag(0x0002, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidGlobalObjectId
        {
            get { return new PropertyTag(0x0003, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidIsSilent
        {
            get { return new PropertyTag(0x0004, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidIsRecurring
        {
            get { return new PropertyTag(0x0005, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidRequiredAttendees
        {
            get { return new PropertyTag(0x0006, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidOptionalAttendees
        {
            get { return new PropertyTag(0x0007, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidResourceAttendees
        {
            get { return new PropertyTag(0x0008, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidDelegateMail
        {
            get { return new PropertyTag(0x0009, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidIsException
        {
            get { return new PropertyTag(0x000A, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidSingleInvite
        {
            get { return new PropertyTag(0x000B, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTimeZone
        {
            get { return new PropertyTag(0x000C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidStartRecurrenceDate
        {
            get { return new PropertyTag(0x000D, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidStartRecurrenceTime
        {
            get { return new PropertyTag(0x000E, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidEndRecurrenceDate
        {
            get { return new PropertyTag(0x000F, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidEndRecurrenceTime
        {
            get { return new PropertyTag(0x0010, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidDayInterval
        {
            get { return new PropertyTag(0x0011, PropertyType.PT_SHORT); }
        }

        internal static PropertyTag PidLidWeekInterval
        {
            get { return new PropertyTag(0x0012, PropertyType.PT_SHORT); }
        }

        internal static PropertyTag PidLidMonthInterval
        {
            get { return new PropertyTag(0x0013, PropertyType.PT_SHORT); }
        }

        internal static PropertyTag PidLidYearInterval
        {
            get { return new PropertyTag(0x0014, PropertyType.PT_SHORT); }
        }

        internal static PropertyTag PidLidMonthOfYearMask
        {
            get { return new PropertyTag(0x0017, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidOldRecurrenceType
        {
            get { return new PropertyTag(0x0018, PropertyType.PT_SHORT); }
        }

        internal static PropertyTag PidLidOwnerCriticalChange
        {
            get { return new PropertyTag(0x001A, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidUnknown001B
        {
            get { return new PropertyTag(0x001B, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidCalendarType
        {
            get { return new PropertyTag(0x001C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAllAttendeesList
        {
            get { return new PropertyTag(0x001D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidCleanGlobalObjectId
        {
            get { return new PropertyTag(0x0023, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAppointmentMessageClass
        {
            get { return new PropertyTag(0x0024, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidMeetingType
        {
            get { return new PropertyTag(0x0026, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidOldLocation
        {
            get { return new PropertyTag(0x0028, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidOldWhenStartWhole
        {
            get { return new PropertyTag(0x0029, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidOldWhenEndWhole
        {
            get { return new PropertyTag(0x002A, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidFileUnder
        {
            get { return new PropertyTag(0x8005, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFileUnderId
        {
            get { return new PropertyTag(0x8006, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidContactItemData
        {
            get { return new PropertyTag(0x8007, PropertyType.PT_MV_LONG); }
        }

        internal static PropertyTag PidLidReferredBy
        {
            get { return new PropertyTag(0x800E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidDepartment
        {
            get { return new PropertyTag(0x8010, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidHasPicture
        {
            get { return new PropertyTag(0x8015, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidHomeAddress
        {
            get { return new PropertyTag(0x801A, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddress
        {
            get { return new PropertyTag(0x801B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidOtherAddress
        {
            get { return new PropertyTag(0x801C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostalAddressId
        {
            get { return new PropertyTag(0x8022, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidContactCharacterSet
        {
            get { return new PropertyTag(0x8023, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAutoLog
        {
            get { return new PropertyTag(0x8025, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidFileUnderList
        {
            get { return new PropertyTag(0x8026, PropertyType.PT_MV_LONG); }
        }

        internal static PropertyTag PidLidEmailList
        {
            get { return new PropertyTag(0x8027, PropertyType.PT_MV_LONG); }
        }

        internal static PropertyTag PidLidAddressBookProviderEmailList
        {
            get { return new PropertyTag(0x8028, PropertyType.PT_MV_LONG); }
        }

        internal static PropertyTag PidLidAddressBookProviderArrayType
        {
            get { return new PropertyTag(0x8029, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidHtml
        {
            get { return new PropertyTag(0x802B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidYomiFirstName
        {
            get { return new PropertyTag(0x802C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidYomiLastName
        {
            get { return new PropertyTag(0x802D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidYomiCompanyName
        {
            get { return new PropertyTag(0x802E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidBusinessCardDisplayDefinition
        {
            get { return new PropertyTag(0x8040, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidBusinessCardCardPicture
        {
            get { return new PropertyTag(0x8041, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidWorkAddressStreet
        {
            get { return new PropertyTag(0x8045, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddressCity
        {
            get { return new PropertyTag(0x8046, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddressState
        {
            get { return new PropertyTag(0x8047, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddressPostalCode
        {
            get { return new PropertyTag(0x8048, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddressCountry
        {
            get { return new PropertyTag(0x8049, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddressPostOfficeBox
        {
            get { return new PropertyTag(0x804A, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidDistributionListChecksum
        {
            get { return new PropertyTag(0x804C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidBirthdayEventEntryId
        {
            get { return new PropertyTag(0x804D, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAnniversaryEventEntryId
        {
            get { return new PropertyTag(0x804E, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidContactUserField1
        {
            get { return new PropertyTag(0x804F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidContactUserField2
        {
            get { return new PropertyTag(0x8050, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidContactUserField3
        {
            get { return new PropertyTag(0x8051, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidContactUserField4
        {
            get { return new PropertyTag(0x8052, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidDistributionListName
        {
            get { return new PropertyTag(0x8053, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidDistributionListOneOffMembers
        {
            get { return new PropertyTag(0x8054, PropertyType.PT_MV_BINARY); }
        }

        internal static PropertyTag PidLidDistributionListMembers
        {
            get { return new PropertyTag(0x8055, PropertyType.PT_MV_BINARY); }
        }

        internal static PropertyTag PidLidInstantMessagingAddress
        {
            get { return new PropertyTag(0x8062, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidDistributionListStream
        {
            get { return new PropertyTag(0x8064, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidEmail1DisplayName
        {
            get { return new PropertyTag(0x8080, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail1AddressType
        {
            get { return new PropertyTag(0x8082, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail1EmailAddress
        {
            get { return new PropertyTag(0x8083, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail1OriginalDisplayName
        {
            get { return new PropertyTag(0x8084, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail1OriginalEntryId
        {
            get { return new PropertyTag(0x8085, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidEmail1RichTextFormat
        {
            get { return new PropertyTag(0x8086, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidEmail1EmailType
        {
            get { return new PropertyTag(0x8087, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail2DisplayName
        {
            get { return new PropertyTag(0x8090, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail2EntryId
        {
            get { return new PropertyTag(0x8091, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidEmail2AddressType
        {
            get { return new PropertyTag(0x8092, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail2EmailAddress
        {
            get { return new PropertyTag(0x8093, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail2OriginalDisplayName
        {
            get { return new PropertyTag(0x8094, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail2OriginalEntryId
        {
            get { return new PropertyTag(0x8095, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidEmail2RichTextFormat
        {
            get { return new PropertyTag(0x8096, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidEmail3DisplayName
        {
            get { return new PropertyTag(0x80A0, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail3EntryId
        {
            get { return new PropertyTag(0x80A1, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidEmail3AddressType
        {
            get { return new PropertyTag(0x80A2, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail3EmailAddress
        {
            get { return new PropertyTag(0x80A3, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail3OriginalDisplayName
        {
            get { return new PropertyTag(0x80A4, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidEmail3OriginalEntryId
        {
            get { return new PropertyTag(0x80A5, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidEmail3RichTextFormat
        {
            get { return new PropertyTag(0x80A6, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidFax1AddressType
        {
            get { return new PropertyTag(0x80B2, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax1EmailAddress
        {
            get { return new PropertyTag(0x80B3, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax1OriginalDisplayName
        {
            get { return new PropertyTag(0x80B4, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax1OriginalEntryId
        {
            get { return new PropertyTag(0x80B5, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidFax2AddressType
        {
            get { return new PropertyTag(0x80C2, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax2EmailAddress
        {
            get { return new PropertyTag(0x80C3, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax2OriginalDisplayName
        {
            get { return new PropertyTag(0x80C4, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax2OriginalEntryId
        {
            get { return new PropertyTag(0x80C5, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidFax3AddressType
        {
            get { return new PropertyTag(0x80D2, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax3EmailAddress
        {
            get { return new PropertyTag(0x80D3, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax3OriginalDisplayName
        {
            get { return new PropertyTag(0x80D4, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFax3OriginalEntryId
        {
            get { return new PropertyTag(0x80D5, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidFreeBusyLocation
        {
            get { return new PropertyTag(0x80D8, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidHomeAddressCountryCode
        {
            get { return new PropertyTag(0x80DA, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWorkAddressCountryCode
        {
            get { return new PropertyTag(0x80DB, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidOtherAddressCountryCode
        {
            get { return new PropertyTag(0x80DC, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidBirthdayLocal
        {
            get { return new PropertyTag(0x80DE, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAddressCountryCode
        {
            get { return new PropertyTag(0x80DD, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidWeddingAnniversaryLocal
        {
            get { return new PropertyTag(0x80DF, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidTaskStatus
        {
            get { return new PropertyTag(0x8101, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidPercentComplete
        {
            get { return new PropertyTag(0x8102, PropertyType.PT_DOUBLE); }
        }

        internal static PropertyTag PidLidTeamTask
        {
            get { return new PropertyTag(0x8103, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskStartDate
        {
            get { return new PropertyTag(0x8104, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidTaskDueDate
        {
            get { return new PropertyTag(0x8105, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidTaskResetReminder
        {
            get { return new PropertyTag(0x8107, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskAccepted
        {
            get { return new PropertyTag(0x8108, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskDeadOccurrence
        {
            get { return new PropertyTag(0x8109, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskDateCompleted
        {
            get { return new PropertyTag(0x810F, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidTaskActualEffort
        {
            get { return new PropertyTag(0x8110, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskEstimatedEffort
        {
            get { return new PropertyTag(0x8111, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskVersion
        {
            get { return new PropertyTag(0x8112, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskState
        {
            get { return new PropertyTag(0x8113, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskLastUpdate
        {
            get { return new PropertyTag(0x8115, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidTaskRecurrence
        {
            get { return new PropertyTag(0x8116, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidTaskAssigners
        {
            get { return new PropertyTag(0x8117, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidTaskStatusOnComplete
        {
            get { return new PropertyTag(0x8119, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskHistory
        {
            get { return new PropertyTag(0x811A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskUpdates
        {
            get { return new PropertyTag(0x811B, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskComplete
        {
            get { return new PropertyTag(0x811C, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskFCreator
        {
            get { return new PropertyTag(0x811E, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskOwner
        {
            get { return new PropertyTag(0x811F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidTaskMultipleRecipients
        {
            get { return new PropertyTag(0x8120, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskAssigner
        {
            get { return new PropertyTag(0x8121, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidTaskLastUser
        {
            get { return new PropertyTag(0x8122, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidTaskOrdinal
        {
            get { return new PropertyTag(0x8123, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskNoCompute
        {
            get { return new PropertyTag(0x8124, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskLastDelegate
        {
            get { return new PropertyTag(0x8125, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidTaskFRecurring
        {
            get { return new PropertyTag(0x8126, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskRole
        {
            get { return new PropertyTag(0x8127, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidTaskOwnership
        {
            get { return new PropertyTag(0x8129, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAcceptanceState
        {
            get { return new PropertyTag(0x812A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTaskFFixOffline
        {
            get { return new PropertyTag(0x812C, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidTaskCustomFlags
        {
            get { return new PropertyTag(0x8139, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidTrustRecipientHighlights
        {
            get { return new PropertyTag(0x823E, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidSendMeetingAsIcal
        {
            get { return new PropertyTag(0x8200, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAppointmentSequence
        {
            get { return new PropertyTag(0x8201, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAppointmentSequenceTime
        {
            get { return new PropertyTag(0x8202, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentLastSequence
        {
            get { return new PropertyTag(0x8203, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidChangeHighlight
        {
            get { return new PropertyTag(0x8204, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidBusyStatus
        {
            get { return new PropertyTag(0x8205, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidFExceptionalBody
        {
            get { return new PropertyTag(0x8206, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAppointmentAuxiliaryFlags
        {
            get { return new PropertyTag(0x8207, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidLocation
        {
            get { return new PropertyTag(0x8208, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidMeetingWorkspaceUrl
        {
            get { return new PropertyTag(0x8209, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidForwardInstance
        {
            get { return new PropertyTag(0x820A, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidLinkedTaskItems
        {
            get { return new PropertyTag(0x820C, PropertyType.PT_MV_BINARY); }
        }

        internal static PropertyTag PidLidAppointmentStartWhole
        {
            get { return new PropertyTag(0x820D, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentEndWhole
        {
            get { return new PropertyTag(0x820E, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentStartTime
        {
            get { return new PropertyTag(0x820F, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentEndTime
        {
            get { return new PropertyTag(0x8210, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentEndDate
        {
            get { return new PropertyTag(0x8211, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentStartDate
        {
            get { return new PropertyTag(0x8212, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentDuration
        {
            get { return new PropertyTag(0x8213, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAppointmentColor
        {
            get { return new PropertyTag(0x8214, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAppointmentSubType
        {
            get { return new PropertyTag(0x8215, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAppointmentRecur
        {
            get { return new PropertyTag(0x8216, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAppointmentStateFlags
        {
            get { return new PropertyTag(0x8217, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidResponseStatus
        {
            get { return new PropertyTag(0x8218, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAppointmentReplyTime
        {
            get { return new PropertyTag(0x8220, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidRecurring
        {
            get { return new PropertyTag(0x8223, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidIntendedBusyStatus
        {
            get { return new PropertyTag(0x8224, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidUnknown8225
        {
            get { return new PropertyTag(0x8225, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidAppointmentUpdateTime
        {
            get { return new PropertyTag(0x8226, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidExceptionReplaceTime
        {
            get { return new PropertyTag(0x8228, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidFInvited
        {
            get { return new PropertyTag(0x8229, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidFExceptionalAttendees
        {
            get { return new PropertyTag(0x822B, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidUnknown822c
        {
            get { return new PropertyTag(0x822C, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidUnknown822d
        {
            get { return new PropertyTag(0x822D, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidOwnerName
        {
            get { return new PropertyTag(0x822E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidFOthersAppointment
        {
            get { return new PropertyTag(0x822F, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAppointmentReplyName
        {
            get { return new PropertyTag(0x8230, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidRecurrenceType
        {
            get { return new PropertyTag(0x8231, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidRecurrencePattern
        {
            get { return new PropertyTag(0x8232, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidTimeZoneStruct
        {
            get { return new PropertyTag(0x8233, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidTimeZoneDescription
        {
            get { return new PropertyTag(0x8234, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidClipStart
        {
            get { return new PropertyTag(0x8235, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidClipEnd
        {
            get { return new PropertyTag(0x8236, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidOriginalStoreEntryId
        {
            get { return new PropertyTag(0x8237, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAllAttendeesString
        {
            get { return new PropertyTag(0x8238, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidAutoFillLocation
        {
            get { return new PropertyTag(0x823A, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidToAttendeesString
        {
            get { return new PropertyTag(0x823B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidCcAttendeesString
        {
            get { return new PropertyTag(0x823C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidConferencingCheck
        {
            get { return new PropertyTag(0x8240, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidConferencingType
        {
            get { return new PropertyTag(0x8241, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidDirectory
        {
            get { return new PropertyTag(0x8242, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidOrganizerAlias
        {
            get { return new PropertyTag(0x8243, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidAutoStartCheck
        {
            get { return new PropertyTag(0x8244, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAutoStartWhen
        {
            get { return new PropertyTag(0x8245, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAllowExternalCheck
        {
            get { return new PropertyTag(0x8246, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidCollaborateDoc
        {
            get { return new PropertyTag(0x8247, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidNetShowUrl
        {
            get { return new PropertyTag(0x8248, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidOnlinePassword
        {
            get { return new PropertyTag(0x8249, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidAppointmentProposedStartWhole
        {
            get { return new PropertyTag(0x8250, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentProposedEndWhole
        {
            get { return new PropertyTag(0x8251, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidAppointmentProposedDuration
        {
            get { return new PropertyTag(0x8256, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAppointmentCounterProposal
        {
            get { return new PropertyTag(0x8257, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAppointmentProposalNumber
        {
            get { return new PropertyTag(0x8259, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidAppointmentNotAllowPropose
        {
            get { return new PropertyTag(0x825A, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidAppointmentUnsendableRecipients
        {
            get { return new PropertyTag(0x825D, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAppointmentTimeZoneDefinitionStartDisplay
        {
            get { return new PropertyTag(0x825E, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAppointmentTimeZoneDefinitionEndDisplay
        {
            get { return new PropertyTag(0x825F, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidAppointmentTimeZoneDefinitionRecur
        {
            get { return new PropertyTag(0x8260, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidForwardNotificationRecipients
        {
            get { return new PropertyTag(0x8261, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidInboundICalStream
        {
            get { return new PropertyTag(0x827A, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSingleBodyIcal
        {
            get { return new PropertyTag(0x827B, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidDayOfMonth
        {
            get { return new PropertyTag(0x1000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidICalendarDayOfWeekMask
        {
            get { return new PropertyTag(0x1001, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidUnknown1003
        {
            get { return new PropertyTag(0x1003, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidUnknown1004
        {
            get { return new PropertyTag(0x1004, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidOccurrences
        {
            get { return new PropertyTag(0x1005, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidMonthOfYear
        {
            get { return new PropertyTag(0x1006, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidUnknown100a
        {
            get { return new PropertyTag(0x100A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidNoEndDateFlag
        {
            get { return new PropertyTag(0x100B, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidRecurrenceDuration
        {
            get { return new PropertyTag(0x100D, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidUnknown100f
        {
            get { return new PropertyTag(0x100F, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidLidReminderTimeTime
        {
            get { return new PropertyTag(0x8504, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidReminderTimeDate
        {
            get { return new PropertyTag(0x8505, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidRemoteStatus
        {
            get { return new PropertyTag(0x8511, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidConversationActionMoveFolderEid
        {
            get { return new PropertyTag(0x85C6, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidConversationActionMoveStoreEid
        {
            get { return new PropertyTag(0x85C7, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidConversationActionMaxDeliveryTime
        {
            get { return new PropertyTag(0x85C8, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidConversationProcessed
        {
            get { return new PropertyTag(0x85C9, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidConversationActionLastAppliedTime
        {
            get { return new PropertyTag(0x85CA, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidConversationActionVersion
        {
            get { return new PropertyTag(0x85CB, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidLogType
        {
            get { return new PropertyTag(0x8700, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidLogStart
        {
            get { return new PropertyTag(0x8706, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidLogDuration
        {
            get { return new PropertyTag(0x8707, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidLogEnd
        {
            get { return new PropertyTag(0x8708, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidLogFlags
        {
            get { return new PropertyTag(0x870C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidDocumentPrinted
        {
            get { return new PropertyTag(0x870E, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidDocumentSaved
        {
            get { return new PropertyTag(0x870F, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidDocumentRouted
        {
            get { return new PropertyTag(0x8710, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidDocumentPosted
        {
            get { return new PropertyTag(0x8711, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidLogTypeDesc
        {
            get { return new PropertyTag(0x8712, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostRssChannelLink
        {
            get { return new PropertyTag(0x8900, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostRssItemLink
        {
            get { return new PropertyTag(0x8901, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostRssItemHash
        {
            get { return new PropertyTag(0x8902, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidPostRssItemGuid
        {
            get { return new PropertyTag(0x8903, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostRssChannel
        {
            get { return new PropertyTag(0x8904, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostRssItemXml
        {
            get { return new PropertyTag(0x8905, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidPostRssSubscription
        {
            get { return new PropertyTag(0x8906, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingStatus
        {
            get { return new PropertyTag(0x8A00, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingProviderGuid
        {
            get { return new PropertyTag(0x8A01, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingProviderName
        {
            get { return new PropertyTag(0x8A02, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingProviderUrl
        {
            get { return new PropertyTag(0x8A03, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemotePath
        {
            get { return new PropertyTag(0x8A04, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemoteName
        {
            get { return new PropertyTag(0x8A05, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemoteUid
        {
            get { return new PropertyTag(0x8A06, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingInitiatorName
        {
            get { return new PropertyTag(0x8A07, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingInitiatorSmtp
        {
            get { return new PropertyTag(0x8A08, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingInitiatorEntryId
        {
            get { return new PropertyTag(0x8A09, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingFlags
        {
            get { return new PropertyTag(0x8A0A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingProviderExtension
        {
            get { return new PropertyTag(0x8A0B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemoteUser
        {
            get { return new PropertyTag(0x8A0C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemotePass
        {
            get { return new PropertyTag(0x8A0D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingLocalPath
        {
            get { return new PropertyTag(0x8A0E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingLocalName
        {
            get { return new PropertyTag(0x8A0F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingLocalUid
        {
            get { return new PropertyTag(0x8A10, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingFilter
        {
            get { return new PropertyTag(0x8A13, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingLocalType
        {
            get { return new PropertyTag(0x8A14, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingFolderEntryId
        {
            get { return new PropertyTag(0x8A15, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingCapabilities
        {
            get { return new PropertyTag(0x8A17, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingFlavor
        {
            get { return new PropertyTag(0x8A18, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingAnonymity
        {
            get { return new PropertyTag(0x8A19, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingReciprocation
        {
            get { return new PropertyTag(0x8A1A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingPermissions
        {
            get { return new PropertyTag(0x8A1B, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingInstanceGuid
        {
            get { return new PropertyTag(0x8A1C, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingRemoteType
        {
            get { return new PropertyTag(0x8A1D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingParticipants
        {
            get { return new PropertyTag(0x8A1E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingLastSyncTime
        {
            get { return new PropertyTag(0x8A1F, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingExtensionXml
        {
            get { return new PropertyTag(0x8A21, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemoteLastModificationTime
        {
            get { return new PropertyTag(0x8A22, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingLocalLastModificationTime
        {
            get { return new PropertyTag(0x8A23, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingConfigurationUrl
        {
            get { return new PropertyTag(0x8A24, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingStart
        {
            get { return new PropertyTag(0x8A25, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingStop
        {
            get { return new PropertyTag(0x8A26, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingResponseType
        {
            get { return new PropertyTag(0x8A27, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingResponseTime
        {
            get { return new PropertyTag(0x8A28, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingOriginalMessageEntryId
        {
            get { return new PropertyTag(0x8A29, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingSyncInterval
        {
            get { return new PropertyTag(0x8A2A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingDetail
        {
            get { return new PropertyTag(0x8A2B, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingTimeToLive
        {
            get { return new PropertyTag(0x8A2C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingBindingEntryId
        {
            get { return new PropertyTag(0x8A2D, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingIndexEntryId
        {
            get { return new PropertyTag(0x8A2E, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingRemoteComment
        {
            get { return new PropertyTag(0x8A2F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingWorkingHoursStart
        {
            get { return new PropertyTag(0x8A40, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingWorkingHoursEnd
        {
            get { return new PropertyTag(0x8A41, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingWorkingHoursDay
        {
            get { return new PropertyTag(0x8A42, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingWorkingHoursTimeZone
        {
            get { return new PropertyTag(0x8A43, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingDataRangeStart
        {
            get { return new PropertyTag(0x8A44, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingDataRangeEnd
        {
            get { return new PropertyTag(0x8A45, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingRangeStart
        {
            get { return new PropertyTag(0x8A46, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingRangeEnd
        {
            get { return new PropertyTag(0x8A47, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingRemoteStoreUid
        {
            get { return new PropertyTag(0x8A48, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingLocalStoreUid
        {
            get { return new PropertyTag(0x8A49, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRemoteByteSize
        {
            get { return new PropertyTag(0x8A4B, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingRemoteCrc
        {
            get { return new PropertyTag(0x8A4C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingLocalComment
        {
            get { return new PropertyTag(0x8A4D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingRoamLog
        {
            get { return new PropertyTag(0x8A4E, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingRemoteMessageCount
        {
            get { return new PropertyTag(0x8A4F, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingBrowseUrl
        {
            get { return new PropertyTag(0x8A51, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingLastAutoSyncTime
        {
            get { return new PropertyTag(0x8A55, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidLidSharingTimeToLiveAuto
        {
            get { return new PropertyTag(0x8A56, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidSharingRemoteVersion
        {
            get { return new PropertyTag(0x8A5B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidSharingParentBindingEntryId
        {
            get { return new PropertyTag(0x8A5C, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidLidSharingSyncFlags
        {
            get { return new PropertyTag(0x8A60, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidNoteColor
        {
            get { return new PropertyTag(0x8B00, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidNoteWidth
        {
            get { return new PropertyTag(0x8B02, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidNoteHeight
        {
            get { return new PropertyTag(0x8B03, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidNoteX
        {
            get { return new PropertyTag(0x8B04, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidNoteY
        {
            get { return new PropertyTag(0x8B05, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidCategories
        {
            get { return new PropertyTag(0x9000, PropertyType.PT_MV_STRING8); }
        }

        internal static PropertyTag PidNameApplicationName
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAuthor
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameByteCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameCalendarAttendeeRole
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameCalendarBusyStatus
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCalendarContact
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCalendarContactUrl
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCalendarCreated
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidNameCalendarDescriptionUrl
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCalendarDuration
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameCalendarExceptionDate
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_MV_SYSTIME); }
        }

        internal static PropertyTag PidNameCalendarExceptionRule
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_MV_UNICODE); }
        }

        internal static PropertyTag PidNameCategory
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCharacterCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameComments
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCompany
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCreateDateTimeReadOnly
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidNameRightsManagementLicense
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_MV_BINARY); }
        }

        internal static PropertyTag PidNameEditTime
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameHiddenCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameKeywords
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_MV_STRING8); }
        }

        internal static PropertyTag PidNameLastAuthor
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameLastPrinted
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidNameLastSaveDateTime
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidNameLineCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameManager
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameMultimediaClipCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameNoteCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameOMSAccountGuid
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameOMSMobileModel
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameOMSGScheduleTime
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PidNameOMSServiceType
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameOMSSourceType
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNamePhishingStamp
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameSpoofingStamp
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNamePageCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameParagraphCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNamePresentationFormat
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameSecurity
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameSlideCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameSTSId
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_NULL); }
        }

        internal static PropertyTag PidNameSubject
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameTemplate
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameTitle
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameWordCount
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameAcceptLanguage
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameApproved
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameApprovalAllowedDescisionMakers
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameApprovalRequestor
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAuthenticatedAs
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAuthenticatedDomain
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAuthenticatedMechanism
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAuthenticatedSource
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameBcc
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCc
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentBase
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentClass
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentDisposition
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentID
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentLanguage
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentLocation
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentTransferEncoding
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameContentType
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameCrossReference
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingBrowseUrl
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingCapabilities
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingConfigUrl
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingExtendedCaps
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingFlavor
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingInstanceGuid
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingLocalType
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingProviderGuid
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingProviderName
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingProviderUrl
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingRemoteName
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingRemotePath
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingRemoteStoreUid
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingRemoteType
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSharingRemoteUid
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXSieve
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXVirusScanned
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidLidClientIntent
        {
            get { return new PropertyTag(0x0015, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidServerProcessed
        {
            get { return new PropertyTag(0x85CC, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PidLidServerProcessingActions
        {
            get { return new PropertyTag(0x85CD, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidNameAttachmentMacContentType
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAttachmentMacInfo
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidNameAudioNotes
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameAutomaticSpeechRecognitionData
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PidNameOutlookProtectionRuleTimestamp
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXUnifiedMessagingPartnerAssignedId
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXUnifiedMessagingPartnerContent
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXUnifiedMessagingPartnerContext
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameXUnifiedMessagingPartnerStatus
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameInstantMessagingAddress2
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameInstantMessagingAddress3
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PidNameOriginalSpamConfidenceLevel
        {
            get { return new PropertyTag(0x0000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidRemoteTransferSize
        {
            get { return new PropertyTag(0x8f05, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PidLidRemoteAttachment
        {
            get { return new PropertyTag(0x8f07, PropertyType.PT_BOOLEAN); }
        }
    }
}
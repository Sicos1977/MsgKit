//
// MessageIconIndex.cs
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

namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains a number that indicates which icon to use when you display a group of e-mail objects.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc815472(v=office.15).aspx
    ///     This property, if it exists, is a hint to the client. The client may ignore the value of this property.
    /// </remarks>
    [Flags]
    public enum MessageIconIndex : uint
    {
        /// <summary>
        ///     New mail
        /// </summary>
        NewMail = 0x00000000,

        /// <summary>
        ///     Post
        /// </summary>
        Post = 0x00000001,

        /// <summary>
        ///     Other
        /// </summary>
        Other = 0x00000003,

        /// <summary>
        ///     Read mail
        /// </summary>
        ReadMail = 0x00000100,

        /// <summary>
        ///     Unread mail
        /// </summary>
        UnreadMail = 0x00000101,

        /// <summary>
        ///     Submitted mail
        /// </summary>
        SubmittedMail = 0x00000102,

        /// <summary>
        ///     Unsent mail
        /// </summary>
        UnsentMail = 0x00000103,

        /// <summary>
        ///     Receipt mail
        /// </summary>
        ReceiptMail = 0x00000104,

        /// <summary>
        ///     Replied mail
        /// </summary>
        RepliedMail = 0x00000105,

        /// <summary>
        ///     Forwarded mail
        /// </summary>
        ForwardedMail = 0x00000106,

        /// <summary>
        ///     Remote mail
        /// </summary>
        RemoteMail = 0x00000107,

        /// <summary>
        ///     Delivery receipt
        /// </summary>
        DeliveryReceipt = 0x00000108,

        /// <summary>
        ///     Read receipt 
        /// </summary>
        ReadReceipt = 0x00000109,

        /// <summary>
        ///     Non delivery report
        /// </summary>
        NondeliveryReport = 0x0000010A,

        /// <summary>
        ///     Non read receipt
        /// </summary>
        NonReadReceipt = 0x0000010B,

        /// <summary>
        ///     Recall S mail
        /// </summary>
        RecallSMail = 0x0000010C,

        /// <summary>
        ///     Recall F mail
        /// </summary>
        RecallFMail = 0x0000010D,

        /// <summary>
        ///     Tracking mail
        /// </summary>
        TrackingMail = 0x0000010E,

        /// <summary>
        ///     Out of office mail
        /// </summary>
        OutOfOfficeMail = 0x0000011B,

        /// <summary>
        ///     Recall mail
        /// </summary>
        RecallMail = 0x0000011C,

        /// <summary>
        ///     Tracked mail
        /// </summary>
        TrackedMail = 0x00000130,

        /// <summary>
        ///     Contact
        /// </summary>
        Contact = 0x00000200,

        /// <summary>
        ///     Distribution list
        /// </summary>
        DistributionList = 0x00000202,

        /// <summary>
        ///     Sticky note blue
        /// </summary>
        StickyNoteBlue = 0x00000300,

        /// <summary>
        ///     Sticky note green
        /// </summary>
        StickyNoteGreen = 0x00000301,

        /// <summary>
        ///     Sticky note pink
        /// </summary>
        StickyNotePink = 0x00000302,

        /// <summary>
        ///     Sticky note yellow
        /// </summary>
        StickyNoteYellow = 0x00000303,

        /// <summary>
        ///     Sticky note white
        /// </summary>
        StickyNoteWhite = 0x00000304,

        /// <summary>
        ///     Single instance appointment
        /// </summary>
        SingleInstanceAppointment = 0x00000400,

        /// <summary>
        ///     Recurring appointment
        /// </summary>
        RecurringAppointment = 0x00000401,

        /// <summary>
        ///     Single instance meeting
        /// </summary>
        SingleInstanceMeeting = 0x00000402,

        /// <summary>
        ///     Recurring meeting
        /// </summary>
        RecurringMeeting = 0x00000403,

        /// <summary>
        ///     Meeting request
        /// </summary>
        MeetingRequest = 0x00000404,

        /// <summary>
        ///     Accept
        /// </summary>
        Accept = 0x00000405,

        /// <summary>
        ///     Decline
        /// </summary>
        Decline = 0x00000406,

        /// <summary>
        ///     Tentativly
        /// </summary>
        Tentativly = 0x00000407,

        /// <summary>
        ///     Cancellation
        /// </summary>
        Cancellation = 0x00000408,

        /// <summary>
        ///     Informational update
        /// </summary>
        InformationalUpdate = 0x00000409,

        /// <summary>
        ///     Task/task
        /// </summary>
        TaskTask = 0x00000500,

        /// <summary>
        ///     Unassigned recurring task
        /// </summary>
        UnassignedRecurringTask = 0x00000501,

        /// <summary>
        ///     Assignee's task
        /// </summary>
        AssigneesTask = 0x00000502,

        /// <summary>
        ///     Assigner's task
        /// </summary>
        AssignersTask = 0x00000503,

        /// <summary>
        ///     Task request
        /// </summary>
        TaskRequest = 0x00000504,

        /// <summary>
        ///     Task acceptance
        /// </summary>
        TaskAcceptance = 0x00000505,

        /// <summary>
        ///     Task rejection
        /// </summary>
        TaskRejection = 0x00000506,

        /// <summary>
        ///     Journal conversation
        /// </summary>
        JournalConversation = 0x00000601,

        /// <summary>
        ///     Journal e-mail message
        /// </summary>
        JournalEmailMessage = 0x00000602,

        /// <summary>
        ///     Journal meeting request
        /// </summary>
        JournalMeetingRequest = 0x00000603,

        /// <summary>
        ///     Journal meeting response
        /// </summary>
        JournalMeetingResponse = 0x00000604,

        /// <summary>
        ///     Journal task request
        /// </summary>
        JournalTaskRequest = 0x00000606,

        /// <summary>
        ///     Journal task response
        /// </summary>
        JournalTaskResponse = 0x00000607,

        /// <summary>
        ///     Journal note
        /// </summary>
        JournalNote = 0x00000608,

        /// <summary>
        ///     Journal fax
        /// </summary>
        JournalFax = 0x00000609,

        /// <summary>
        ///     Journal phone call
        /// </summary>
        JournalPhoneCall = 0x0000060A,

        /// <summary>
        ///     Journal letter
        /// </summary>
        JournalLetter = 0x0000060C,

        /// <summary>
        ///     Journal Microsoft Office Word
        /// </summary>
        JournalMicrosoftOfficeWord = 0x0000060D,

        /// <summary>
        ///     Journal Microsoft Office Excel
        /// </summary>
        JournalMicrosoftOfficeExcel = 0x0000060E,

        /// <summary>
        ///     Journal Microsoft Office PowerPoint
        /// </summary>
        JournalMicrosoftOfficePowerPoint = 0x0000060F,

        /// <summary>
        ///     Journal Microsoft Office Access
        /// </summary>
        JournalMicrosoftOfficeAccess = 0x00000610,

        /// <summary>
        ///     Journal document
        /// </summary>
        JournalDocument = 0x00000612,

        /// <summary>
        ///     Journal meeting
        /// </summary>
        JournalMeeting = 0x00000613,

        /// <summary>
        ///     Journal meeting cancellation
        /// </summary>
        JournalMeetingCancellation = 0x00000614,

        /// <summary>
        ///     Journal remote session
        /// </summary>
        JournalRemoteSession = 0x00000615
    }
 } 
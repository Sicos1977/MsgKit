namespace MsgWriter.Enums
{
    /// <summary>
    ///     Contains a number that indicates which icon to use when you display a group of e-mail objects.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc815472(v=office.15).aspx
    ///     This property, if it exists, is a hint to the client. The client may ignore the value of this property.
    /// </remarks>
    public enum MessageIconIndex : uint
    {
        /// <summary>
        ///     New mail
        /// </summary>
        NewMail = 0xFFFF,

        /// <summary>
        ///     Post
        /// </summary>
        Post = 0x0001,

        /// <summary>
        ///     Other
        /// </summary>
        Other = 0x0003,

        /// <summary>
        ///     Read mail
        /// </summary>
        ReadMail = 0x0100,

        /// <summary>
        ///     Unread mail
        /// </summary>
        UnreadMail = 0x0101,

        /// <summary>
        ///     Submitted mail
        /// </summary>
        SubmittedMail = 0x0102,

        /// <summary>
        ///     Unsent mail
        /// </summary>
        UnsentMail = 0x0103,

        /// <summary>
        ///     Receipt mail
        /// </summary>
        ReceiptMail = 0x0104,

        /// <summary>
        ///     Replied mail
        /// </summary>
        RepliedMail = 0x0105,

        /// <summary>
        ///     Forwarded mail
        /// </summary>
        ForwardedMail = 0x0106,

        /// <summary>
        ///     Remote mail
        /// </summary>
        RemoteMail = 0x0107,

        /// <summary>
        ///     Delivery receipt
        /// </summary>
        DeliveryReceipt = 0x0108,

        /// <summary>
        /// Read mail 
        /// </summary>
        ReadReceipt = 0x0109,

        /// <summary>
        ///     Non delivery report
        /// </summary>
        NonDeliveryReport = 0x010A,

        /// <summary>
        ///     Non read receipt
        /// </summary>
        NonReadReceipt = 0x010B,

        /// <summary>
        ///     Recall S mails
        /// </summary>
        RecallSMails = 0x010C,

        /// <summary>
        ///     Recall F mail
        /// </summary>
        RecallFMail = 0x010D,

        /// <summary>
        ///     Tracking mail
        /// </summary>
        TrackingMail = 0x010E,

        /// <summary>
        ///     Out of office mail
        /// </summary>
        OutOfOfficeMail = 0x011B,

        /// <summary>
        ///     Recall mail
        /// </summary>
        RecallMail = 0x011C,

        /// <summary>
        ///     Tracked mail
        /// </summary>
        TrackedMail = 0x0130,

        /// <summary>
        ///     Contact
        /// </summary>
        Contact = 0x0200,

        /// <summary>
        ///     Distribution list
        /// </summary>
        DistributionList = 0x0202,

        /// <summary>
        ///     Sticky note blue
        /// </summary>
        StickyNoteBlue = 0x0300,

        /// <summary>
        ///     Sticky note green
        /// </summary>
        StickyNoteGreen = 0x0301,

        /// <summary>
        ///     Sticky note pink
        /// </summary>
        StickyNotePink = 0x0302,

        /// <summary>
        ///     Sticky note yellow
        /// </summary>
        StickyNoteYellow = 0x0303,

        /// <summary>
        ///     Sticky note white
        /// </summary>
        StickyNoteWhite = 0x0304,

        /// <summary>
        ///     Single instance appointment
        /// </summary>
        SingleInstanceAppointment = 0x0400,

        /// <summary>
        ///     Recurring appointment
        /// </summary>
        RecurringAppointment = 0x0401,

        /// <summary>
        ///     Single instance meeting
        /// </summary>
        SingleInstanceMeeting = 0x0402,

        /// <summary>
        ///     Recurring meeting
        /// </summary>
        RecurringMeeting = 0x0403,

        /// <summary>
        ///     Meeting request
        /// </summary>
        MeetingRequest = 0x0404,

        /// <summary>
        ///     Accept
        /// </summary>
        Accept = 0x0405,

        /// <summary>
        ///     Decline
        /// </summary>
        Decline = 0x0406,

        /// <summary>
        ///     Tentativly
        /// </summary>
        Tentativly = 0x0407,

        /// <summary>
        ///     Cancellation
        /// </summary>
        Cancellation = 0x0408,

        /// <summary>
        ///     Informational update
        /// </summary>
        InformationalUpdate = 0x0409,

        /// <summary>
        ///     Task/task
        /// </summary>
        TaskTask = 0x0500,

        /// <summary>
        ///     Unassigned recurring task
        /// </summary>
        UnassignedRecurringTask = 0x0501,

        /// <summary>
        ///     Assignee's task
        /// </summary>
        AssigneesTask = 0x0502,

        /// <summary>
        ///     Assigner's task
        /// </summary>
        AssignersTask = 0x0503,

        /// <summary>
        ///     Task request
        /// </summary>
        TaskRequest = 0x0504,

        /// <summary>
        ///     Task acceptance
        /// </summary>
        TaskAcceptance = 0x0505,

        /// <summary>
        ///     Task rejection
        /// </summary>
        TaskRejection = 0x0506,

        /// <summary>
        ///     Journal conversation
        /// </summary>
        JournalConversation = 0x0601,

        /// <summary>
        ///     Journal e-mail message
        /// </summary>
        JournalEmailMessage = 0x0602,

        /// <summary>
        ///     Journal meeting request
        /// </summary>
        JournalMeetingRequest = 0x0603,

        /// <summary>
        ///     Journal meeting response
        /// </summary>
        JournalMeetingResponse = 0x0604,

        /// <summary>
        ///     Journal task request
        /// </summary>
        JournalTaskRequest = 0x0606,

        /// <summary>
        ///     Journal task response
        /// </summary>
        JournalTaskResponse = 0x0607,

        /// <summary>
        ///     Journal note
        /// </summary>
        JournalNote = 0x0608,

        /// <summary>
        ///     Journal fax
        /// </summary>
        JournalFax = 0x0609,

        /// <summary>
        ///     Journal phone call
        /// </summary>
        JournalPhoneCall = 0x060A,

        /// <summary>
        ///     Journal letter
        /// </summary>
        JournalLetter = 0x060C,

        /// <summary>
        ///     Journal Microsoft Office Word
        /// </summary>
        JournalMicrosoftOfficeWord = 0x060D,

        /// <summary>
        ///     Journal Microsoft Office Excel
        /// </summary>
        JournalMicrosoftOfficeExcel = 0x060E,

        /// <summary>
        ///     Journal Microsoft Office PowerPoint
        /// </summary>
        JournalMicrosoftOfficePowerPoint = 0x060F,

        /// <summary>
        ///     Journal Microsoft Office Access
        /// </summary>
        JournalMicrosoftOfficeAccess = 0x0610,

        /// <summary>
        ///     Journal document
        /// </summary>
        JournalDocument = 0x0612,

        /// <summary>
        ///     Journal meeting
        /// </summary>
        JournalMeeting = 0x0613,

        /// <summary>
        ///     Journal meeting cancellation
        /// </summary>
        JournalMeetingCancellation = 0x0614,

        /// <summary>
        ///     Journal remote session
        /// </summary>
        JournalRemoteSession = 0x0615
    }
}
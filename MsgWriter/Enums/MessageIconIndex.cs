// ReSharper disable InconsistentNaming
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
        /// <summary>        /// New mail         /// </summary>        New_mail = 0xFFFFFFFF,
        /// <summary>        /// Post         /// </summary>        Post = 0x00000001,
        /// <summary>        /// Other         /// </summary>        Other = 0x00000003,
        /// <summary>        /// Read mail         /// </summary>        Read_mail = 0x00000100,
        /// <summary>        /// Unread mail         /// </summary>        Unread_mail = 0x00000101,
        /// <summary>        /// Submitted mail         /// </summary>        Submitted_mail = 0x00000102,
        /// <summary>        /// Unsent mail         /// </summary>        Unsent_mail = 0x00000103,
        /// <summary>        /// Receipt mail         /// </summary>        Receipt_mail = 0x00000104,
        /// <summary>        /// Replied mail         /// </summary>        Replied_mail = 0x00000105,
        /// <summary>        /// Forwarded mail         /// </summary>        Forwarded_mail = 0x00000106,
        /// <summary>        /// Remote mail         /// </summary>        Remote_mail = 0x00000107,
        /// <summary>        /// Delivery mail         /// </summary>        Delivery_mail = 0x00000108,
        ///// <summary>        ///// Read mail         ///// </summary>        //Read_mail = 0x00000109,
        /// <summary>        /// Nondelivery mail         /// </summary>        Nondelivery_mail = 0x0000010A,
        /// <summary>        /// Nonread mail         /// </summary>        Nonread_mail = 0x0000010B,
        /// <summary>        /// Recall_S mail         /// </summary>        Recall_S_mail = 0x0000010C,
        /// <summary>        /// Recall_F mail         /// </summary>        Recall_F_mail = 0x0000010D,
        /// <summary>        /// Tracking mail         /// </summary>        Tracking_mail = 0x0000010E,
        /// <summary>        /// Out of office mail         /// </summary>        Out_of_office_mail = 0x0000011B,
        /// <summary>        /// Recall mail         /// </summary>        Recall_mail = 0x0000011C,
        /// <summary>        /// Tracked mail         /// </summary>        Tracked_mail = 0x00000130,
        /// <summary>        /// Contact         /// </summary>        Contact = 0x00000200,
        /// <summary>        /// Distribution list         /// </summary>        Distribution_list = 0x00000202,
        /// <summary>        /// Sticky note blue         /// </summary>        Sticky_note_blue = 0x00000300,
        /// <summary>        /// Sticky note green         /// </summary>        Sticky_note_green = 0x00000301,
        /// <summary>        /// Sticky note pink         /// </summary>        Sticky_note_pink = 0x00000302,
        /// <summary>        /// Sticky note yellow         /// </summary>        Sticky_note_yellow = 0x00000303,
        /// <summary>        /// Sticky note white         /// </summary>        Sticky_note_white = 0x00000304,
        /// <summary>        /// Single instance appointment         /// </summary>        Single_instance_appointment = 0x00000400,
        /// <summary>        /// Recurring appointment         /// </summary>        Recurring_appointment = 0x00000401,
        /// <summary>        /// Single instance meeting         /// </summary>        Single_instance_meeting = 0x00000402,
        /// <summary>        /// Recurring meeting         /// </summary>        Recurring_meeting = 0x00000403,
        /// <summary>        /// Meeting request         /// </summary>        Meeting_request = 0x00000404,
        /// <summary>        /// Accept         /// </summary>        Accept = 0x00000405,
        /// <summary>        /// Decline         /// </summary>        Decline = 0x00000406,
        /// <summary>        /// Tentativly         /// </summary>        Tentativly = 0x00000407,
        /// <summary>        /// Cancellation         /// </summary>        Cancellation = 0x00000408,
        /// <summary>        /// Informational update         /// </summary>        Informational_update = 0x00000409,
        /// <summary>        /// Task/task         /// </summary>        Task_task = 0x00000500,
        /// <summary>        /// Unassigned recurring task         /// </summary>        Unassigned_recurring_task = 0x00000501,
        /// <summary>        /// Assignee's task         /// </summary>        Assignees_task = 0x00000502,
        /// <summary>        /// Assigner's task         /// </summary>        Assigners_task = 0x00000503,
        /// <summary>        /// Task request         /// </summary>        Task_request = 0x00000504,
        /// <summary>        /// Task acceptance         /// </summary>        Task_acceptance = 0x00000505,
        /// <summary>        /// Task rejection         /// </summary>        Task_rejection = 0x00000506,
        /// <summary>        /// Journal conversation         /// </summary>        Journal_conversation = 0x00000601,
        /// <summary>        /// Journal e-mail message         /// </summary>        Journal_email_message = 0x00000602,
        /// <summary>        /// Journal meeting request         /// </summary>        Journal_meeting_request = 0x00000603,
        /// <summary>        /// Journal meeting response         /// </summary>        Journal_meeting_response = 0x00000604,
        /// <summary>        /// Journal task request         /// </summary>        Journal_task_request = 0x00000606,
        /// <summary>        /// Journal task response         /// </summary>        Journal_task_response = 0x00000607,
        /// <summary>        /// Journal note         /// </summary>        Journal_note = 0x00000608,
        /// <summary>        /// Journal fax         /// </summary>        Journal_fax = 0x00000609,
        /// <summary>        /// Journal phone call         /// </summary>        Journal_phone_call = 0x0000060A,
        /// <summary>        /// Journal letter         /// </summary>        Journal_letter = 0x0000060C,
        /// <summary>        /// Journal Microsoft Office Word         /// </summary>        Journal_Microsoft_Office_Word = 0x0000060D,
        /// <summary>        /// Journal Microsoft Office Excel         /// </summary>        Journal_Microsoft_Office_Excel = 0x0000060E,
        /// <summary>        /// Journal Microsoft Office PowerPoint         /// </summary>        Journal_Microsoft_Office_PowerPoint = 0x0000060F,
        /// <summary>        /// Journal Microsoft Office Access         /// </summary>        Journal_Microsoft_Office_Access = 0x00000610,
        /// <summary>        /// Journal document         /// </summary>        Journal_document = 0x00000612,
        /// <summary>        /// Journal meeting         /// </summary>        Journal_meeting = 0x00000613,
        /// <summary>        /// Journal meeting cancellation         /// </summary>        Journal_meeting_cancellation = 0x00000614,
        /// <summary>        /// Journal remote session         /// </summary>        Journal_remote_session = 0x00000615,    }
}
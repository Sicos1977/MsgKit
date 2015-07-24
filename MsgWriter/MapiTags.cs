// ReSharper disable InconsistentNaming

using CompoundFileStorage;
using MsgWriter.Streams;

namespace MsgWriter
{
    /// <summary>
    ///     A class that holds all the known mapi tags
    /// </summary>
    internal static class MapiTags
    {
        /// <summary>
        /// The prefix for an <see cref="Attachment"/> <see cref="CFStorage"/>
        /// </summary>
        internal const string AttachmentStoragePrefix = "__attach_version1.0_#";

        /// <summary>
        /// The prefix for a <see cref="MapiTag"/> <see cref="CFStream"/>
        /// </summary>
        internal const string SubStorageStreamPrefix = "__substg1.0_";

        internal static MapiTag PR_ACKNOWLEDGEMENT_MODE
        {
            get { return new MapiTag(0x0001, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ALTERNATE_RECIPIENT_ALLOWED
        {
            get { return new MapiTag(0x0002, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_AUTHORIZING_USERS
        {
            get { return new MapiTag(0x0003, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_AUTO_FORWARD_COMMENT
        {
            get { return new MapiTag(0x0004, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_AUTO_FORWARD_COMMENT_W
        {
            get { return new MapiTag(0x0004, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_AUTO_FORWARD_COMMENT_A
        {
            get { return new MapiTag(0x0004, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_AUTO_FORWARDED
        {
            get { return new MapiTag(0x0005, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_CONTENT_CONFIDENTIALITY_ALGORITHM_ID
        {
            get { return new MapiTag(0x0006, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONTENT_CORRELATOR
        {
            get { return new MapiTag(0x0007, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONTENT_IDENTIFIER
        {
            get { return new MapiTag(0x0008, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_CONTENT_IDENTIFIER_W
        {
            get { return new MapiTag(0x0008, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_CONTENT_IDENTIFIER_A
        {
            get { return new MapiTag(0x0008, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CONTENT_LENGTH
        {
            get { return new MapiTag(0x0009, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CONTENT_RETURN_REQUESTED
        {
            get { return new MapiTag(0x000A, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_CONVERSATION_KEY
        {
            get { return new MapiTag(0x000B, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONVERSION_EITS
        {
            get { return new MapiTag(0x000C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONVERSION_WITH_LOSS_PROHIBITED
        {
            get { return new MapiTag(0x000D, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_CONVERTED_EITS
        {
            get { return new MapiTag(0x000E, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_DEFERRED_DELIVERY_TIME
        {
            get { return new MapiTag(0x000F, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_DELIVER_TIME
        {
            get { return new MapiTag(0x0010, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_DISCARD_REASON
        {
            get { return new MapiTag(0x0011, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_DISCLOSURE_OF_RECIPIENTS
        {
            get { return new MapiTag(0x0012, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_DL_EXPANSION_HISTORY
        {
            get { return new MapiTag(0x0013, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_DL_EXPANSION_PROHIBITED
        {
            get { return new MapiTag(0x0014, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_EXPIRY_TIME
        {
            get { return new MapiTag(0x0015, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_IMPLICIT_CONVERSION_PROHIBITED
        {
            get { return new MapiTag(0x0016, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_IMPORTANCE
        {
            get { return new MapiTag(0x0017, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_IPM_ID
        {
            get { return new MapiTag(0x0018, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_LATEST_DELIVERY_TIME
        {
            get { return new MapiTag(0x0019, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_MESSAGE_CLASS
        {
            get { return new MapiTag(0x001A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_MESSAGE_CLASS_W
        {
            get { return new MapiTag(0x001A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_MESSAGE_CLASS_A
        {
            get { return new MapiTag(0x001A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_MESSAGE_DELIVERY_ID
        {
            get { return new MapiTag(0x001B, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_MESSAGE_SECURITY_LABEL
        {
            get { return new MapiTag(0x001E, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_OBSOLETED_IPMS
        {
            get { return new MapiTag(0x001F, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIPIENT_NAME
        {
            get { return new MapiTag(0x0020, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_EITS
        {
            get { return new MapiTag(0x0021, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINATOR_CERTIFICATE
        {
            get { return new MapiTag(0x0022, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINATOR_DELIVERY_REPORT_REQUESTED
        {
            get { return new MapiTag(0x0023, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ORIGINATOR_RETURN_ADDRESS
        {
            get { return new MapiTag(0x0024, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PARENT_KEY
        {
            get { return new MapiTag(0x0025, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PRIORITY
        {
            get { return new MapiTag(0x0026, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ORIGIN_CHECK
        {
            get { return new MapiTag(0x0027, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROOF_OF_SUBMISSION_REQUESTED
        {
            get { return new MapiTag(0x0028, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_READ_RECEIPT_REQUESTED
        {
            get { return new MapiTag(0x0029, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_RECEIPT_TIME
        {
            get { return new MapiTag(0x002A, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_RECIPIENT_REASSIGNMENT_PROHIBITED
        {
            get { return new MapiTag(0x002B, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_REDIRECTION_HISTORY
        {
            get { return new MapiTag(0x002C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RELATED_IPMS
        {
            get { return new MapiTag(0x002D, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_LANGUAGES
        {
            get { return new MapiTag(0x002F, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_LANGUAGES_W
        {
            get { return new MapiTag(0x002F, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_LANGUAGES_A
        {
            get { return new MapiTag(0x002F, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_REPLY_TIME
        {
            get { return new MapiTag(0x0030, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_REPORT_TAG
        {
            get { return new MapiTag(0x0031, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_REPORT_TIME
        {
            get { return new MapiTag(0x0032, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_RETURNED_IPM
        {
            get { return new MapiTag(0x0033, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_SECURITY
        {
            get { return new MapiTag(0x0034, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_INCOMPLETE_COPY
        {
            get { return new MapiTag(0x0035, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_SENSITIVITY
        {
            get { return new MapiTag(0x0036, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_SUBJECT
        {
            get { return new MapiTag(0x0037, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SUBJECT_W
        {
            get { return new MapiTag(0x0037, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SUBJECT_A
        {
            get { return new MapiTag(0x0037, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SUBJECT_IPM
        {
            get { return new MapiTag(0x0038, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CLIENT_SUBMIT_TIME
        {
            get { return new MapiTag(0x0039, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_REPORT_NAME
        {
            get { return new MapiTag(0x003A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_REPORT_NAME_W
        {
            get { return new MapiTag(0x003A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_REPORT_NAME_A
        {
            get { return new MapiTag(0x003A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_SEARCH_KEY
        {
            get { return new MapiTag(0x003B, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_X400_CONTENT_TYPE
        {
            get { return new MapiTag(0x003C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SUBJECT_PREFIX
        {
            get { return new MapiTag(0x003D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SUBJECT_PREFIX_W
        {
            get { return new MapiTag(0x003D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SUBJECT_PREFIX_A
        {
            get { return new MapiTag(0x003D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_NON_RECEIPT_REASON
        {
            get { return new MapiTag(0x003E, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RECEIVED_BY_ENTRYID
        {
            get { return new MapiTag(0x003F, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RECEIVED_BY_NAME
        {
            get { return new MapiTag(0x0040, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RECEIVED_BY_NAME_W
        {
            get { return new MapiTag(0x0040, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RECEIVED_BY_NAME_A
        {
            get { return new MapiTag(0x0040, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_ENTRYID
        {
            get { return new MapiTag(0x0041, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_NAME
        {
            get { return new MapiTag(0x0042, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_NAME_W
        {
            get { return new MapiTag(0x0042, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_NAME_A
        {
            get { return new MapiTag(0x0042, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_ENTRYID
        {
            get { return new MapiTag(0x0043, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_NAME
        {
            get { return new MapiTag(0x0044, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_NAME_W
        {
            get { return new MapiTag(0x0044, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_NAME_A
        {
            get { return new MapiTag(0x0044, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_REPORT_ENTRYID
        {
            get { return new MapiTag(0x0045, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_READ_RECEIPT_ENTRYID
        {
            get { return new MapiTag(0x0046, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_MESSAGE_SUBMISSION_ID
        {
            get { return new MapiTag(0x0047, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROVIDER_SUBMIT_TIME
        {
            get { return new MapiTag(0x0048, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_ORIGINAL_SUBJECT
        {
            get { return new MapiTag(0x0049, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SUBJECT_W
        {
            get { return new MapiTag(0x0049, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SUBJECT_A
        {
            get { return new MapiTag(0x0049, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_DISC_VAL
        {
            get { return new MapiTag(0x004A, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ORIG_MESSAGE_CLASS
        {
            get { return new MapiTag(0x004B, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIG_MESSAGE_CLASS_W
        {
            get { return new MapiTag(0x004B, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIG_MESSAGE_CLASS_A
        {
            get { return new MapiTag(0x004B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_ENTRYID
        {
            get { return new MapiTag(0x004C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_NAME
        {
            get { return new MapiTag(0x004D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_NAME_W
        {
            get { return new MapiTag(0x004D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_NAME_A
        {
            get { return new MapiTag(0x004D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SUBMIT_TIME
        {
            get { return new MapiTag(0x004E, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_REPLY_RECIPIENT_ENTRIES
        {
            get { return new MapiTag(0x004F, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_REPLY_RECIPIENT_NAMES
        {
            get { return new MapiTag(0x0050, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_REPLY_RECIPIENT_NAMES_W
        {
            get { return new MapiTag(0x0050, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_REPLY_RECIPIENT_NAMES_A
        {
            get { return new MapiTag(0x0050, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RECEIVED_BY_SEARCH_KEY
        {
            get { return new MapiTag(0x0051, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_SEARCH_KEY
        {
            get { return new MapiTag(0x0052, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_READ_RECEIPT_SEARCH_KEY
        {
            get { return new MapiTag(0x0053, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_REPORT_SEARCH_KEY
        {
            get { return new MapiTag(0x0054, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_DELIVERY_TIME
        {
            get { return new MapiTag(0x0055, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_SEARCH_KEY
        {
            get { return new MapiTag(0x0056, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_MESSAGE_TO_ME
        {
            get { return new MapiTag(0x0057, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_MESSAGE_CC_ME
        {
            get { return new MapiTag(0x0058, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_MESSAGE_RECIP_ME
        {
            get { return new MapiTag(0x0059, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_NAME
        {
            get { return new MapiTag(0x005A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_NAME_W
        {
            get { return new MapiTag(0x005A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_NAME_A
        {
            get { return new MapiTag(0x005A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_ENTRYID
        {
            get { return new MapiTag(0x005B, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_SEARCH_KEY
        {
            get { return new MapiTag(0x005C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_NAME
        {
            get { return new MapiTag(0x005D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_NAME_W
        {
            get { return new MapiTag(0x005D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_NAME_A
        {
            get { return new MapiTag(0x005D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_ENTRYID
        {
            get { return new MapiTag(0x005E, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_SEARCH_KEY
        {
            get { return new MapiTag(0x005F, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_START_DATE
        {
            get { return new MapiTag(0x0060, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_END_DATE
        {
            get { return new MapiTag(0x0061, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_OWNER_APPT_ID
        {
            get { return new MapiTag(0x0062, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RESPONSE_REQUESTED
        {
            get { return new MapiTag(0x0063, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_ADDRTYPE
        {
            get { return new MapiTag(0x0064, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_ADDRTYPE_W
        {
            get { return new MapiTag(0x0064, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_ADDRTYPE_A
        {
            get { return new MapiTag(0x0064, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x0065, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x0065, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SENT_REPRESENTING_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x0065, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_ADDRTYPE
        {
            get { return new MapiTag(0x0066, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_ADDRTYPE_W
        {
            get { return new MapiTag(0x0066, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_ADDRTYPE_A
        {
            get { return new MapiTag(0x0066, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x0067, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x0067, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SENDER_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x0067, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE
        {
            get { return new MapiTag(0x0068, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE_W
        {
            get { return new MapiTag(0x0068, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE_A
        {
            get { return new MapiTag(0x0068, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x0069, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x0069, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x0069, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CONVERSATION_TOPIC
        {
            get { return new MapiTag(0x0070, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_CONVERSATION_TOPIC_W
        {
            get { return new MapiTag(0x0070, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_CONVERSATION_TOPIC_A
        {
            get { return new MapiTag(0x0070, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CONVERSATION_INDEX
        {
            get { return new MapiTag(0x0071, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_BCC
        {
            get { return new MapiTag(0x0072, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_BCC_W
        {
            get { return new MapiTag(0x0072, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_BCC_A
        {
            get { return new MapiTag(0x0072, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_CC
        {
            get { return new MapiTag(0x0073, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_CC_W
        {
            get { return new MapiTag(0x0073, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_CC_A
        {
            get { return new MapiTag(0x0073, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_TO
        {
            get { return new MapiTag(0x0074, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_TO_W
        {
            get { return new MapiTag(0x0074, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_TO_A
        {
            get { return new MapiTag(0x0074, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RECEIVED_BY_ADDRTYPE
        {
            get { return new MapiTag(0x0075, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RECEIVED_BY_ADDRTYPE_W
        {
            get { return new MapiTag(0x0075, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RECEIVED_BY_ADDRTYPE_A
        {
            get { return new MapiTag(0x0075, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RECEIVED_BY_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x0076, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RECEIVED_BY_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x0076, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RECEIVED_BY_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x0076, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_ADDRTYPE
        {
            get { return new MapiTag(0x0077, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_ADDRTYPE_W
        {
            get { return new MapiTag(0x0077, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_ADDRTYPE_A
        {
            get { return new MapiTag(0x0077, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x0078, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x0078, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RCVD_REPRESENTING_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x0078, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_ADDRTYPE
        {
            get { return new MapiTag(0x0079, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_ADDRTYPE_W
        {
            get { return new MapiTag(0x0079, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_ADDRTYPE_A
        {
            get { return new MapiTag(0x0079, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x007A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x007A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_AUTHOR_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x007A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_ADDRTYPE
        {
            get { return new MapiTag(0x007B, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_ADDRTYPE_W
        {
            get { return new MapiTag(0x007B, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_ADDRTYPE_A
        {
            get { return new MapiTag(0x007B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x007C, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x007C, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x007C, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_TRANSPORT_MESSAGE_HEADERS
        {
            get { return new MapiTag(0x007D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_TRANSPORT_MESSAGE_HEADERS_W
        {
            get { return new MapiTag(0x007D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_TRANSPORT_MESSAGE_HEADERS_A
        {
            get { return new MapiTag(0x007D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_BODY
        {
            get { return new MapiTag(0x1000, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_BODY_W
        {
            get { return new MapiTag(0x1000, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_BODY_A
        {
            get { return new MapiTag(0x1000, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_REPORT_TEXT
        {
            get { return new MapiTag(0x1001, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_REPORT_TEXT_W
        {
            get { return new MapiTag(0x1001, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_REPORT_TEXT_A
        {
            get { return new MapiTag(0x1001, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINATOR_AND_DL_EXPANSION_HISTORY
        {
            get { return new MapiTag(0x1002, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_REPORTING_DL_NAME
        {
            get { return new MapiTag(0x1003, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_REPORTING_MTA_CERTIFICATE
        {
            get { return new MapiTag(0x1004, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RTF_SYNC_BODY_CRC
        {
            get { return new MapiTag(0x1006, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RTF_SYNC_BODY_COUNT
        {
            get { return new MapiTag(0x1007, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RTF_SYNC_BODY_TAG
        {
            get { return new MapiTag(0x1008, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RTF_SYNC_BODY_TAG_W
        {
            get { return new MapiTag(0x1008, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RTF_SYNC_BODY_TAG_A
        {
            get { return new MapiTag(0x1008, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RTF_COMPRESSED
        {
            get { return new MapiTag(0x1009, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RTF_SYNC_PREFIX_COUNT
        {
            get { return new MapiTag(0x1010, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RTF_SYNC_TRAILING_COUNT
        {
            get { return new MapiTag(0x1011, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ORIGINALLY_INTENDED_RECIP_ENTRYID
        {
            get { return new MapiTag(0x1012, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONTENT_INTEGRITY_CHECK
        {
            get { return new MapiTag(0x0C00, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_EXPLICIT_CONVERSION
        {
            get { return new MapiTag(0x0C01, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_IPM_RETURN_REQUESTED
        {
            get { return new MapiTag(0x0C02, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_MESSAGE_TOKEN
        {
            get { return new MapiTag(0x0C03, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_NDR_REASON_CODE
        {
            get { return new MapiTag(0x0C04, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_NDR_DIAG_CODE
        {
            get { return new MapiTag(0x0C05, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_NON_RECEIPT_NOTIFICATION_REQUESTED
        {
            get { return new MapiTag(0x0C06, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ORIGINATOR_NON_DELIVERY_REPORT_REQUESTED
        {
            get { return new MapiTag(0x0C08, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ORIGINATOR_REQUESTED_ALTERNATE_RECIPIENT
        {
            get { return new MapiTag(0x0C09, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PHYSICAL_DELIVERY_BUREAU_FAX_DELIVERY
        {
            get { return new MapiTag(0x0C0A, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_PHYSICAL_DELIVERY_MODE
        {
            get { return new MapiTag(0x0C0B, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_PHYSICAL_DELIVERY_REPORT_REQUEST
        {
            get { return new MapiTag(0x0C0C, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_PHYSICAL_FORWARDING_ADDRESS
        {
            get { return new MapiTag(0x0C0D, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PHYSICAL_FORWARDING_ADDRESS_REQUESTED
        {
            get { return new MapiTag(0x0C0E, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_PHYSICAL_FORWARDING_PROHIBITED
        {
            get { return new MapiTag(0x0C0F, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_PHYSICAL_RENDITION_ATTRIBUTES
        {
            get { return new MapiTag(0x0C10, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROOF_OF_DELIVERY
        {
            get { return new MapiTag(0x0C11, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROOF_OF_DELIVERY_REQUESTED
        {
            get { return new MapiTag(0x0C12, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_RECIPIENT_CERTIFICATE
        {
            get { return new MapiTag(0x0C13, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RECIPIENT_NUMBER_FOR_ADVICE
        {
            get { return new MapiTag(0x0C14, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RECIPIENT_NUMBER_FOR_ADVICE_W
        {
            get { return new MapiTag(0x0C14, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RECIPIENT_NUMBER_FOR_ADVICE_A
        {
            get { return new MapiTag(0x0C14, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RECIPIENT_TYPE
        {
            get { return new MapiTag(0x0C15, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_REGISTERED_MAIL_TYPE
        {
            get { return new MapiTag(0x0C16, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_REPLY_REQUESTED
        {
            get { return new MapiTag(0x0C17, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_REQUESTED_DELIVERY_METHOD
        {
            get { return new MapiTag(0x0C18, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_SENDER_ENTRYID
        {
            get { return new MapiTag(0x0C19, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SENDER_NAME
        {
            get { return new MapiTag(0x0C1A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SENDER_NAME_W
        {
            get { return new MapiTag(0x0C1A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SENDER_NAME_A
        {
            get { return new MapiTag(0x0C1A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SUPPLEMENTARY_INFO
        {
            get { return new MapiTag(0x0C1B, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SUPPLEMENTARY_INFO_W
        {
            get { return new MapiTag(0x0C1B, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SUPPLEMENTARY_INFO_A
        {
            get { return new MapiTag(0x0C1B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_TYPE_OF_MTS_USER
        {
            get { return new MapiTag(0x0C1C, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_SENDER_SEARCH_KEY
        {
            get { return new MapiTag(0x0C1D, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SENDER_ADDRTYPE
        {
            get { return new MapiTag(0x0C1E, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SENDER_ADDRTYPE_W
        {
            get { return new MapiTag(0x0C1E, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SENDER_ADDRTYPE_A
        {
            get { return new MapiTag(0x0C1E, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SENDER_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x0C1F, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SENDER_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x0C1F, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SENDER_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x0C1F, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CURRENT_VERSION
        {
            get { return new MapiTag(0x0E00, PropertyType.PT_I8); }
        }

        internal static MapiTag PR_DELETE_AFTER_SUBMIT
        {
            get { return new MapiTag(0x0E01, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_DISPLAY_BCC
        {
            get { return new MapiTag(0x0E02, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_DISPLAY_BCC_W
        {
            get { return new MapiTag(0x0E02, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_DISPLAY_BCC_A
        {
            get { return new MapiTag(0x0E02, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_DISPLAY_CC
        {
            get { return new MapiTag(0x0E03, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_DISPLAY_CC_W
        {
            get { return new MapiTag(0x0E03, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_DISPLAY_CC_A
        {
            get { return new MapiTag(0x0E03, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_DISPLAY_TO
        {
            get { return new MapiTag(0x0E04, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_DISPLAY_TO_W
        {
            get { return new MapiTag(0x0E04, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_DISPLAY_TO_A
        {
            get { return new MapiTag(0x0E04, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_PARENT_DISPLAY
        {
            get { return new MapiTag(0x0E05, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PARENT_DISPLAY_W
        {
            get { return new MapiTag(0x0E05, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_PARENT_DISPLAY_A
        {
            get { return new MapiTag(0x0E05, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_MESSAGE_DELIVERY_TIME
        {
            get { return new MapiTag(0x0E06, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_MESSAGE_FLAGS
        {
            get { return new MapiTag(0x0E07, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_MESSAGE_SIZE
        {
            get { return new MapiTag(0x0E08, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_PARENT_ENTRYID
        {
            get { return new MapiTag(0x0E09, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SENTMAIL_ENTRYID
        {
            get { return new MapiTag(0x0E0A, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CORRELATE
        {
            get { return new MapiTag(0x0E0C, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_CORRELATE_MTSID
        {
            get { return new MapiTag(0x0E0D, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_DISCRETE_VALUES
        {
            get { return new MapiTag(0x0E0E, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_RESPONSIBILITY
        {
            get { return new MapiTag(0x0E0F, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_SPOOLER_STATUS
        {
            get { return new MapiTag(0x0E10, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_TRANSPORT_STATUS
        {
            get { return new MapiTag(0x0E11, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_MESSAGE_RECIPIENTS
        {
            get { return new MapiTag(0x0E12, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_MESSAGE_ATTACHMENTS
        {
            get { return new MapiTag(0x0E13, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_SUBMIT_FLAGS
        {
            get { return new MapiTag(0x0E14, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RECIPIENT_STATUS
        {
            get { return new MapiTag(0x0E15, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_TRANSPORT_KEY
        {
            get { return new MapiTag(0x0E16, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_MSG_STATUS
        {
            get { return new MapiTag(0x0E17, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_MESSAGE_DOWNLOAD_TIME
        {
            get { return new MapiTag(0x0E18, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CREATION_VERSION
        {
            get { return new MapiTag(0x0E19, PropertyType.PT_I8); }
        }

        internal static MapiTag PR_MODIFY_VERSION
        {
            get { return new MapiTag(0x0E1A, PropertyType.PT_I8); }
        }

        internal static MapiTag PR_HASATTACH
        {
            get { return new MapiTag(0x0E1B, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_BODY_CRC
        {
            get { return new MapiTag(0x0E1C, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_NORMALIZED_SUBJECT
        {
            get { return new MapiTag(0x0E1D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_NORMALIZED_SUBJECT_W
        {
            get { return new MapiTag(0x0E1D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_NORMALIZED_SUBJECT_A
        {
            get { return new MapiTag(0x0E1D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RTF_IN_SYNC
        {
            get { return new MapiTag(0x0E1F, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ATTACH_SIZE
        {
            get { return new MapiTag(0x0E20, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ATTACH_NUM
        {
            get { return new MapiTag(0x0E21, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_PREPROCESS
        {
            get { return new MapiTag(0x0E22, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_ENTRYID
        {
            get { return new MapiTag(0x0FFF, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_OBJECT_TYPE
        {
            get { return new MapiTag(0x0FFE, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ICON
        {
            get { return new MapiTag(0x0FFD, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_MINI_ICON
        {
            get { return new MapiTag(0x0FFC, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_STORE_ENTRYID
        {
            get { return new MapiTag(0x0FFB, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_STORE_RECORD_KEY
        {
            get { return new MapiTag(0x0FFA, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RECORD_KEY
        {
            get { return new MapiTag(0x0FF9, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_MAPPING_SIGNATURE
        {
            get { return new MapiTag(0x0FF8, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ACCESS_LEVEL
        {
            get { return new MapiTag(0x0FF7, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_INSTANCE_KEY
        {
            get { return new MapiTag(0x0FF6, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ROW_TYPE
        {
            get { return new MapiTag(0x0FF5, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ACCESS
        {
            get { return new MapiTag(0x0FF4, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ROWID
        {
            get { return new MapiTag(0x3000, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_DISPLAY_NAME
        {
            get { return new MapiTag(0x3001, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_DISPLAY_NAME_W
        {
            get { return new MapiTag(0x3001, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_DISPLAY_NAME_A
        {
            get { return new MapiTag(0x3001, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ADDRTYPE
        {
            get { return new MapiTag(0x3002, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ADDRTYPE_W
        {
            get { return new MapiTag(0x3002, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ADDRTYPE_A
        {
            get { return new MapiTag(0x3002, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_EMAIL_ADDRESS
        {
            get { return new MapiTag(0x3003, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_EMAIL_ADDRESS_W
        {
            get { return new MapiTag(0x3003, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_EMAIL_ADDRESS_A
        {
            get { return new MapiTag(0x3003, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_COMMENT
        {
            get { return new MapiTag(0x3004, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_COMMENT_W
        {
            get { return new MapiTag(0x3004, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_COMMENT_A
        {
            get { return new MapiTag(0x3004, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_DEPTH
        {
            get { return new MapiTag(0x3005, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_PROVIDER_DISPLAY
        {
            get { return new MapiTag(0x3006, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PROVIDER_DISPLAY_W
        {
            get { return new MapiTag(0x3006, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_PROVIDER_DISPLAY_A
        {
            get { return new MapiTag(0x3006, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CREATION_TIME
        {
            get { return new MapiTag(0x3007, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_LAST_MODIFICATION_TIME
        {
            get { return new MapiTag(0x3008, PropertyType.PT_SYSTIME); }
        }

        internal static MapiTag PR_RESOURCE_FLAGS
        {
            get { return new MapiTag(0x3009, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_PROVIDER_DLL_NAME
        {
            get { return new MapiTag(0x300A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PROVIDER_DLL_NAME_W
        {
            get { return new MapiTag(0x300A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_PROVIDER_DLL_NAME_A
        {
            get { return new MapiTag(0x300A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SEARCH_KEY
        {
            get { return new MapiTag(0x300B, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROVIDER_UID
        {
            get { return new MapiTag(0x300C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROVIDER_ORDINAL
        {
            get { return new MapiTag(0x300D, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_FORM_VERSION
        {
            get { return new MapiTag(0x3301, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_FORM_VERSION_W
        {
            get { return new MapiTag(0x3301, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_FORM_VERSION_A
        {
            get { return new MapiTag(0x3301, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_FORM_CLSID
        {
            get { return new MapiTag(0x3302, PropertyType.PT_CLSID); }
        }

        internal static MapiTag PR_FORM_CONTACT_NAME
        {
            get { return new MapiTag(0x3303, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_FORM_CONTACT_NAME_W
        {
            get { return new MapiTag(0x3303, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_FORM_CONTACT_NAME_A
        {
            get { return new MapiTag(0x3303, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_FORM_CATEGORY
        {
            get { return new MapiTag(0x3304, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_FORM_CATEGORY_W
        {
            get { return new MapiTag(0x3304, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_FORM_CATEGORY_A
        {
            get { return new MapiTag(0x3304, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_FORM_CATEGORY_SUB
        {
            get { return new MapiTag(0x3305, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_FORM_CATEGORY_SUB_W
        {
            get { return new MapiTag(0x3305, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_FORM_CATEGORY_SUB_A
        {
            get { return new MapiTag(0x3305, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_FORM_HOST_MAP
        {
            get { return new MapiTag(0x3306, PropertyType.PT_MV_LONG); }
        }

        internal static MapiTag PR_FORM_HIDDEN
        {
            get { return new MapiTag(0x3307, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_FORM_DESIGNER_NAME
        {
            get { return new MapiTag(0x3308, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_FORM_DESIGNER_NAME_W
        {
            get { return new MapiTag(0x3308, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_FORM_DESIGNER_NAME_A
        {
            get { return new MapiTag(0x3308, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_FORM_DESIGNER_GUID
        {
            get { return new MapiTag(0x3309, PropertyType.PT_CLSID); }
        }

        internal static MapiTag PR_FORM_MESSAGE_BEHAVIOR
        {
            get { return new MapiTag(0x330A, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_DEFAULT_STORE
        {
            get { return new MapiTag(0x3400, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_STORE_SUPPORT_MASK
        {
            get { return new MapiTag(0x340D, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_STORE_STATE
        {
            get { return new MapiTag(0x340E, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_IPM_SUBTREE_SEARCH_KEY
        {
            get { return new MapiTag(0x3410, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_IPM_OUTBOX_SEARCH_KEY
        {
            get { return new MapiTag(0x3411, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_IPM_WASTEBASKET_SEARCH_KEY
        {
            get { return new MapiTag(0x3412, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_IPM_SENTMAIL_SEARCH_KEY
        {
            get { return new MapiTag(0x3413, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_MDB_PROVIDER
        {
            get { return new MapiTag(0x3414, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RECEIVE_FOLDER_SETTINGS
        {
            get { return new MapiTag(0x3415, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_VALID_FOLDER_MASK
        {
            get { return new MapiTag(0x35DF, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_IPM_SUBTREE_ENTRYID
        {
            get { return new MapiTag(0x35E0, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_IPM_OUTBOX_ENTRYID
        {
            get { return new MapiTag(0x35E2, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_IPM_WASTEBASKET_ENTRYID
        {
            get { return new MapiTag(0x35E3, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_IPM_SENTMAIL_ENTRYID
        {
            get { return new MapiTag(0x35E4, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_VIEWS_ENTRYID
        {
            get { return new MapiTag(0x35E5, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_COMMON_VIEWS_ENTRYID
        {
            get { return new MapiTag(0x35E6, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_FINDER_ENTRYID
        {
            get { return new MapiTag(0x35E7, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONTAINER_FLAGS
        {
            get { return new MapiTag(0x3600, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_FOLDER_TYPE
        {
            get { return new MapiTag(0x3601, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CONTENT_COUNT
        {
            get { return new MapiTag(0x3602, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CONTENT_UNREAD
        {
            get { return new MapiTag(0x3603, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CREATE_TEMPLATES
        {
            get { return new MapiTag(0x3604, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_DETAILS_TABLE
        {
            get { return new MapiTag(0x3605, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_SEARCH
        {
            get { return new MapiTag(0x3607, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_SELECTABLE
        {
            get { return new MapiTag(0x3609, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_SUBFOLDERS
        {
            get { return new MapiTag(0x360a, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_STATUS
        {
            get { return new MapiTag(0x360b, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ANR
        {
            get { return new MapiTag(0x360c, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ANR_W
        {
            get { return new MapiTag(0x360c, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ANR_A
        {
            get { return new MapiTag(0x360c, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CONTENTS_SORT_ORDER
        {
            get { return new MapiTag(0x360d, PropertyType.PT_MV_LONG); }
        }

        internal static MapiTag PR_CONTAINER_HIERARCHY
        {
            get { return new MapiTag(0x360e, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_CONTAINER_CONTENTS
        {
            get { return new MapiTag(0x360f, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_FOLDER_ASSOCIATED_CONTENTS
        {
            get { return new MapiTag(0x3610, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_DEF_CREATE_DL
        {
            get { return new MapiTag(0x3611, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_DEF_CREATE_MAILUSER
        {
            get { return new MapiTag(0x3612, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONTAINER_CLASS
        {
            get { return new MapiTag(0x3613, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_CONTAINER_CLASS_W
        {
            get { return new MapiTag(0x3613, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_CONTAINER_CLASS_A
        {
            get { return new MapiTag(0x3613, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CONTAINER_MODIFY_VERSION
        {
            get { return new MapiTag(0x3614, PropertyType.PT_I8); }
        }

        internal static MapiTag PR_AB_PROVIDER_ID
        {
            get { return new MapiTag(0x3615, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_DEFAULT_VIEW_ENTRYID
        {
            get { return new MapiTag(0x3616, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ASSOC_CONTENT_COUNT
        {
            get { return new MapiTag(0x3617, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ATTACHMENT_X400_PARAMETERS
        {
            get { return new MapiTag(0x3700, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ATTACH_DATA_OBJ
        {
            get { return new MapiTag(0x3701, PropertyType.PT_OBJECT); }
        }

        internal static MapiTag PR_ATTACH_DATA_BIN
        {
            get { return new MapiTag(0x3701, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ATTACH_ENCODING
        {
            get { return new MapiTag(0x3702, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ATTACH_EXTENSION
        {
            get { return new MapiTag(0x3703, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ATTACH_EXTENSION_W
        {
            get { return new MapiTag(0x3703, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ATTACH_EXTENSION_A
        {
            get { return new MapiTag(0x3703, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ATTACH_FILENAME
        {
            get { return new MapiTag(0x3704, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ATTACH_FILENAME_W
        {
            get { return new MapiTag(0x3704, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ATTACH_FILENAME_A
        {
            get { return new MapiTag(0x3704, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ATTACH_METHOD
        {
            get { return new MapiTag(0x3705, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ATTACH_LONG_FILENAME
        {
            get { return new MapiTag(0x3707, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ATTACH_LONG_FILENAME_W
        {
            get { return new MapiTag(0x3707, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ATTACH_LONG_FILENAME_A
        {
            get { return new MapiTag(0x3707, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ATTACH_PATHNAME
        {
            get { return new MapiTag(0x3708, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ATTACH_PATHNAME_W
        {
            get { return new MapiTag(0x3708, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ATTACH_PATHNAME_A
        {
            get { return new MapiTag(0x3708, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ATTACH_RENDERING
        {
            get { return new MapiTag(0x3709, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ATTACH_TAG
        {
            get { return new MapiTag(0x370A, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RENDERING_POSITION
        {
            get { return new MapiTag(0x370B, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_ATTACH_TRANSPORT_NAME
        {
            get { return new MapiTag(0x370C, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ATTACH_TRANSPORT_NAME_W
        {
            get { return new MapiTag(0x370C, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ATTACH_TRANSPORT_NAME_A
        {
            get { return new MapiTag(0x370C, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_DISPLAY_TYPE
        {
            get { return new MapiTag(0x3900, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_TEMPLATEID
        {
            get { return new MapiTag(0x3902, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PRIMARY_CAPABILITY
        {
            get { return new MapiTag(0x3904, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ACCOUNT
        {
            get { return new MapiTag(0x3A00, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ACCOUNT_W
        {
            get { return new MapiTag(0x3A00, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ACCOUNT_A
        {
            get { return new MapiTag(0x3A00, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ALTERNATE_RECIPIENT
        {
            get { return new MapiTag(0x3A01, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CALLBACK_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A02, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_CALLBACK_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A02, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_CALLBACK_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A02, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CONVERSION_PROHIBITED
        {
            get { return new MapiTag(0x3A03, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_DISCLOSE_RECIPIENTS
        {
            get { return new MapiTag(0x3A04, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_GENERATION
        {
            get { return new MapiTag(0x3A05, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_GENERATION_W
        {
            get { return new MapiTag(0x3A05, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_GENERATION_A
        {
            get { return new MapiTag(0x3A05, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_GIVEN_NAME
        {
            get { return new MapiTag(0x3A06, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_GIVEN_NAME_W
        {
            get { return new MapiTag(0x3A06, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_GIVEN_NAME_A
        {
            get { return new MapiTag(0x3A06, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_GOVERNMENT_ID_NUMBER
        {
            get { return new MapiTag(0x3A07, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_GOVERNMENT_ID_NUMBER_W
        {
            get { return new MapiTag(0x3A07, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_GOVERNMENT_ID_NUMBER_A
        {
            get { return new MapiTag(0x3A07, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_BUSINESS_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A08, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_BUSINESS_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A08, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_BUSINESS_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A08, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_HOME_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A09, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_HOME_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A09, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_HOME_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A09, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_INITIALS
        {
            get { return new MapiTag(0x3A0A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_INITIALS_W
        {
            get { return new MapiTag(0x3A0A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_INITIALS_A
        {
            get { return new MapiTag(0x3A0A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_KEYWORD
        {
            get { return new MapiTag(0x3A0B, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_KEYWORD_W
        {
            get { return new MapiTag(0x3A0B, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_KEYWORD_A
        {
            get { return new MapiTag(0x3A0B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_LANGUAGE
        {
            get { return new MapiTag(0x3A0C, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_LANGUAGE_W
        {
            get { return new MapiTag(0x3A0C, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_LANGUAGE_A
        {
            get { return new MapiTag(0x3A0C, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_LOCATION
        {
            get { return new MapiTag(0x3A0D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_LOCATION_W
        {
            get { return new MapiTag(0x3A0D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_LOCATION_A
        {
            get { return new MapiTag(0x3A0D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_MAIL_PERMISSION
        {
            get { return new MapiTag(0x3A0E, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_MHS_COMMON_NAME
        {
            get { return new MapiTag(0x3A0F, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_MHS_COMMON_NAME_W
        {
            get { return new MapiTag(0x3A0F, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_MHS_COMMON_NAME_A
        {
            get { return new MapiTag(0x3A0F, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORGANIZATIONAL_ID_NUMBER
        {
            get { return new MapiTag(0x3A10, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORGANIZATIONAL_ID_NUMBER_W
        {
            get { return new MapiTag(0x3A10, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORGANIZATIONAL_ID_NUMBER_A
        {
            get { return new MapiTag(0x3A10, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SURNAME
        {
            get { return new MapiTag(0x3A11, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SURNAME_W
        {
            get { return new MapiTag(0x3A11, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SURNAME_A
        {
            get { return new MapiTag(0x3A11, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_ENTRYID
        {
            get { return new MapiTag(0x3A12, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_NAME
        {
            get { return new MapiTag(0x3A13, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_NAME_W
        {
            get { return new MapiTag(0x3A13, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ORIGINAL_DISPLAY_NAME_A
        {
            get { return new MapiTag(0x3A13, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ORIGINAL_SEARCH_KEY
        {
            get { return new MapiTag(0x3A14, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_POSTAL_ADDRESS
        {
            get { return new MapiTag(0x3A15, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_POSTAL_ADDRESS_W
        {
            get { return new MapiTag(0x3A15, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_POSTAL_ADDRESS_A
        {
            get { return new MapiTag(0x3A15, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_COMPANY_NAME
        {
            get { return new MapiTag(0x3A16, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_COMPANY_NAME_W
        {
            get { return new MapiTag(0x3A16, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_COMPANY_NAME_A
        {
            get { return new MapiTag(0x3A16, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_TITLE
        {
            get { return new MapiTag(0x3A17, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_TITLE_W
        {
            get { return new MapiTag(0x3A17, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_TITLE_A
        {
            get { return new MapiTag(0x3A17, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_DEPARTMENT_NAME
        {
            get { return new MapiTag(0x3A18, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_DEPARTMENT_NAME_W
        {
            get { return new MapiTag(0x3A18, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_DEPARTMENT_NAME_A
        {
            get { return new MapiTag(0x3A18, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_OFFICE_LOCATION
        {
            get { return new MapiTag(0x3A19, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_OFFICE_LOCATION_W
        {
            get { return new MapiTag(0x3A19, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_OFFICE_LOCATION_A
        {
            get { return new MapiTag(0x3A19, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_PRIMARY_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A1A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PRIMARY_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A1A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_PRIMARY_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A1A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_BUSINESS2_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A1B, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_BUSINESS2_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A1B, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_BUSINESS2_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A1B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_MOBILE_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A1C, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_MOBILE_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A1C, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_MOBILE_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A1C, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_RADIO_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A1D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RADIO_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A1D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RADIO_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A1D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_CAR_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A1E, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_CAR_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A1E, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_CAR_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A1E, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_OTHER_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A1F, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_OTHER_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A1F, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_OTHER_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A1F, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_TRANSMITABLE_DISPLAY_NAME
        {
            get { return new MapiTag(0x3A20, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_TRANSMITABLE_DISPLAY_NAME_W
        {
            get { return new MapiTag(0x3A20, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_TRANSMITABLE_DISPLAY_NAME_A
        {
            get { return new MapiTag(0x3A20, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_PAGER_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A21, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PAGER_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A21, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_PAGER_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A21, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_USER_CERTIFICATE
        {
            get { return new MapiTag(0x3A22, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PRIMARY_FAX_NUMBER
        {
            get { return new MapiTag(0x3A23, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PRIMARY_FAX_NUMBER_W
        {
            get { return new MapiTag(0x3A23, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_PRIMARY_FAX_NUMBER_A
        {
            get { return new MapiTag(0x3A23, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_BUSINESS_FAX_NUMBER
        {
            get { return new MapiTag(0x3A24, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_BUSINESS_FAX_NUMBER_W
        {
            get { return new MapiTag(0x3A24, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_BUSINESS_FAX_NUMBER_A
        {
            get { return new MapiTag(0x3A24, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_HOME_FAX_NUMBER
        {
            get { return new MapiTag(0x3A25, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_HOME_FAX_NUMBER_W
        {
            get { return new MapiTag(0x3A25, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_HOME_FAX_NUMBER_A
        {
            get { return new MapiTag(0x3A25, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_COUNTRY
        {
            get { return new MapiTag(0x3A26, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_COUNTRY_W
        {
            get { return new MapiTag(0x3A26, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_COUNTRY_A
        {
            get { return new MapiTag(0x3A26, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_LOCALITY
        {
            get { return new MapiTag(0x3A27, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_LOCALITY_W
        {
            get { return new MapiTag(0x3A27, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_LOCALITY_A
        {
            get { return new MapiTag(0x3A27, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_STATE_OR_PROVINCE
        {
            get { return new MapiTag(0x3A28, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_STATE_OR_PROVINCE_W
        {
            get { return new MapiTag(0x3A28, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_STATE_OR_PROVINCE_A
        {
            get { return new MapiTag(0x3A28, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_STREET_ADDRESS
        {
            get { return new MapiTag(0x3A29, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_STREET_ADDRESS_W
        {
            get { return new MapiTag(0x3A29, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_STREET_ADDRESS_A
        {
            get { return new MapiTag(0x3A29, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_POSTAL_CODE
        {
            get { return new MapiTag(0x3A2A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_POSTAL_CODE_W
        {
            get { return new MapiTag(0x3A2A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_POSTAL_CODE_A
        {
            get { return new MapiTag(0x3A2A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_POST_OFFICE_BOX
        {
            get { return new MapiTag(0x3A2B, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_POST_OFFICE_BOX_W
        {
            get { return new MapiTag(0x3A2B, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_POST_OFFICE_BOX_A
        {
            get { return new MapiTag(0x3A2B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_TELEX_NUMBER
        {
            get { return new MapiTag(0x3A2C, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_TELEX_NUMBER_W
        {
            get { return new MapiTag(0x3A2C, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_TELEX_NUMBER_A
        {
            get { return new MapiTag(0x3A2C, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ISDN_NUMBER
        {
            get { return new MapiTag(0x3A2D, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ISDN_NUMBER_W
        {
            get { return new MapiTag(0x3A2D, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ISDN_NUMBER_A
        {
            get { return new MapiTag(0x3A2D, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ASSISTANT_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A2E, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ASSISTANT_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A2E, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ASSISTANT_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A2E, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_HOME2_TELEPHONE_NUMBER
        {
            get { return new MapiTag(0x3A2F, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_HOME2_TELEPHONE_NUMBER_W
        {
            get { return new MapiTag(0x3A2F, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_HOME2_TELEPHONE_NUMBER_A
        {
            get { return new MapiTag(0x3A2F, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_ASSISTANT
        {
            get { return new MapiTag(0x3A30, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_ASSISTANT_W
        {
            get { return new MapiTag(0x3A30, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_ASSISTANT_A
        {
            get { return new MapiTag(0x3A30, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SEND_RICH_INFO
        {
            get { return new MapiTag(0x3A40, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_STORE_PROVIDERS
        {
            get { return new MapiTag(0x3D00, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_AB_PROVIDERS
        {
            get { return new MapiTag(0x3D01, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_TRANSPORT_PROVIDERS
        {
            get { return new MapiTag(0x3D02, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_DEFAULT_PROFILE
        {
            get { return new MapiTag(0x3D04, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_AB_SEARCH_PATH
        {
            get { return new MapiTag(0x3D05, PropertyType.PT_MV_BINARY); }
        }

        internal static MapiTag PR_AB_DEFAULT_DIR
        {
            get { return new MapiTag(0x3D06, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_AB_DEFAULT_PAB
        {
            get { return new MapiTag(0x3D07, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_FILTERING_HOOKS
        {
            get { return new MapiTag(0x3D08, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SERVICE_NAME
        {
            get { return new MapiTag(0x3D09, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SERVICE_NAME_W
        {
            get { return new MapiTag(0x3D09, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SERVICE_NAME_A
        {
            get { return new MapiTag(0x3D09, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SERVICE_DLL_NAME
        {
            get { return new MapiTag(0x3D0A, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_SERVICE_DLL_NAME_W
        {
            get { return new MapiTag(0x3D0A, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_SERVICE_DLL_NAME_A
        {
            get { return new MapiTag(0x3D0A, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SERVICE_ENTRY_NAME
        {
            get { return new MapiTag(0x3D0B, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_SERVICE_UID
        {
            get { return new MapiTag(0x3D0C, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SERVICE_EXTRA_UIDS
        {
            get { return new MapiTag(0x3D0D, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SERVICES
        {
            get { return new MapiTag(0x3D0E, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_SERVICE_SUPPORT_FILES
        {
            get { return new MapiTag(0x3D0F, PropertyType.PT_MV_TSTRING); }
        }

        internal static MapiTag PR_SERVICE_SUPPORT_FILES_W
        {
            get { return new MapiTag(0x3D0F, PropertyType.PT_MV_UNICODE); }
        }

        internal static MapiTag PR_SERVICE_SUPPORT_FILES_A
        {
            get { return new MapiTag(0x3D0F, PropertyType.PT_MV_STRING8); }
        }

        internal static MapiTag PR_SERVICE_DELETE_FILES
        {
            get { return new MapiTag(0x3D10, PropertyType.PT_MV_TSTRING); }
        }

        internal static MapiTag PR_SERVICE_DELETE_FILES_W
        {
            get { return new MapiTag(0x3D10, PropertyType.PT_MV_UNICODE); }
        }

        internal static MapiTag PR_SERVICE_DELETE_FILES_A
        {
            get { return new MapiTag(0x3D10, PropertyType.PT_MV_STRING8); }
        }

        internal static MapiTag PR_AB_SEARCH_PATH_UPDATE
        {
            get { return new MapiTag(0x3D11, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_PROFILE_NAME
        {
            get { return new MapiTag(0x3D12, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_PROFILE_NAME_A
        {
            get { return new MapiTag(0x3D12, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_PROFILE_NAME_W
        {
            get { return new MapiTag(0x3D12, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_IDENTITY_DISPLAY
        {
            get { return new MapiTag(0x3E00, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_IDENTITY_DISPLAY_W
        {
            get { return new MapiTag(0x3E00, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_IDENTITY_DISPLAY_A
        {
            get { return new MapiTag(0x3E00, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_IDENTITY_ENTRYID
        {
            get { return new MapiTag(0x3E01, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RESOURCE_METHODS
        {
            get { return new MapiTag(0x3E02, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_RESOURCE_TYPE
        {
            get { return new MapiTag(0x3E03, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_STATUS_CODE
        {
            get { return new MapiTag(0x3E04, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_IDENTITY_SEARCH_KEY
        {
            get { return new MapiTag(0x3E05, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_OWN_STORE_ENTRYID
        {
            get { return new MapiTag(0x3E06, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_RESOURCE_PATH
        {
            get { return new MapiTag(0x3E07, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_RESOURCE_PATH_W
        {
            get { return new MapiTag(0x3E07, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_RESOURCE_PATH_A
        {
            get { return new MapiTag(0x3E07, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_STATUS_STRING
        {
            get { return new MapiTag(0x3E08, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_STATUS_STRING_W
        {
            get { return new MapiTag(0x3E08, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_STATUS_STRING_A
        {
            get { return new MapiTag(0x3E08, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_X400_DEFERRED_DELIVERY_CANCEL
        {
            get { return new MapiTag(0x3E09, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_HEADER_FOLDER_ENTRYID
        {
            get { return new MapiTag(0x3E0A, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_REMOTE_PROGRESS
        {
            get { return new MapiTag(0x3E0B, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_REMOTE_PROGRESS_TEXT
        {
            get { return new MapiTag(0x3E0C, PropertyType.PT_TSTRING); }
        }

        internal static MapiTag PR_REMOTE_PROGRESS_TEXT_W
        {
            get { return new MapiTag(0x3E0C, PropertyType.PT_UNICODE); }
        }

        internal static MapiTag PR_REMOTE_PROGRESS_TEXT_A
        {
            get { return new MapiTag(0x3E0C, PropertyType.PT_STRING8); }
        }

        internal static MapiTag PR_REMOTE_VALIDATE_OK
        {
            get { return new MapiTag(0x3E0D, PropertyType.PT_BOOLEAN); }
        }

        internal static MapiTag PR_CONTROL_FLAGS
        {
            get { return new MapiTag(0x3F00, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CONTROL_STRUCTURE
        {
            get { return new MapiTag(0x3F01, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_CONTROL_TYPE
        {
            get { return new MapiTag(0x3F02, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_DELTAX
        {
            get { return new MapiTag(0x3F03, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_DELTAY
        {
            get { return new MapiTag(0x3F04, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_XPOS
        {
            get { return new MapiTag(0x3F05, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_YPOS
        {
            get { return new MapiTag(0x3F06, PropertyType.PT_LONG); }
        }

        internal static MapiTag PR_CONTROL_ID
        {
            get { return new MapiTag(0x3F07, PropertyType.PT_BINARY); }
        }

        internal static MapiTag PR_INITIAL_DETAILS_PANE
        {
            get { return new MapiTag(0x3F08, PropertyType.PT_LONG); }
        }
    }

    /// <summary>
    ///     Used to hold exactly one mapi tag
    /// </summary>
    internal class MapiTag
    {
        #region Properties
        /// <summary>
        ///     The 2 byte identifier
        /// </summary>
        public ushort Id { get; private set; }

        /// <summary>
        ///     The 2 byte <see cref="PropertyType" />
        /// </summary>
        public PropertyType Type { get; private set; }

        /// <summary>
        ///     Returns the MapiTag as a readable string, e.g.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get { return MapiTags.SubStorageStreamPrefix + Id.ToString("X4") + ((ushort) Type).ToString("X4"); }
        }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all its properties
        /// </summary>
        /// <param name="id">The id (ushort)</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        internal MapiTag(ushort id, PropertyType type)
        {
            Id = id;
            Type = type;
        }
        #endregion
    }
}
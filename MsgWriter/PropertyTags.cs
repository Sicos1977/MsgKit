using CompoundFileStorage;
using MsgWriter.Streams;

// ReSharper disable InconsistentNaming

/*
   Copyright 2015 Kees van Spelde

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

namespace MsgWriter
{
    /// <summary>
    ///     A class that holds all the known mapi tags
    /// </summary>
    internal static class PropertyTags
    {
        /// <summary>
        ///     The prefix for an <see cref="Attachment" /> <see cref="CFStorage" />
        /// </summary>
        internal const string AttachmentStoragePrefix = "__attach_version1.0_#";

        /// <summary>
        ///     The prefix for a <see cref="PropertyTag" /> <see cref="CFStream" />
        /// </summary>
        internal const string SubStorageStreamPrefix = "__substg1.0_";

        /// <summary>
        ///     Contains the identifier of the mode for message acknowledgment.
        /// </summary>
        internal static PropertyTag PR_ACKNOWLEDGEMENT_MODE
        {
            get { return new PropertyTag(0x0001, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if the sender permits auto forwarding of this message.
        /// </summary>
        internal static PropertyTag PR_ALTERNATE_RECIPIENT_ALLOWED
        {
            get { return new PropertyTag(0x0002, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a list of entry identifiers for users who have authorized the sending of a message.
        /// </summary>
        internal static PropertyTag PR_AUTHORIZING_USERS
        {
            get { return new PropertyTag(0x0003, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unicode comment added by the auto-forwarding agent.
        /// </summary>
        internal static PropertyTag PR_AUTO_FORWARD_COMMENT_W
        {
            get { return new PropertyTag(0x0004, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a ANSI comment added by the auto-forwarding agent.
        /// </summary>
        internal static PropertyTag PR_AUTO_FORWARD_COMMENT_A
        {
            get { return new PropertyTag(0x0004, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if the client requests an X-MS-Exchange-Organization-AutoForwarded header field.
        /// </summary>
        internal static PropertyTag PR_AUTO_FORWARDED
        {
            get { return new PropertyTag(0x0005, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an identifier for the algorithm used to confirm message content confidentiality.
        /// </summary>
        internal static PropertyTag PR_CONTENT_CONFIDENTIALITY_ALGORITHM_ID
        {
            get { return new PropertyTag(0x0006, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value the message sender can use to match a report with the original message.
        /// </summary>
        internal static PropertyTag PR_CONTENT_CORRELATOR
        {
            get { return new PropertyTag(0x0007, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unicode key value that enables the message recipient to identify its content.
        /// </summary>
        internal static PropertyTag PR_CONTENT_IDENTIFIER_W
        {
            get { return new PropertyTag(0x0008, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a ANSI key value that enables the message recipient to identify its content.
        /// </summary>
        internal static PropertyTag PR_CONTENT_IDENTIFIER_A
        {
            get { return new PropertyTag(0x0008, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a message length, in bytes, passed to a client application or service provider to determine if a message
        ///     of that length can be delivered.
        /// </summary>
        internal static PropertyTag PR_CONTENT_LENGTH
        {
            get { return new PropertyTag(0x0009, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if a message should be returned with a nondelivery report.
        /// </summary>
        internal static PropertyTag PR_CONTENT_RETURN_REQUESTED
        {
            get { return new PropertyTag(0x000A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the conversation key used in Microsoft Outlook only when locating IPM.MessageManager messages, such as the
        ///     message that contains download history for a Post Office Protocol (POP3) account. This property has been deprecated
        ///     in Exchange Server.
        /// </summary>
        internal static PropertyTag PR_CONVERSATION_KEY
        {
            get { return new PropertyTag(0x000B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the encoded information types (EITs) that are applied to a message in transit to describe conversions.
        /// </summary>
        internal static PropertyTag PR_CONVERSION_EITS
        {
            get { return new PropertyTag(0x000C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message transfer agent (MTA) is prohibited from making message text conversions that lose
        ///     information.
        /// </summary>
        internal static PropertyTag PR_CONVERSION_WITH_LOSS_PROHIBITED
        {
            get { return new PropertyTag(0x000D, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an identifier for the types of text in a message after conversion.
        /// </summary>
        internal static PropertyTag PR_CONVERTED_EITS
        {
            get { return new PropertyTag(0x000E, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_DEFERRED_DELIVERY_TIME
        {
            get { return new PropertyTag(0x000F, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the date and time when the original message was delivered.
        /// </summary>
        internal static PropertyTag PR_DELIVER_TIME
        {
            get { return new PropertyTag(0x0010, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a reason why a message transfer agent (MTA) has discarded a message.
        /// </summary>
        internal static PropertyTag PR_DISCARD_REASON
        {
            get { return new PropertyTag(0x0011, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if disclosure of recipients is allowed.
        /// </summary>
        internal static PropertyTag PR_DISCLOSURE_OF_RECIPIENTS
        {
            get { return new PropertyTag(0x0012, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a history showing how a distribution list has been expanded during message transmiss
        /// </summary>
        internal static PropertyTag PR_DL_EXPANSION_HISTORY
        {
            get { return new PropertyTag(0x0013, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message transfer agent (MTA) is prohibited from expanding distribution lists.
        /// </summary>
        internal static PropertyTag PR_DL_EXPANSION_PROHIBITED
        {
            get { return new PropertyTag(0x0014, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the date and time when the messaging system can invalidate the content of a message.
        /// </summary>
        internal static PropertyTag PR_EXPIRY_TIME
        {
            get { return new PropertyTag(0x0015, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the date and time when the messaging system can invalidate the content of a message.
        /// </summary>
        internal static PropertyTag PR_IMPLICIT_CONVERSION_PROHIBITED
        {
            get { return new PropertyTag(0x0016, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a value that indicates the message sender's opinion of the importance of a message.
        /// </summary>
        internal static PropertyTag PR_IMPORTANCE
        {
            get { return new PropertyTag(0x0017, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     The IpmId field represents a PR_IPM_ID MAPI property.
        /// </summary>
        internal static PropertyTag PR_IPM_ID
        {
            get { return new PropertyTag(0x0018, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the latest date and time when a message transfer agent (MTA) should deliver a message.
        /// </summary>
        internal static PropertyTag PR_LATEST_DELIVERY_TIME
        {
            get { return new PropertyTag(0x0019, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a text string that identifies the sender-defined message class, such as IPM.Note.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_CLASS_W
        {
            get { return new PropertyTag(0x001A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a text string that identifies the sender-defined message class, such as IPM.Note.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_CLASS_A
        {
            get { return new PropertyTag(0x001A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a message transfer system (MTS) identifier for a message delivered to a client application.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_DELIVERY_ID
        {
            get { return new PropertyTag(0x001B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a security label for a message.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_SECURITY_LABEL
        {
            get { return new PropertyTag(0x001E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the identifiers of messages that this message supersedes.
        /// </summary>
        internal static PropertyTag PR_OBSOLETED_IPMS
        {
            get { return new PropertyTag(0x001F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the encoded name of the originally intended recipient of an autoforwarded message.
        /// </summary>
        internal static PropertyTag PR_ORIGINALLY_INTENDED_RECIPIENT_NAME
        {
            get { return new PropertyTag(0x0020, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a copy of the original encoded information types (EITs) for message text.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_EITS
        {
            get { return new PropertyTag(0x0021, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an ASN.1 certificate for the message originator.
        /// </summary>
        internal static PropertyTag PR_ORIGINATOR_CERTIFICATE
        {
            get { return new PropertyTag(0x0022, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests a delivery report for a particular recipient from the messaging system
        ///     before the message is placed in the message store.
        /// </summary>
        internal static PropertyTag PR_ORIGINATOR_DELIVERY_REPORT_REQUESTED
        {
            get { return new PropertyTag(0x0023, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the binary-encoded return address of the message originator.
        /// </summary>
        internal static PropertyTag PR_ORIGINATOR_RETURN_ADDRESS
        {
            get { return new PropertyTag(0x0024, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Was originally meant to contain a value used in correlating conversation threads. No longer supported.
        /// </summary>
        internal static PropertyTag PR_PARENT_KEY
        {
            get { return new PropertyTag(0x0025, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the relative priority of a message.
        /// </summary>
        internal static PropertyTag PR_PRIORITY
        {
            get { return new PropertyTag(0x0026, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a binary verification value enabling a delivery report recipient to verify the origin of the original
        ///     message.
        /// </summary>
        internal static PropertyTag PR_ORIGIN_CHECK
        {
            get { return new PropertyTag(0x0027, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests proof that the message transfer system has submitted a message for
        ///     delivery to the originally intended recipient.
        /// </summary>
        internal static PropertyTag PR_PROOF_OF_SUBMISSION_REQUESTED
        {
            get { return new PropertyTag(0x0028, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender wants the messaging system to generate a read report when the recipient has read
        ///     a message.
        /// </summary>
        internal static PropertyTag PR_READ_RECEIPT_REQUESTED
        {
            get { return new PropertyTag(0x0029, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the date and time a delivery report is generated.
        /// </summary>
        internal static PropertyTag PR_RECEIPT_TIME
        {
            get { return new PropertyTag(0x002A, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains TRUE if recipient reassignment is prohibited.
        /// </summary>
        internal static PropertyTag PR_RECIPIENT_REASSIGNMENT_PROHIBITED
        {
            get { return new PropertyTag(0x002B, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains information about the route covered by a delivered message.
        /// </summary>
        internal static PropertyTag PR_REDIRECTION_HISTORY
        {
            get { return new PropertyTag(0x002C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of identifiers for messages to which a message is related.
        /// </summary>
        internal static PropertyTag PR_RELATED_IPMS
        {
            get { return new PropertyTag(0x002D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the sensitivity value assigned by the sender of the first version of a message — that is, the message
        ///     before being forwarded or replied to.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENSITIVITY
        {
            get { return new PropertyTag(0x002E, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains an ASCII list of the languages incorporated in a message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_LANGUAGES_W
        {
            get { return new PropertyTag(0x002F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an ASCII list of the languages incorporated in a message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_LANGUAGES_A
        {
            get { return new PropertyTag(0x002F, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the date and time by which a reply is expected for a message.
        /// </summary>
        internal static PropertyTag PR_REPLY_TIME
        {
            get { return new PropertyTag(0x0030, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a binary tag value that the messaging system should copy to any report generated for the message.
        /// </summary>
        internal static PropertyTag PR_REPORT_TAG
        {
            get { return new PropertyTag(0x0031, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the date and time when the messaging system generated a report.
        /// </summary>
        internal static PropertyTag PR_REPORT_TIME
        {
            get { return new PropertyTag(0x0032, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains TRUE if the original message is being returned with a nonread report.
        /// </summary>
        internal static PropertyTag PR_RETURNED_IPM
        {
            get { return new PropertyTag(0x0033, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a flag that indicates the security level of a message.
        /// </summary>
        internal static PropertyTag PR_SECURITY
        {
            get { return new PropertyTag(0x0034, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if this message is an incomplete copy of another message.
        /// </summary>
        internal static PropertyTag PR_INCOMPLETE_COPY
        {
            get { return new PropertyTag(0x0035, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a value indicating the message sender's opinion of the sensitivity of a message.
        /// </summary>
        internal static PropertyTag PR_SENSITIVITY
        {
            get { return new PropertyTag(0x0036, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the full subject, encoded in Unicode standard, of a message.
        /// </summary>
        internal static PropertyTag PR_SUBJECT_W
        {
            get { return new PropertyTag(0x0037, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the full subject, encoded in ANSI standard, of a message.
        /// </summary>
        internal static PropertyTag PR_SUBJECT_A
        {
            get { return new PropertyTag(0x0037, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a binary value that is copied from the message for which a report is being generated.
        /// </summary>
        internal static PropertyTag PR_SUBJECT_IPM
        {
            get { return new PropertyTag(0x0038, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the date and time the message sender submitted a message.
        /// </summary>
        internal static PropertyTag PR_CLIENT_SUBMIT_TIME
        {
            get { return new PropertyTag(0x0039, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the unicode display name for the recipient that should get reports for this message.
        /// </summary>
        internal static PropertyTag PR_REPORT_NAME_W
        {
            get { return new PropertyTag(0x003A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the ANSI display name for the recipient that should get reports for this message.
        /// </summary>
        internal static PropertyTag PR_REPORT_NAME_A
        {
            get { return new PropertyTag(0x003A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the search key for the messaging user represented by the sender.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_SEARCH_KEY
        {
            get { return new PropertyTag(0x003B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains the content type for a submitted message.
        /// </summary>
        internal static PropertyTag PR_X400_CONTENT_TYPE
        {
            get { return new PropertyTag(0x003C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unicode subject prefix that typically indicates some action on a message, such as "FW: " for forwarding.
        /// </summary>
        internal static PropertyTag PR_SUBJECT_PREFIX_W
        {
            get { return new PropertyTag(0x003D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a ANSI subject prefix that typically indicates some action on a message, such as "FW: " for forwarding.
        /// </summary>
        internal static PropertyTag PR_SUBJECT_PREFIX_A
        {
            get { return new PropertyTag(0x003D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains reasons why a message was not received that forms part of a non-delivery report.
        /// </summary>
        internal static PropertyTag PR_NON_RECEIPT_REASON
        {
            get { return new PropertyTag(0x003E, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry identifier of the messaging user that actually receives the message.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_ENTRYID
        {
            get { return new PropertyTag(0x003F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of the messaging user that actually receives the message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_NAME_W
        {
            get { return new PropertyTag(0x0040, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the messaging user that actually receives the message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_NAME_A
        {
            get { return new PropertyTag(0x0040, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier for the messaging user represented by the sender.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_ENTRYID
        {
            get { return new PropertyTag(0x0041, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name for the messaging user represented by the sender. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_NAME_W
        {
            get { return new PropertyTag(0x0042, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name for the messaging user represented by the sender. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_NAME_A
        {
            get { return new PropertyTag(0x0042, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the display name for the messaging user represented by the receiving user. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_NAME_W
        {
            get { return new PropertyTag(0x0044, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name for the messaging user represented by the receiving user. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_NAME_A
        {
            get { return new PropertyTag(0x0044, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier for the recipient that should get reports for this message.
        /// </summary>
        internal static PropertyTag PR_REPORT_ENTRYID
        {
            get { return new PropertyTag(0x0045, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an entry identifier for the messaging user to which the messaging system should direct a read report for
        ///     this message.
        /// </summary>
        internal static PropertyTag PR_READ_RECEIPT_ENTRYID
        {
            get { return new PropertyTag(0x0046, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a message transfer system (MTS) identifier for the message transfer agent (MTA).
        /// </summary>
        internal static PropertyTag PR_MESSAGE_SUBMISSION_ID
        {
            get { return new PropertyTag(0x0047, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the date and time a transport provider passed a message to its underlying messaging system.
        /// </summary>
        internal static PropertyTag PR_PROVIDER_SUBMIT_TIME
        {
            get { return new PropertyTag(0x0048, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the subject of an original message for use in a report about the message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SUBJECT_W
        {
            get { return new PropertyTag(0x0049, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the subject of an original message for use in a report about the message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SUBJECT_A
        {
            get { return new PropertyTag(0x0049, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     The obsolete precursor of the PR_DISCRETE_VALUES property. No longer supported.
        /// </summary>
        internal static PropertyTag PR_DISC_VAL
        {
            get { return new PropertyTag(0x004A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the class of the original message for use in a report. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIG_MESSAGE_CLASS_W
        {
            get { return new PropertyTag(0x004B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the class of the original message for use in a report. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIG_MESSAGE_CLASS_A
        {
            get { return new PropertyTag(0x004B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier of the author of the first version of a message, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_ENTRYID
        {
            get { return new PropertyTag(0x004C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of the author of the first version of a message, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_NAME_W
        {
            get { return new PropertyTag(0x004D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the author of the first version of a message, that is, the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_NAME_A
        {
            get { return new PropertyTag(0x004D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the original submission date and time of the message in the report.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SUBMIT_TIME
        {
            get { return new PropertyTag(0x004E, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a sized array of entry identifiers for recipients that are to get a reply.
        /// </summary>
        internal static PropertyTag PR_REPLY_RECIPIENT_ENTRIES
        {
            get { return new PropertyTag(0x004F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of display names for recipients that are to get a reply. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_REPLY_RECIPIENT_NAMES_W
        {
            get { return new PropertyTag(0x0050, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a list of display names for recipients that are to get a reply. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_REPLY_RECIPIENT_NAMES_A
        {
            get { return new PropertyTag(0x0050, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the search key of the messaging user that actually receives the message.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_SEARCH_KEY
        {
            get { return new PropertyTag(0x0051, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key for the messaging user represented by the receiving user.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_SEARCH_KEY
        {
            get { return new PropertyTag(0x0052, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a search key for the messaging user to which the messaging system should direct a read report for a
        ///     message.
        /// </summary>
        internal static PropertyTag PR_READ_RECEIPT_SEARCH_KEY
        {
            get { return new PropertyTag(0x0053, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key for the recipient that should get reports for this message.
        /// </summary>
        internal static PropertyTag PR_REPORT_SEARCH_KEY
        {
            get { return new PropertyTag(0x0054, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a copy of the original message's delivery date and time in a thread.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DELIVERY_TIME
        {
            get { return new PropertyTag(0x0055, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the search key of the author of the first version of a message, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_SEARCH_KEY
        {
            get { return new PropertyTag(0x0056, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if this messaging user is specifically named as a primary (To) recipient of this message and is not
        ///     part of a distribution list.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_TO_ME
        {
            get { return new PropertyTag(0x0057, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if this messaging user is specifically named as a carbon copy (CC) recipient of this message and is
        ///     not part of a distribution list.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_CC_ME
        {
            get { return new PropertyTag(0x0058, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if this messaging user is specifically named as a primary (To), carbon copy (CC), or blind carbon
        ///     copy (BCC) recipient of this message and is not part of a distribution list.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_RECIP_ME
        {
            get { return new PropertyTag(0x0059, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the display name of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_NAME_W
        {
            get { return new PropertyTag(0x005A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_NAME_A
        {
            get { return new PropertyTag(0x005A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_ENTRYID
        {
            get { return new PropertyTag(0x005B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key for the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_SEARCH_KEY
        {
            get { return new PropertyTag(0x005C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of the messaging user on whose behalf the original message was sent. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_NAME_W
        {
            get { return new PropertyTag(0x005D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the messaging user on whose behalf the original message was sent. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_NAME_A
        {
            get { return new PropertyTag(0x005D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier of the messaging user on whose behalf the original message was sent.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_ENTRYID
        {
            get { return new PropertyTag(0x005E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key of the messaging user on whose behalf the original message was sent.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_SEARCH_KEY
        {
            get { return new PropertyTag(0x005F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the starting date and time of an appointment as managed by a scheduling application.
        /// </summary>
        internal static PropertyTag PR_START_DATE
        {
            get { return new PropertyTag(0x0060, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the ending date and time of an appointment as managed by a scheduling application.
        /// </summary>
        internal static PropertyTag PR_END_DATE
        {
            get { return new PropertyTag(0x0061, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains an identifier for an appointment in the owner's schedule.
        /// </summary>
        internal static PropertyTag PR_OWNER_APPT_ID
        {
            get { return new PropertyTag(0x0062, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if the message sender wants a response to a meeting request.
        /// </summary>
        internal static PropertyTag PR_RESPONSE_REQUESTED
        {
            get { return new PropertyTag(0x0063, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the address type for the messaging user represented by the sender. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0064, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type for the messaging user represented by the sender. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0064, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user represented by the sender. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0065, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user represented by the sender. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENT_REPRESENTING_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0065, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the address type of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0066, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0066, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0067, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address of the sender of the first version of a message, that is, the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0067, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the address type of the messaging user on whose behalf the original message was sent. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0068, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type of the messaging user on whose behalf the original message was sent. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0068, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address of the messaging user on whose behalf the original message was sent. UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0069, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address of the messaging user on whose behalf the original message was sent. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0069, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the topic of the first message in a conversation thread. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_CONVERSATION_TOPIC_W
        {
            get { return new PropertyTag(0x0070, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the topic of the first message in a conversation thread. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_CONVERSATION_TOPIC_A
        {
            get { return new PropertyTag(0x0070, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a binary value that indicates the relative position of this message within a conversation thread.
        /// </summary>
        internal static PropertyTag PR_CONVERSATION_INDEX
        {
            get { return new PropertyTag(0x0071, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a binary value that indicates the relative position of this message within a conversation thread.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_BCC_W
        {
            get { return new PropertyTag(0x0072, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display names of any blind carbon copy (BCC) recipients of the original message. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_BCC_A
        {
            get { return new PropertyTag(0x0072, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the display names of any carbon copy (CC) recipients of the original message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_CC_W
        {
            get { return new PropertyTag(0x0073, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display names of any carbon copy (CC) recipients of the original message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_CC_A
        {
            get { return new PropertyTag(0x0073, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the display names of the primary (To) recipients of the original message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_TO_W
        {
            get { return new PropertyTag(0x0074, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display names of the primary (To) recipients of the original message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_TO_A
        {
            get { return new PropertyTag(0x0074, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address type, such as SMTP, for the messaging user that actually receives the message. UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0075, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address type, such as SMTP, for the messaging user that actually receives the message.
        ///     Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0075, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user that actually receives the message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0076, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user that actually receives the message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0076, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the address type for the messaging user represented by the user actually receiving the message. UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0077, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type for the messaging user represented by the user actually receiving the message.
        ///     Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0077, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user represented by the receiving user. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0078, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user represented by the receiving user. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RCVD_REPRESENTING_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0078, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the address type of the author of the first version of a message. That is — the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0079, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type of the author of the first version of a message. That is — the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0079, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address of the author of the first version of a message. That is — the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x007A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address of the author of the first version of a message. That is — the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x007A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the address type of the originally intended recipient of an autoforwarded message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_ADDRTYPE_W
        {
            get { return new PropertyTag(0x007B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type of the originally intended recipient of an autoforwarded message. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_ADDRTYPE_A
        {
            get { return new PropertyTag(0x007B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address of the originally intended recipient of an autoforwarded message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x007C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address of the originally intended recipient of an autoforwarded message. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x007C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains transport-specific message envelope information. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TRANSPORT_MESSAGE_HEADERS_W
        {
            get { return new PropertyTag(0x007D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains transport-specific message envelope information. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TRANSPORT_MESSAGE_HEADERS_A
        {
            get { return new PropertyTag(0x007D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the converted value of the attDelegate workgroup property.
        /// </summary>
        internal static PropertyTag PR_DELEGATION
        {
            get { return new PropertyTag(0x007E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value used to correlate a Transport Neutral Encapsulation Format (TNEF) attachment with a message
        /// </summary>
        internal static PropertyTag PR_TNEF_CORRELATION_KEY
        {
            get { return new PropertyTag(0x007F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the message text. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties are typically used only in an interpersonal message (IPM).
        ///     Message stores that support Rich Text Format (RTF) ignore any changes to white space in the message text. When
        ///     PR_BODY is stored for the first time, the message store also generates and stores the PR_RTF_COMPRESSED
        ///     (PidTagRtfCompressed) property, the RTF version of the message text. If the IMAPIProp::SaveChanges method is
        ///     subsequently called and PR_BODY has been modified, the message store calls the RTFSync function to ensure
        ///     synchronization with the RTF version. If only white space has been changed, the properties are left unchanged. This
        ///     preserves any nontrivial RTF formatting when the message travels through non-RTF-aware clients and messaging
        ///     systems.
        ///     The value for this property must be expressed in the code page of the operating system that MAPI is running on.
        /// </remarks>
        internal static PropertyTag PR_BODY_W
        {
            get { return new PropertyTag(0x1000, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the message text. Non-UNICDOE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties are typically used only in an interpersonal message (IPM).
        ///     Message stores that support Rich Text Format (RTF) ignore any changes to white space in the message text. When
        ///     PR_BODY is stored for the first time, the message store also generates and stores the PR_RTF_COMPRESSED
        ///     (PidTagRtfCompressed) property, the RTF version of the message text. If the IMAPIProp::SaveChanges method is
        ///     subsequently called and PR_BODY has been modified, the message store calls the RTFSync function to ensure
        ///     synchronization with the RTF version. If only white space has been changed, the properties are left unchanged. This
        ///     preserves any nontrivial RTF formatting when the message travels through non-RTF-aware clients and messaging
        ///     systems.
        ///     The value for this property must be expressed in the code page of the operating system that MAPI is running on.
        /// </remarks>
        internal static PropertyTag PR_BODY_A
        {
            get { return new PropertyTag(0x1000, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains optional text for a report generated by the messaging system. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_REPORT_TEXT_W
        {
            get { return new PropertyTag(0x1001, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains optional text for a report generated by the messaging system. NON-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_REPORT_TEXT_A
        {
            get { return new PropertyTag(0x1001, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains information about a message originator and a distribution list expansion history.
        /// </summary>
        internal static PropertyTag PR_ORIGINATOR_AND_DL_EXPANSION_HISTORY
        {
            get { return new PropertyTag(0x1002, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of a distribution list where the messaging system delivers a report.
        /// </summary>
        internal static PropertyTag PR_REPORTING_DL_NAME
        {
            get { return new PropertyTag(0x1003, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an identifier for the message transfer agent that generated a report.
        /// </summary>
        internal static PropertyTag PR_REPORTING_MTA_CERTIFICATE
        {
            get { return new PropertyTag(0x1004, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the cyclical redundancy check (CRC) computed for the message text.
        /// </summary>
        internal static PropertyTag PR_RTF_SYNC_BODY_CRC
        {
            get { return new PropertyTag(0x1006, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a count of the significant characters of the message text.
        /// </summary>
        internal static PropertyTag PR_RTF_SYNC_BODY_COUNT
        {
            get { return new PropertyTag(0x1007, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains significant characters that appear at the beginning of the message text. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RTF_SYNC_BODY_TAG_W
        {
            get { return new PropertyTag(0x1008, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains significant characters that appear at the beginning of the message text. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RTF_SYNC_BODY_TAG_A
        {
            get { return new PropertyTag(0x1008, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the Rich Text Format (RTF) version of the message text, usually in compressed form.
        /// </summary>
        internal static PropertyTag PR_RTF_COMPRESSED
        {
            get { return new PropertyTag(0x1009, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a count of the ignorable characters that appear before the significant characters of the message.
        /// </summary>
        internal static PropertyTag PR_RTF_SYNC_PREFIX_COUNT
        {
            get { return new PropertyTag(0x1010, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a count of the ignorable characters that appear after the significant characters of the message.
        /// </summary>
        internal static PropertyTag PR_RTF_SYNC_TRAILING_COUNT
        {
            get { return new PropertyTag(0x1011, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry identifier of the originally intended recipient of an auto-forwarded message.
        /// </summary>
        internal static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_ENTRYID
        {
            get { return new PropertyTag(0x1012, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an ASN.1 content integrity check value that allows a message sender to protect message content from
        ///     disclosure to unauthorized recipients.
        /// </summary>
        internal static PropertyTag PR_CONTENT_INTEGRITY_CHECK
        {
            get { return new PropertyTag(0x0C00, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Indicates that a message sender has requested a message content conversion for a particular recipient.
        /// </summary>
        internal static PropertyTag PR_EXPLICIT_CONVERSION
        {
            get { return new PropertyTag(0x0C01, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if this message should be returned with a report.
        /// </summary>
        internal static PropertyTag PR_IPM_RETURN_REQUESTED
        {
            get { return new PropertyTag(0x0C02, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an ASN.1 security token for a message.
        /// </summary>
        internal static PropertyTag PR_MESSAGE_TOKEN
        {
            get { return new PropertyTag(0x0C03, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a diagnostic code that forms part of a nondelivery report.
        /// </summary>
        internal static PropertyTag PR_NDR_REASON_CODE
        {
            get { return new PropertyTag(0x0C04, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a diagnostic code that forms part of a nondelivery report.
        /// </summary>
        internal static PropertyTag PR_NDR_DIAG_CODE
        {
            get { return new PropertyTag(0x0C05, PropertyType.PT_LONG); }
        }

        /// <summary>
        /// </summary>
        internal static PropertyTag PR_NON_RECEIPT_NOTIFICATION_REQUESTED
        {
            get { return new PropertyTag(0x0C06, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender wants notification of non-receipt for a specified recipient.
        /// </summary>
        internal static PropertyTag PR_ORIGINATOR_NON_DELIVERY_REPORT_REQUESTED
        {
            get { return new PropertyTag(0x0C08, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an entry identifier for an alternate recipient designated by the sender.
        /// </summary>
        internal static PropertyTag PR_ORIGINATOR_REQUESTED_ALTERNATE_RECIPIENT
        {
            get { return new PropertyTag(0x0C09, PropertyType.PT_BINARY); }
        }

        /// <summary>
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_DELIVERY_BUREAU_FAX_DELIVERY
        {
            get { return new PropertyTag(0x0C0A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if the messaging system should use a fax bureau for physical delivery of this message.
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_DELIVERY_MODE
        {
            get { return new PropertyTag(0x0C0B, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the mode of a report to be delivered to a particular message recipient upon completion of physical message
        ///     delivery or delivery by the message handling system.
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_DELIVERY_REPORT_REQUEST
        {
            get { return new PropertyTag(0x0C0C, PropertyType.PT_LONG); }
        }

        /// <summary>
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_FORWARDING_ADDRESS
        {
            get { return new PropertyTag(0x0C0D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests the message transfer agent to attach a physical forwarding address for a
        ///     message recipient.
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_FORWARDING_ADDRESS_REQUESTED
        {
            get { return new PropertyTag(0x0C0E, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender prohibits physical message forwarding for a specific recipient.
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_FORWARDING_PROHIBITED
        {
            get { return new PropertyTag(0x0C0F, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an ASN.1 object identifier that is used for rendering message attachments.
        /// </summary>
        internal static PropertyTag PR_PHYSICAL_RENDITION_ATTRIBUTES
        {
            get { return new PropertyTag(0x0C10, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains an ASN.1 proof of delivery value.
        /// </summary>
        internal static PropertyTag PR_PROOF_OF_DELIVERY
        {
            get { return new PropertyTag(0x0C11, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains TRUE if a message sender requests proof of delivery for a particular recipient.
        /// </summary>
        internal static PropertyTag PR_PROOF_OF_DELIVERY_REQUESTED
        {
            get { return new PropertyTag(0x0C12, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a message recipient's ASN.1 certificate for use in a report.
        /// </summary>
        internal static PropertyTag PR_RECIPIENT_CERTIFICATE
        {
            get { return new PropertyTag(0x0C13, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains a message recipient's telephone number to call to advise of the physical delivery of a
        ///     message. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECIPIENT_NUMBER_FOR_ADVICE_W
        {
            get { return new PropertyTag(0x0C14, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     This property contains a message recipient's telephone number to call to advise of the physical delivery of a
        ///     message. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECIPIENT_NUMBER_FOR_ADVICE_A
        {
            get { return new PropertyTag(0x0C14, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient type for a message recipient.
        /// </summary>
        internal static PropertyTag PR_RECIPIENT_TYPE
        {
            get { return new PropertyTag(0x0C15, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     This property contains the type of registration used for physical delivery of a message.
        /// </summary>
        internal static PropertyTag PR_REGISTERED_MAIL_TYPE
        {
            get { return new PropertyTag(0x0C16, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests a reply from a recipient.
        /// </summary>
        internal static PropertyTag PR_REPLY_REQUESTED
        {
            get { return new PropertyTag(0x0C17, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     This property contains a binary array of delivery methods (service providers), in the order of a message sender's
        ///     preference.
        /// </summary>
        internal static PropertyTag PR_REQUESTED_DELIVERY_METHOD
        {
            get { return new PropertyTag(0x0C18, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the message sender's entry identifier.
        /// </summary>
        internal static PropertyTag PR_SENDER_ENTRYID
        {
            get { return new PropertyTag(0x0C19, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the message sender's display name. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENDER_NAME_W
        {
            get { return new PropertyTag(0x0C1A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the message sender's display name. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENDER_NAME_A
        {
            get { return new PropertyTag(0x0C1A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains additional information for use in a report. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SUPPLEMENTARY_INFO_W
        {
            get { return new PropertyTag(0x0C1B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains additional information for use in a report. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SUPPLEMENTARY_INFO_A
        {
            get { return new PropertyTag(0x0C1B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     This property contains the type of a message recipient for use in a report.
        /// </summary>
        internal static PropertyTag PR_TYPE_OF_MTS_USER
        {
            get { return new PropertyTag(0x0C1C, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the message sender's search key.
        /// </summary>
        internal static PropertyTag PR_SENDER_SEARCH_KEY
        {
            get { return new PropertyTag(0x0C1D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the message sender's e-mail address type. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENDER_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0C1E, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the message sender's e-mail address type. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SENDER_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0C1E, PropertyType.PT_STRING8); }
        }

        /// <summary>
        /// </summary>
        internal static PropertyTag PR_SENDER_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0C1F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        /// </summary>
        internal static PropertyTag PR_SENDER_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0C1F, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_CURRENT_VERSION
        {
            get { return new PropertyTag(0x0E00, PropertyType.PT_I8); }
        }

        internal static PropertyTag PR_DELETE_AFTER_SUBMIT
        {
            get { return new PropertyTag(0x0E01, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_DISPLAY_BCC_W
        {
            get { return new PropertyTag(0x0E02, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_DISPLAY_BCC_A
        {
            get { return new PropertyTag(0x0E02, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_DISPLAY_CC_W
        {
            get { return new PropertyTag(0x0E03, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_DISPLAY_CC_A
        {
            get { return new PropertyTag(0x0E03, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_DISPLAY_TO_W
        {
            get { return new PropertyTag(0x0E04, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_DISPLAY_TO_A
        {
            get { return new PropertyTag(0x0E04, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_PARENT_DISPLAY_W
        {
            get { return new PropertyTag(0x0E05, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_PARENT_DISPLAY_A
        {
            get { return new PropertyTag(0x0E05, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_MESSAGE_DELIVERY_TIME
        {
            get { return new PropertyTag(0x0E06, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PR_MESSAGE_FLAGS
        {
            get { return new PropertyTag(0x0E07, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_MESSAGE_SIZE
        {
            get { return new PropertyTag(0x0E08, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_PARENT_ENTRYID
        {
            get { return new PropertyTag(0x0E09, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_SENTMAIL_ENTRYID
        {
            get { return new PropertyTag(0x0E0A, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_CORRELATE
        {
            get { return new PropertyTag(0x0E0C, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_CORRELATE_MTSID
        {
            get { return new PropertyTag(0x0E0D, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_DISCRETE_VALUES
        {
            get { return new PropertyTag(0x0E0E, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_RESPONSIBILITY
        {
            get { return new PropertyTag(0x0E0F, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_SPOOLER_STATUS
        {
            get { return new PropertyTag(0x0E10, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_TRANSPORT_STATUS
        {
            get { return new PropertyTag(0x0E11, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_MESSAGE_RECIPIENTS
        {
            get { return new PropertyTag(0x0E12, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_MESSAGE_ATTACHMENTS
        {
            get { return new PropertyTag(0x0E13, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_SUBMIT_FLAGS
        {
            get { return new PropertyTag(0x0E14, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_RECIPIENT_STATUS
        {
            get { return new PropertyTag(0x0E15, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_TRANSPORT_KEY
        {
            get { return new PropertyTag(0x0E16, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_MSG_STATUS
        {
            get { return new PropertyTag(0x0E17, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_MESSAGE_DOWNLOAD_TIME
        {
            get { return new PropertyTag(0x0E18, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_CREATION_VERSION
        {
            get { return new PropertyTag(0x0E19, PropertyType.PT_I8); }
        }

        internal static PropertyTag PR_MODIFY_VERSION
        {
            get { return new PropertyTag(0x0E1A, PropertyType.PT_I8); }
        }

        internal static PropertyTag PR_HASATTACH
        {
            get { return new PropertyTag(0x0E1B, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_BODY_CRC
        {
            get { return new PropertyTag(0x0E1C, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_NORMALIZED_SUBJECT_W
        {
            get { return new PropertyTag(0x0E1D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_NORMALIZED_SUBJECT_A
        {
            get { return new PropertyTag(0x0E1D, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_RTF_IN_SYNC
        {
            get { return new PropertyTag(0x0E1F, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_ATTACH_SIZE
        {
            get { return new PropertyTag(0x0E20, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ATTACH_NUM
        {
            get { return new PropertyTag(0x0E21, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_PREPROCESS
        {
            get { return new PropertyTag(0x0E22, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_ENTRYID
        {
            get { return new PropertyTag(0x0FFF, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_OBJECT_TYPE
        {
            get { return new PropertyTag(0x0FFE, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ICON
        {
            get { return new PropertyTag(0x0FFD, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_MINI_ICON
        {
            get { return new PropertyTag(0x0FFC, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_STORE_ENTRYID
        {
            get { return new PropertyTag(0x0FFB, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_STORE_RECORD_KEY
        {
            get { return new PropertyTag(0x0FFA, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_RECORD_KEY
        {
            get { return new PropertyTag(0x0FF9, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_MAPPING_SIGNATURE
        {
            get { return new PropertyTag(0x0FF8, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ACCESS_LEVEL
        {
            get { return new PropertyTag(0x0FF7, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_INSTANCE_KEY
        {
            get { return new PropertyTag(0x0FF6, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ROW_TYPE
        {
            get { return new PropertyTag(0x0FF5, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ACCESS
        {
            get { return new PropertyTag(0x0FF4, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ROWID
        {
            get { return new PropertyTag(0x3000, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x3001, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x3001, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ADDRTYPE_W
        {
            get { return new PropertyTag(0x3002, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ADDRTYPE_A
        {
            get { return new PropertyTag(0x3002, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x3003, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x3003, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_COMMENT_W
        {
            get { return new PropertyTag(0x3004, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_COMMENT_A
        {
            get { return new PropertyTag(0x3004, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_DEPTH
        {
            get { return new PropertyTag(0x3005, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_PROVIDER_DISPLAY_W
        {
            get { return new PropertyTag(0x3006, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_PROVIDER_DISPLAY_A
        {
            get { return new PropertyTag(0x3006, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_CREATION_TIME
        {
            get { return new PropertyTag(0x3007, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PR_LAST_MODIFICATION_TIME
        {
            get { return new PropertyTag(0x3008, PropertyType.PT_SYSTIME); }
        }

        internal static PropertyTag PR_RESOURCE_FLAGS
        {
            get { return new PropertyTag(0x3009, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_PROVIDER_DLL_NAME_W
        {
            get { return new PropertyTag(0x300A, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_PROVIDER_DLL_NAME_A
        {
            get { return new PropertyTag(0x300A, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_SEARCH_KEY
        {
            get { return new PropertyTag(0x300B, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_PROVIDER_UID
        {
            get { return new PropertyTag(0x300C, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_PROVIDER_ORDINAL
        {
            get { return new PropertyTag(0x300D, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_FORM_VERSION_W
        {
            get { return new PropertyTag(0x3301, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_FORM_VERSION_A
        {
            get { return new PropertyTag(0x3301, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_FORM_CLSID
        {
            get { return new PropertyTag(0x3302, PropertyType.PT_CLSID); }
        }

        internal static PropertyTag PR_FORM_CONTACT_NAME_W
        {
            get { return new PropertyTag(0x3303, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_FORM_CONTACT_NAME_A
        {
            get { return new PropertyTag(0x3303, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_FORM_CATEGORY_W
        {
            get { return new PropertyTag(0x3304, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_FORM_CATEGORY_A
        {
            get { return new PropertyTag(0x3304, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_FORM_CATEGORY_SUB_W
        {
            get { return new PropertyTag(0x3305, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_FORM_CATEGORY_SUB_A
        {
            get { return new PropertyTag(0x3305, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_FORM_HOST_MAP
        {
            get { return new PropertyTag(0x3306, PropertyType.PT_MV_LONG); }
        }

        internal static PropertyTag PR_FORM_HIDDEN
        {
            get { return new PropertyTag(0x3307, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_FORM_DESIGNER_NAME_W
        {
            get { return new PropertyTag(0x3308, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_FORM_DESIGNER_NAME_A
        {
            get { return new PropertyTag(0x3308, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_FORM_DESIGNER_GUID
        {
            get { return new PropertyTag(0x3309, PropertyType.PT_CLSID); }
        }

        internal static PropertyTag PR_FORM_MESSAGE_BEHAVIOR
        {
            get { return new PropertyTag(0x330A, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_DEFAULT_STORE
        {
            get { return new PropertyTag(0x3400, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_STORE_SUPPORT_MASK
        {
            get { return new PropertyTag(0x340D, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_STORE_STATE
        {
            get { return new PropertyTag(0x340E, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_IPM_SUBTREE_SEARCH_KEY
        {
            get { return new PropertyTag(0x3410, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_IPM_OUTBOX_SEARCH_KEY
        {
            get { return new PropertyTag(0x3411, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_IPM_WASTEBASKET_SEARCH_KEY
        {
            get { return new PropertyTag(0x3412, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_IPM_SENTMAIL_SEARCH_KEY
        {
            get { return new PropertyTag(0x3413, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_MDB_PROVIDER
        {
            get { return new PropertyTag(0x3414, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_RECEIVE_FOLDER_SETTINGS
        {
            get { return new PropertyTag(0x3415, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_VALID_FOLDER_MASK
        {
            get { return new PropertyTag(0x35DF, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_IPM_SUBTREE_ENTRYID
        {
            get { return new PropertyTag(0x35E0, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_IPM_OUTBOX_ENTRYID
        {
            get { return new PropertyTag(0x35E2, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_IPM_WASTEBASKET_ENTRYID
        {
            get { return new PropertyTag(0x35E3, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_IPM_SENTMAIL_ENTRYID
        {
            get { return new PropertyTag(0x35E4, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_VIEWS_ENTRYID
        {
            get { return new PropertyTag(0x35E5, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_COMMON_VIEWS_ENTRYID
        {
            get { return new PropertyTag(0x35E6, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_FINDER_ENTRYID
        {
            get { return new PropertyTag(0x35E7, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_CONTAINER_FLAGS
        {
            get { return new PropertyTag(0x3600, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_FOLDER_TYPE
        {
            get { return new PropertyTag(0x3601, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_CONTENT_COUNT
        {
            get { return new PropertyTag(0x3602, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_CONTENT_UNREAD
        {
            get { return new PropertyTag(0x3603, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_CREATE_TEMPLATES
        {
            get { return new PropertyTag(0x3604, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_DETAILS_TABLE
        {
            get { return new PropertyTag(0x3605, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_SEARCH
        {
            get { return new PropertyTag(0x3607, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_SELECTABLE
        {
            get { return new PropertyTag(0x3609, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_SUBFOLDERS
        {
            get { return new PropertyTag(0x360a, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_STATUS
        {
            get { return new PropertyTag(0x360b, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ANR_W
        {
            get { return new PropertyTag(0x360c, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ANR_A
        {
            get { return new PropertyTag(0x360c, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_CONTENTS_SORT_ORDER
        {
            get { return new PropertyTag(0x360d, PropertyType.PT_MV_LONG); }
        }

        internal static PropertyTag PR_CONTAINER_HIERARCHY
        {
            get { return new PropertyTag(0x360e, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_CONTAINER_CONTENTS
        {
            get { return new PropertyTag(0x360f, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_FOLDER_ASSOCIATED_CONTENTS
        {
            get { return new PropertyTag(0x3610, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_DEF_CREATE_DL
        {
            get { return new PropertyTag(0x3611, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_DEF_CREATE_MAILUSER
        {
            get { return new PropertyTag(0x3612, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_CONTAINER_CLASS_W
        {
            get { return new PropertyTag(0x3613, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_CONTAINER_CLASS_A
        {
            get { return new PropertyTag(0x3613, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_CONTAINER_MODIFY_VERSION
        {
            get { return new PropertyTag(0x3614, PropertyType.PT_I8); }
        }

        internal static PropertyTag PR_AB_PROVIDER_ID
        {
            get { return new PropertyTag(0x3615, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_DEFAULT_VIEW_ENTRYID
        {
            get { return new PropertyTag(0x3616, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ASSOC_CONTENT_COUNT
        {
            get { return new PropertyTag(0x3617, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ATTACHMENT_X400_PARAMETERS
        {
            get { return new PropertyTag(0x3700, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ATTACH_DATA_OBJ
        {
            get { return new PropertyTag(0x3701, PropertyType.PT_OBJECT); }
        }

        internal static PropertyTag PR_ATTACH_DATA_BIN
        {
            get { return new PropertyTag(0x3701, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ATTACH_ENCODING
        {
            get { return new PropertyTag(0x3702, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ATTACH_EXTENSION_W
        {
            get { return new PropertyTag(0x3703, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ATTACH_EXTENSION_A
        {
            get { return new PropertyTag(0x3703, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ATTACH_FILENAME_W
        {
            get { return new PropertyTag(0x3704, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ATTACH_FILENAME_A
        {
            get { return new PropertyTag(0x3704, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ATTACH_METHOD
        {
            get { return new PropertyTag(0x3705, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ATTACH_LONG_FILENAME_W
        {
            get { return new PropertyTag(0x3707, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ATTACH_LONG_FILENAME_A
        {
            get { return new PropertyTag(0x3707, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ATTACH_PATHNAME_W
        {
            get { return new PropertyTag(0x3708, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ATTACH_PATHNAME_A
        {
            get { return new PropertyTag(0x3708, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ATTACH_RENDERING
        {
            get { return new PropertyTag(0x3709, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ATTACH_TAG
        {
            get { return new PropertyTag(0x370A, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_RENDERING_POSITION
        {
            get { return new PropertyTag(0x370B, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_ATTACH_TRANSPORT_NAME_W
        {
            get { return new PropertyTag(0x370C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ATTACH_TRANSPORT_NAME_A
        {
            get { return new PropertyTag(0x370C, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_DISPLAY_TYPE
        {
            get { return new PropertyTag(0x3900, PropertyType.PT_LONG); }
        }

        internal static PropertyTag PR_TEMPLATEID
        {
            get { return new PropertyTag(0x3902, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_PRIMARY_CAPABILITY
        {
            get { return new PropertyTag(0x3904, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ACCOUNT_W
        {
            get { return new PropertyTag(0x3A00, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ACCOUNT_A
        {
            get { return new PropertyTag(0x3A00, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ALTERNATE_RECIPIENT
        {
            get { return new PropertyTag(0x3A01, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_CALLBACK_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A02, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_CALLBACK_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A02, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_CONVERSION_PROHIBITED
        {
            get { return new PropertyTag(0x3A03, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_DISCLOSE_RECIPIENTS
        {
            get { return new PropertyTag(0x3A04, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_GENERATION_W
        {
            get { return new PropertyTag(0x3A05, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_GENERATION_A
        {
            get { return new PropertyTag(0x3A05, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_GIVEN_NAME_W
        {
            get { return new PropertyTag(0x3A06, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_GIVEN_NAME_A
        {
            get { return new PropertyTag(0x3A06, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_GOVERNMENT_ID_NUMBER_W
        {
            get { return new PropertyTag(0x3A07, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_GOVERNMENT_ID_NUMBER_A
        {
            get { return new PropertyTag(0x3A07, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_BUSINESS_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A08, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_BUSINESS_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A08, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_HOME_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A09, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_HOME_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A09, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_INITIALS_W
        {
            get { return new PropertyTag(0x3A0A, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_INITIALS_A
        {
            get { return new PropertyTag(0x3A0A, PropertyType.PT_STRING8); }
        }


        internal static PropertyTag PR_KEYWORD_W
        {
            get { return new PropertyTag(0x3A0B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_KEYWORD_A
        {
            get { return new PropertyTag(0x3A0B, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_LANGUAGE_W
        {
            get { return new PropertyTag(0x3A0C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_LANGUAGE_A
        {
            get { return new PropertyTag(0x3A0C, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_LOCATION_W
        {
            get { return new PropertyTag(0x3A0D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_LOCATION_A
        {
            get { return new PropertyTag(0x3A0D, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_MAIL_PERMISSION
        {
            get { return new PropertyTag(0x3A0E, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_MHS_COMMON_NAME_W
        {
            get { return new PropertyTag(0x3A0F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_MHS_COMMON_NAME_A
        {
            get { return new PropertyTag(0x3A0F, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ORGANIZATIONAL_ID_NUMBER_W
        {
            get { return new PropertyTag(0x3A10, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ORGANIZATIONAL_ID_NUMBER_A
        {
            get { return new PropertyTag(0x3A10, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_SURNAME_W
        {
            get { return new PropertyTag(0x3A11, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_SURNAME_A
        {
            get { return new PropertyTag(0x3A11, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ORIGINAL_ENTRYID
        {
            get { return new PropertyTag(0x3A12, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_ORIGINAL_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x3A13, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ORIGINAL_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x3A13, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ORIGINAL_SEARCH_KEY
        {
            get { return new PropertyTag(0x3A14, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_POSTAL_ADDRESS_W
        {
            get { return new PropertyTag(0x3A15, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_POSTAL_ADDRESS_A
        {
            get { return new PropertyTag(0x3A15, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_COMPANY_NAME_W
        {
            get { return new PropertyTag(0x3A16, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_COMPANY_NAME_A
        {
            get { return new PropertyTag(0x3A16, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_TITLE_W
        {
            get { return new PropertyTag(0x3A17, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_TITLE_A
        {
            get { return new PropertyTag(0x3A17, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_DEPARTMENT_NAME_W
        {
            get { return new PropertyTag(0x3A18, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_DEPARTMENT_NAME_A
        {
            get { return new PropertyTag(0x3A18, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_OFFICE_LOCATION_W
        {
            get { return new PropertyTag(0x3A19, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_OFFICE_LOCATION_A
        {
            get { return new PropertyTag(0x3A19, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_PRIMARY_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1A, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_PRIMARY_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1A, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_BUSINESS2_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_BUSINESS2_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1B, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_MOBILE_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_MOBILE_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1C, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_RADIO_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_RADIO_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1D, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_CAR_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_CAR_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1E, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_OTHER_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_OTHER_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1F, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_TRANSMITABLE_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x3A20, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_TRANSMITABLE_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x3A20, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_PAGER_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A21, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_PAGER_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A21, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_USER_CERTIFICATE
        {
            get { return new PropertyTag(0x3A22, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_PRIMARY_FAX_NUMBER_W
        {
            get { return new PropertyTag(0x3A23, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_PRIMARY_FAX_NUMBER_A
        {
            get { return new PropertyTag(0x3A23, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_BUSINESS_FAX_NUMBER_W
        {
            get { return new PropertyTag(0x3A24, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_BUSINESS_FAX_NUMBER_A
        {
            get { return new PropertyTag(0x3A24, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_HOME_FAX_NUMBER_W
        {
            get { return new PropertyTag(0x3A25, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_HOME_FAX_NUMBER_A
        {
            get { return new PropertyTag(0x3A25, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_COUNTRY_W
        {
            get { return new PropertyTag(0x3A26, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_COUNTRY_A
        {
            get { return new PropertyTag(0x3A26, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_LOCALITY_W
        {
            get { return new PropertyTag(0x3A27, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_LOCALITY_A
        {
            get { return new PropertyTag(0x3A27, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_STATE_OR_PROVINCE_W
        {
            get { return new PropertyTag(0x3A28, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_STATE_OR_PROVINCE_A
        {
            get { return new PropertyTag(0x3A28, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_STREET_ADDRESS_W
        {
            get { return new PropertyTag(0x3A29, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_STREET_ADDRESS_A
        {
            get { return new PropertyTag(0x3A29, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_POSTAL_CODE_W
        {
            get { return new PropertyTag(0x3A2A, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_POSTAL_CODE_A
        {
            get { return new PropertyTag(0x3A2A, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_POST_OFFICE_BOX_W
        {
            get { return new PropertyTag(0x3A2B, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_POST_OFFICE_BOX_A
        {
            get { return new PropertyTag(0x3A2B, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_TELEX_NUMBER_W
        {
            get { return new PropertyTag(0x3A2C, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_TELEX_NUMBER_A
        {
            get { return new PropertyTag(0x3A2C, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ISDN_NUMBER_W
        {
            get { return new PropertyTag(0x3A2D, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ISDN_NUMBER_A
        {
            get { return new PropertyTag(0x3A2D, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ASSISTANT_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A2E, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ASSISTANT_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A2E, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_HOME2_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A2F, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_HOME2_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A2F, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_ASSISTANT_W
        {
            get { return new PropertyTag(0x3A30, PropertyType.PT_UNICODE); }
        }

        internal static PropertyTag PR_ASSISTANT_A
        {
            get { return new PropertyTag(0x3A30, PropertyType.PT_STRING8); }
        }

        internal static PropertyTag PR_SEND_RICH_INFO
        {
            get { return new PropertyTag(0x3A40, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_STORE_PROVIDERS
        {
            get { return new PropertyTag(0x3D00, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_AB_PROVIDERS
        {
            get { return new PropertyTag(0x3D01, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_TRANSPORT_PROVIDERS
        {
            get { return new PropertyTag(0x3D02, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_DEFAULT_PROFILE
        {
            get { return new PropertyTag(0x3D04, PropertyType.PT_BOOLEAN); }
        }

        internal static PropertyTag PR_AB_SEARCH_PATH
        {
            get { return new PropertyTag(0x3D05, PropertyType.PT_MV_BINARY); }
        }

        internal static PropertyTag PR_AB_DEFAULT_DIR
        {
            get { return new PropertyTag(0x3D06, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_AB_DEFAULT_PAB
        {
            get { return new PropertyTag(0x3D07, PropertyType.PT_BINARY); }
        }

        internal static PropertyTag PR_FILTERING_HOOKS
        {
            get { return new PropertyTag(0x3D08, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the unicode name of a message service as set by the user in the MapiSvc.inf file.
        /// </summary>
        internal static PropertyTag PR_SERVICE_NAME_W
        {
            get { return new PropertyTag(0x3D09, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the ANSI name of a message service as set by the user in the MapiSvc.inf file.
        /// </summary>
        internal static PropertyTag PR_SERVICE_NAME_A
        {
            get { return new PropertyTag(0x3D09, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the unicode filename of the DLL containing the message service provider entry point function to call for
        ///     configuration.
        /// </summary>
        internal static PropertyTag PR_SERVICE_DLL_NAME_W
        {
            get { return new PropertyTag(0x3D0A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the ANSI filename of the DLL containing the message service provider entry point function to call for
        ///     configuration.
        /// </summary>
        internal static PropertyTag PR_SERVICE_DLL_NAME_A
        {
            get { return new PropertyTag(0x3D0A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the MAPIUID structure for a message service.
        /// </summary>
        internal static PropertyTag PR_SERVICE_UID
        {
            get { return new PropertyTag(0x3D0C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of MAPIUID structures that identify additional profile sections for the message service.
        /// </summary>
        internal static PropertyTag PR_SERVICE_EXTRA_UIDS
        {
            get { return new PropertyTag(0x3D0D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of identifiers of message services in the current profile.
        /// </summary>
        internal static PropertyTag PR_SERVICES
        {
            get { return new PropertyTag(0x3D0E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a ANSI list of the files that belong to the message service.
        /// </summary>
        internal static PropertyTag PR_SERVICE_SUPPORT_FILES_W
        {
            get { return new PropertyTag(0x3D0F, PropertyType.PT_MV_UNICODE); }
        }

        /// <summary>
        ///     Contains a ANSI list of the files that belong to the message service.
        /// </summary>
        internal static PropertyTag PR_SERVICE_SUPPORT_FILES_A
        {
            get { return new PropertyTag(0x3D0F, PropertyType.PT_MV_STRING8); }
        }

        /// <summary>
        ///     Contains a list of unicode filenames that are to be deleted when the message service is uninstalled.
        /// </summary>
        internal static PropertyTag PR_SERVICE_DELETE_FILES_W
        {
            get { return new PropertyTag(0x3D10, PropertyType.PT_MV_UNICODE); }
        }

        /// <summary>
        ///     Contains a list of filenames that are to be deleted when the message service is uninstalled.
        /// </summary>
        internal static PropertyTag PR_SERVICE_DELETE_FILES_A
        {
            get { return new PropertyTag(0x3D10, PropertyType.PT_MV_STRING8); }
        }

        /// <summary>
        ///     Contains a list of entry identifiers for address book containers explicitly configured by the user.
        /// </summary>
        internal static PropertyTag PR_AB_SEARCH_PATH_UPDATE
        {
            get { return new PropertyTag(0x3D11, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the ANSI name of the profile.
        /// </summary>
        internal static PropertyTag PR_PROFILE_NAME_A
        {
            get { return new PropertyTag(0x3D12, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the unicode name of the profile.
        /// </summary>
        internal static PropertyTag PR_PROFILE_NAME_W
        {
            get { return new PropertyTag(0x3D12, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name for a service provider's identity as defined within a messaging system. UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_IDENTITY_DISPLAY_W
        {
            get { return new PropertyTag(0x3E00, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name for a service provider's identity as defined within a messaging system. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_IDENTITY_DISPLAY_A
        {
            get { return new PropertyTag(0x3E00, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier for a service provider's identity as defined within a messaging system.
        /// </summary>
        internal static PropertyTag PR_IDENTITY_ENTRYID
        {
            get { return new PropertyTag(0x3E01, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating the methods in the IMAPIStatus interface that are supported by the status
        ///     object.
        /// </summary>
        internal static PropertyTag PR_RESOURCE_METHODS
        {
            get { return new PropertyTag(0x3E02, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value indicating the service provider type.
        /// </summary>
        internal static PropertyTag PR_RESOURCE_TYPE
        {
            get { return new PropertyTag(0x3E03, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating the current status of a session resource. All service providers set status
        ///     codes as does MAPI to report on the status of the subsystem, the MAPI spooler, and the integrated address book.
        /// </summary>
        internal static PropertyTag PR_STATUS_CODE
        {
            get { return new PropertyTag(0x3E04, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the search key for a service provider's identity as defined within a messaging system.
        /// </summary>
        internal static PropertyTag PR_IDENTITY_SEARCH_KEY
        {
            get { return new PropertyTag(0x3E05, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of a transport's tightly coupled message store.
        /// </summary>
        internal static PropertyTag PR_OWN_STORE_ENTRYID
        {
            get { return new PropertyTag(0x3E06, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a path to the service provider's server. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RESOURCE_PATH_W
        {
            get { return new PropertyTag(0x3E07, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a path to the service provider's server. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RESOURCE_PATH_A
        {
            get { return new PropertyTag(0x3E07, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an ASCII message indicating the current status of a session resource. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_STATUS_STRING_W
        {
            get { return new PropertyTag(0x3E08, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an ASCII message indicating the current status of a session resource. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_STATUS_STRING_A
        {
            get { return new PropertyTag(0x3E08, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Was originally meant to contain TRUE if the message transfer system (MTS) allows X.400 deferred delivery
        ///     cancellation. No longer supported.
        /// </summary>
        internal static PropertyTag PR_X400_DEFERRED_DELIVERY_CANCEL
        {
            get { return new PropertyTag(0x3E09, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Was originally meant to contain the entry identifier that a remote transport provider furnishes for its header
        ///     folder. No longer supported.
        /// </summary>
        internal static PropertyTag PR_HEADER_FOLDER_ENTRYID
        {
            get { return new PropertyTag(0x3E0A, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a number indicating the status of a remote transfer.
        /// </summary>
        internal static PropertyTag PR_REMOTE_PROGRESS
        {
            get { return new PropertyTag(0x3E0B, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains an ASCII string indicating the status of a remote transfer. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_REMOTE_PROGRESS_TEXT_W
        {
            get { return new PropertyTag(0x3E0C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an ASCII string indicating the status of a remote transfer. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_REMOTE_PROGRESS_TEXT_A
        {
            get { return new PropertyTag(0x3E0C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if the remote viewer is allowed to call the IMAPIStatus::ValidateState method.
        /// </summary>
        internal static PropertyTag PR_REMOTE_VALIDATE_OK
        {
            get { return new PropertyTag(0x3E0D, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a bitmask of flags governing the behavior of a control used in a dialog box built from a display table.
        /// </summary>
        internal static PropertyTag PR_CONTROL_FLAGS
        {
            get { return new PropertyTag(0x3F00, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a pointer to a structure for a control used in a dialog box.
        /// </summary>
        internal static PropertyTag PR_CONTROL_STRUCTURE
        {
            get { return new PropertyTag(0x3F01, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value indicating a control type for a control used in a dialog box.
        /// </summary>
        internal static PropertyTag PR_CONTROL_TYPE
        {
            get { return new PropertyTag(0x3F02, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the width of a dialog box control in standard Windows dialog units.
        /// </summary>
        internal static PropertyTag PR_DELTAX
        {
            get { return new PropertyTag(0x3F03, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the height of a dialog box control in standard Windows dialog units.
        /// </summary>
        internal static PropertyTag PR_DELTAY
        {
            get { return new PropertyTag(0x3F04, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the x coordinate of the starting position (the upper-left corner) of a dialog box control, in standard
        ///     Windows dialog units.
        /// </summary>
        internal static PropertyTag PR_XPOS
        {
            get { return new PropertyTag(0x3F05, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the y coordinate of the starting position (the upper-left corner) of a dialog box control, in standard
        ///     Windows dialog units.
        /// </summary>
        internal static PropertyTag PR_YPOS
        {
            get { return new PropertyTag(0x3F06, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a unique identifier for a control used in a dialog box.
        /// </summary>
        internal static PropertyTag PR_CONTROL_ID
        {
            get { return new PropertyTag(0x3F07, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Indicates the page of a display template to display first.
        /// </summary>
        internal static PropertyTag PR_INITIAL_DETAILS_PANE
        {
            get { return new PropertyTag(0x3F08, PropertyType.PT_LONG); }
        }
    }

    /// <summary>
    ///     Used to hold exactly one mapi tag
    /// </summary>
    internal class PropertyTag
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
        ///     Returns the PropertyTag as a readable string, e.g.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get { return PropertyTags.SubStorageStreamPrefix + Id.ToString("X4") + ((ushort) Type).ToString("X4"); }
        }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all its properties
        /// </summary>
        /// <param name="id">The id <see cref="ushort" /></param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        internal PropertyTag(ushort id, PropertyType type)
        {
            Id = id;
            Type = type;
        }
        #endregion
    }
}
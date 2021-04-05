// ReSharper disable CommentTypo
//
// PropertyTags.cs
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

using MsgKit.Enums;
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace MsgKit
{
    /// <summary>
    ///     A class that holds all the known mapi tags
    /// </summary>
    public static class PropertyTags
    {
        /// <summary>
        ///     The prefix for an <see cref="Recipient" /> <see cref="OpenMcdf.CFStorage" />
        /// </summary>
        internal const string RecipientStoragePrefix = "__recip_version1.0_#";

        /// <summary>
        ///     The prefix for an <see cref="Attachment" /> <see cref="OpenMcdf.CFStorage" />
        /// </summary>
        internal const string AttachmentStoragePrefix = "__attach_version1.0_#";

        /// <summary>
        ///     The prefix for a <see cref="PropertyTag" /> <see cref="OpenMcdf.CFStream" />
        /// </summary>
        internal const string SubStorageStreamPrefix = "__substg1.0_";

        /// <summary>
        ///     The name for the properties stream
        /// </summary>
        internal const string PropertiesStreamName = "__properties_version1.0";

        /// <summary>
        ///     The name id storage (named property mapping storage)
        /// </summary>
        internal const string NameIdStorage = "__nameid_version1.0";

        /// <summary>
        ///     The <see cref="Streams.EntryStream"/> stream
        /// </summary>
        internal const string EntryStream = "__substg1.0_00030102";

        /// <summary>
        ///     The <see cref="Streams.GuidStream"/> stream
        /// </summary>
        internal const string GuidStream = "__substg1.0_00020102";

        /// <summary>
        ///     The <see cref="Streams.StringStream"/> stream
        /// </summary>
        internal const string StringStream = "__substg1.0_00040102";

        /// <summary>
        ///     Contains the identifier of the mode for message acknowledgment.
        /// </summary>
        public static PropertyTag PR_ACKNOWLEDGEMENT_MODE
        {
            get { return new PropertyTag(0x0001, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if the sender permits auto forwarding of this message.
        /// </summary>
        public static PropertyTag PR_ALTERNATE_RECIPIENT_ALLOWED
        {
            get { return new PropertyTag(0x0002, PropertyType.PT_BOOLEAN); }
        }
        
        /// <summary>
        ///     Contains a list of entry identifiers for users who have authorized the sending of a message.
        /// </summary>
        public static PropertyTag PR_AUTHORIZING_USERS
        {
            get { return new PropertyTag(0x0003, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unicode comment added by the auto-forwarding agent.
        /// </summary>
        public static PropertyTag PR_AUTO_FORWARD_COMMENT_W
        {
            get { return new PropertyTag(0x0004, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a comment added by the auto-forwarding agent.
        /// </summary>
        internal static PropertyTag PR_AUTO_FORWARD_COMMENT_A
        {
            get { return new PropertyTag(0x0004, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if the client requests an X-MS-Exchange-Organization-AutoForwarded header field.
        /// </summary>
        public static PropertyTag PR_AUTO_FORWARDED
        {
            get { return new PropertyTag(0x0005, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an identifier for the algorithm used to confirm message content confidentiality.
        /// </summary>
        public static PropertyTag PR_CONTENT_CONFIDENTIALITY_ALGORITHM_ID
        {
            get { return new PropertyTag(0x0006, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value the message sender can use to match a report with the original message.
        /// </summary>
        public static PropertyTag PR_CONTENT_CORRELATOR
        {
            get { return new PropertyTag(0x0007, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unicode key value that enables the message recipient to identify its content.
        /// </summary>
        public static PropertyTag PR_CONTENT_IDENTIFIER_W
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
        public static PropertyTag PR_CONTENT_LENGTH
        {
            get { return new PropertyTag(0x0009, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if a message should be returned with a nondelivery report.
        /// </summary>
        public static PropertyTag PR_CONTENT_RETURN_REQUESTED
        {
            get { return new PropertyTag(0x000A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the conversation key used in Microsoft Outlook only when locating IPM.MessageManager messages, such as the
        ///     message that contains download history for a Post Office Protocol (POP3) account. This property has been deprecated
        ///     in Exchange Server.
        /// </summary>
        public static PropertyTag PR_CONVERSATION_KEY
        {
            get { return new PropertyTag(0x000B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the encoded information types (EITs) that are applied to a message in transit to describe conversions.
        /// </summary>
        public static PropertyTag PR_CONVERSION_EITS
        {
            get { return new PropertyTag(0x000C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message transfer agent (MTA) is prohibited from making message text conversions that lose
        ///     information.
        /// </summary>
        public static PropertyTag PR_CONVERSION_WITH_LOSS_PROHIBITED
        {
            get { return new PropertyTag(0x000D, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an identifier for the types of text in a message after conversion.
        /// </summary>
        public static PropertyTag PR_CONVERTED_EITS
        {
            get { return new PropertyTag(0x000E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     	Contains the date and time when a message sender wants a message delivered.
        /// </summary>
        public static PropertyTag PR_DEFERRED_DELIVERY_TIME
        {
            get { return new PropertyTag(0x000F, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the date and time when the original message was delivered.
        /// </summary>
        public static PropertyTag PR_DELIVER_TIME
        {
            get { return new PropertyTag(0x0010, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a reason why a message transfer agent (MTA) has discarded a message.
        /// </summary>
        public static PropertyTag PR_DISCARD_REASON
        {
            get { return new PropertyTag(0x0011, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if disclosure of recipients is allowed.
        /// </summary>
        public static PropertyTag PR_DISCLOSURE_OF_RECIPIENTS
        {
            get { return new PropertyTag(0x0012, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a history showing how a distribution list has been expanded during message transmiss
        /// </summary>
        public static PropertyTag PR_DL_EXPANSION_HISTORY
        {
            get { return new PropertyTag(0x0013, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message transfer agent (MTA) is prohibited from expanding distribution lists.
        /// </summary>
        public static PropertyTag PR_DL_EXPANSION_PROHIBITED
        {
            get { return new PropertyTag(0x0014, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the date and time when the messaging system can invalidate the content of a message.
        /// </summary>
        public static PropertyTag PR_EXPIRY_TIME
        {
            get { return new PropertyTag(0x0015, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the date and time when the messaging system can invalidate the content of a message.
        /// </summary>
        public static PropertyTag PR_IMPLICIT_CONVERSION_PROHIBITED
        {
            get { return new PropertyTag(0x0016, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a value that indicates the message sender's opinion of the importance of a message.
        /// </summary>
        public static PropertyTag PR_IMPORTANCE
        {
            get { return new PropertyTag(0x0017, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     The IpmId field represents a PR_IPM_ID MAPI property.
        /// </summary>
        public static PropertyTag PR_IPM_ID
        {
            get { return new PropertyTag(0x0018, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the latest date and time when a message transfer agent (MTA) should deliver a message.
        /// </summary>
        public static PropertyTag PR_LATEST_DELIVERY_TIME
        {
            get { return new PropertyTag(0x0019, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a text string that identifies the sender-defined message class, such as IPM.Note.
        /// </summary>
        public static PropertyTag PR_MESSAGE_CLASS_W
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
        public static PropertyTag PR_MESSAGE_DELIVERY_ID
        {
            get { return new PropertyTag(0x001B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a security label for a message.
        /// </summary>
        public static PropertyTag PR_MESSAGE_SECURITY_LABEL
        {
            get { return new PropertyTag(0x001E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the identifiers of messages that this message supersedes.
        /// </summary>
        public static PropertyTag PR_OBSOLETED_IPMS
        {
            get { return new PropertyTag(0x001F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the encoded name of the originally intended recipient of an autoforwarded message.
        /// </summary>
        public static PropertyTag PR_ORIGINALLY_INTENDED_RECIPIENT_NAME
        {
            get { return new PropertyTag(0x0020, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a copy of the original encoded information types (EITs) for message text.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_EITS
        {
            get { return new PropertyTag(0x0021, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an ASN.1 certificate for the message originator.
        /// </summary>
        public static PropertyTag PR_ORIGINATOR_CERTIFICATE
        {
            get { return new PropertyTag(0x0022, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests a delivery report for a particular recipient from the messaging system
        ///     before the message is placed in the message store.
        /// </summary>
        public static PropertyTag PR_ORIGINATOR_DELIVERY_REPORT_REQUESTED
        {
            get { return new PropertyTag(0x0023, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the binary-encoded return address of the message originator.
        /// </summary>
        public static PropertyTag PR_ORIGINATOR_RETURN_ADDRESS
        {
            get { return new PropertyTag(0x0024, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Was originally meant to contain a value used in correlating conversation threads. No longer supported.
        /// </summary>
        public static PropertyTag PR_PARENT_KEY
        {
            get { return new PropertyTag(0x0025, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the relative priority of a message.
        /// </summary>
        public static PropertyTag PR_PRIORITY
        {
            get { return new PropertyTag(0x0026, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a binary verification value enabling a delivery report recipient to verify the origin of the original
        ///     message.
        /// </summary>
        public static PropertyTag PR_ORIGIN_CHECK
        {
            get { return new PropertyTag(0x0027, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests proof that the message transfer system has submitted a message for
        ///     delivery to the originally intended recipient.
        /// </summary>
        public static PropertyTag PR_PROOF_OF_SUBMISSION_REQUESTED
        {
            get { return new PropertyTag(0x0028, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender wants the messaging system to generate a read report when the recipient has read
        ///     a message.
        /// </summary>
        public static PropertyTag PR_READ_RECEIPT_REQUESTED
        {
            get { return new PropertyTag(0x0029, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the date and time a delivery report is generated.
        /// </summary>
        public static PropertyTag PR_RECEIPT_TIME
        {
            get { return new PropertyTag(0x002A, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains TRUE if recipient reassignment is prohibited.
        /// </summary>
        public static PropertyTag PR_RECIPIENT_REASSIGNMENT_PROHIBITED
        {
            get { return new PropertyTag(0x002B, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains information about the route covered by a delivered message.
        /// </summary>
        public static PropertyTag PR_REDIRECTION_HISTORY
        {
            get { return new PropertyTag(0x002C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of identifiers for messages to which a message is related.
        /// </summary>
        public static PropertyTag PR_RELATED_IPMS
        {
            get { return new PropertyTag(0x002D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the sensitivity value assigned by the sender of the first version of a message — that is, the message
        ///     before being forwarded or replied to.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENSITIVITY
        {
            get { return new PropertyTag(0x002E, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains an ASCII list of the languages incorporated in a message. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_LANGUAGES_W
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
        public static PropertyTag PR_REPLY_TIME
        {
            get { return new PropertyTag(0x0030, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a binary tag value that the messaging system should copy to any report generated for the message.
        /// </summary>
        public static PropertyTag PR_REPORT_TAG
        {
            get { return new PropertyTag(0x0031, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the date and time when the messaging system generated a report.
        /// </summary>
        public static PropertyTag PR_REPORT_TIME
        {
            get { return new PropertyTag(0x0032, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains TRUE if the original message is being returned with a nonread report.
        /// </summary>
        public static PropertyTag PR_RETURNED_IPM
        {
            get { return new PropertyTag(0x0033, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a flag that indicates the security level of a message.
        /// </summary>
        public static PropertyTag PR_SECURITY
        {
            get { return new PropertyTag(0x0034, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if this message is an incomplete copy of another message.
        /// </summary>
        public static PropertyTag PR_INCOMPLETE_COPY
        {
            get { return new PropertyTag(0x0035, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a value indicating the message sender's opinion of the sensitivity of a message.
        /// </summary>
        public static PropertyTag PR_SENSITIVITY
        {
            get { return new PropertyTag(0x0036, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the full subject, encoded in Unicode standard, of a message.
        /// </summary>
        public static PropertyTag PR_SUBJECT_W
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
        public static PropertyTag PR_SUBJECT_IPM
        {
            get { return new PropertyTag(0x0038, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the date and time the message sender submitted a message.
        /// </summary>
        public static PropertyTag PR_CLIENT_SUBMIT_TIME
        {
            get { return new PropertyTag(0x0039, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the unicode display name for the recipient that should get reports for this message.
        /// </summary>
        public static PropertyTag PR_REPORT_NAME_W
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
        public static PropertyTag PR_SENT_REPRESENTING_SEARCH_KEY
        {
            get { return new PropertyTag(0x003B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains the content type for a submitted message.
        /// </summary>
        public static PropertyTag PR_X400_CONTENT_TYPE
        {
            get { return new PropertyTag(0x003C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unicode subject prefix that typically indicates some action on a messagE, such as "FW: " for forwarding.
        /// </summary>
        public static PropertyTag PR_SUBJECT_PREFIX_W
        {
            get { return new PropertyTag(0x003D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a ANSI subject prefix that typically indicates some action on a messagE, such as "FW: " for forwarding.
        /// </summary>
        internal static PropertyTag PR_SUBJECT_PREFIX_A
        {
            get { return new PropertyTag(0x003D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains reasons why a message was not received that forms part of a non-delivery report.
        /// </summary>
        public static PropertyTag PR_NON_RECEIPT_REASON
        {
            get { return new PropertyTag(0x003E, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry identifier of the messaging user that actually receives the message.
        /// </summary>
        public static PropertyTag PR_RECEIVED_BY_ENTRYID
        {
            get { return new PropertyTag(0x003F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of the messaging user that actually receives the message. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RECEIVED_BY_NAME_W
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
        public static PropertyTag PR_SENT_REPRESENTING_ENTRYID
        {
            get { return new PropertyTag(0x0041, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name for the messaging user represented by the sender. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_SENT_REPRESENTING_NAME_W
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
        public static PropertyTag PR_RCVD_REPRESENTING_NAME_W
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
        public static PropertyTag PR_REPORT_ENTRYID
        {
            get { return new PropertyTag(0x0045, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an entry identifier for the messaging user to which the messaging system should direct a read report for
        ///     this message.
        /// </summary>
        public static PropertyTag PR_READ_RECEIPT_ENTRYID
        {
            get { return new PropertyTag(0x0046, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a message transfer system (MTS) identifier for the message transfer agent (MTA).
        /// </summary>
        public static PropertyTag PR_MESSAGE_SUBMISSION_ID
        {
            get { return new PropertyTag(0x0047, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the date and time a transport provider passed a message to its underlying messaging system.
        /// </summary>
        public static PropertyTag PR_PROVIDER_SUBMIT_TIME
        {
            get { return new PropertyTag(0x0048, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the subject of an original message for use in a report about the message. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SUBJECT_W
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
        public static PropertyTag PR_DISC_VAL
        {
            get { return new PropertyTag(0x004A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the class of the original message for use in a report. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIG_MESSAGE_CLASS_W
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
        ///     Contains the entry identifier of the author of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_AUTHOR_ENTRYID
        {
            get { return new PropertyTag(0x004C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of the author of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_AUTHOR_NAME_W
        {
            get { return new PropertyTag(0x004D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the author of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_AUTHOR_NAME_A
        {
            get { return new PropertyTag(0x004D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the original submission date and time of the message in the report.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SUBMIT_TIME
        {
            get { return new PropertyTag(0x004E, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a sized array of entry identifiers for recipients that are to get a reply.
        /// </summary>
        public static PropertyTag PR_REPLY_RECIPIENT_ENTRIES
        {
            get { return new PropertyTag(0x004F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of display names for recipients that are to get a reply. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_REPLY_RECIPIENT_NAMES_W
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
        public static PropertyTag PR_RECEIVED_BY_SEARCH_KEY
        {
            get { return new PropertyTag(0x0051, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key for the messaging user represented by the receiving user.
        /// </summary>
        public static PropertyTag PR_RCVD_REPRESENTING_SEARCH_KEY
        {
            get { return new PropertyTag(0x0052, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a search key for the messaging user to which the messaging system should direct a read report for a
        ///     message.
        /// </summary>
        public static PropertyTag PR_READ_RECEIPT_SEARCH_KEY
        {
            get { return new PropertyTag(0x0053, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key for the recipient that should get reports for this message.
        /// </summary>
        public static PropertyTag PR_REPORT_SEARCH_KEY
        {
            get { return new PropertyTag(0x0054, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a copy of the original message's delivery date and time in a thread.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_DELIVERY_TIME
        {
            get { return new PropertyTag(0x0055, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the search key of the author of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_AUTHOR_SEARCH_KEY
        {
            get { return new PropertyTag(0x0056, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if this messaging user is specifically named as a primary (To) recipient of this message and is not
        ///     part of a distribution list.
        /// </summary>
        public static PropertyTag PR_MESSAGE_TO_ME
        {
            get { return new PropertyTag(0x0057, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if this messaging user is specifically named as a carbon copy (CC) recipient of this message and is
        ///     not part of a distribution list.
        /// </summary>
        public static PropertyTag PR_MESSAGE_CC_ME
        {
            get { return new PropertyTag(0x0058, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if this messaging user is specifically named as a primary (To), carbon copy (CC), or blind carbon
        ///     copy (BCC) recipient of this message and is not part of a distribution list.
        /// </summary>
        public static PropertyTag PR_MESSAGE_RECIP_ME
        {
            get { return new PropertyTag(0x0059, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the display name of the sender of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENDER_NAME_W
        {
            get { return new PropertyTag(0x005A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the sender of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_SENDER_NAME_A
        {
            get { return new PropertyTag(0x005A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the entry identifier of the sender of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENDER_ENTRYID
        {
            get { return new PropertyTag(0x005B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key for the sender of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENDER_SEARCH_KEY
        {
            get { return new PropertyTag(0x005C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of the messaging user on whose behalf the original message was sent. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_NAME_W
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
        public static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_ENTRYID
        {
            get { return new PropertyTag(0x005E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the search key of the messaging user on whose behalf the original message was sent.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_SEARCH_KEY
        {
            get { return new PropertyTag(0x005F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the starting date and time of an appointment as managed by a scheduling application.
        /// </summary>
        public static PropertyTag PR_START_DATE
        {
            get { return new PropertyTag(0x0060, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the ending date and time of an appointment as managed by a scheduling application.
        /// </summary>
        public static PropertyTag PR_END_DATE
        {
            get { return new PropertyTag(0x0061, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains an identifier for an appointment in the owner's schedule.
        /// </summary>
        public static PropertyTag PR_OWNER_APPT_ID
        {
            get { return new PropertyTag(0x0062, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if the message sender wants a response to a meeting request.
        /// </summary>
        public static PropertyTag PR_RESPONSE_REQUESTED
        {
            get { return new PropertyTag(0x0063, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the address type for the messaging user represented by the sender. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_SENT_REPRESENTING_ADDRTYPE_W
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
        public static PropertyTag PR_SENT_REPRESENTING_EMAIL_ADDRESS_W
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
        ///     Contains the address type of the sender of the first version of a messagE, that is, the message before being
        ///     forwarded or replied to. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SENDER_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0066, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the address type of the sender of the first version of a messagE, that is, the message before being
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
        public static PropertyTag PR_ORIGINAL_SENDER_EMAIL_ADDRESS_W
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
        public static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE_W
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
        public static PropertyTag PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS_W
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
        public static PropertyTag PR_CONVERSATION_TOPIC_W
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
        /// <remarks>
        ///     See https://msdn.microsoft.com/en-us/library/office/cc842470.aspx
        /// </remarks>
        public static PropertyTag PR_CONVERSATION_INDEX
        {
            get { return new PropertyTag(0x0071, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a binary value that indicates the relative position of this message within a conversation thread.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_DISPLAY_BCC_W
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
        public static PropertyTag PR_ORIGINAL_DISPLAY_CC_W
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
        public static PropertyTag PR_ORIGINAL_DISPLAY_TO_W
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
        ///     Contains the e-mail address typE, such as SMTP, for the messaging user that actually receives the message. UNICODE
        ///     compilation.
        /// </summary>
        public static PropertyTag PR_RECEIVED_BY_ADDRTYPE_W
        {
            get { return new PropertyTag(0x0075, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the e-mail address typE, such as SMTP, for the messaging user that actually receives the message.
        ///     Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECEIVED_BY_ADDRTYPE_A
        {
            get { return new PropertyTag(0x0075, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the e-mail address for the messaging user that actually receives the message. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RECEIVED_BY_EMAIL_ADDRESS_W
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
        public static PropertyTag PR_RCVD_REPRESENTING_ADDRTYPE_W
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
        public static PropertyTag PR_RCVD_REPRESENTING_EMAIL_ADDRESS_W
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
        public static PropertyTag PR_ORIGINAL_AUTHOR_ADDRTYPE_W
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
        public static PropertyTag PR_ORIGINAL_AUTHOR_EMAIL_ADDRESS_W
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
        public static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_ADDRTYPE_W
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
        public static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_EMAIL_ADDRESS_W
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
        ///     Contains transport-specific message envelope information. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TRANSPORT_MESSAGE_HEADERS_A
        {
            get { return new PropertyTag(0x007D, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains transport-specific message envelope information. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_TRANSPORT_MESSAGE_HEADERS_W
        {
            get { return new PropertyTag(0x007D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the converted value of the attDelegate workgroup property.
        /// </summary>
        public static PropertyTag PR_DELEGATION
        {
            get { return new PropertyTag(0x007E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value used to correlate a Transport Neutral Encapsulation Format (TNEF) attachment with a message
        /// </summary>
        public static PropertyTag PR_TNEF_CORRELATION_KEY
        {
            get { return new PropertyTag(0x007F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the message text. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties are typically used only in an interpersonal message (IPM).
        ///     Message stores that support Rich Text Format (RTF) ignore any changes to white space in the message text. When
        ///     PR_BODY is stored for the first timE, the message store also generates and stores the PR_RTF_COMPRESSED
        ///     (PidTagRtfCompressed) property, the RTF version of the message text. If the IMAPIProp::SaveChanges method is
        ///     subsequently called and PR_BODY has been modifieD, the message store calls the RTFSync function to ensure
        ///     synchronization with the RTF version. If only white space has been changeD, the properties are left unchanged. This
        ///     preserves any nontrivial RTF formatting when the message travels through non-RTF-aware clients and messaging
        ///     systems.
        ///     The value for this property must be expressed in the code page of the operating system that MAPI is running on.
        /// </remarks>
        public static PropertyTag PR_BODY_W
        {
            get { return new PropertyTag(0x1000, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the message text. Non-UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties are typically used only in an interpersonal message (IPM).
        ///     Message stores that support Rich Text Format (RTF) ignore any changes to white space in the message text. When
        ///     PR_BODY is stored for the first timE, the message store also generates and stores the PR_RTF_COMPRESSED
        ///     (PidTagRtfCompressed) property, the RTF version of the message text. If the IMAPIProp::SaveChanges method is
        ///     subsequently called and PR_BODY has been modifieD, the message store calls the RTFSync function to ensure
        ///     synchronization with the RTF version. If only white space has been changeD, the properties are left unchanged. This
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
        public static PropertyTag PR_REPORT_TEXT_W
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
        public static PropertyTag PR_ORIGINATOR_AND_DL_EXPANSION_HISTORY
        {
            get { return new PropertyTag(0x1002, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the display name of a distribution list where the messaging system delivers a report.
        /// </summary>
        public static PropertyTag PR_REPORTING_DL_NAME
        {
            get { return new PropertyTag(0x1003, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an identifier for the message transfer agent that generated a report.
        /// </summary>
        public static PropertyTag PR_REPORTING_MTA_CERTIFICATE
        {
            get { return new PropertyTag(0x1004, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the cyclical redundancy check (CRC) computed for the message text.
        /// </summary>
        public static PropertyTag PR_RTF_SYNC_BODY_CRC
        {
            get { return new PropertyTag(0x1006, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a count of the significant characters of the message text.
        /// </summary>
        public static PropertyTag PR_RTF_SYNC_BODY_COUNT
        {
            get { return new PropertyTag(0x1007, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains significant characters that appear at the beginning of the message text. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RTF_SYNC_BODY_TAG_W
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
        public static PropertyTag PR_RTF_COMPRESSED
        {
            get { return new PropertyTag(0x1009, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a count of the ignorable characters that appear before the significant characters of the message.
        /// </summary>
        public static PropertyTag PR_RTF_SYNC_PREFIX_COUNT
        {
            get { return new PropertyTag(0x1010, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a count of the ignorable characters that appear after the significant characters of the message.
        /// </summary>
        public static PropertyTag PR_RTF_SYNC_TRAILING_COUNT
        {
            get { return new PropertyTag(0x1011, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry identifier of the originally intended recipient of an auto-forwarded message.
        /// </summary>
        public static PropertyTag PR_ORIGINALLY_INTENDED_RECIP_ENTRYID
        {
            get { return new PropertyTag(0x1012, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the Hypertext Markup Language (HTML) version of the message text. 
        /// </summary>
        /// <remarks>
        ///     These properties contain the same message text as the <see cref="PR_BODY_CONTENT_LOCATION_W" />
        ///     (PidTagBodyContentLocation), but in HTML. A message store that supports HTML indicates this by setting the 
        ///     <see cref="StoreSupportMask.STORE_HTML_OK" /> flag in its <see cref="PR_STORE_SUPPORT_MASK" />
        ///     (PidTagStoreSupportMask). Note <see cref="StoreSupportMask.STORE_HTML_OK" /> is not defined in versions of 
        ///     Mapidefs.h included with Microsoft® Exchange 2000 Server and earlier. If <see cref="StoreSupportMask.STORE_HTML_OK" /> 
        ///     is undefined, use the value 0x00010000 instead.
        /// </remarks>
        internal static PropertyTag PR_BODY_HTML_A
        {
            get { return new PropertyTag(0x1013, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the message body text in HTML format.
        /// </summary>
        public static PropertyTag PR_HTML
        {
            get { return new PropertyTag(0x1013, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the value of a MIME Content-Location header field.
        /// </summary>
        /// <remarks>
        ///     To set the value of these properties, MIME clients should write the desired value to a Content-Location header 
        ///     field on a MIME entity that maps to a message body. MIME readers should copy the value of a Content-Location 
        ///     header field on such a MIME entity to the value of these properties
        /// </remarks>
        internal static PropertyTag PR_BODY_CONTENT_LOCATION_A
        {
            get { return new PropertyTag(0x1014, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the value of a MIME Content-Location header field. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     To set the value of these properties, MIME clients should write the desired value to a Content-Location header 
        ///     field on a MIME entity that maps to a message body. MIME readers should copy the value of a Content-Location 
        ///     header field on such a MIME entity to the value of these properties
        /// </remarks>
        public static PropertyTag PR_BODY_CONTENT_LOCATION_W
        {
            get { return new PropertyTag(0x1014, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Corresponds to the message ID field as specified in [RFC2822]. 
        /// </summary>
        /// <remarks>
        ///     These properties should be present on all e-mail messages.
        /// </remarks>
        internal static PropertyTag PR_INTERNET_MESSAGE_ID_A
        {
            get { return new PropertyTag(0x1035, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Corresponds to the message ID field as specified in [RFC2822]. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties should be present on all e-mail messages.
        /// </remarks>
        public static PropertyTag PR_INTERNET_MESSAGE_ID_W
        {
            get { return new PropertyTag(0x1035, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the original message's PR_INTERNET_MESSAGE_ID (PidTagInternetMessageId) property value.
        /// </summary>
        /// <remarks>
        ///     These properties must be set on all message replies.
        /// </remarks>
        internal static PropertyTag PR_IN_REPLY_TO_ID_A
        {
            get { return new PropertyTag(0x1042, PropertyType.PT_STRING8); }
        }


        /// <summary>
        ///     Contains the original message's PR_INTERNET_MESSAGE_ID (PidTagInternetMessageId) property value. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties should be present on all e-mail messages.
        /// </remarks>
        public static PropertyTag PR_IN_REPLY_TO_ID_W
        {
            get { return new PropertyTag(0x1042, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the value of a Multipurpose Internet Mail Extensions (MIME) message's References header field.
        /// </summary>
        /// <remarks>
        ///     To generate a References header field, clients must set these properties to the desired value. MIME writers must copy 
        ///     the value of these properties to the References header field. To set the value of these properties, MIME clients must 
        ///     write the desired value to a References header field. MIME readers must copy the value of the References header field 
        ///     to these properties. MIME readers may truncate the value of these properties if it exceeds 64KB in length.
        /// </remarks>
        internal static PropertyTag PR_INTERNET_REFERENCES_A
        {
            get { return new PropertyTag(0x1039, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the value of a Multipurpose Internet Mail Extensions (MIME) message's References header field. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     To generate a References header field, clients must set these properties to the desired value. MIME writers must copy 
        ///     the value of these properties to the References header field. To set the value of these properties, MIME clients must 
        ///     write the desired value to a References header field. MIME readers must copy the value of the References header field 
        ///     to these properties. MIME readers may truncate the value of these properties if it exceeds 64KB in length.
        /// </remarks>
        public static PropertyTag PR_INTERNET_REFERENCES_W
        {
            get { return new PropertyTag(0x1039, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an ASN.1 content integrity check value that allows a message sender to protect message content from
        ///     disclosure to unauthorized recipients.
        /// </summary>
        public static PropertyTag PR_CONTENT_INTEGRITY_CHECK
        {
            get { return new PropertyTag(0x0C00, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Indicates that a message sender has requested a message content conversion for a particular recipient.
        /// </summary>
        public static PropertyTag PR_EXPLICIT_CONVERSION
        {
            get { return new PropertyTag(0x0C01, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if this message should be returned with a report.
        /// </summary>
        public static PropertyTag PR_IPM_RETURN_REQUESTED
        {
            get { return new PropertyTag(0x0C02, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an ASN.1 security token for a message.
        /// </summary>
        public static PropertyTag PR_MESSAGE_TOKEN
        {
            get { return new PropertyTag(0x0C03, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a diagnostic code that forms part of a nondelivery report.
        /// </summary>
        public static PropertyTag PR_NDR_REASON_CODE
        {
            get { return new PropertyTag(0x0C04, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a diagnostic code that forms part of a nondelivery report.
        /// </summary>
        public static PropertyTag PR_NDR_DIAG_CODE
        {
            get { return new PropertyTag(0x0C05, PropertyType.PT_LONG); }
        }

        /// <summary>
        /// </summary>
        public static PropertyTag PR_NON_RECEIPT_NOTIFICATION_REQUESTED
        {
            get { return new PropertyTag(0x0C06, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender wants notification of non-receipt for a specified recipient.
        /// </summary>
        public static PropertyTag PR_ORIGINATOR_NON_DELIVERY_REPORT_REQUESTED
        {
            get { return new PropertyTag(0x0C08, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an entry identifier for an alternate recipient designated by the sender.
        /// </summary>
        public static PropertyTag PR_ORIGINATOR_REQUESTED_ALTERNATE_RECIPIENT
        {
            get { return new PropertyTag(0x0C09, PropertyType.PT_BINARY); }
        }

        /// <summary>
        /// </summary>
        public static PropertyTag PR_PHYSICAL_DELIVERY_BUREAU_FAX_DELIVERY
        {
            get { return new PropertyTag(0x0C0A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if the messaging system should use a fax bureau for physical delivery of this message.
        /// </summary>
        public static PropertyTag PR_PHYSICAL_DELIVERY_MODE
        {
            get { return new PropertyTag(0x0C0B, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the mode of a report to be delivered to a particular message recipient upon completion of physical message
        ///     delivery or delivery by the message handling system.
        /// </summary>
        public static PropertyTag PR_PHYSICAL_DELIVERY_REPORT_REQUEST
        {
            get { return new PropertyTag(0x0C0C, PropertyType.PT_LONG); }
        }

        /// <summary>
        /// </summary>
        public static PropertyTag PR_PHYSICAL_FORWARDING_ADDRESS
        {
            get { return new PropertyTag(0x0C0D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests the message transfer agent to attach a physical forwarding address for a
        ///     message recipient.
        /// </summary>
        public static PropertyTag PR_PHYSICAL_FORWARDING_ADDRESS_REQUESTED
        {
            get { return new PropertyTag(0x0C0E, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender prohibits physical message forwarding for a specific recipient.
        /// </summary>
        public static PropertyTag PR_PHYSICAL_FORWARDING_PROHIBITED
        {
            get { return new PropertyTag(0x0C0F, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an ASN.1 object identifier that is used for rendering message attachments.
        /// </summary>
        public static PropertyTag PR_PHYSICAL_RENDITION_ATTRIBUTES
        {
            get { return new PropertyTag(0x0C10, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains an ASN.1 proof of delivery value.
        /// </summary>
        public static PropertyTag PR_PROOF_OF_DELIVERY
        {
            get { return new PropertyTag(0x0C11, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains TRUE if a message sender requests proof of delivery for a particular recipient.
        /// </summary>
        public static PropertyTag PR_PROOF_OF_DELIVERY_REQUESTED
        {
            get { return new PropertyTag(0x0C12, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a message recipient's ASN.1 certificate for use in a report.
        /// </summary>
        public static PropertyTag PR_RECIPIENT_CERTIFICATE
        {
            get { return new PropertyTag(0x0C13, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     This property contains a message recipient's telephone number to call to advise of the physical delivery of a
        ///     message. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RECIPIENT_NUMBER_FOR_ADVICE_W
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
        public static PropertyTag PR_RECIPIENT_TYPE
        {
            get { return new PropertyTag(0x0C15, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     This property contains the type of registration used for physical delivery of a message.
        /// </summary>
        public static PropertyTag PR_REGISTERED_MAIL_TYPE
        {
            get { return new PropertyTag(0x0C16, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if a message sender requests a reply from a recipient.
        /// </summary>
        public static PropertyTag PR_REPLY_REQUESTED
        {
            get { return new PropertyTag(0x0C17, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     This property contains a binary array of delivery methods (service providers), in the order of a message sender's
        ///     preference.
        /// </summary>
        public static PropertyTag PR_REQUESTED_DELIVERY_METHOD
        {
            get { return new PropertyTag(0x0C18, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the message sender's entry identifier.
        /// </summary>
        public static PropertyTag PR_SENDER_ENTRYID
        {
            get { return new PropertyTag(0x0C19, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the message sender's display name. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_SENDER_NAME_W
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
        public static PropertyTag PR_SUPPLEMENTARY_INFO_W
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
        public static PropertyTag PR_TYPE_OF_MTS_USER
        {
            get { return new PropertyTag(0x0C1C, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the message sender's search key.
        /// </summary>
        public static PropertyTag PR_SENDER_SEARCH_KEY
        {
            get { return new PropertyTag(0x0C1D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the message sender's e-mail address type. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_SENDER_ADDRTYPE_W
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
        ///     Contains the message sender's e-mail address, encoded in Unicode standard.
        /// </summary>
        public static PropertyTag PR_SENDER_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x0C1F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the message sender's e-mail address, encoded in Non-Unicode standard.
        /// </summary>
        internal static PropertyTag PR_SENDER_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x0C1F, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Was originally meant to contain the current version of a message store. No longer supported.
        /// </summary>
        public static PropertyTag PR_CURRENT_VERSION
        {
            get { return new PropertyTag(0x0E00, PropertyType.PT_I8); }
        }

        /// <summary>
        ///     Contains TRUE if a client application wants MAPI to delete the associated message after submission.
        /// </summary>
        public static PropertyTag PR_DELETE_AFTER_SUBMIT
        {
            get { return new PropertyTag(0x0E01, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an ASCII list of the display names of any blind carbon copy (BCC) message recipients, separated by
        ///     semicolons (;). UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_DISPLAY_BCC_W
        {
            get { return new PropertyTag(0x0E02, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an ASCII list of the display names of any blind carbon copy (BCC) message recipients, separated by
        ///     semicolons (;). Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_DISPLAY_BCC_A
        {
            get { return new PropertyTag(0x0E02, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an ASCII list of the display names of any carbon copy (CC) message recipients, separated by semicolons
        ///     (;). UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_DISPLAY_CC_W
        {
            get { return new PropertyTag(0x0E03, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an ASCII list of the display names of any carbon copy (CC) message recipients, separated by semicolons
        ///     (;). Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_DISPLAY_CC_A
        {
            get { return new PropertyTag(0x0E03, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a list of the display names of the primary (To) message recipients, separated by semicolons (;). UNICODE
        ///     compilation.
        /// </summary>
        public static PropertyTag PR_DISPLAY_TO_W
        {
            get { return new PropertyTag(0x0E04, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a list of the display names of the primary (To) message recipients, separated by semicolons (;).
        ///     Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_DISPLAY_TO_A
        {
            get { return new PropertyTag(0x0E04, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the display name of the folder in which a message was found during a search. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PARENT_DISPLAY_W
        {
            get { return new PropertyTag(0x0E05, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name of the folder in which a message was found during a search. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PARENT_DISPLAY_A
        {
            get { return new PropertyTag(0x0E05, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the date and time a message was delivered.
        /// </summary>
        public static PropertyTag PR_MESSAGE_DELIVERY_TIME
        {
            get { return new PropertyTag(0x0E06, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating the origin and current state of a message.
        /// </summary>
        public static PropertyTag PR_MESSAGE_FLAGS
        {
            get { return new PropertyTag(0x0E07, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the sum, in bytes, of the sizes of all properties on a message object.
        /// </summary>
        public static PropertyTag PR_MESSAGE_SIZE
        {
            get { return new PropertyTag(0x0E08, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry identifier of the folder containing a folder or message.
        /// </summary>
        public static PropertyTag PR_PARENT_ENTRYID
        {
            get { return new PropertyTag(0x0E09, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the folder where the message should be moved after submission.
        /// </summary>
        public static PropertyTag PR_SENTMAIL_ENTRYID
        {
            get { return new PropertyTag(0x0E0A, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if the sender of a message requests the correlation feature of the messaging system.
        /// </summary>
        public static PropertyTag PR_CORRELATE
        {
            get { return new PropertyTag(0x0E0C, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the message transfer system (MTS) identifier used in correlating reports with sent messages.
        /// </summary>
        public static PropertyTag PR_CORRELATE_MTSID
        {
            get { return new PropertyTag(0x0E0D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a nondelivery report applies only to discrete members of a distribution list rather than the
        ///     entire list.
        /// </summary>
        public static PropertyTag PR_DISCRETE_VALUES
        {
            get { return new PropertyTag(0x0E0E, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if some transport provider has already accepted responsibility for delivering the message to this
        ///     recipient, and FALSE if the MAPI spooler considers that this transport provider should accept responsibility.
        /// </summary>
        public static PropertyTag PR_RESPONSIBILITY
        {
            get { return new PropertyTag(0x0E0F, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the status of the message based on information available to the MAPI spooler.
        /// </summary>
        public static PropertyTag PR_SPOOLER_STATUS
        {
            get { return new PropertyTag(0x0E10, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Obsolete MAPI spooler property. No longer supported.
        /// </summary>
        public static PropertyTag PR_TRANSPORT_STATUS
        {
            get { return new PropertyTag(0x0E11, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a table of restrictions that can be applied to a contents table to find all messages that contain
        ///     recipient subobjects meeting the restrictions.
        /// </summary>
        public static PropertyTag PR_MESSAGE_RECIPIENTS
        {
            get { return new PropertyTag(0x0E12, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains a table of restrictions that can be applied to a contents table to find all messages that contain
        ///     attachment subobjects meeting the restrictions.
        /// </summary>
        public static PropertyTag PR_MESSAGE_ATTACHMENTS
        {
            get { return new PropertyTag(0x0E13, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating details about a message submission.
        /// </summary>
        public static PropertyTag PR_SUBMIT_FLAGS
        {
            get { return new PropertyTag(0x0E14, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value used by the MAPI spooler in assigning delivery responsibility among transport providers.
        /// </summary>
        public static PropertyTag PR_RECIPIENT_STATUS
        {
            get { return new PropertyTag(0x0E15, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value used by the MAPI spooler to track the progress of an outbound message through the outgoing
        ///     transport providers.
        /// </summary>
        public static PropertyTag PR_TRANSPORT_KEY
        {
            get { return new PropertyTag(0x0E16, PropertyType.PT_LONG); }
        }

        /// <summary>
        /// </summary>
        public static PropertyTag PR_MSG_STATUS
        {
            get { return new PropertyTag(0x0E17, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmask of property tags that define the status of a message.
        /// </summary>
        public static PropertyTag PR_MESSAGE_DOWNLOAD_TIME
        {
            get { return new PropertyTag(0x0E18, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Was originally meant to contain the message store version current at the time a message was created. No longer
        ///     supported.
        /// </summary>
        public static PropertyTag PR_CREATION_VERSION
        {
            get { return new PropertyTag(0x0E19, PropertyType.PT_I8); }
        }

        /// <summary>
        ///     Was originally meant to contain the message store version current at the time the message was last modified. No
        ///     longer supported.
        /// </summary>
        public static PropertyTag PR_MODIFY_VERSION
        {
            get { return new PropertyTag(0x0E1A, PropertyType.PT_I8); }
        }

        /// <summary>
        ///     When true then the message contains at least one attachment.
        /// </summary>
        public static PropertyTag PR_HASATTACH
        {
            get { return new PropertyTag(0x0E1B, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a circular redundancy check (CRC) value on the message text.
        /// </summary>
        public static PropertyTag PR_BODY_CRC
        {
            get { return new PropertyTag(0x0E1C, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the message subject with any prefix removed. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     See https://msdn.microsoft.com/en-us/library/office/cc815282.aspx
        /// </remarks>
        public static PropertyTag PR_NORMALIZED_SUBJECT_W
        {
            get { return new PropertyTag(0x0E1D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the message subject with any prefix removed. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_NORMALIZED_SUBJECT_A
        {
            get { return new PropertyTag(0x0E1D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if PR_RTF_COMPRESSED has the same text content as PR_BODY for this message.
        /// </summary>
        public static PropertyTag PR_RTF_IN_SYNC
        {
            get { return new PropertyTag(0x0E1F, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the sum, in bytes, of the sizes of all properties on an attachment.
        /// </summary>
        public static PropertyTag PR_ATTACH_SIZE
        {
            get { return new PropertyTag(0x0E20, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a number that uniquely identifies the attachment within its parent message.
        /// </summary>
        public static PropertyTag PR_ATTACH_NUM
        {
            get { return new PropertyTag(0x0E21, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmask of flags for an attachment.
        /// </summary>
        /// <remarks>
        ///     If the PR_ATTACH_FLAGS property is zero or absent, the attachment is to be processed by all applications.
        /// </remarks>
        public static PropertyTag PR_ATTACH_FLAGS
        {
            get { return new PropertyTag(0x3714, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if the message requires preprocessing.
        /// </summary>
        public static PropertyTag PR_PREPROCESS
        {
            get { return new PropertyTag(0x0E22, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains an identifier for the message transfer agent (MTA) that originated the message.
        /// </summary>
        public static PropertyTag PR_ORIGINATING_MTA_CERTIFICATE
        {
            get { return new PropertyTag(0x0E25, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an ASN.1 proof of submission value.
        /// </summary>
        public static PropertyTag PR_PROOF_OF_SUBMISSION
        {
            get { return new PropertyTag(0x0E26, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     The PR_ENTRYID property contains a MAPI entry identifier used to open and edit properties of a particular MAPI
        ///     object.
        /// </summary>
        public static PropertyTag PR_ENTRYID
        {
            get { return new PropertyTag(0x0FFF, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the type of an object
        /// </summary>
        public static PropertyTag PR_OBJECT_TYPE
        {
            get { return new PropertyTag(0x0FFE, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmap of a full size icon for a form.
        /// </summary>
        public static PropertyTag PR_ICON
        {
            get { return new PropertyTag(0x0FFD, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a bitmap of a half-size icon for a form.
        /// </summary>
        public static PropertyTag PR_MINI_ICON
        {
            get { return new PropertyTag(0x0FFC, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Specifies the hexadecimal string representation of the value of the PR_STORE_ENTRYID (PidTagStoreEntryId) property
        ///     on the shared folder. This is a property of a sharing message.
        /// </summary>
        public static PropertyTag PR_STORE_ENTRYID
        {
            get { return new PropertyTag(0x0FFB, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the unique binary-comparable identifier (record key) of the message store in which an object resides.
        /// </summary>
        public static PropertyTag PR_STORE_RECORD_KEY
        {
            get { return new PropertyTag(0x0FFA, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a unique binary-comparable identifier for a specific object.
        /// </summary>
        public static PropertyTag PR_RECORD_KEY
        {
            get { return new PropertyTag(0x0FF9, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the mapping signature for named properties of a particular MAPI object.
        /// </summary>
        public static PropertyTag PR_MAPPING_SIGNATURE
        {
            get { return new PropertyTag(0x0FF8, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Indicates the client's access level to the object.
        /// </summary>
        public static PropertyTag PR_ACCESS_LEVEL
        {
            get { return new PropertyTag(0x0FF7, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value that uniquely identifies a row in a table.
        /// </summary>
        public static PropertyTag PR_INSTANCE_KEY
        {
            get { return new PropertyTag(0x0FF6, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value that indicates the type of a row in a table.
        /// </summary>
        public static PropertyTag PR_ROW_TYPE
        {
            get { return new PropertyTag(0x0FF5, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating the operations that are available to the client for the object.
        /// </summary>
        public static PropertyTag PR_ACCESS
        {
            get { return new PropertyTag(0x0FF4, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a number that indicates which icon to use when you display a group of e-mail objects.
        /// </summary>
        /// <remarks>
        ///     This property, if it exists, is a hint to the client. The client may ignore the value of this property. 
        /// </remarks>
        public static PropertyTag PR_ICON_INDEX
        {
            get { return new PropertyTag(0x1080, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Specifies the last verb executed for the message item to which it is related.
        /// </summary>
        public static PropertyTag PR_LAST_VERB_EXECUTED
        {
            get { return new PropertyTag(0x1081, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the time when the last verb was executed.
        /// </summary>
        public static PropertyTag PR_LAST_VERB_EXECUTION_TIME
        {
            get { return new PropertyTag(0x1082, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a unique identifier for a recipient in a recipient table or status table.
        /// </summary>
        public static PropertyTag PR_ROWID
        {
            get { return new PropertyTag(0x3000, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the display name for a given MAPI object. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x3001, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the value of the <see cref="PR_DISPLAY_NAME_W"/> (PidTagDisplayName) property. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RECIPIENT_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x5FF6, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the value of the <see cref="PR_DISPLAY_NAME_W"/> (PidTagDisplayName) property. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RECIPIENT_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x5FF6, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Specifies a bit field that describes the recipient status.
        /// </summary>
        /// <remarks>
        ///     This property is not required. The following are the individual flags that can be set.
        /// </remarks>
        public static PropertyTag PR_RECIPIENT_FLAGS
        {
            get { return new PropertyTag(0x5FFD, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the display name for a given MAPI object. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x3001, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the messaging user's e-mail address type, such as SMTP. UNICODE compilation.
        /// </summary>
        /// <remarks>
        ///     These properties are examples of the base address properties common to all messaging users. 
        ///     It specifies which messaging system MAPI uses to handle a given message.
        ///     This property also determines the format of the address string in the PR_EMAIL_ADRESS(PidTagEmailAddress). 
        ///     The string it provides can contain only the uppercase alphabetic characters from A through Z and the numbers 
        ///     from 0 through 9.
        /// </remarks>
        public static PropertyTag PR_ADDRTYPE_W
        {
            get { return new PropertyTag(0x3002, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the messaging user's e-mail address type such as SMTP. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ADDRTYPE_A
        {
            get { return new PropertyTag(0x3002, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the messaging user's e-mail address. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_EMAIL_ADDRESS_W
        {
            get { return new PropertyTag(0x3003, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the messaging user's SMTP e-mail address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SMTP_ADDRESS_A
        {
            get { return new PropertyTag(0x39FE, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the messaging user's SMTP e-mail address. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_SMTP_ADDRESS_W
        {
            get { return new PropertyTag(0x39FE, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the messaging user's 7bit e-mail address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_7BIT_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x39FF, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the messaging user's SMTP e-mail address. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_7BIT_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x39FF, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the messaging user's e-mail address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_EMAIL_ADDRESS_A
        {
            get { return new PropertyTag(0x3003, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a comment about the purpose or content of an object. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_COMMENT_W
        {
            get { return new PropertyTag(0x3004, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a comment about the purpose or content of an object. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_COMMENT_A
        {
            get { return new PropertyTag(0x3004, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an integer that represents the relative level of indentation, or depth, of an object in a hierarchy table.
        /// </summary>
        public static PropertyTag PR_DEPTH
        {
            get { return new PropertyTag(0x3005, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the vendor-defined display name for a service provider. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PROVIDER_DISPLAY_W
        {
            get { return new PropertyTag(0x3006, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the vendor-defined display name for a service provider. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PROVIDER_DISPLAY_A
        {
            get { return new PropertyTag(0x3006, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the creation date and time of a message.
        /// </summary>
        public static PropertyTag PR_CREATION_TIME
        {
            get { return new PropertyTag(0x3007, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the date and time when the object or subobject was last modified.
        /// </summary>
        public static PropertyTag PR_LAST_MODIFICATION_TIME
        {
            get { return new PropertyTag(0x3008, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains a bitmask of flags for message services and providers.
        /// </summary>
        public static PropertyTag PR_RESOURCE_FLAGS
        {
            get { return new PropertyTag(0x3009, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the base file name of the MAPI service provider dynamic-link library (DLL). UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PROVIDER_DLL_NAME_W
        {
            get { return new PropertyTag(0x300A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the base file name of the MAPI service provider dynamic-link library (DLL). Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PROVIDER_DLL_NAME_A
        {
            get { return new PropertyTag(0x300A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a binary-comparable key that identifies correlated objects for a search.
        /// </summary>
        public static PropertyTag PR_SEARCH_KEY
        {
            get { return new PropertyTag(0x300B, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a MAPIUID structure of the service provider that is handling a message.
        /// </summary>
        public static PropertyTag PR_PROVIDER_UID
        {
            get { return new PropertyTag(0x300C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the zero-based index of a service provider's position in the provider table.
        /// </summary>
        public static PropertyTag PR_PROVIDER_ORDINAL
        {
            get { return new PropertyTag(0x300D, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the version of a form. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_FORM_VERSION_W
        {
            get { return new PropertyTag(0x3301, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the version of a form. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_FORM_VERSION_A
        {
            get { return new PropertyTag(0x3301, PropertyType.PT_STRING8); }
        }

        ///// <summary>
        /////     Contains the 128-bit Object Linking and Embedding (OLE) globally unique identifier (GUID) of a form.
        ///// </summary>
        //public static PropertyTag PR_FORM_CLSID
        //{
        //    get { return new PropertyTag(0x3302, PropertyType.PT_CLSID); }
        //}

        /// <summary>
        ///     Contains the name of a contact for information about a form. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_FORM_CONTACT_NAME_W
        {
            get { return new PropertyTag(0x3303, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of a contact for information about a form. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_FORM_CONTACT_NAME_A
        {
            get { return new PropertyTag(0x3303, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the category of a form. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_FORM_CATEGORY_W
        {
            get { return new PropertyTag(0x3304, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the category of a form. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_FORM_CATEGORY_A
        {
            get { return new PropertyTag(0x3304, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the subcategory of a form, as defined by a client application. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_FORM_CATEGORY_SUB_W
        {
            get { return new PropertyTag(0x3305, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the subcategory of a form, as defined by a client application. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_FORM_CATEGORY_SUB_A
        {
            get { return new PropertyTag(0x3305, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a host map of available forms.
        /// </summary>
        public static PropertyTag PR_FORM_HOST_MAP
        {
            get { return new PropertyTag(0x3306, PropertyType.PT_MV_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if a form is to be suppressed from display by compose menus and dialog boxes.
        /// </summary>
        public static PropertyTag PR_FORM_HIDDEN
        {
            get { return new PropertyTag(0x3307, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the display name for the object that is used to design the form. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_FORM_DESIGNER_NAME_W
        {
            get { return new PropertyTag(0x3308, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name for the object that is used to design the form. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_FORM_DESIGNER_NAME_A
        {
            get { return new PropertyTag(0x3308, PropertyType.PT_STRING8); }
        }

        ///// <summary>
        /////     Contains the unique identifier for the object that is used to design a form.
        ///// </summary>
        //public static PropertyTag PR_FORM_DESIGNER_GUID
        //{
        //    get { return new PropertyTag(0x3309, PropertyType.PT_CLSID); }
        //}

        /// <summary>
        ///     Contains TRUE if a message should be composed in the current folder.
        /// </summary>
        public static PropertyTag PR_FORM_MESSAGE_BEHAVIOR
        {
            get { return new PropertyTag(0x330A, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains TRUE if a message store is the default message store in the message store table.
        /// </summary>
        public static PropertyTag PR_DEFAULT_STORE
        {
            get { return new PropertyTag(0x3400, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a bitmask of flags that client applications query to determine the characteristics of a message store.
        /// </summary>
        public static PropertyTag PR_STORE_SUPPORT_MASK
        {
            get { return new PropertyTag(0x340D, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a flag that describes the state of the message store.
        /// </summary>
        public static PropertyTag PR_STORE_STATE
        {
            get { return new PropertyTag(0x340E, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmask of flags that client applications should query to determine the characteristics of a message store.
        /// </summary>
        public static PropertyTag PR_STORE_UNICODE_MASK
        {
            get { return new PropertyTag(0x340F, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Was originally meant to contain the search key of the interpersonal message (IPM) root folder. No longer supported
        /// </summary>
        public static PropertyTag PR_IPM_SUBTREE_SEARCH_KEY
        {
            get { return new PropertyTag(0x3410, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Was originally meant to contain the search key of the standard Outbox folder. No longer supported.
        /// </summary>
        public static PropertyTag PR_IPM_OUTBOX_SEARCH_KEY
        {
            get { return new PropertyTag(0x3411, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Was originally meant to contain the search key of the standard Deleted Items folder. No longer supported.
        /// </summary>
        public static PropertyTag PR_IPM_WASTEBASKET_SEARCH_KEY
        {
            get { return new PropertyTag(0x3412, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Was originally meant to contain the search key of the standard Sent Items folder. No longer supported.
        /// </summary>
        public static PropertyTag PR_IPM_SENTMAIL_SEARCH_KEY
        {
            get { return new PropertyTag(0x3413, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a provider-defined MAPIUID structure that indicates the type of the message store.
        /// </summary>
        public static PropertyTag PR_MDB_PROVIDER
        {
            get { return new PropertyTag(0x3414, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a table of a message store's receive folder settings.
        /// </summary>
        public static PropertyTag PR_RECEIVE_FOLDER_SETTINGS
        {
            get { return new PropertyTag(0x3415, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains a bitmask of flags that indicate the validity of the entry identifiers of the folders in a message store.
        /// </summary>
        public static PropertyTag PR_VALID_FOLDER_MASK
        {
            get { return new PropertyTag(0x35DF, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the entry identifier of the root of the IPM folder subtree in the message store's folder tree.
        /// </summary>
        public static PropertyTag PR_IPM_SUBTREE_ENTRYID
        {
            get { return new PropertyTag(0x35E0, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the standard interpersonal message (IPM) Outbox folder.
        /// </summary>
        public static PropertyTag PR_IPM_OUTBOX_ENTRYID
        {
            get { return new PropertyTag(0x35E2, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the standard IPM Deleted Items folder.
        /// </summary>
        public static PropertyTag PR_IPM_WASTEBASKET_ENTRYID
        {
            get { return new PropertyTag(0x35E3, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the standard IPM Sent Items folder.
        /// </summary>
        public static PropertyTag PR_IPM_SENTMAIL_ENTRYID
        {
            get { return new PropertyTag(0x35E4, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the user-defined Views folder.
        /// </summary>
        public static PropertyTag PR_VIEWS_ENTRYID
        {
            get { return new PropertyTag(0x35E5, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the predefined common view folder.
        /// </summary>
        public static PropertyTag PR_COMMON_VIEWS_ENTRYID
        {
            get { return new PropertyTag(0x35E6, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier for the folder in which search results are typically created.
        /// </summary>
        public static PropertyTag PR_FINDER_ENTRYID
        {
            get { return new PropertyTag(0x35E7, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     When TRUE, forces the serialization of SMTP and POP3 authentication requests such that the POP3 account is
        ///     authenticated before the SMTP account.
        /// </summary>
        public static PropertyTag PR_CE_RECEIVE_BEFORE_SEND
        {
            get { return new PropertyTag(0x812D, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a bitmask of flags describing capabilities of an address book container.
        /// </summary>
        public static PropertyTag PR_CONTAINER_FLAGS
        {
            get { return new PropertyTag(0x3600, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a constant that indicates the folder type.
        /// </summary>
        public static PropertyTag PR_FOLDER_TYPE
        {
            get { return new PropertyTag(0x3601, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the number of messages in a folder, as computed by the message store.
        /// </summary>
        public static PropertyTag PR_CONTENT_COUNT
        {
            get { return new PropertyTag(0x3602, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the number of unread messages in a folder, as computed by the message store.
        /// </summary>
        public static PropertyTag PR_CONTENT_UNREAD
        {
            get { return new PropertyTag(0x3603, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains an embedded table object that contains dialog box template entry identifiers.
        /// </summary>
        public static PropertyTag PR_CREATE_TEMPLATES
        {
            get { return new PropertyTag(0x3604, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains an embedded display table object.
        /// </summary>
        public static PropertyTag PR_DETAILS_TABLE
        {
            get { return new PropertyTag(0x3605, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains a container object that is used for advanced searches.
        /// </summary>
        public static PropertyTag PR_SEARCH
        {
            get { return new PropertyTag(0x3607, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains TRUE if the entry in the one-off table can be selected.
        /// </summary>
        public static PropertyTag PR_SELECTABLE
        {
            get { return new PropertyTag(0x3609, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains TRUE if a folder contains subfolders.
        /// </summary>
        public static PropertyTag PR_SUBFOLDERS
        {
            get { return new PropertyTag(0x360A, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a 32-bit bitmask of flags that define folder status.
        /// </summary>
        public static PropertyTag PR_STATUS
        {
            get { return new PropertyTag(0x360B, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a string value for use in a property restriction on an address book container contents table. UNICODE
        ///     compilation
        /// </summary>
        public static PropertyTag PR_ANR_W
        {
            get { return new PropertyTag(0x360C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a string value for use in a property restriction on an address book container contents table. Non-UNICODE
        ///     compilation
        /// </summary>
        internal static PropertyTag PR_ANR_A
        {
            get { return new PropertyTag(0x360C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     No longer supported
        /// </summary>
        public static PropertyTag PR_CONTENTS_SORT_ORDER
        {
            get { return new PropertyTag(0x360D, PropertyType.PT_MV_LONG); }
        }

        /// <summary>
        ///     Contains an embedded hierarchy table object that provides information about the child containers.
        /// </summary>
        public static PropertyTag PR_CONTAINER_HIERARCHY
        {
            get { return new PropertyTag(0x360E, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains an embedded contents table object that provides information about a container.
        /// </summary>
        public static PropertyTag PR_CONTAINER_CONTENTS
        {
            get { return new PropertyTag(0x360F, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains an embedded contents table object that provides information about a container.
        /// </summary>
        public static PropertyTag PR_FOLDER_ASSOCIATED_CONTENTS
        {
            get { return new PropertyTag(0x3610, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains the template entry identifier for a default distribution list.
        /// </summary>
        public static PropertyTag PR_DEF_CREATE_DL
        {
            get { return new PropertyTag(0x3611, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the template entry identifier for a default messaging user object.
        /// </summary>
        public static PropertyTag PR_DEF_CREATE_MAILUSER
        {
            get { return new PropertyTag(0x3612, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a text string describing the type of a folder. Although this property is generally ignored, versions of
        ///     Microsoft® Exchange Server prior to Exchange Server 2003 Mailbox Manager expect this property to be present.
        ///     UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_CONTAINER_CLASS_W
        {
            get { return new PropertyTag(0x3613, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a text string describing the type of a folder. Although this property is generally ignored, versions of
        ///     Microsoft® Exchange Server prior to Exchange Server 2003 Mailbox Manager expect this property to be present.
        ///     Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_CONTAINER_CLASS_A
        {
            get { return new PropertyTag(0x3613, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Unknown
        /// </summary>
        public static PropertyTag PR_CONTAINER_MODIFY_VERSION
        {
            get { return new PropertyTag(0x3614, PropertyType.PT_I8); }
        }

        /// <summary>
        ///     Contains an address book provider's MAPIUID structure.
        /// </summary>
        public static PropertyTag PR_AB_PROVIDER_ID
        {
            get { return new PropertyTag(0x3615, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of a folder's default view.
        /// </summary>
        public static PropertyTag PR_DEFAULT_VIEW_ENTRYID
        {
            get { return new PropertyTag(0x3616, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the count of items in the associated contents table of the folder.
        /// </summary>
        public static PropertyTag PR_ASSOC_CONTENT_COUNT
        {
            get { return new PropertyTag(0x3617, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     was originally meant to contain an ASN.1 object identifier specifying how the attachment should be handled during
        ///     transmission. No longer supported.
        /// </summary>
        public static PropertyTag PR_ATTACHMENT_X400_PARAMETERS
        {
            get { return new PropertyTag(0x3700, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the content identification header of a MIME message attachment. This property is used for MHTML support.
        ///     It represents the content identification header for the appropriate MIME body part. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_CONTENT_ID_W
        {
            get { return new PropertyTag(0x3712, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the content identification header of a MIME message attachment. This property is used for MHTML support.
        ///     It represents the content identification header for the appropriate MIME body part. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_CONTENT_ID_A
        {
            get { return new PropertyTag(0x3712, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the content location header of a MIME message attachment. This property is used for MHTML support. It
        ///     represents the content location header for the appropriate MIME body part. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_CONTENT_LOCATION_W
        {
            get { return new PropertyTag(0x3713, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the content location header of a MIME message attachment. This property is used for MHTML support. It
        ///     represents the content location header for the appropriate MIME body part. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_CONTENT_LOCATION_A
        {
            get { return new PropertyTag(0x3713, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an attachment object typically accessed through the OLE IStorage:IUnknown interface.
        /// </summary>
        public static PropertyTag PR_ATTACH_DATA_OBJ
        {
            get { return new PropertyTag(0x3701, PropertyType.PT_OBJECT); }
        }

        /// <summary>
        ///     Contains binary attachment data typically accessed through the COM IStream:IUnknown interface.
        /// </summary>
        public static PropertyTag PR_ATTACH_DATA_BIN
        {
            get { return new PropertyTag(0x3701, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an ASN.1 object identifier specifying the encoding for an attachment.
        /// </summary>
        public static PropertyTag PR_ATTACH_ENCODING
        {
            get { return new PropertyTag(0x3702, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a filename extension that indicates the document type of an attachment. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_EXTENSION_W
        {
            get { return new PropertyTag(0x3703, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a filename extension that indicates the document type of an attachment. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_EXTENSION_A
        {
            get { return new PropertyTag(0x3703, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an attachment's base filename and extension, excluding path. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_FILENAME_W
        {
            get { return new PropertyTag(0x3704, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an attachment's base filename and extension, excluding path. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_FILENAME_A
        {
            get { return new PropertyTag(0x3704, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a MAPI-defined constant representing the way the contents of an attachment can be accessed.
        /// </summary>
        public static PropertyTag PR_ATTACH_METHOD
        {
            get { return new PropertyTag(0x3705, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains an attachment's long filename and extension, excluding path. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_LONG_FILENAME_W
        {
            get { return new PropertyTag(0x3707, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an attachment's long filename and extension, excluding path. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_LONG_FILENAME_A
        {
            get { return new PropertyTag(0x3707, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an attachment's fully qualified path and filename. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_PATHNAME_W
        {
            get { return new PropertyTag(0x3708, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an attachment's fully qualified path and filename. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_PATHNAME_A
        {
            get { return new PropertyTag(0x3708, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a Microsoft Windows metafile with rendering information for an attachment.
        /// </summary>
        public static PropertyTag PR_ATTACH_RENDERING
        {
            get { return new PropertyTag(0x3709, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an ASN.1 object identifier specifying the application that supplied an attachment.
        /// </summary>
        public static PropertyTag PR_ATTACH_TAG
        {
            get { return new PropertyTag(0x370A, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains an offset, in characters, to use in rendering an attachment within the main message text.
        /// </summary>
        public static PropertyTag PR_RENDERING_POSITION
        {
            get { return new PropertyTag(0x370B, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the name of an attachment file modified so that it can be correlated with TNEF messages. UNICODE
        ///     compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_TRANSPORT_NAME_W
        {
            get { return new PropertyTag(0x370C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of an attachment file modified so that it can be correlated with TNEF messages. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_TRANSPORT_NAME_A
        {
            get { return new PropertyTag(0x370C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an attachment's fully qualified long path and filename. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_LONG_PATHNAME_W
        {
            get { return new PropertyTag(0x370D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an attachment's fully qualified long path and filename. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_LONG_PATHNAME_A
        {
            get { return new PropertyTag(0x370D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains formatting information about a Multipurpose Internet Mail Extensions (MIME) attachment. UNICODE
        ///     compilation.
        /// </summary>
        public static PropertyTag PR_ATTACH_MIME_TAG_W
        {
            get { return new PropertyTag(0x370E, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains formatting information about a Multipurpose Internet Mail Extensions (MIME) attachment. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_ATTACH_MIME_TAG_A
        {
            get { return new PropertyTag(0x370E, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Provides file type information for a non-Windows attachment.
        /// </summary>
        public static PropertyTag PR_ATTACH_ADDITIONAL_INFO
        {
            get { return new PropertyTag(0x370F, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value used to associate an icon with a particular row of a table.
        /// </summary>
        public static PropertyTag PR_DISPLAY_TYPE
        {
            get { return new PropertyTag(0x3900, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the PR_ENTRYID (PidTagEntryId), expressed as a permanent entry ID format.
        /// </summary>
        public static PropertyTag PR_TEMPLATEID
        {
            get { return new PropertyTag(0x3902, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     These properties appear on address book objects. Obsolete.
        /// </summary>
        public static PropertyTag PR_PRIMARY_CAPABILITY
        {
            get { return new PropertyTag(0x3904, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the type of an entry, with respect to how the entry should be displayed in a row in a table for the Global
        ///     Address List.
        /// </summary>
        public static PropertyTag PR_DISPLAY_TYPE_EX
        {
            get { return new PropertyTag(0x3905, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the recipient's account name. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ACCOUNT_W
        {
            get { return new PropertyTag(0x3A00, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's account name. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ACCOUNT_A
        {
            get { return new PropertyTag(0x3A00, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a list of entry identifiers for alternate recipients designated by the original recipient.
        /// </summary>
        public static PropertyTag PR_ALTERNATE_RECIPIENT
        {
            get { return new PropertyTag(0x3A01, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a telephone number that the message recipient can use to reach the sender. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_CALLBACK_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A02, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a telephone number that the message recipient can use to reach the sender. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_CALLBACK_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A02, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if message conversions are prohibited by default for the associated messaging user.
        /// </summary>
        public static PropertyTag PR_CONVERSION_PROHIBITED
        {
            get { return new PropertyTag(0x3A03, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     The DiscloseRecipients field represents a PR_DISCLOSE_RECIPIENTS MAPI property.
        /// </summary>
        public static PropertyTag PR_DISCLOSE_RECIPIENTS
        {
            get { return new PropertyTag(0x3A04, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a generational abbreviation that follows the full name of the recipient. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_GENERATION_W
        {
            get { return new PropertyTag(0x3A05, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a generational abbreviation that follows the full name of the recipient. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_GENERATION_A
        {
            get { return new PropertyTag(0x3A05, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the first or given name of the recipient. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_GIVEN_NAME_W
        {
            get { return new PropertyTag(0x3A06, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the first or given name of the recipient. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_GIVEN_NAME_A
        {
            get { return new PropertyTag(0x3A06, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a government identifier for the recipient. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_GOVERNMENT_ID_NUMBER_W
        {
            get { return new PropertyTag(0x3A07, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a government identifier for the recipient. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_GOVERNMENT_ID_NUMBER_A
        {
            get { return new PropertyTag(0x3A07, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the primary telephone number of the recipient's place of business. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A08, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the primary telephone number of the recipient's place of business. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A08, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the primary telephone number of the recipient's home. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_HOME_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A09, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the primary telephone number of the recipient's home. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A09, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the initials for parts of the full name of the recipient. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_INITIALS_W
        {
            get { return new PropertyTag(0x3A0A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the initials for parts of the full name of the recipient. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_INITIALS_A
        {
            get { return new PropertyTag(0x3A0A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a keyword that identifies the recipient to the recipient's system administrator. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_KEYWORD_W
        {
            get { return new PropertyTag(0x3A0B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a keyword that identifies the recipient to the recipient's system administrator. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_KEYWORD_A
        {
            get { return new PropertyTag(0x3A0B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a value that indicates the language in which the messaging user is writing messages. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_LANGUAGE_W
        {
            get { return new PropertyTag(0x3A0C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a value that indicates the language in which the messaging user is writing messages. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_LANGUAGE_A
        {
            get { return new PropertyTag(0x3A0C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the location of the recipient in a format that is useful to the recipient's organization. UNICODE
        ///     compilation.
        /// </summary>
        public static PropertyTag PR_LOCATION_W
        {
            get { return new PropertyTag(0x3A0D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the location of the recipient in a format that is useful to the recipient's organization. Non-UNICODE
        ///     compilation.
        /// </summary>
        internal static PropertyTag PR_LOCATION_A
        {
            get { return new PropertyTag(0x3A0D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if the messaging user is allowed to send and receive messages.
        /// </summary>
        public static PropertyTag PR_MAIL_PERMISSION
        {
            get { return new PropertyTag(0x3A0E, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the common name of the message handling system. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_MHS_COMMON_NAME_W
        {
            get { return new PropertyTag(0x3A0F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the common name of the message handling system. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_MHS_COMMON_NAME_A
        {
            get { return new PropertyTag(0x3A0F, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an organizational ID number for the contact, such as an employee ID number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORGANIZATIONAL_ID_NUMBER_W
        {
            get { return new PropertyTag(0x3A10, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an organizational ID number for the contact, such as an employee ID number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORGANIZATIONAL_ID_NUMBER_A
        {
            get { return new PropertyTag(0x3A10, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the last or surname of the recipient. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_SURNAME_W
        {
            get { return new PropertyTag(0x3A11, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the last or surname of the recipient. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_SURNAME_A
        {
            get { return new PropertyTag(0x3A11, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the original entry identifier for an entry copied from an address book to a personal address book or other
        ///     writeable address book.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_ENTRYID
        {
            get { return new PropertyTag(0x3A12, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the original display name for an entry copied from an address book to a personal address book or other
        ///     writable address book. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x3A13, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the original display name for an entry copied from an address book to a personal address book or other
        ///     writable address book. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ORIGINAL_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x3A13, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the original search key for an entry copied from an address book to a personal address book or other
        ///     writeable address book.
        /// </summary>
        public static PropertyTag PR_ORIGINAL_SEARCH_KEY
        {
            get { return new PropertyTag(0x3A14, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the recipient's postal address. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_POSTAL_ADDRESS_W
        {
            get { return new PropertyTag(0x3A15, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's postal address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_POSTAL_ADDRESS_A
        {
            get { return new PropertyTag(0x3A15, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's home page. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_HOME_PAGE_W
        {
            get { return new PropertyTag(0x3A51, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's home page. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_HOME_PAGE_A
        {
            get { return new PropertyTag(0x3A51, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's company name. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_COMPANY_NAME_W
        {
            get { return new PropertyTag(0x3A16, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the telephone number for the contact's text telephone (TTY) or telecommunication device for the deaf (TDD). UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TTYTDD_PHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A4B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the telephone number for the contact's text telephone (TTY) or telecommunication device for the deaf (TDD). Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TTYTDD_PHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A4B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's companys main phone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_COMPANY_MAIN_PHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A57, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's companys main phone number. NON-UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_COMPANY_MAIN_PHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A57, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a list of names of children. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_CHILDRENS_NAMES_W
        {
            get { return new PropertyTag(0x3A58, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a list of names of children. NON-UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_CHILDRENS_NAMES_A
        {
            get { return new PropertyTag(0x3A58, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's city address. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_CITY_A
        {
            get { return new PropertyTag(0x3A59, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's city address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_CITY_W
        {
            get { return new PropertyTag(0x3A59, PropertyType.PT_UNICODE); }
        }
        
        /// <summary>
        ///     Contains the recipient's city address. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_COUNTRY_A
        {
            get { return new PropertyTag(0x3A5A, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's country address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_COUNTRY_W
        {
            get { return new PropertyTag(0x3A5A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's country address. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_STREET_A
        {
            get { return new PropertyTag(0x3A5D, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's street address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_STREET_W
        {
            get { return new PropertyTag(0x3A5D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's city address. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_POSTAL_CODE_A
        {
            get { return new PropertyTag(0x3A5B, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's city address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_POSTAL_CODE_W
        {
            get { return new PropertyTag(0x3A5B, PropertyType.PT_UNICODE); }
        }
        
        /// <summary>
        ///     Contains the recipient's city address. UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_STATE_OR_PROVINCE_A
        {
            get { return new PropertyTag(0x3A5C, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's city address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_ADDRESS_STATE_OR_PROVINCE_W
        {
            get { return new PropertyTag(0x3A5C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's company name. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_COMPANY_NAME_A
        {
            get { return new PropertyTag(0x3A16, PropertyType.PT_STRING8); }
        }
       
        /// <summary>
        ///     Contains the recipient's job title. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_TITLE_W
        {
            get { return new PropertyTag(0x3A17, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's job title. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TITLE_A
        {
            get { return new PropertyTag(0x3A17, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a name for the department in which the recipient works. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_DEPARTMENT_NAME_W
        {
            get { return new PropertyTag(0x3A18, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a name for the department in which the recipient works. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_DEPARTMENT_NAME_A
        {
            get { return new PropertyTag(0x3A18, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's office location. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OFFICE_LOCATION_W
        {
            get { return new PropertyTag(0x3A19, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's office location. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OFFICE_LOCATION_A
        {
            get { return new PropertyTag(0x3A19, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's primary telephone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PRIMARY_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's primary telephone number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PRIMARY_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a secondary telephone number at the recipient's place of business. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS2_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a secondary telephone number at the recipient's place of business. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS2_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's cellular telephone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_MOBILE_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's cellular telephone number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_MOBILE_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's radio telephone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RADIO_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's radio telephone number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_RADIO_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's other street. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OTHER_ADDRESS_STREET_W
        {
            get { return new PropertyTag(0x3A63, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's other street. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OTHER_ADDRESS_STREET_A
        {
            get { return new PropertyTag(0x3A63, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's other postal code. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OTHER_ADDRESS_POSTAL_CODE_W
        {
            get { return new PropertyTag(0x3A61, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's other postal code. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OTHER_ADDRESS_POSTAL_CODE_A
        {
            get { return new PropertyTag(0x3A61, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's other city. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OTHER_ADDRESS_CITY_W
        {
            get { return new PropertyTag(0x3A5F, PropertyType.PT_UNICODE); }
        }
        
        /// <summary>
        ///     Contains the recipient's other city. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OTHER_ADDRESS_CITY_A
        {
            get { return new PropertyTag(0x3A5F, PropertyType.PT_STRING8); }
        }
        
        /// <summary>
        ///     Contains the recipient's other country. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OTHER_ADDRESS_COUNTRY_W
        {
            get { return new PropertyTag(0x3A60, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's other country. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OTHER_ADDRESS_COUNTRY_A
        {
            get { return new PropertyTag(0x3A60, PropertyType.PT_STRING8); }
        }
       
                
        /// <summary>
        ///     Contains the recipient's other state or provence. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OTHER_ADDRESS_STATE_OR_PROVINCE_W
        {
            get { return new PropertyTag(0x3A62, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's other state or provence. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OTHER_ADDRESS_STATE_OR_PROVINCE_A
        {
            get { return new PropertyTag(0x3A62, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's car telephone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_CAR_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1E, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's car telephone number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_CAR_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1E, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an alternate telephone number for the recipient. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_OTHER_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A1F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains an alternate telephone number for the recipient. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_OTHER_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A1F, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a recipient's display name in a secure form that cannot be changed. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_TRANSMITABLE_DISPLAY_NAME_W
        {
            get { return new PropertyTag(0x3A20, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a recipient's display name in a secure form that cannot be changed. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TRANSMITABLE_DISPLAY_NAME_A
        {
            get { return new PropertyTag(0x3A20, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's pager telephone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PAGER_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A21, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's pager telephone number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PAGER_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A21, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains an ASN.1 authentication certificate for a messaging user.
        /// </summary>
        public static PropertyTag PR_USER_CERTIFICATE
        {
            get { return new PropertyTag(0x3A22, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's primary fax machine. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PRIMARY_FAX_NUMBER_W
        {
            get { return new PropertyTag(0x3A23, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's primary fax machine. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PRIMARY_FAX_NUMBER_A
        {
            get { return new PropertyTag(0x3A23, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's business fax machine. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_FAX_NUMBER_W
        {
            get { return new PropertyTag(0x3A24, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's business fax machine. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_FAX_NUMBER_A
        {
            get { return new PropertyTag(0x3A24, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's home fax machine. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_HOME_FAX_NUMBER_W
        {
            get { return new PropertyTag(0x3A25, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's home fax machine. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME_FAX_NUMBER_A
        {
            get { return new PropertyTag(0x3A25, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the name of the recipient's country/region. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_ADDRESS_COUNTRY_W
        {
            get { return new PropertyTag(0x3A26, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of the recipient's country/region. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_ADDRESS_COUNTRY_A
        {
            get { return new PropertyTag(0x3A26, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the name of the recipient's locality, such as the town or city. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_ADDRESS_CITY_W
        {
            get { return new PropertyTag(0x3A27, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of the recipient's locality, such as the town or city. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_ADDRESS_CITY_A
        {
            get { return new PropertyTag(0x3A27, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the name of the recipient's state or province. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_ADDRESS_STATE_OR_PROVINCE_W
        {
            get { return new PropertyTag(0x3A28, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of the recipient's state or province. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_ADDRESS_STATE_OR_PROVINCE_A
        {
            get { return new PropertyTag(0x3A28, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's street address. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_ADDRESS_STREET_W
        {
            get { return new PropertyTag(0x3A29, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's street address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_ADDRESS_STREET_A
        {
            get { return new PropertyTag(0x3A29, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the postal code for the recipient's postal address. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_BUSINESS_ADDRESS_POSTAL_CODE_W
        {
            get { return new PropertyTag(0x3A2A, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the postal code for the recipient's postal address. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_BUSINESS_ADDRESS_POSTAL_CODE_A
        {
            get { return new PropertyTag(0x3A2A, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the number or identifier of the recipient's post office box. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_POST_OFFICE_BOX_W
        {
            get { return new PropertyTag(0x3A2B, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the number or identifier of the recipient's post office box. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_POST_OFFICE_BOX_A
        {
            get { return new PropertyTag(0x3A2B, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's telex number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_TELEX_NUMBER_W
        {
            get { return new PropertyTag(0x3A2C, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's telex number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_TELEX_NUMBER_A
        {
            get { return new PropertyTag(0x3A2C, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the recipient's ISDN-capable telephone number. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ISDN_NUMBER_W
        {
            get { return new PropertyTag(0x3A2D, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the recipient's ISDN-capable telephone number. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ISDN_NUMBER_A
        {
            get { return new PropertyTag(0x3A2D, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's administrative assistant. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ASSISTANT_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A2E, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the telephone number of the recipient's administrative assistant. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ASSISTANT_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A2E, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a secondary telephone number at the recipient's home. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_HOME2_TELEPHONE_NUMBER_W
        {
            get { return new PropertyTag(0x3A2F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains a secondary telephone number at the recipient's home. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_HOME2_TELEPHONE_NUMBER_A
        {
            get { return new PropertyTag(0x3A2F, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the name of the recipient's administrative assistant. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_ASSISTANT_W
        {
            get { return new PropertyTag(0x3A30, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of the recipient's administrative assistant. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_ASSISTANT_A
        {
            get { return new PropertyTag(0x3A30, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains TRUE if the recipient can receive all message content, including Rich Text Format (RTF) and Object Linking
        ///     and Embedding (OLE) objects.
        /// </summary>
        public static PropertyTag PR_SEND_RICH_INFO
        {
            get { return new PropertyTag(0x3A40, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains the date of a user's wedding anniversary
        /// </summary>
        public static PropertyTag PR_WEDDING_ANNIVERSARY
        {
            get { return new PropertyTag(0x3A41, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the birtday of the contact
        /// </summary>
        public static PropertyTag PR_BIRTHDAY
        {
            get { return new PropertyTag(0x3A42, PropertyType.PT_SYSTIME); }
        }

        /// <summary>
        ///     Contains the middle name of a contact. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_MIDDLE_NAME_W
        {
            get { return new PropertyTag(0x3A44, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the middle name of a contact. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_MIDDLE_NAME_A
        {
            get { return new PropertyTag(0x3A44, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the profession of the user.
        /// </summary>
        public static PropertyTag PR_PROFESSION_W
        {
            get { return new PropertyTag(0x3A46, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the profession of the user.
        /// </summary>
        internal static PropertyTag PR_PROFESSION_A
        {
            get { return new PropertyTag(0x3A46, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the user's spouse name
        /// </summary>
        public static PropertyTag PR_SPOUSE_NAME_W
        {
            get { return new PropertyTag(0x3A48, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the user's spouse name
        /// </summary>
        internal static PropertyTag PR_SPOUSE_NAME_A
        {
            get { return new PropertyTag(0x3A48, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the name of the recipient's manager. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_MANAGER_NAME_W
        {
            get { return new PropertyTag(0x3A4E, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the name of the recipient's manager. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_MANAGER_NAME_A
        {
            get { return new PropertyTag(0x3A4E, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the nickname of the contact. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_NICKNAME_W
        {
            get { return new PropertyTag(0x3A4F, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the nickname of the contact. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_NICKNAME_A
        {
            get { return new PropertyTag(0x3A4F, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains the URL of a user's personal home page. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_PERSONAL_HOME_PAGE_W
        {
            get { return new PropertyTag(0x3A50, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///    Contains the URL of a user's personal home page. Non-UNICODE compilation.
        /// </summary>
        internal static PropertyTag PR_PERSONAL_HOME_PAGE_A
        {
            get { return new PropertyTag(0x3A50, PropertyType.PT_STRING8); }
        }

        /// <summary>
        ///     Contains a list of identifiers of message store providers in the current profile.
        /// </summary>
        public static PropertyTag PR_STORE_PROVIDERS
        {
            get { return new PropertyTag(0x3D00, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of identifiers for address book providers in the current profile.
        /// </summary>
        public static PropertyTag PR_AB_PROVIDERS
        {
            get { return new PropertyTag(0x3D01, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of identifiers of transport providers in the current profile.
        /// </summary>
        public static PropertyTag PR_TRANSPORT_PROVIDERS
        {
            get { return new PropertyTag(0x3D02, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains TRUE if a messaging user profile is the MAPI default profile.
        /// </summary>
        public static PropertyTag PR_DEFAULT_PROFILE
        {
            get { return new PropertyTag(0x3D04, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a list of entry identifiers for address book containers that are to be searched to resolve names.
        /// </summary>
        public static PropertyTag PR_AB_SEARCH_PATH
        {
            get { return new PropertyTag(0x3D05, PropertyType.PT_MV_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the address book container to display first.
        /// </summary>
        public static PropertyTag PR_AB_DEFAULT_DIR
        {
            get { return new PropertyTag(0x3D06, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of the address book container to use as the personal address book (PAB).
        /// </summary>
        public static PropertyTag PR_AB_DEFAULT_PAB
        {
            get { return new PropertyTag(0x3D07, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     The MAPI property PR_FILTERING_HOOKS.
        /// </summary>
        public static PropertyTag PR_FILTERING_HOOKS
        {
            get { return new PropertyTag(0x3D08, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the unicode name of a message service as set by the user in the MapiSvc.inf file.
        /// </summary>
        public static PropertyTag PR_SERVICE_NAME_W
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
        public static PropertyTag PR_SERVICE_DLL_NAME_W
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
        public static PropertyTag PR_SERVICE_UID
        {
            get { return new PropertyTag(0x3D0C, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of MAPIUID structures that identify additional profile sections for the message service.
        /// </summary>
        public static PropertyTag PR_SERVICE_EXTRA_UIDS
        {
            get { return new PropertyTag(0x3D0D, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a list of identifiers of message services in the current profile.
        /// </summary>
        public static PropertyTag PR_SERVICES
        {
            get { return new PropertyTag(0x3D0E, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a ANSI list of the files that belong to the message service.
        /// </summary>
        public static PropertyTag PR_SERVICE_SUPPORT_FILES_W
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
        public static PropertyTag PR_SERVICE_DELETE_FILES_W
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
        public static PropertyTag PR_AB_SEARCH_PATH_UPDATE
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
        public static PropertyTag PR_PROFILE_NAME_W
        {
            get { return new PropertyTag(0x3D12, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Contains the display name for a service provider's identity as defined within a messaging system. UNICODE
        ///     compilation.
        /// </summary>
        public static PropertyTag PR_IDENTITY_DISPLAY_W
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
        public static PropertyTag PR_IDENTITY_ENTRYID
        {
            get { return new PropertyTag(0x3E01, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating the methods in the IMAPIStatus interface that are supported by the status
        ///     object.
        /// </summary>
        public static PropertyTag PR_RESOURCE_METHODS
        {
            get { return new PropertyTag(0x3E02, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a value indicating the service provider type.
        /// </summary>
        public static PropertyTag PR_RESOURCE_TYPE
        {
            get { return new PropertyTag(0x3E03, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a bitmask of flags indicating the current status of a session resource. All service providers set status
        ///     codes as does MAPI to report on the status of the subsystem, the MAPI spooler, and the integrated address book.
        /// </summary>
        public static PropertyTag PR_STATUS_CODE
        {
            get { return new PropertyTag(0x3E04, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the search key for a service provider's identity as defined within a messaging system.
        /// </summary>
        public static PropertyTag PR_IDENTITY_SEARCH_KEY
        {
            get { return new PropertyTag(0x3E05, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains the entry identifier of a transport's tightly coupled message store.
        /// </summary>
        public static PropertyTag PR_OWN_STORE_ENTRYID
        {
            get { return new PropertyTag(0x3E06, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a path to the service provider's server. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_RESOURCE_PATH_W
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
        public static PropertyTag PR_STATUS_STRING_W
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
        public static PropertyTag PR_X400_DEFERRED_DELIVERY_CANCEL
        {
            get { return new PropertyTag(0x3E09, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Was originally meant to contain the entry identifier that a remote transport provider furnishes for its header
        ///     folder. No longer supported.
        /// </summary>
        public static PropertyTag PR_HEADER_FOLDER_ENTRYID
        {
            get { return new PropertyTag(0x3E0A, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a number indicating the status of a remote transfer.
        /// </summary>
        public static PropertyTag PR_REMOTE_PROGRESS
        {
            get { return new PropertyTag(0x3E0B, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains an ASCII string indicating the status of a remote transfer. UNICODE compilation.
        /// </summary>
        public static PropertyTag PR_REMOTE_PROGRESS_TEXT_W
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
        public static PropertyTag PR_REMOTE_VALIDATE_OK
        {
            get { return new PropertyTag(0x3E0D, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Contains a bitmask of flags governing the behavior of a control used in a dialog box built from a display table.
        /// </summary>
        public static PropertyTag PR_CONTROL_FLAGS
        {
            get { return new PropertyTag(0x3F00, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a pointer to a structure for a control used in a dialog box.
        /// </summary>
        public static PropertyTag PR_CONTROL_STRUCTURE
        {
            get { return new PropertyTag(0x3F01, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Contains a value indicating a control type for a control used in a dialog box.
        /// </summary>
        public static PropertyTag PR_CONTROL_TYPE
        {
            get { return new PropertyTag(0x3F02, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the width of a dialog box control in standard Windows dialog units.
        /// </summary>
        public static PropertyTag PR_DELTAX
        {
            get { return new PropertyTag(0x3F03, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the height of a dialog box control in standard Windows dialog units.
        /// </summary>
        public static PropertyTag PR_DELTAY
        {
            get { return new PropertyTag(0x3F04, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the x coordinate of the starting position (the upper-left corner) of a dialog box control, in standard
        ///     Windows dialog units.
        /// </summary>
        public static PropertyTag PR_XPOS
        {
            get { return new PropertyTag(0x3F05, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the y coordinate of the starting position (the upper-left corner) of a dialog box control, in standard
        ///     Windows dialog units.
        /// </summary>
        public static PropertyTag PR_YPOS
        {
            get { return new PropertyTag(0x3F06, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains a unique identifier for a control used in a dialog box.
        /// </summary>
        public static PropertyTag PR_CONTROL_ID
        {
            get { return new PropertyTag(0x3F07, PropertyType.PT_BINARY); }
        }

        /// <summary>
        ///     Indicates the page of a display template to display first.
        /// </summary>
        public static PropertyTag PR_INITIAL_DETAILS_PANE
        {
            get { return new PropertyTag(0x3F08, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Contains the Windows LCID of the end user who created this message.
        /// </summary>
        public static PropertyTag PR_MESSAGE_LOCALE_ID
        {
            get { return new PropertyTag(0x3F08, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the code page used for <see cref="PropertyTags.PR_BODY_W" /> (PidTagBody) or 
        ///     <see cref="PropertyTags.PR_HTML" /> (PidTagBodyHtml) properties.
        /// </summary>
        public static PropertyTag PR_INTERNET_CPID
        {
            get { return new PropertyTag(0x3FDE, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     The creators address type
        /// </summary>
        public static PropertyTag PR_CreatorAddrType_W
        {
            get { return new PropertyTag(0x4022, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     The creators e-mail address
        /// </summary>
        public static PropertyTag PR_CreatorEmailAddr_W
        {
            get { return new PropertyTag(0x4023, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     The creators display name
        /// </summary>
        public static PropertyTag PR_CreatorSimpleDispName_W
        {
            get { return new PropertyTag(0x4038, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     The senders display name
        /// </summary>
        public static PropertyTag PR_SenderSimpleDispName_W
        {
            get { return new PropertyTag(0x4030, PropertyType.PT_UNICODE); }
        }

        /// <summary>
        ///     Indicates the type of Message object to which this attachment is linked.
        /// </summary>
        /// <remarks>
        ///     Must be 0, unless overridden by other protocols that extend the 
        ///     Message and Attachment Object Protocol as noted in [MS-OXCMSG].
        /// </remarks>
        public static PropertyTag PR_ATTACHMENT_LINKID
        {
            get { return new PropertyTag(0x7FFA, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates special handling for this Attachment object.
        /// </summary>
        /// <remarks>
        ///     Must be 0x00000000, unless overridden by other protocols that extend the Message 
        ///     and Attachment Object Protocol as noted in [MS-OXCMSG]
        /// </remarks>
        public static PropertyTag PR_ATTACHMENT_FLAGS
        {
            get { return new PropertyTag(0x7FFD, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates whether an attachment is hidden from the end user.
        /// </summary>
        public static PropertyTag PR_ATTACHMENT_HIDDEN
        {
            get { return new PropertyTag(0x7FFE, PropertyType.PT_BOOLEAN); }
        }

        /// <summary>
        ///     Specifies the format for an editor to use to display a message.
        /// </summary>
        /// <remarks>
        ///     By default, mail messages (with the message class IPM.Note or with a custom message 
        ///     class derived from IPM.Note) sent from a POP3/SMTP mail account are sent in the Transport 
        ///     Neutral Encapsulation Format (TNEF). The PR_MSG_EDITOR_FORMAT property can be used to enforce 
        ///     only plain text, and not TNEF, when sending a message. If PR_MSG_EDITOR_FORMAT is set to 
        ///     EDITOR_FORMAT_PLAINTEXT, the message is sent as plain text without TNEF. If PR_MSG_EDITOR_FORMAT 
        ///     is set to EDITOR_FORMAT_RTF, TNEF encoding is implicitly enabled, and the message is sent by using 
        ///     the default Internet format that is specified in the Outlook client.
        /// </remarks>
        public static PropertyTag PR_MSG_EDITOR_FORMAT
        {
            get { return new PropertyTag(0x5909, PropertyType.PT_LONG); }
        }

        /// <summary>
        ///     Indicates the existence of a photo attachment for a contact.
        /// </summary>
        public static PropertyTag PR_ATTACHMENT_CONTACTPHOTO
        {
            get { return new PropertyTag(0x7FFF, PropertyType.PT_BOOLEAN); }
        }
    }

    /// <summary>
    ///     Used to hold exactly one property tag
    /// </summary>
    public class PropertyTag
    {
        #region Properties
        /// <summary>
        ///     The 2 byte identifier
        /// </summary>
        public ushort Id { get; }

        /// <summary>
        ///     The 2 byte <see cref="PropertyType" />
        /// </summary>
        public PropertyType Type { get; }

        /// <summary>
        ///     Returns the PropertyTag as a readable string, e.g. __substg1.0_0037001F
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get { return PropertyTags.SubStorageStreamPrefix + Id.ToString("X4") + ((ushort)Type).ToString("X4"); }
        }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all its properties
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        internal PropertyTag(ushort id, PropertyType type)
        {
            Id = id;
            Type = type;
        }
        #endregion
    }
}
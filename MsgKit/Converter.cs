//
// Converter.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2013-2026 Kees van Spelde. (www.magic-sessions.com)
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
using System.IO;
using System.Linq;
using System.Text;
using MimeKit;
using MsgKit.Exceptions;
using MsgKit.Helpers;
using MsgKit.Streams;
using OpenMcdf;

// ReSharper disable UnusedMember.Global

namespace MsgKit;

/// <summary>
///     This class exposes some methods to convert MSG to EML and vice versa
/// </summary>
public static class Converter
{
    #region ConvertEmlToMsg
    /// <summary>
    ///     Converts an EML file to MSG format
    /// </summary>
    /// <param name="emlFileName">The EML (MIME) file</param>
    /// <param name="msgFileName">The MSG file</param>
    public static void ConvertEmlToMsg(string emlFileName, string msgFileName)
    {
        using var emlFile = new FileStream(emlFileName, FileMode.Open);
        using var msgFile = new FileStream(msgFileName, FileMode.CreateNew);
        ConvertEmlToMsg(emlFile, msgFile);
    }

    /// <summary>
    ///     Converts an EML file to MSG format
    /// </summary>
    /// <param name="emlFile">The EML (MIME) input stream</param>
    /// <param name="msgFile">The MSG file output stream</param>
    public static void ConvertEmlToMsg(Stream emlFile, Stream msgFile)
    {
        var eml = MimeMessage.Load(emlFile);
        var sender = new Sender(string.Empty, string.Empty);

        if (eml.From.Count > 0)
        {
            var mailAddress = (MailboxAddress)eml.From[0];
            sender = new Sender(mailAddress.Address, mailAddress.Name);
        }

        var representing = new Representing(string.Empty, string.Empty);
        if (eml.ResentSender != null)
            representing = new Representing(eml.ResentSender.Address, eml.ResentSender.Name);
        else if (eml.From.Count > 0)
        {
            var mailAddress = (MailboxAddress)eml.From[0];
            representing = new Representing(mailAddress.Address, mailAddress.Name);
        }

        var msg = new Email(sender, representing, eml.Subject)
        {
            InternetMessageId = eml.MessageId
        };

        if(eml.Date.UtcDateTime > DateTime.MinValue)
        {
            msg.SentOn = eml.Date.UtcDateTime;
            msg.ReceivedOn = eml.Date.UtcDateTime;
        }

        using (var memoryStream = new MemoryStream())
        {
            eml.Headers.WriteTo(memoryStream);
            msg.TransportMessageHeadersText = Encoding.ASCII.GetString(memoryStream.ToArray());
        }

        msg.Priority = eml.Priority switch
        {
            MessagePriority.NonUrgent => Enums.MessagePriority.PRIO_NONURGENT,
            MessagePriority.Normal => Enums.MessagePriority.PRIO_NORMAL,
            MessagePriority.Urgent => Enums.MessagePriority.PRIO_URGENT,
            _ => msg.Priority
        };

        msg.Importance = eml.Importance switch
        {
            MessageImportance.Low => Enums.MessageImportance.IMPORTANCE_LOW,
            MessageImportance.Normal => Enums.MessageImportance.IMPORTANCE_NORMAL,
            MessageImportance.High => Enums.MessageImportance.IMPORTANCE_HIGH,
            _ => msg.Importance
        };

        foreach (var to in eml.To)
        {
            if (to is not MailboxAddress mailAddress) continue;
            msg.Recipients.AddTo(mailAddress.Address, mailAddress.Name);
        }

        foreach (var cc in eml.Cc)
        {
            var mailAddress = (MailboxAddress)cc;
            msg.Recipients.AddCc(mailAddress.Address, mailAddress.Name);
        }

        foreach (var bcc in eml.Bcc)
        {
            var mailAddress = (MailboxAddress)bcc;
            msg.Recipients.AddBcc(mailAddress.Address, mailAddress.Name);
        }

        using (var headerStream = new MemoryStream())
        {
            eml.Headers.WriteTo(headerStream);
            headerStream.Position = 0;
            msg.TransportMessageHeadersText = Encoding.ASCII.GetString(headerStream.ToArray());
        }

        var namelessCount = 0;
        var index = 1;

        // This loops through the top-level parts (i.e. it doesn't open up attachments and continue to traverse).
        // As such, any included messages are just attachments here.
        foreach (var bodyPart in eml.BodyParts)
        {
            var handled = false;

            // The first text/plain part (that's not an attachment) is the body part.
            if (!bodyPart.IsAttachment && bodyPart is TextPart text)
            {
                // Sets the first matching inline content type for body parts.

                if (msg.BodyText == null && text.IsPlain)
                {
                    msg.BodyText = text.Text;
                    handled = true;
                }

                if (msg.BodyHtml == null && text.IsHtml)
                {
                    msg.BodyHtml = text.Text;
                    handled = true;
                }

                if (msg.BodyRtf == null && text.IsRichText)
                {
                    msg.BodyRtf = text.Text;
                    handled = true;
                }
            }

            // If the part hasn't previously been handled by "body" part handling
            if (handled) continue;
            
            var attachmentStream = new MemoryStream();
            var fileName = bodyPart.ContentType.Name;
            var extension = string.Empty;

            switch (bodyPart)
            {
                case MessagePart messagePart:
                {
                    messagePart.Message.WriteTo(attachmentStream);
                    if (messagePart.Message != null)
                        fileName = messagePart.Message.Subject;

                    extension = ".eml";
                    break;
                }

                case MessageDispositionNotification notification:
                    fileName = notification.FileName;
                    break;
                
                case MessageDeliveryStatus status:
                    fileName = "details";
                    extension = ".txt";
                    status.WriteTo(FormatOptions.Default, attachmentStream, true);
                    break;
                
                default:
                {
                    var part = (MimePart)bodyPart;
                    part.Content?.DecodeTo(attachmentStream);
                    fileName = part.FileName;
                    break;
                }
            }

            fileName = string.IsNullOrWhiteSpace(fileName)
                ? $"part_{++namelessCount:00}"
                : FileManager.RemoveInvalidFileNameChars(fileName);

            if (!string.IsNullOrEmpty(extension))
                fileName += extension;

            var inline = bodyPart.ContentDisposition != null &&
                         !string.IsNullOrEmpty(bodyPart.ContentId) &&
                         bodyPart.ContentDisposition.Disposition.Equals("inline",
                             StringComparison.InvariantCultureIgnoreCase);

            attachmentStream.Position = 0;

            try
            {
                msg.Attachments.Add(attachmentStream, fileName, -1, inline, bodyPart.ContentId);
            }
            catch (MKAttachmentExists)
            {
                var tempFileName = Path.GetFileNameWithoutExtension(fileName);
                var tempExtension = Path.GetExtension(fileName);
                msg.Attachments.Add(attachmentStream, $"{tempFileName}({index}){tempExtension}", -1, inline,
                    bodyPart.ContentId);
                index += 1;
            }
        }

        msg.Save(msgFile);
    }
    #endregion

    #region ConvertMsgToEml
    /// <summary>
    ///     Converts an MSG file to EML format
    /// </summary>
    /// <param name="msgFileName">The MSG file</param>
    /// <param name="emlFileName">The EML (MIME) file</param>
    public static void ConvertMsgToEml(string msgFileName, string emlFileName)
    {
        using var msgFile = new FileStream(msgFileName, FileMode.Open, FileAccess.Read);
        using var emlFile = new FileStream(emlFileName, FileMode.CreateNew);
        ConvertMsgToEml(msgFile, emlFile);
    }

    /// <summary>
    ///     Converts an MSG file to EML format
    /// </summary>
    /// <param name="msgFile">The MSG file input stream</param>
    /// <param name="emlFile">The EML (MIME) output stream</param>
    public static void ConvertMsgToEml(Stream msgFile, Stream emlFile)
    {
        using var rootStorage = RootStorage.Open(msgFile, StorageModeFlags.LeaveOpen);

        // Read top-level properties
        var propsStream = rootStorage.OpenStream(PropertyTags.PropertiesStreamName);
        var topLevelProps = new TopLevelProperties(propsStream);

        // Read variable-size properties from substg streams
        var subject = ReadUnicodeString(rootStorage, PropertyTags.PR_SUBJECT_W);
        var bodyText = ReadUnicodeString(rootStorage, PropertyTags.PR_BODY_W);
        var htmlBytes = ReadBinaryProperty(rootStorage, PropertyTags.PR_HTML);
        var senderName = ReadUnicodeString(rootStorage, PropertyTags.PR_SENDER_NAME_W);
        var senderEmail = ReadUnicodeString(rootStorage, PropertyTags.PR_SENDER_EMAIL_ADDRESS_W);
        var senderSmtp = ReadUnicodeString(rootStorage, PropertyTags.PR_SMTP_ADDRESS_W);
        var messageId = ReadUnicodeString(rootStorage, PropertyTags.PR_INTERNET_MESSAGE_ID_W);

        // Determine sender SMTP address (prefer SMTP over email, discard Exchange DNs)
        var senderAddress = senderSmtp ?? senderEmail ?? string.Empty;
        if (senderAddress.StartsWith("/O=", StringComparison.OrdinalIgnoreCase))
            senderAddress = string.Empty;

        // Read fixed properties
        var clientSubmitTime = topLevelProps.FirstOrDefault(p => p.Id == PropertyTags.PR_CLIENT_SUBMIT_TIME.Id);
        var importance = topLevelProps.FirstOrDefault(p => p.Id == PropertyTags.PR_IMPORTANCE.Id);
        var priority = topLevelProps.FirstOrDefault(p => p.Id == PropertyTags.PR_PRIORITY.Id);

        // Build MimeMessage
        var message = new MimeMessage();

        if (!string.IsNullOrEmpty(senderAddress))
            message.From.Add(new MailboxAddress(senderName ?? string.Empty, senderAddress));

        if (!string.IsNullOrEmpty(subject))
            message.Subject = subject;

        if (!string.IsNullOrEmpty(messageId))
            message.MessageId = messageId;

        if (clientSubmitTime != null)
            message.Date = new DateTimeOffset(clientSubmitTime.ToDateTime);

        if (importance != null)
        {
            message.Importance = importance.ToInt switch
            {
                0 => MessageImportance.Low,
                2 => MessageImportance.High,
                _ => MessageImportance.Normal
            };
        }

        if (priority != null)
        {
            message.Priority = priority.ToInt switch
            {
                -1 => MessagePriority.NonUrgent,
                1 => MessagePriority.Urgent,
                _ => MessagePriority.Normal
            };
        }

        // Read recipients
        for (var i = 0; i < topLevelProps.RecipientCount; i++)
        {
            var storageName = PropertyTags.RecipientStoragePrefix + i.ToString("X8");
            if (!rootStorage.TryOpenStorage(storageName, out var recipStorage))
                continue;

            var recipPropsStream = recipStorage.OpenStream(PropertyTags.PropertiesStreamName);
            var recipProps = new RecipientProperties(recipPropsStream);

            var displayName = ReadUnicodeString(recipStorage, PropertyTags.PR_DISPLAY_NAME_W);
            var emailAddress = ReadUnicodeString(recipStorage, PropertyTags.PR_EMAIL_ADDRESS_W);
            var smtpAddress = ReadUnicodeString(recipStorage, PropertyTags.PR_SMTP_ADDRESS_W);

            var address = smtpAddress ?? emailAddress ?? string.Empty;
            if (address.StartsWith("/O=", StringComparison.OrdinalIgnoreCase))
                address = string.Empty;

            if (string.IsNullOrEmpty(address))
                continue;

            var recipientType = recipProps.FirstOrDefault(p => p.Id == PropertyTags.PR_RECIPIENT_TYPE.Id);
            var type = recipientType?.ToInt ?? 1;

            var mailbox = new MailboxAddress(displayName ?? string.Empty, address);

            switch (type)
            {
                case 1: message.To.Add(mailbox); break;
                case 2: message.Cc.Add(mailbox); break;
                case 3: message.Bcc.Add(mailbox); break;
            }
        }

        // Build body and read attachments
        var builder = new BodyBuilder();
        builder.TextBody = bodyText;

        if (htmlBytes != null)
            builder.HtmlBody = Encoding.UTF8.GetString(htmlBytes);

        for (var i = 0; i < topLevelProps.AttachmentCount; i++)
        {
            var storageName = PropertyTags.AttachmentStoragePrefix + i.ToString("X8");
            if (!rootStorage.TryOpenStorage(storageName, out var attachStorage))
                continue;

            var fileName = ReadUnicodeString(attachStorage, PropertyTags.PR_ATTACH_LONG_FILENAME_W)
                        ?? ReadUnicodeString(attachStorage, PropertyTags.PR_ATTACH_FILENAME_W);
            var mimeTag = ReadUnicodeString(attachStorage, PropertyTags.PR_ATTACH_MIME_TAG_W);
            var contentId = ReadUnicodeString(attachStorage, PropertyTags.PR_ATTACH_CONTENT_ID_W);
            var attachData = ReadBinaryProperty(attachStorage, PropertyTags.PR_ATTACH_DATA_BIN);

            if (attachData == null) continue;

            var contentType = !string.IsNullOrEmpty(mimeTag)
                ? ContentType.Parse(mimeTag)
                : new ContentType("application", "octet-stream");

            if (!string.IsNullOrEmpty(contentId))
            {
                var attachment = builder.LinkedResources.Add(fileName ?? "inline", attachData, contentType);
                attachment.ContentId = contentId;
            }
            else
            {
                builder.Attachments.Add(fileName ?? "attachment", attachData, contentType);
            }
        }

        message.Body = builder.ToMessageBody();
        message.WriteTo(emlFile);
    }
    #endregion

    #region ReadUnicodeString
    /// <summary>
    ///     Reads a unicode string property from a substg stream in the given storage
    /// </summary>
    private static string ReadUnicodeString(Storage storage, PropertyTags.PropertyTag tag)
    {
        if (!storage.TryOpenStream(tag.Name, out var stream))
            return null;

        using (stream)
        using (var reader = new BinaryReader(stream))
        {
            var bytes = reader.ReadBytes((int)stream.Length);
            return Encoding.Unicode.GetString(bytes).TrimEnd('\0');
        }
    }
    #endregion

    #region ReadBinaryProperty
    /// <summary>
    ///     Reads a binary property from a substg stream in the given storage
    /// </summary>
    private static byte[] ReadBinaryProperty(Storage storage, PropertyTags.PropertyTag tag)
    {
        if (!storage.TryOpenStream(tag.Name, out var stream))
            return null;

        using (stream)
        using (var reader = new BinaryReader(stream))
        {
            return reader.ReadBytes((int)stream.Length);
        }
    }
    #endregion
}
//
// Converter.cs
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
using System.IO;
using System.Text;
using MimeKit;
using MsgKit.Exceptions;
using MsgKit.Helpers;

namespace MsgKit
{
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
            using (var emlFile = new FileStream(emlFileName, FileMode.Open))
            using (var msgFile = new FileStream(msgFileName, FileMode.CreateNew))
            {
                ConvertEmlToMsg(emlFile, msgFile);
            }
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

            var msg = new Email(sender, representing, eml.Subject)
            {
                SentOn = eml.Date.UtcDateTime,
                InternetMessageId = eml.MessageId
            };

            using (var memoryStream = new MemoryStream())
            {
                eml.Headers.WriteTo(memoryStream);
                msg.TransportMessageHeadersText = Encoding.ASCII.GetString(memoryStream.ToArray());
            }

            switch (eml.Priority)
            {
                case MessagePriority.NonUrgent:
                    msg.Priority = Enums.MessagePriority.PRIO_NONURGENT;
                    break;
                case MessagePriority.Normal:
                    msg.Priority = Enums.MessagePriority.PRIO_NORMAL;
                    break;
                case MessagePriority.Urgent:
                    msg.Priority = Enums.MessagePriority.PRIO_URGENT;
                    break;
            }

            switch (eml.Importance)
            {
                case MessageImportance.Low:
                    msg.Importance = Enums.MessageImportance.IMPORTANCE_LOW;
                    break;
                case MessageImportance.Normal:
                    msg.Importance = Enums.MessageImportance.IMPORTANCE_NORMAL;
                    break;
                case MessageImportance.High:
                    msg.Importance = Enums.MessageImportance.IMPORTANCE_HIGH;
                    break;
            }

            foreach (var to in eml.To)
            {
                var mailAddress = (MailboxAddress)to;
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
                if(!bodyPart.IsAttachment && bodyPart is TextPart text)
                {
                    // Sets the first matching inline content type for body parts.

                    if(msg.BodyText == null && text.IsPlain)
                    {
                        msg.BodyText = text.Text;
                        handled = true;
                    }

                    if(msg.BodyHtml == null && text.IsHtml)
                    {
                        msg.BodyHtml = text.Text;
                        handled = true;
                    }

                    if(msg.BodyRtf == null && text.IsRichText)
                    {
                        msg.BodyRtf = text.Text;
                        handled = true;
                    }
                }

                // If the part hasn't previously been handled by "body" part handling
                if (!handled)
                {
                    var attachmentStream = new MemoryStream();
                    var fileName = bodyPart.ContentType.Name;
                    var extension = string.Empty;

                    if (bodyPart is MessagePart messagePart)
                    {
                        messagePart.Message.WriteTo(attachmentStream);
                        if (messagePart.Message != null)
                            fileName = messagePart.Message.Subject;

                        extension = ".eml";
                    }
                    else if (bodyPart is MessageDispositionNotification)
                    {
                        var part = (MessageDispositionNotification)bodyPart;
                        fileName = part.FileName;
                    }
                    else if (bodyPart is MessageDeliveryStatus)
                    {
                        var part = (MessageDeliveryStatus)bodyPart;
                        fileName = "details";
                        extension = ".txt";
                        part.WriteTo(FormatOptions.Default, attachmentStream, true);
                    }
                    else
                    {
                        var part = (MimePart)bodyPart;
                        part.Content.DecodeTo(attachmentStream);
                        fileName = part.FileName;
                    }

                    fileName = string.IsNullOrWhiteSpace(fileName)
                        ? $"part_{++namelessCount:00}"
                        : FileManager.RemoveInvalidFileNameChars(fileName);

                    if (!string.IsNullOrEmpty(extension))
                        fileName += extension;

                    var inline = bodyPart.ContentDisposition != null &&
                                 bodyPart.ContentId != null &&
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
                        msg.Attachments.Add(attachmentStream, $"{tempFileName}({index}){tempExtension}", -1, inline, bodyPart.ContentId);
                        index += 1;
                    }
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
            //var eml = MimeKit.MimeMessage.CreateFromMailMessage()
            throw new NotImplementedException("Not yet done");
        }
        #endregion
    }
}

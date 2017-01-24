//
// Converter.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2017 Magic-Sessions. (www.magic-sessions.com)
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
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.IO;
using System.Text;
using MimeKit;

namespace MsgKit
{
    /// <summary>
    ///     This class exposes some methods to convert MSG to EML and vice versa
    /// </summary>
    public static class Converter
    {
        /// <summary>
        ///     Converts an EML file to MSG format
        /// </summary>
        /// <param name="emlFileName">The EML (MIME) file</param>
        /// <param name="msgFileName">The MSG file</param>
        public static void ConvertEmlToMsg(string emlFileName, string msgFileName)
        {
            var eml = MimeMessage.Load(emlFileName);
            var sender = new Sender(string.Empty, string.Empty);

            if (eml.From.Count > 0)
            {
                var mailAddress = ((MailboxAddress) eml.From[0]);
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
                var mailAddress = ((MailboxAddress)to);
                msg.Recipients.AddTo(mailAddress.Address, mailAddress.Name);
            }

            foreach (var cc in eml.Cc)
            {
                var mailAddress = ((MailboxAddress)cc);
                msg.Recipients.AddCc(mailAddress.Address, mailAddress.Name);
            }

            foreach (var bcc in eml.Bcc)
            {
                var mailAddress = ((MailboxAddress)bcc);
                msg.Recipients.AddBcc(mailAddress.Address, mailAddress.Name);
            }

            using (var headerStream = new MemoryStream())
            {
                eml.Headers.WriteTo(headerStream);
                headerStream.Position = 0;
                msg.TransportMessageHeaders = Encoding.ASCII.GetString(headerStream.ToArray());
            }

            msg.BodyHtml = eml.HtmlBody;
            msg.BodyText = eml.TextBody;

            foreach (var bodyPart in eml.BodyParts)
            {
                var attachmentStream = new MemoryStream();
                var fileName = bodyPart.ContentType.Name;

                if (bodyPart is MessagePart)
                {
                    var part = (MessagePart)bodyPart;
                    part.Message.WriteTo(attachmentStream);
                    if (part.Message.HtmlBody == eml.HtmlBody) continue;
                    if (part.Message.TextBody == eml.TextBody) continue;
                }
                else
                {
                    var part = (MimePart)bodyPart;
                    part.ContentObject.DecodeTo(attachmentStream);

                    if (part.ContentType.MimeType == "message/delivery-status")
                    {
                        var att = Encoding.ASCII.GetString(attachmentStream.ToArray());
                        fileName = "details.txt";
                        attachmentStream.Position = 0;
                        msg.Attachments.Add(attachmentStream, fileName, -1, false, bodyPart.ContentId);
                    }
                    else
                    {
                        var text = part as TextPart;
                        if (text != null && (text.Text == eml.HtmlBody || text.Text == eml.TextBody)) continue;

                        if (text == null)
                            fileName = Guid.NewGuid().ToString();
                        else if (text.IsPlain)
                            fileName = "details.txt";
                        else if (text.IsHtml)
                            fileName = "details.htm";
                        else if (text.IsRichText)
                            fileName = "details.rtf";

                        bodyPart.WriteTo(attachmentStream);
                        attachmentStream.Position = 0;
                        msg.Attachments.Add(attachmentStream, fileName, -1,
                            bodyPart.ContentDisposition.Disposition.Equals("inline",
                                StringComparison.InvariantCultureIgnoreCase), bodyPart.ContentId);
                    }
                }
            }

            msg.Save(msgFileName);
        }

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
    }
}

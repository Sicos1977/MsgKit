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
            var sender = new Sender(eml.Sender.Address, eml.Sender.Name);
            var representing = new Representing(eml.ResentSender.Address, eml.ResentSender.Name);
            var msg = new Email(sender, representing, eml.Subject) {SentOn = eml.Date.DateTime};
            
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
                msg.Recipients.AddTo(to.ToString(), to.Name);

            foreach (var cc in eml.Cc)
                msg.Recipients.AddBcc(cc.ToString(), cc.Name);

            foreach (var bcc in eml.Bcc)
                msg.Recipients.AddBcc(bcc.ToString(), bcc.Name);

            using (var headerStream = new MemoryStream())
            {
                eml.Headers.WriteTo(headerStream);
                headerStream.Position = 0;
                msg.TransportMessageHeaders = Encoding.ASCII.GetString(headerStream.ToArray());
            }

            msg.BodyHtml = eml.HtmlBody;
            msg.BodyText = eml.TextBody;

            foreach (var attachment in eml.Attachments)
            {
                if (!attachment.IsAttachment) continue;

                using (var attachmentStream = new MemoryStream())
                {
                    attachment.WriteTo(attachmentStream);
                    attachmentStream.Position = 0;
                    msg.Attachments.Add(attachmentStream, attachment.ContentDisposition.FileName, -1,
                        attachment.ContentDisposition.Disposition.Equals("inline",
                            StringComparison.InvariantCultureIgnoreCase), attachment.ContentId);
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

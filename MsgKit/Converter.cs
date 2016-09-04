//
// Converter.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2016 Magic-Sessions. (www.magic-sessions.com)
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
            var eml = MimeKit.MimeMessage.Load(emlFileName);
            var sender = new Sender(eml.Sender.Address, eml.Sender.Name);
            var msg = new MsgKit.Email(sender, eml.Subject);
            throw new NotImplementedException("Not yet done");
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

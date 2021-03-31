//
// MessageFlags.cs
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
// ReSharper disable InconsistentNaming

namespace MsgKit.Enums
{
    /// <summary>
    ///     Contains a bitmask of flags that indicate the origin and current state of a message.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/cc839733(v=office.15).aspx
    ///     This property is a nontransmittable message property exposed at both the sending and receiving ends of a
    ///     transmission, with different values depending upon the client application or store provider involved. This property
    ///     is initialized by the client or message store provider when a message is created and saved for the first time and
    ///     then updated periodically by the message store provider, a transport provider, and the MAPI spooler as the message
    ///     is processed and its state changes.
    ///     This property exists on a message both before and after submission, and on all copies of the received
    ///     message. Although it is not a recipient property, it is exposed differently to each recipient according to whether
    ///     it has been read or modified by that recipient.
    /// </remarks>
    [Flags]
    public enum MessageFlags : uint
    {
        /// <summary>
        ///     The message is marked as having been read. This can occur as the result of a call at any time to
        ///     IMessage::SetReadFlag or IMAPIFolder::SetReadFlags. Clients can also set this flag by calling a message's
        ///     IMAPIProp::SetProps method before the message has been saved for the first time. This flag is ignored if the
        ///     ASSOCIATED flag is set.
        /// </summary>
        MSGFLAG_READ = 0x0001,

        /// <summary>
        ///     The outgoing message has not been modified since the first time that it was saved; the incoming message has not
        ///     been modified since it was delivered.
        /// </summary>
        MSGFLAG_UNMODIFIED = 0x0002,

        /// <summary>
        ///     The message is marked for sending as a result of a call to IMessage::SubmitMessage. Message store providers set
        ///     this flag; the client has read-only access.
        /// </summary>
        MSGFLAG_SUBMIT = 0x0004,

        /// <summary>
        ///     The message is still being composed. It is saved, but has not been sent. The client or provider has read/write
        ///     access to this flag until the first IMAPIProp::SaveChanges call and read-only thereafter. If a client doesn't set
        ///     this flag by the time the message is sent, the message store provider sets it when IMessage::SubmitMessage is
        ///     called. Typically, this flag is cleared after the message is sent.
        /// </summary>
        MSGFLAG_UNSENT = 0x0008,

        /// <summary>
        ///     The message has at least one attachment. This flag corresponds to the message's PR_HASATTACH (PidTagHasAttachments)
        ///     property. The client has read-only access to this flag.
        /// </summary>
        MSGFLAG_HASATTACH = 0x0010,

        /// <summary>
        ///     The messaging user sending was the messaging user receiving the message. The client or provider has read/write
        ///     access to this flag until the first IMAPIProp::SaveChanges call and read-only thereafter. This flag is meant to be
        ///     set by the transport provider.
        /// </summary>
        MSGFLAG_FROMME = 0x0020,

        /// <summary>
        ///     The message is an associated message of a folder. The client or provider has read-only access to this flag. The
        ///     READ flag is ignored for associated messages, which do not retain a read/unread state.
        /// </summary>
        MSGFLAG_ASSOCIATED = 0x040,

        /// <summary>
        ///     The message includes a request for a resend operation with a nondelivery report. The client or provider has
        ///     read/write access to this flag until the first IMAPIProp::SaveChanges call and read-only thereafter.
        /// </summary>
        MSGFLAG_RESEND = 0x0080,

        /// <summary>
        ///     A read report needs to be sent for the message. The client or provider has read-only access to this flag.
        /// </summary>
        MSGFLAG_NOTIFYREAD = 0x100,

        /// <summary>
        ///     A nonread report needs to be sent for the message. The client or provider has read-only access to this flag.
        /// </summary>
        MSGFLAG_NOTIFYUNREAD = 0x0200,

        /// <summary>
        ///     The message has been read at least once. This flag is set or cleared by the server whenever the MSGFLAG_READ flag
        ///     is set or cleared.
        /// </summary>
        MSGFLAG_EVERREAD = 0x0400,

        /// <summary>
        ///     The incoming message arrived over an X.400 link. It originated either outside the organization or from a source the
        ///     gateway cannot consider trusted. The client should display an appropriate message to the user. Transport providers
        ///     set this flag; the client has read-only access.
        /// </summary>
        MSGFLAG_ORIGIN_X400 = 0x1000,

        /// <summary>
        ///     The incoming message arrived over the Internet. It originated either outside the organization or from a source the
        ///     gateway cannot consider trusted. The client should display an appropriate message to the user. Transport providers
        ///     set this flag; the client has read-only access.
        /// </summary>
        MSGFLAG_ORIGIN_INTERNET = 0x2000,

        /// <summary>
        ///     The incoming message arrived over an external link other than X.400 or the Internet. It originated either outside
        ///     the organization or from a source the gateway cannot consider trusted. The client should display an appropriate
        ///     message to the user. Transport providers set this flag; the client has read-only access.
        /// </summary>
        MSGFLAG_ORIGIN_MISC_EXT = 0x8000
    }
}
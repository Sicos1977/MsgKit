//
// Appointment.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com> and Travis Semple
//
// Copyright (c) 2015-2023 Magic-Sessions. (www.magic-sessions.com)
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
using MsgKit.Enums;
using OpenMcdf;
// ReSharper disable UnusedMember.Global

namespace MsgKit;

/// <summary>
///     A class to make an appointment
/// </summary>
/// <remarks>
///     Inherits from <see cref="Email"/>>, because it has quite a few of the same fields
/// </remarks>
public class Appointment : Email
{
    #region Properties
    /// <summary>
    ///     Holds the location for the Appointment
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    ///     This property specifies whether or not the event is an all-day event, as 
    ///     specified by the user. A value of <c>true</c> indicates that the event is an all-day 
    ///     event, in which case the start time and end time must be midnight so that the 
    ///     duration is a multiple of 24 hours and is at least 24 hours. A value of <c>false</c> 
    ///     or the absence of this property indicates the event is not an all-day event. The 
    ///     client or server must not infer the value as TRUE when a user happens to create an 
    ///     event that is 24 hours, even if the event starts and ends at midnight.
    /// </summary>
    public bool AllDay { get; set; }

    /// <summary>
    ///     Holds meeting information for the appointment
    /// </summary>
    public DateTime MeetingStart { get; set; }

    /// <summary>
    ///     The end of the meeting
    /// </summary>
    public DateTime MeetingEnd { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    ///     Sends an appointment with sender, representing, subject, draft.
    /// </summary>
    /// <param name="sender"> Contains sender name and email. </param>
    /// <param name="representing">Contains who this appointment is representing. </param>
    /// <param name="subject"> Contains the subject for this appointment. </param>
    /// <param name="draft"> Is this a draft?</param>
    public Appointment(Sender sender,
        Representing representing,
        string subject,
        bool draft = false) : base(sender, representing, subject, draft)
    {
    }

    /// <summary>
    ///     Used to send without the representing structure.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="subject"></param>
    /// <param name="draft"></param>
    public Appointment(Sender sender,
        string subject,
        bool draft = false) : base(sender, subject, draft)
    {
    }
    #endregion

    #region WriteToStorage
    /// <summary>
    ///     Writes all the properties that are part of the <see cref="Appointment"/> object either as <see cref="CFStorage"/>'s
    ///     or <see cref="CFStream"/>'s to the <see cref="CompoundFile.RootStorage"/>
    /// </summary>
    private new void WriteToStorage()
    {
        Class = MessageClass.IPM_Appointment;
        NamedProperties.AddProperty(NamedPropertyTags.PidLidLocation, Location);
        NamedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentStartWhole, MeetingStart);
        NamedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentEndWhole, MeetingEnd);
        NamedProperties.AddProperty(NamedPropertyTags.PidLidMeetingType, MeetingType.mtgRequest);
        NamedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentSubType, AllDay);
        NamedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentStateFlags, AppointmentState.asfMeeting);
    }
    #endregion

    #region Save
    /// <summary>
    ///     Saves the message to the given <paramref name="stream" />
    /// </summary>
    /// <param name="stream"></param>
    public new void Save(System.IO.Stream stream)
    {
        WriteToStorage();
        base.Save(stream);
    }

    /// <summary>
    ///     Saves the message to the given <paramref name="fileName" />
    /// </summary>
    /// <param name="fileName"></param>
    public new void Save(string fileName)
    {
        WriteToStorage();
        base.Save(fileName);
    }
    #endregion
}
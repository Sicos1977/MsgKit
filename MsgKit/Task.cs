//
// Task.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
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
using MsgKit.Helpers;
using System.Collections.ObjectModel;
using MsgKit.Enums;
using OpenMcdf;
using Stream = System.IO.Stream;

namespace MsgKit;

/// <summary>
///     A class used to make a task that can be added to a <see cref="Email"/> or <see cref="Appointment"/>
/// </summary>
/// <remarks>
///     See https://msdn.microsoft.com/en-us/library/office/cc979231.aspx
/// </remarks>
public class Task : Message
{
    #region Properties
    /// <summary>
    ///     Specifies the <see cref="TaskStatus"/>> of the user's progress on the task
    /// </summary>
    public TaskStatus Status { get; }

    /// <summary>
    ///     Percentage complete or <c>null</c>
    /// </summary>
    public double? PercentageComplete { get; }

    /// <summary>
    ///     Represents the date when the user expects to complete the task
    /// </summary>
    /// <remarks>
    ///     The task has no due date if this property is unset or set to 0x5AE980E0
    ///     (1,525,252,320). However, a due date is optional only if no start date is indicated in
    ///     the dispidTaskStartDate (PidLidTaskStartDate) property. If the task has a due date, the
    ///     value must have a time component of midnight, and the dispidCommonEnd (PidLidCommonEnd)
    ///     property must also be set. If dispidTaskStartDate has a start date, then the value of the
    ///     dispidTaskDueDate property must be greater than or equal to the value of dispidTaskStartDate.
    /// </remarks>
    public DateTime? DueDate { get; }

    /// <summary>
    ///     The date when the user expects to begin the task.
    /// </summary>
    /// <remarks>
    ///     If this property value is left unset, the task does not have a start date. A value of
    ///     "0x5AE980E0" (1,525,252,320) also means that the task does not have a start date.
    ///     If the task has a start date, the value must have a time component of midnight, and the
    ///     dispidTaskDueDate (PidLidTaskDueDate) and dispidCommonStart (PidLidCommonStart) properties
    ///     must also be set.
    /// </remarks>
    public DateTime? StartDate { get; }

    /// <summary>
    ///     Indicates the number of minutes that the user performed a task.
    /// </summary>
    /// <remarks>
    ///     The value must be greater than or equal to 0 and less than 0x5AE980DF (1,525,252,319),
    ///     where 480 minutes equal one day and 2400 minutes equal one week (eight hours in a work
    ///     day and five days in a work week).
    /// </remarks>
    public TimeSpan? ActualEffort { get; }

    /// <summary>
    ///     Indicates the amount of time, in minutes, that the user expects to perform a task.
    /// </summary>
    /// <remarks>
    ///     The value must be greater than or equal to 0 and less than 0x5AE980DF (1,525,252,319), where 480 minutes equal
    ///     one day and 2400 minutes equal one week (eight hours in a work day and five days in a work week).
    /// </remarks>
    public TimeSpan? EstimatedEffort { get; }
    
    /// <summary>
    ///     Indicates whether the task assignee has been requested to send a task update when the assigned task changes.
    /// </summary>
    public bool Updates { get; }

    /// <summary>
    ///     Indicates whether the task assignee has been requested to send an email message update when they complete
    ///     the assigned task.
    /// </summary>
    public bool StatusOnComplete { get; }

    /// <summary>
    ///     Indicates the task is complete.
    /// </summary>
    public bool Complete { get; }

    /// <summary>
    ///     Contains the name of the task owner.
    /// </summary>
    public string Owner { get; }

    /// <summary>
    ///     Indicates the role of the current user relative to the task.
    /// </summary>
    public TaskOwnership Ownership { get; }
    
    /// <summary>
    ///     Indicates the acceptance state of the task.
    /// </summary>
    public TaskAcceptanceState AcceptanceState { get; }

    /// <summary>
    ///     ??????
    /// </summary>
    public string Role { get; }

    /// <summary>
    ///     Indicates which copy is the latest update of a task.
    /// </summary>
    /// <remarks>
    ///     Updates with lower versions than the task are ignored.
    ///     When embedding a task in a task communication, the client sets the current version of the embedded task
    ///     on the task communication as well.
    /// </remarks>
    public long Version { get; }

    /// <summary>
    ///     Indicates the current assignment state of the task.
    /// </summary>
    public TaskState State { get; }

    /// <summary>
    ///     Names the user who was last assigned the task.
    /// </summary>
    /// <remarks>
    ///     If the task has not been assigned, this property is left unset. Because the client sets this property after
    ///     the task assignee receives a task request, the property will not be set on the task assigner's copy of the task.
    ///     When the client adds or removes a task assigner from the task assigner list in the dispidTaskMyDelegators
    ///     (PidLidTaskAssigners) property, the dispidTaskDelegator (PidLidTaskAssigner) property must be set to the added
    ///     or removed task assigner.
    /// </remarks>
    public string Assigner { get; }

    /// <summary>
    ///     <c>true</c> when it is a team task
    /// </summary>
    public bool TeamTask { get; }

    /// <summary>
    ///     Provides an aid to custom sorting tasks.
    /// </summary>
    /// <remarks>
    ///     This property may be left unset. If set, its value must be greater than "0x800186A0" (-2,147,383,648) and less than
    ///     "0x7FFE7960" (2,147,383,648) and must be unique among tasks in the same folder.
    ///     Whenever the client sets this property to a number less than the negative of the current value of the PR_ORDINAL_MOST
    ///     (PidTagOrdinalMost) property of the folder, the client must also update PR_ORDINAL_MOST on the folder.
    ///     The PR_ORDINAL_MOST property of the folder provides an efficient way to determine a unique value among tasks in the same folder.
    /// </remarks>
    public long Ordinal { get; }

    /// <summary>
    ///     <c>true</c> when the task is recurring
    /// </summary>
    public bool Recurring { get; }

    // PidLidTaskRecurrence Canonical Property

    /// <summary>
    ///     Specifies the interval, in minutes, between the time at which the reminder first becomes overdue and the start time of
    ///     the Calendar object.
    /// </summary>
    public long ReminderDelta { get; }

    /// <summary>
    ///     Specifies the initial signal time for objects that are not Calendar objects.
    /// </summary>
    public DateTime? ReminderTime { get; }

    /// <summary>
    ///     Specifies the point in time when a reminder transitions from pending to overdue.
    /// </summary>
    public DateTime? ReminderSignalTime { get; }

    /// <summary>
    ///      Indicates the start time for the Message object.
    /// </summary>
    public DateTime? CommonStart { get; }

    /// <summary>
    ///      Indicates the end time for the Message object.
    /// </summary>
    public DateTime? CommonEnd { get; }

    /// <summary>
    ///     Specifies whether a reminder is set on the object.
    /// </summary>
    public bool ReminderSet { get; }

    /// <summary>
    ///     Specifies the assignment status of the task.
    /// </summary>
    public TaskMode Mode { get; }

    /// <summary>
    ///     Determines the sort order of objects in a consolidated to-do list.
    /// </summary>
    /// <remarks>
    ///     When an object is flagged, this property should be set to the current time in Coordinated Universal Time (UTC).
    ///     If the client allows a user to reorder tasks within the consolidated task list via dragging or other mechanisms,
    ///     they can use any suitable algorithm to determine the new value of this property so that the task appears in the
    ///     correct place when this property is used as a sorting field.
    ///     When this property is used to sort objects and the sort results in a tie, the dispidToDoSubOrdinal (PidLidToDoSubOrdinal)
    ///     property is used as a tiebreaker.
    /// </remarks>
    public DateTime? ToDoOrdinalDate { get; }

    /// <summary>
    ///     Acts as a tiebreaker when the dispidToDoOrdinalDate (PidLidToDoOrdinalDate) property sorts objects and the result in a tie.   
    /// </summary>
    /// <remarks>
    ///     If used, this property must be sorted lexicographically. The component characters of the string must consist of only the numerals
    ///     zero through nine. This property should be initially set to "5555555". The length of this property must not exceed 254 characters
    ///     (excluding the terminating null character).
    /// </remarks>
    public string ToDoSubOrdinal { get; }
    
    #endregion

    #region WriteToStorage
    /// <summary>
    ///     Writes all the properties that are part of the <see cref="Appointment"/> object either as <see cref="CFStorage"/>'s
    ///     or <see cref="CFStream"/>'s to the <see cref="CompoundFile.RootStorage"/>
    /// </summary>
    private void WriteToStorage()
    {
        var rootStorage = CompoundFile.RootStorage;

        //var namedProperties = new NamedProperties(propertiesStream); //Uses the top level properties. 
        //namedProperties.AddProperty(NamedPropertyTags.PidLidLocation, Location);
        //namedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentStartWhole, MeetingStart);
        //namedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentEndWhole, MeetingEnd);
        //namedProperties.AddProperty(NamedPropertyTags.PidLidMeetingType, MeetingType.mtgRequest);
        //namedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentSubType, AllDay);
        //namedProperties.AddProperty(NamedPropertyTags.PidLidAppointmentStateFlags, AppointmentState.asfMeeting);
        //namedProperties.WriteProperties(rootStorage);
        //propertiesStream.WriteProperties(rootStorage, messageSize);
    }
    #endregion

    public Task()
    {
        throw new NotImplementedException("This functionality is not yet completely implemented");
    }

    #region Save
    /// <summary>
    ///     Saves the message to the given <paramref name="stream" />
    /// </summary>
    /// <param name="stream"></param>
    public new void Save(Stream stream)
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
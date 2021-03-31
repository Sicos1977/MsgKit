//
// Task.cs
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
using OpenMcdf;
using Stream = System.IO.Stream;

namespace MsgKit
{
    /// <summary>
    ///     A class used to make a task that can be added to an <see cref="Email"/> or <see cref="Appointment"/>
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc979231.aspx
    /// </remarks>
    public class Task : Message
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReminderTime { get; set; }

        /// <summary>
        /// Start date of the task
        /// </summary>
        public DateTime TaskStartDate { get; set; }

        /// <summary>
        /// Due date of the task
        /// </summary>
        public DateTime TaskDueDate { get; set; }

        /// <summary>
        /// <c>true</c> when the task is complete
        /// </summary>
        public bool TaskComplete { get; set; }

        /// <summary>
        /// The complete percentage of the task
        /// </summary>
        public double PercentComplete { get; set; }

        /// <summary>
        /// The actual task effort in minutes
        /// </summary>
        public long TaskActualEffort { get; set; }

        /// <summary>
        /// The estimated task effort in minutes
        /// </summary>
        public long TaskEstimatedEffort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TaskNoCompute { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TaskFFixOffline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TaskOwnership { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TaskAcceptanceState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskRole { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TaskState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskAssigner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskOwner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TeamTask { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TaskOrdinal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaskFRecurring { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ReminderDelta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ReminderSignalTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CommonStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CommonEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AgingDontAgeMe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TaskMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ToDoOrdinalDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ToDoSubOrdinal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ValidFlagStringProof { get; set; }
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
}

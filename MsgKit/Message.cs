//
// Message.cs
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
using MsgKit.Enums;
using MsgKit.Exceptions;
using MsgKit.Streams;
using OpenMcdf;

// ReSharper disable InconsistentNaming

namespace MsgKit
{
    /// <summary>
    ///     The base class for all the different types of Outlook MSG files
    /// </summary>
    public class Message : IDisposable
    {
        #region Fields
        /// <summary>
        ///     A flag to keep track if the message already has been saved
        /// </summary>
        private bool _saved;
        #endregion

        #region Properties
        /// <summary>
        ///     The <see cref="CompoundFile" />
        /// </summary>
        internal CompoundFile CompoundFile { get; }

        /// <summary>
        ///     The <see cref="MessageClass"/>
        /// </summary>
        internal MessageClass Class = MessageClass.Unknown;

        /// <summary>
        ///     Returns <see cref="Class"/> as a string that is written into the MSG file
        /// </summary>
        private string ClassAsString
        {
            get
            {
                switch (Class)
                {
                    case MessageClass.Unknown:
                        throw new ArgumentException("Class field is not set");
                    case MessageClass.IPM_Note:
                        return "IPM.Note";
                    case MessageClass.IPM_Note_SMIME:
                        return "IPM.Note.SMIME";
                    case MessageClass.IPM_Note_SMIME_MultipartSigned:
                        return "IPM.Note.SMIME.MultipartSigned";
                    case MessageClass.IPM_Note_Receipt_SMIME:
                        return "IPM.Note.Receipt.SMIME";
                    case MessageClass.IPM_Post:
                        return "IPM.Post";
                    case MessageClass.IPM_Octel_Voice:
                        return "IPM.Octel.Voice";
                    case MessageClass.IPM_Voicenotes:
                        return "IPM.Voicenotes";
                    case MessageClass.IPM_Sharing:
                        return "IPM.Sharing";
                    case MessageClass.REPORT_IPM_NOTE_NDR:
                        return "REPORT.IPM.NOTE.NDR";
                    case MessageClass.REPORT_IPM_NOTE_DR:
                        return "REPORT.IPM.NOTE.DR";
                    case MessageClass.REPORT_IPM_NOTE_DELAYED:
                        return "REPORT.IPM.NOTE.DELAYED";
                    case MessageClass.REPORT_IPM_NOTE_IPNRN:
                        return "*REPORT.IPM.NOTE.IPNRN";
                    case MessageClass.REPORT_IPM_NOTE_IPNNRN:
                        return "*REPORT.IPM.NOTE.IPNNRN";
                    case MessageClass.REPORT_IPM_SCHEDULE_MEETING_REQUEST_NDR:
                        return "REPORT.IPM.SCHEDULE. MEETING.REQUEST.NDR";
                    case MessageClass.REPORT_IPM_SCHEDULE_MEETING_RESP_POS_NDR:
                        return "REPORT.IPM.SCHEDULE.MEETING.RESP.POS.NDR";
                    case MessageClass.REPORT_IPM_SCHEDULE_MEETING_RESP_TENT_NDR:
                        return "REPORT.IPM.SCHEDULE.MEETING.RESP.TENT.NDR";
                    case MessageClass.REPORT_IPM_SCHEDULE_MEETING_CANCELED_NDR:
                        return "REPORT.IPM.SCHEDULE.MEETING.CANCELED.NDR";
                    case MessageClass.REPORT_IPM_NOTE_SMIME_NDR:
                        return "REPORT.IPM.NOTE.SMIME.NDR";
                    case MessageClass.REPORT_IPM_NOTE_SMIME_DR:
                        return "*REPORT.IPM.NOTE.SMIME.DR";
                    case MessageClass.REPORT_IPM_NOTE_SMIME_MULTIPARTSIGNED_NDR:
                        return "*REPORT.IPM.NOTE.SMIME.MULTIPARTSIGNED.NDR";
                    case MessageClass.REPORT_IPM_NOTE_SMIME_MULTIPARTSIGNED_DR:
                        return "*REPORT.IPM.NOTE.SMIME.MULTIPARTSIGNED.DR";
                    case MessageClass.IPM_Appointment:
                        return "IPM.Appointment";
                    case MessageClass.IPM_Task:
                        return "IPM.Task";
                    case MessageClass.IPM_Contact:
                        return "IPM.Contact";

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Contains a number that indicates which icon to use when you display a group
        ///     of e-mail objects. Default set to <see cref="MessageIconIndex.NewMail" />
        /// </summary>
        /// <remarks>
        ///     This property, if it exists, is a hint to the client. The client may ignore the
        ///     value of this property.
        /// </remarks>
        public MessageIconIndex IconIndex { get; set; }

        /// <summary>
        ///     The size of the message
        /// </summary>
        public long MessageSize { get; internal set; }

        /// <summary>
        ///     The <see cref="TopLevelProperties"/>
        /// </summary>
        internal readonly TopLevelProperties TopLevelProperties;
        
        /// <summary>
        ///     The <see cref="NamedProperties"/>
        /// </summary>
        internal readonly NamedProperties NamedProperties;
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all it's properties
        /// </summary>
        internal Message()
        {
            CompoundFile = new CompoundFile();

            // In the preceding figure, the "__nameid_version1.0" named property mapping storage contains the 
            // three streams  used to provide a mapping from property ID to property name 
            // ("__substg1.0_00020102", "__substg1.0_00030102", and "__substg1.0_00040102") and various other 
            // streams that provide a mapping from property names to property IDs.
            if (!CompoundFile.RootStorage.TryGetStorage(PropertyTags.NameIdStorage, out var nameIdStorage))
                nameIdStorage = CompoundFile.RootStorage.AddStorage(PropertyTags.NameIdStorage);

            var entryStream = nameIdStorage.AddStream(PropertyTags.EntryStream);
            entryStream.SetData(new byte[0]);
            var stringStream = nameIdStorage.AddStream(PropertyTags.StringStream);
            stringStream.SetData(new byte[0]);
            var guidStream = nameIdStorage.AddStream(PropertyTags.GuidStream);
            guidStream.SetData(new byte[0]);

            TopLevelProperties = new TopLevelProperties();
            NamedProperties = new NamedProperties(TopLevelProperties);
        }
        #endregion

        #region Save
        private void Save()
        {
            TopLevelProperties.AddProperty(PropertyTags.PR_MESSAGE_CLASS_W, ClassAsString);
            TopLevelProperties.WriteProperties(CompoundFile.RootStorage, MessageSize);
            NamedProperties.WriteProperties(CompoundFile.RootStorage);
            _saved = true;
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        internal void Save(string fileName)
        {
            Save();
            CompoundFile.Save(fileName);
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="stream" />
        /// </summary>
        /// <param name="stream"></param>
        internal void Save(Stream stream)
        {
            Save();
            CompoundFile.Save(stream);
        }
        #endregion

        #region AddProperty
        /// <summary>
        ///     Adds a custom property to the message or replaces it when it already exists
        /// </summary>
        /// <param name="propertyTag"><see cref="PropertyTag"/></param>
        /// <param name="value">The value of the property</param>
        /// <param name="flags"><see cref="PropertyFlags"/></param>
        /// <exception cref="MKMessageSaved">Raised when the mesage has already been saved with the Save method</exception>
        public void AddProperty(PropertyTag propertyTag, object value, PropertyFlags flags = PropertyFlags.PROPATTR_WRITABLE)
        {
            if (_saved)
                throw new MKMessageSaved("The message can't be modified when it already has been saved");

            TopLevelProperties.AddOrReplaceProperty(propertyTag, value, flags);
        }
        #endregion

        #region Dispose
        /// <summary>
        ///     Disposes this object and all its resources
        /// </summary>
        public void Dispose()
        {
            CompoundFile?.Close();
        }
        #endregion
    }
}
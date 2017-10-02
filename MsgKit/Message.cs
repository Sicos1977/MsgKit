//
// Message.cs
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using MsgKit.Enums;
using MsgKit.Exceptions;
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
        ///     The <see cref="OpenMcdf.CompoundFile" />
        /// </summary>
        internal readonly CompoundFile CompoundFile;

        /// <summary>
        ///     The message class
        /// </summary>
        /// <remarks>
        /// Not used yet, this property is for future use (when we are going to implement reading of MSG files)
        /// </remarks>
        internal MessageClass Class;
        #endregion

        #region Properties
        /// <summary>
        ///     Contains a number that indicates which icon to use when you display a group
        ///     of e-mail objects. Default set to <see cref="MessageIconIndex.NewMail" />
        /// </summary>
        /// <remarks>
        ///     This property, if it exists, is a hint to the client. The client may ignore the
        ///     value of this property.
        /// </remarks>
        public MessageIconIndex IconIndex { get; set; }

        ///// <summary>
        /////     Contains the sum, in bytes, of the sizes of all properties on a message object.
        ///// </summary>
        ///// <remarks>
        /////     It is recommended that message objects expose this property. The message size indicates the approximate number of
        /////     bytes that are transferred when the message is moved from one message store to another. Being the sum of the sizes
        /////     of all properties on the message object, it is usually considerably greater than the message text alone.
        ///// </remarks>
        //public long MessageSize { get; private set; }
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
            var nameIdStorage = CompoundFile.RootStorage.TryGetStorage(PropertyTags.NameIdStorage) ??
                                       CompoundFile.RootStorage.AddStorage(PropertyTags.NameIdStorage);

            var entryStream = nameIdStorage.AddStream(PropertyTags.EntryStream);
            entryStream.SetData(new byte[0]);
            var stringStream = nameIdStorage.AddStream(PropertyTags.StringStream);
            stringStream.SetData(new byte[0]);
            var guidStream = nameIdStorage.AddStream(PropertyTags.GuidStream);
            guidStream.SetData(new byte[0]);
        }
        #endregion

        #region Save
        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        internal void Save(string fileName)
        {
            CompoundFile.Save(fileName);
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="stream" />
        /// </summary>
        /// <param name="stream"></param>
        internal void Save(Stream stream)
        {
            CompoundFile.Save(stream);
        }
        #endregion

        #region GetString
        /// <summary>
        ///     Returns the string value for the given <paramref name="propertyTag" />.
        ///     <c>null</c> is returned when the property does not exists or no valid value is found
        /// </summary>
        /// <param name="propertyTag">
        ///     <see cref="PropertyTag" />
        /// </param>
        /// <returns></returns>
        /// <exception cref="MKInvalidProperty">
        ///     Raised when the <paramref name="propertyTag" /> is not of the type
        ///     <see cref="PropertyType.PT_STRING8" /> or <see cref="PropertyType.PT_UNICODE" />
        /// </exception>
        internal string GetString(PropertyTag propertyTag)
        {
            return GetString(new List<PropertyTag> {propertyTag});
        }

        /// <summary>
        ///     Returns the string value from the first item in the list of <paramref name="propertyTags" />
        ///     that gives back a valid value. <c>null</c> is returned when the property does not exists or
        ///     no valid value is found
        /// </summary>
        /// <param name="propertyTags">List of <see cref="PropertyTag" /></param>
        /// <returns></returns>
        /// <exception cref="MKInvalidProperty">
        ///     Raised when the <paramref name="propertyTags" /> is not of the type
        ///     <see cref="PropertyType.PT_STRING8" /> or <see cref="PropertyType.PT_UNICODE" />
        /// </exception>
        internal string GetString(List<PropertyTag> propertyTags)
        {
            string result = null;

            foreach (var propertyTag in propertyTags)
            {
                var stream = CompoundFile.RootStorage.TryGetStream(propertyTag.Name);
                if (stream != null)
                {
                    switch (propertyTag.Type)
                    {
                        case PropertyType.PT_STRING8:
                            result = Encoding.Default.GetString(stream.GetData());
                            break;

                        case PropertyType.PT_UNICODE:
                            result =
                                Encoding.UTF8.GetString(CompoundFile.RootStorage.GetStream(propertyTag.Name).GetData());
                            break;

                        default:
                            throw new MKInvalidProperty("The property is not of the type PT_STRING8 or PT_UNICODE");
                    }
                }

                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return null;
        }
        #endregion

        #region AddString
        /// <summary>
        ///     Adds the given single value <paramref name="propertyTag" />
        ///     to the message, any already existing <see cref="PropertyTag" /> is
        ///     overwritten.
        /// </summary>
        /// <param name="propertyTag">
        ///     <see cref="PropertyTag" />
        /// </param>
        /// <param name="value">The value</param>
        /// <returns></returns>
        /// <exception cref="MKInvalidProperty">
        ///     Raised when the <paramref name="propertyTag" /> is not of the type
        ///     <see cref="PropertyType.PT_STRING8" /> or <see cref="PropertyType.PT_UNICODE" />
        /// </exception>
        internal void AddString(PropertyTag propertyTag, string value)
        {
            var stream = CompoundFile.RootStorage.TryGetStream(propertyTag.Name);
            if (stream != null)
            {
                switch (propertyTag.Type)
                {
                    case PropertyType.PT_STRING8:
                    case PropertyType.PT_UNICODE:
                        stream.SetData(Encoding.UTF8.GetBytes(value));
                        break;

                    default:
                        throw new MKInvalidProperty("The property is not of the type PT_STRING8 or PT_UNICODE");
                }
            }
            else
            {
                stream = CompoundFile.RootStorage.AddStream(propertyTag.Name);
                stream.SetData(Encoding.Unicode.GetBytes(value));
            }
        }

        /// <summary>
        ///     Adds the given multivalue propertyTag to the message, any already existing <see cref="PropertyTag" /> is
        ///     overwritten.
        /// </summary>
        /// <param name="propertyTag">List of <see cref="PropertyTag" /></param>
        /// <param name="values">The values</param>
        /// <returns></returns>
        /// <exception cref="MKInvalidProperty">
        ///     Raised when the <paramref name="propertyTag" /> is not of the type
        ///     <see cref="PropertyType.PT_MV_STRING8" /> or <see cref="PropertyType.PT_MV_UNICODE" />
        /// </exception>
        internal void AddStrings(PropertyTag propertyTag, List<string> values)
        {
            //  “__substg1.0_<tag>-00000000”, “__substg1.0_<tag>-00000001”, etc…
            var index = 0;

            var name = propertyTag.Name + "-" + index.ToString().PadLeft(8, '0');
            var stream = CompoundFile.RootStorage.TryGetStream(name);
            while (stream != null)
            {
                index += 1;
                name = propertyTag.Name + "-" + index.ToString().PadLeft(8, '0');
                stream = CompoundFile.RootStorage.TryGetStream(name);
                CompoundFile.RootStorage.Delete(name);
            }

            index = 0;

            foreach (var value in values)
            {
                name = propertyTag.Name + "-" + index.ToString().PadLeft(8, '0');
                stream = CompoundFile.RootStorage.TryGetStream(name);
                if (stream != null)
                {
                    switch (propertyTag.Type)
                    {
                        case PropertyType.PT_MV_STRING8:
                        case PropertyType.PT_MV_UNICODE:
                            stream.SetData(Encoding.Unicode.GetBytes(value));
                            break;

                        default:
                            throw new MKInvalidProperty("The property is not of the type PT_MV_STRING8 or PT_MV_UNICODE");
                    }
                }
                else
                {
                    stream = CompoundFile.RootStorage.AddStream(propertyTag.Name);
                    stream.SetData(Encoding.Unicode.GetBytes(value));
                }

                index += 1;
            }
        }
        #endregion

        #region AddNamedProperty
        /// <summary>
        ///     Add's a custom named property to the <see cref="Message"/>
        /// </summary>
        /// <param name="name">The property name</param>
        /// <param name="value">The value</param>
        /// <param name="guid">The <see cref="Guid"/> for the <see cref="NamedPropertyTags"/>, when
        /// left blank a new guid is generated automaticly</param>
        /// <remarks>
        /// Not used yet, this method is for future use
        /// </remarks>
        public void AddNamedProperty(string name, string value, Guid? guid)
        {
            // Get next available property id from string stream
            //var prop = new PropertyTag();
            // TODO add NamedProperty class
        }
        #endregion

        #region Dispose
        /// <summary>
        ///     Disposes this object and all its resources
        /// </summary>
        public void Dispose()
        {
            if (CompoundFile != null)
                CompoundFile.Close();
        }
        #endregion
    }
}
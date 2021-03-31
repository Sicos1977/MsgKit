//
// Contact.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com> and Travis Semple
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

using MsgKit.Enums;
using OpenMcdf;

namespace MsgKit
{
    /// <summary>
    /// 
    /// </summary>
    public class Contact : Email
    {
        #region Properties
        /// <summary>
        ///     The name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        ///     The company's main phone number
        /// </summary>
        public string CompanyMainPhoneNumber { get; set; } 

        /// <summary>
        ///     The job title    
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        ///     E-mail address 1
        /// </summary>
        public Address Email1 { get; set; }

        /// <summary>
        ///     E-mail address 2
        /// </summary>
        public Address Email2 { get; set; }

        /// <summary>
        ///     E-mail address 3
        /// </summary>
        public Address Email3 { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates this object and sets all the needed properties
        /// </summary>
        /// <param name="sender">The <see cref="Email.Sender"/> of the E-mail</param>
        /// <param name="representing">The <see cref="MsgKit.Representing"/> sender of the E-mail</param>
        /// <param name="subject">The subject of the E-mail</param>
        /// <param name="draft">Set to <c>true</c> to save the E-mail as a draft message</param>
        /// <param name="readReceipt">Set to <c>true</c> to request a read receipt for the E-mail</param>
        public Contact(
            Sender sender, 
            Representing representing, 
            string subject, 
            bool draft = false, 
            bool readReceipt = false) : base(sender, representing, subject, draft, readReceipt)
        {
        }

        /// <summary>
        ///     Creates this object and sets all the needed properties
        /// </summary>
        /// <param name="sender">The <see cref="Email.Sender"/> of the E-mail</param>
        /// <param name="subject">The subject of the E-mail</param>
        /// <param name="draft">Set to <c>true</c> to save the E-mail as a draft message</param>
        /// <param name="readReceipt">Set to <c>true</c> to request a read receipt for the E-mail</param>
        public Contact(
            Sender sender, 
            string subject, 
            bool draft = false, 
            bool readReceipt = false) : base(sender, subject, draft, readReceipt)
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
            Class = MessageClass.IPM_Contact;
            TopLevelProperties.AddProperty(PropertyTags.PR_COMPANY_NAME_W, CompanyName);
            TopLevelProperties.AddProperty(PropertyTags.PR_COMPANY_MAIN_PHONE_NUMBER_W, CompanyMainPhoneNumber);
            TopLevelProperties.AddProperty(PropertyTags.PR_TITLE_W, JobTitle);

            if (Email1 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Email1.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1DisplayName, Email1.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailType, Email1.AddressTypeString);
                // Figure out if the entry id also needs to be added
            }

            if (Email2 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Email2.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1DisplayName, Email2.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailType, Email2.AddressTypeString);
                // Figure out if the entry id also needs to be added
            }

            if (Email3 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Email3.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1DisplayName, Email3.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailType, Email3.AddressTypeString);
                // Figure out if the entry id also needs to be added
            }

            // Etc ...
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
}

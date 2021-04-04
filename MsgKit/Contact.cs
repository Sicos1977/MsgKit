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

        /// <summary>
        ///     Fax 1
        /// </summary>
        public Address Fax1 { get; set; }

        /// <summary>
        ///     Fax 2
        /// </summary>
        public Address Fax2 { get; set; }

        /// <summary>
        ///     Fax  3
        /// </summary>
        public Address Fax3 { get; set; }

        /// <summary>
        ///     The work details
        /// </summary>
        public ContactWork Work { get; set; }

        /// <summary>
        ///     The business details
        /// </summary>
        public ContactBusiness Business { get; set; }

        /// <summary>
        ///     The home details
        /// </summary>
        public ContactHome Home { get; set; }

        /// <summary>
        ///     The other address
        /// </summary>
        public ContactOther Other{ get; set; }
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

            if (!string.IsNullOrWhiteSpace(CompanyName))
                TopLevelProperties.AddProperty(PropertyTags.PR_COMPANY_NAME_W, CompanyName);

            if (!string.IsNullOrWhiteSpace(CompanyMainPhoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_COMPANY_MAIN_PHONE_NUMBER_W, CompanyMainPhoneNumber);

            if (!string.IsNullOrWhiteSpace(JobTitle))
                TopLevelProperties.AddProperty(PropertyTags.PR_TITLE_W, JobTitle);

            if (Work != null)
            {
                if (!string.IsNullOrWhiteSpace(Work.Street))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddressStreet, Work.Street);

                if (!string.IsNullOrWhiteSpace(Work.PostalCode))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddressPostalCode, Work.PostalCode);

                if (!string.IsNullOrWhiteSpace(Work.PostOfficeBox))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddressPostOfficeBox, Work.PostOfficeBox);

                if (!string.IsNullOrWhiteSpace(Work.City))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddressCity, Work.City);

                if (!string.IsNullOrWhiteSpace(Work.Country))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddressCountry, Work.Country);

                if (!string.IsNullOrWhiteSpace(Work.CountryCode))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddressCountryCode, Work.CountryCode);
            }

            if (Business != null)
            {
                if (!string.IsNullOrWhiteSpace(Business.Street))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_ADDRESS_STREET_W, Business.Street);

                if (!string.IsNullOrWhiteSpace(Business.City))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_ADDRESS_CITY_W, Business.City);

                if (!string.IsNullOrWhiteSpace(Business.Country))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_ADDRESS_COUNTRY_W, Business.Country);

                if (!string.IsNullOrWhiteSpace(Business.PostalCode))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_ADDRESS_POSTAL_CODE_W, Business.PostalCode);

                if (!string.IsNullOrWhiteSpace(Business.State))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_ADDRESS_STATE_OR_PROVINCE_W, Business.State);

                if (!string.IsNullOrWhiteSpace(Business.HomePage))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_HOME_PAGE_W, Business.HomePage);

                if (!string.IsNullOrWhiteSpace(Business.TelePhoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_TELEPHONE_NUMBER_W, Business.TelePhoneNumber);
                
                if (!string.IsNullOrWhiteSpace(Business.FaxNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_FAX_NUMBER_W, Business.FaxNumber);
            }
            
            if (Home != null)
            {
                if (!string.IsNullOrWhiteSpace(Home.Street))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_STREET_W, Home.Street);

                if (!string.IsNullOrWhiteSpace(Home.PostalCode))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_POSTAL_CODE_W, Home.PostalCode);

                if (!string.IsNullOrWhiteSpace(Home.City))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_CITY_W, Home.City);

                if (!string.IsNullOrWhiteSpace(Home.Country))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_COUNTRY_W, Home.Country);

                if (!string.IsNullOrWhiteSpace(Home.TelePhoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_TELEPHONE_NUMBER_W, Home.TelePhoneNumber);

                if (!string.IsNullOrWhiteSpace(Home.TelePhoneNumber2))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME2_TELEPHONE_NUMBER_W, Home.TelePhoneNumber2);

                if (!string.IsNullOrWhiteSpace(Home.FaxNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_FAX_NUMBER_W, Home.FaxNumber);
            }

            if (Other != null)
            {
                if (!string.IsNullOrWhiteSpace(Other.Street))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_ADDRESS_STREET_W, Other.Street);

                if (!string.IsNullOrWhiteSpace(Other.PostalCode))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_ADDRESS_POSTAL_CODE_W, Other.PostalCode);

                if (!string.IsNullOrWhiteSpace(Other.City))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_ADDRESS_CITY_W, Other.City);

                if (!string.IsNullOrWhiteSpace(Other.Country))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_ADDRESS_COUNTRY_W, Other.Country);

                if (!string.IsNullOrWhiteSpace(Other.State))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_ADDRESS_STATE_OR_PROVINCE_W, Other.State);

                if (!string.IsNullOrWhiteSpace(Other.TelePhoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_TELEPHONE_NUMBER_W, Other.TelePhoneNumber);
            }

            //NamedProperties.AddProperty(NamedPropertyTags.PidLidHomeAddress, WorkAddress);
            //NamedProperties.AddProperty(NamedPropertyTags.PidLidHomeAddressCountryCode, WorkAddress);
            //NamedProperties.AddProperty(NamedPropertyTags.PidLidOtherAddress, OtherAddress);
            //NamedProperties.AddProperty(NamedPropertyTags.PidLidOtherAddressCountryCode, OtherAddress);
            
            NamedProperties.AddProperty(NamedPropertyTags.PidLidHtml, WebPage);
            
            if (Email1 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Email1.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1DisplayName, Email1.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1AddressType, Email1.AddressTypeString);
                // Figure out if the entry id also needs to be added
            }

            if (Email2 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2EmailAddress, Email2.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2DisplayName, Email2.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2AddressType, Email2.AddressTypeString);
            }

            if (Email3 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3EmailAddress, Email3.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3DisplayName, Email3.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3AddressType, Email3.AddressTypeString);
            }

            if (Fax1 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1EmailAddress, Fax1.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1OriginalDisplayName, Fax1.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1AddressType, Fax1.AddressTypeString);
            }

            if (Fax2 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Fax2.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax2OriginalDisplayName, Fax2.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax2AddressType, Fax2.AddressTypeString);
            }

            if (Fax3 != null)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Fax3.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax3OriginalDisplayName, Fax3.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFax3AddressType, Fax3.AddressTypeString);
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

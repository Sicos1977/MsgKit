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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MsgKit.Enums;
using OpenMcdf;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace MsgKit
{
    /// <summary>
    ///     A class used to make a new Outlook contact MSG file
    /// </summary>
    public class Contact : Email
    {
        #region Properties
        /// <summary>
        ///     The contact image, this needs to be an JPG file
        /// </summary>
        public byte[] ContactPicture { get; set; }

        /// <summary>
        ///     File the contact card as ...
        /// </summary>
        public string FileUnder { get; set; }

        /// <summary>
        ///     The instant messaging address
        /// </summary>
        public string InstantMessagingAddress { get; set; }

        /// <summary>
        ///     Indicates whether the end-user wants this message object hidden from other users who have access to the message object
        /// </summary>
        public bool Private { get; set; }

        /// <summary>
        ///     The birth day
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        ///     Specifies the wedding anniversary
        /// </summary>
        public DateTime? WeddingAnniversary { get; set; }

        /// <summary>
        ///     Information about the assistant
        /// </summary>
        public ContactAssistant Assistant { get; set; }

        /// <summary>
        ///     Contains a telephone number that the message recipient can use to reach the sender
        /// </summary>
        public string CallBackTelePhoneNumber { get; set; }

        /// <summary>
        ///     Contains the recipient's car telephone number
        /// </summary>
        public string CarTelePhoneNumber { get; set; }

        /// <summary>
        ///     The names of the childrens
        /// </summary>
        public List<string> ChildrensNames { get; set; }

        /// <summary>
        ///     The company's main info
        /// </summary>
        public ContactCompanyMain CompanyMain { get; set; }

        /// <summary>
        ///     The department name
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Contains a generational abbreviation that follows the full name of the recipient
        /// </summary>
        public string Generation { get; set; }

        /// <summary>
        ///     ontains the first or given name of the recipient
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        ///     Contains the initials for parts of the full name of the recipient
        /// </summary>
        public string Initials { get;set; }

        /// <summary>
        ///     Contains the recipient's ISDN-capable telephone number
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string ISDNNumber { get; set; }

        /// <summary>
        ///     Contains a value that indicates the language in which the messaging user is writing messages
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Contains the location of the recipient in a format that is useful to the recipient's organization.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        ///     Contains the name of the recipient's manager
        /// </summary>
        public string ManagerName { get; set; }

        /// <summary>
        ///     Contains the middle name of a contact
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        ///     Contains the recipient's cellular telephone number
        /// </summary>
        public string MobileTelephoneNumber { get; set; }

        /// <summary>
        ///     Contains the nickname of the contact
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        ///     Contains the recipient's office location
        /// </summary>
        public string OfficeLocation { get; set; }

        /// <summary>
        ///     Contains the recipient's office location
        /// </summary>
        public string OfficeTelephoneNumber { get; set; }
        
        /// <summary>
        ///     Contains the URL of a user's personal home page
        /// </summary>
        public string PersonalHomePage { get;set; }

        /// <summary>
        ///     Contains the recipient's postal address
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        ///     Contains the telephone number of the recipient's primary fax machine
        /// </summary>
        public string PrimaryFaxNumber { get; set; }
        
        /// <summary>
        ///     Contains the recipient's primary telephone number
        /// </summary>
        public string PrimaryTelephoneNumber { get; set; }

        /// <summary>
        ///     Contains the profession of the user
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        ///     Contains the recipient's radio telephone number
        /// </summary>
        public string RadioTelephoneNumber { get; set; }

        /// <summary>
        ///     Contains the user's spouse name
        /// </summary>
        public string SpouseName { get; set; }

        /// <summary>
        ///     Contains the last or surname of the recipient
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        ///     Contains the recipient's telex number
        /// </summary>
        public string TelexNumber { get; set; }

        /// <summary>
        ///      Contains the recipient's job title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Contains the telephone number for the contact's text telephone (TTY) or telecommunication device for the deaf (TDD)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string TTYTDDPhoneNumber { get; set; }

        /// <summary>
        ///     Contains the recipient's pager telephone number
        /// </summary>
        public string PagerTelephoneNumber { get; set; }

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

        ///// <summary>
        /////     Fax 1
        ///// </summary>
        //public string Fax1 { get; set; }

        ///// <summary>
        /////     Fax 2
        ///// </summary>
        //public string Fax2 { get; set; }

        ///// <summary>
        /////     Fax  3
        ///// </summary>
        //public string Fax3 { get; set; }

        /// <summary>
        ///     Yomi name and Yomi company name are fields for entering the phonetic equivalent for Japanese names.
        ///     In Japan, there is commonly a Furigana equivalent for the Kanji name that is used for sorting and searching.
        /// </summary>
        public ContactYomi Yomi { get; set; }

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

        /// <summary>
        ///     Specifies which physical address is the contact's mailing address
        /// </summary>
        public PostalAddressId PostalAddressId { get; set; }
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

            if (ContactPicture != null)
            {
                var memoryStream = new MemoryStream(ContactPicture);
                Attachments.AddContactPhoto(memoryStream, "ContactPicture.jpg");
                NamedProperties.AddProperty(NamedPropertyTags.PidLidHasPicture, true);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidSmartNoAttach, true);
            }
            else
                NamedProperties.AddProperty(NamedPropertyTags.PidLidHasPicture, false);

            if (!string.IsNullOrWhiteSpace(FileUnder))
                NamedProperties.AddProperty(NamedPropertyTags.PidLidFileUnder, FileUnder);
                        
            if (!string.IsNullOrWhiteSpace(InstantMessagingAddress))
                NamedProperties.AddProperty(NamedPropertyTags.PidLidInstantMessagingAddress, InstantMessagingAddress);

            NamedProperties.AddProperty(NamedPropertyTags.PidLidPrivate, Private);

            if (BirthDay.HasValue)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidBirthdayLocal, BirthDay);
                TopLevelProperties.AddProperty(PropertyTags.PR_BIRTHDAY, BirthDay);
            }

            if (WeddingAnniversary.HasValue)
            {
                NamedProperties.AddProperty(NamedPropertyTags.PidLidWeddingAnniversaryLocal, WeddingAnniversary);
                TopLevelProperties.AddProperty(PropertyTags.PR_WEDDING_ANNIVERSARY, WeddingAnniversary);
            }

            if (Assistant != null)
            {
                if (!string.IsNullOrWhiteSpace(Assistant.Name))
                    TopLevelProperties.AddProperty(PropertyTags.PR_ASSISTANT_W, Assistant.Name);

                if (!string.IsNullOrWhiteSpace(Assistant.TelephoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_ASSISTANT_TELEPHONE_NUMBER_W, Assistant.TelephoneNumber);
            }

            if (!string.IsNullOrWhiteSpace(CallBackTelePhoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_CALLBACK_TELEPHONE_NUMBER_W, CallBackTelePhoneNumber);

            if (!string.IsNullOrWhiteSpace(CarTelePhoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_CAR_TELEPHONE_NUMBER_W, CarTelePhoneNumber);

            if (ChildrensNames != null)
                TopLevelProperties.AddProperty(PropertyTags.PR_CHILDRENS_NAMES_W, string.Join(", ", ChildrensNames));

            if (CompanyMain != null)
            {
                if (!string.IsNullOrWhiteSpace(CompanyMain.Name))
                    TopLevelProperties.AddProperty(PropertyTags.PR_COMPANY_NAME_W, CompanyMain.Name);

                if (!string.IsNullOrWhiteSpace(CompanyMain.TelephoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_COMPANY_MAIN_PHONE_NUMBER_W, CompanyMain.TelephoneNumber);
            }

            if (!string.IsNullOrWhiteSpace(DepartmentName))
                TopLevelProperties.AddProperty(PropertyTags.PR_DEPARTMENT_NAME_W, DepartmentName);
            
            if (!string.IsNullOrWhiteSpace(Generation))
                TopLevelProperties.AddProperty(PropertyTags.PR_GENERATION_W, Generation);
                        
            if (!string.IsNullOrWhiteSpace(GivenName))
                TopLevelProperties.AddProperty(PropertyTags.PR_GIVEN_NAME_W, GivenName);

            if (!string.IsNullOrWhiteSpace(Initials))
                TopLevelProperties.AddProperty(PropertyTags.PR_INITIALS_W, Initials);
            
            if (!string.IsNullOrWhiteSpace(ISDNNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_ISDN_NUMBER_W, ISDNNumber);

            if (!string.IsNullOrWhiteSpace(Language))
                TopLevelProperties.AddProperty(PropertyTags.PR_LANGUAGE_W, Language);

            if (!string.IsNullOrWhiteSpace(Location))
                TopLevelProperties.AddProperty(PropertyTags.PR_LOCATION_W, Location);

            if (!string.IsNullOrWhiteSpace(ManagerName))
                TopLevelProperties.AddProperty(PropertyTags.PR_MANAGER_NAME_W, ManagerName);

            if (!string.IsNullOrWhiteSpace(MiddleName))
                TopLevelProperties.AddProperty(PropertyTags.PR_MIDDLE_NAME_W, MiddleName);
            
            if (!string.IsNullOrWhiteSpace(MobileTelephoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_MOBILE_TELEPHONE_NUMBER_W, MobileTelephoneNumber);

            if (!string.IsNullOrWhiteSpace(NickName))
                TopLevelProperties.AddProperty(PropertyTags.PR_NICKNAME_W, NickName);
            
            if (!string.IsNullOrWhiteSpace(OfficeLocation))
                TopLevelProperties.AddProperty(PropertyTags.PR_OFFICE_LOCATION_W, OfficeLocation);
                        
            if (!string.IsNullOrWhiteSpace(OfficeTelephoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS2_TELEPHONE_NUMBER_W, OfficeTelephoneNumber);

            if (!string.IsNullOrWhiteSpace(PersonalHomePage))
                TopLevelProperties.AddProperty(PropertyTags.PR_PERSONAL_HOME_PAGE_W, PersonalHomePage);
                                    
            if (!string.IsNullOrWhiteSpace(PostalAddress))
                TopLevelProperties.AddProperty(PropertyTags.PR_POSTAL_ADDRESS_W, PostalAddress);

            var addressBookProviderEmailList = new List<long>();

            if (!string.IsNullOrWhiteSpace(PrimaryFaxNumber))
            {
                TopLevelProperties.AddProperty(PropertyTags.PR_PRIMARY_FAX_NUMBER_W, PrimaryFaxNumber);
                addressBookProviderEmailList.Add(5);
            }

            if (!string.IsNullOrWhiteSpace(PrimaryTelephoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_PRIMARY_TELEPHONE_NUMBER_W, PrimaryTelephoneNumber);
            
            if (!string.IsNullOrWhiteSpace(Profession))
                TopLevelProperties.AddProperty(PropertyTags.PR_PROFESSION_W, Profession);
            
            if (!string.IsNullOrWhiteSpace(RadioTelephoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_RADIO_TELEPHONE_NUMBER_W, RadioTelephoneNumber);
            
            if (!string.IsNullOrWhiteSpace(SpouseName))
                TopLevelProperties.AddProperty(PropertyTags.PR_SPOUSE_NAME_W, SpouseName);
            
            if (!string.IsNullOrWhiteSpace(SurName))
                TopLevelProperties.AddProperty(PropertyTags.PR_SURNAME_W, SurName);
            
            if (!string.IsNullOrWhiteSpace(TelexNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_TELEX_NUMBER_W, TelexNumber);
            
            if (!string.IsNullOrWhiteSpace(Title))
                TopLevelProperties.AddProperty(PropertyTags.PR_TITLE_W, Title);
                        
            if (!string.IsNullOrWhiteSpace(TTYTDDPhoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_TTYTDD_PHONE_NUMBER_W, TTYTDDPhoneNumber);

            if (!string.IsNullOrWhiteSpace(PagerTelephoneNumber))
                TopLevelProperties.AddProperty(PropertyTags.PR_PAGER_TELEPHONE_NUMBER_W, PagerTelephoneNumber);

            var emailList = new List<long>();

            if (Email1 != null)
            {
                emailList.Add(NamedPropertyTags.PidLidEmail1DisplayName.Id);
                addressBookProviderEmailList.Add(0);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1EmailAddress, Email1.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1DisplayName, Email1.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1OriginalDisplayName, Email1.OriginalDisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1AddressType, Email1.AddressTypeString);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail1OriginalEntryId, Email1.OneOffEntryId.ToByteArray());
            }

            if (Email2 != null)
            {
                emailList.Add(NamedPropertyTags.PidLidEmail2DisplayName.Id);
                addressBookProviderEmailList.Add(1);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2EmailAddress, Email2.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2DisplayName, Email2.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2OriginalDisplayName, Email2.OriginalDisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2AddressType, Email2.AddressTypeString);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail2OriginalEntryId, Email2.OneOffEntryId.ToByteArray());
            }

            if (Email3 != null)
            {
                emailList.Add(NamedPropertyTags.PidLidEmail3DisplayName.Id);
                addressBookProviderEmailList.Add(2);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3EmailAddress, Email3.Email);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3DisplayName, Email3.DisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3OriginalDisplayName, Email3.OriginalDisplayName);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3AddressType, Email3.AddressTypeString);
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmail3OriginalEntryId, Email3.OneOffEntryId.ToByteArray());
            }

            if (emailList.Any())
                NamedProperties.AddProperty(NamedPropertyTags.PidLidEmailList, emailList.ToArray());

            //if (!string.IsNullOrWhiteSpace(Fax1))
            //{
            //    var fax1 = new Address(Fax1, SubjectNormalized, AddressType.Fax);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1EmailAddress, fax1.Email);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1OriginalDisplayName, fax1.OriginalDisplayName);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1AddressType, fax1.AddressTypeString);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax1OriginalEntryId, fax1.OneOffEntryId.ToByteArray());
            //}

            //if (!string.IsNullOrWhiteSpace(Fax2))
            //{
            //    var fax2 = new Address(Fax2, SubjectNormalized, AddressType.Fax);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax2EmailAddress, fax2.Email);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax2OriginalDisplayName, fax2.OriginalDisplayName);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax2AddressType, fax2.AddressTypeString);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax2OriginalEntryId, fax2.OneOffEntryId.ToByteArray());
            //}

            //if (!string.IsNullOrWhiteSpace(Fax3))
            //{
            //    var fax3 = new Address(Fax3, SubjectNormalized, AddressType.Fax);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax3EmailAddress, fax3.Email);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax3OriginalDisplayName, fax3.OriginalDisplayName);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax3AddressType, fax3.AddressTypeString);
            //    NamedProperties.AddProperty(NamedPropertyTags.PidLidFax3OriginalEntryId, fax3.OneOffEntryId.ToByteArray());
            //}

            if (Yomi != null)
            {
                if (!string.IsNullOrWhiteSpace(Yomi.FirstName))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidYomiFirstName, Yomi.FirstName);

                if (!string.IsNullOrWhiteSpace(Yomi.LastName))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidYomiLastName, Yomi.LastName);

                if (!string.IsNullOrWhiteSpace(Yomi.CompanyName))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidYomiCompanyName, Yomi.CompanyName);
            }

            if (Work != null)
            {
                if (!string.IsNullOrWhiteSpace(Work.Address))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidWorkAddress, Work.Address);

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

                if (!string.IsNullOrWhiteSpace(Business.TelephoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_TELEPHONE_NUMBER_W, Business.TelephoneNumber);

                if (!string.IsNullOrWhiteSpace(Business.FaxNumber))
                {
                    TopLevelProperties.AddProperty(PropertyTags.PR_BUSINESS_FAX_NUMBER_W, Business.FaxNumber);
                    addressBookProviderEmailList.Add(3);
                }
            }
            
            if (Home != null)
            {
                if (!string.IsNullOrWhiteSpace(Home.Address))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidHomeAddress, Home.Address);

                if (!string.IsNullOrWhiteSpace(Home.Street))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_STREET_W, Home.Street);

                if (!string.IsNullOrWhiteSpace(Home.PostalCode))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_POSTAL_CODE_W, Home.PostalCode);

                if (!string.IsNullOrWhiteSpace(Home.City))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_CITY_W, Home.City);

                if (!string.IsNullOrWhiteSpace(Home.Country))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_ADDRESS_COUNTRY_W, Home.Country);

                if (!string.IsNullOrWhiteSpace(Home.TelephoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_TELEPHONE_NUMBER_W, Home.TelephoneNumber);

                if (!string.IsNullOrWhiteSpace(Home.TelephoneNumber2))
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME2_TELEPHONE_NUMBER_W, Home.TelephoneNumber2);

                if (!string.IsNullOrWhiteSpace(Home.FaxNumber))
                {
                    TopLevelProperties.AddProperty(PropertyTags.PR_HOME_FAX_NUMBER_W, Home.FaxNumber);
                    addressBookProviderEmailList.Add(4);
                }
            }

            if (addressBookProviderEmailList.Any())
                NamedProperties.AddProperty(NamedPropertyTags.PidLidAddressBookProviderEmailList, addressBookProviderEmailList.OrderBy(m => m).ToArray());

            if (Other != null)
            {
                if (!string.IsNullOrWhiteSpace(Other.Address))
                    NamedProperties.AddProperty(NamedPropertyTags.PidLidOtherAddress, Other.Address);
                
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

                if (!string.IsNullOrWhiteSpace(Other.TelephoneNumber))
                    TopLevelProperties.AddProperty(PropertyTags.PR_OTHER_TELEPHONE_NUMBER_W, Other.TelephoneNumber);
            }
        }
        #endregion

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

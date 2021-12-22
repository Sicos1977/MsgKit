//
// MainForm
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
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MsgKit;
using MsgKit.Enums;
using MsgKitTestTool.Properties;

namespace MsgKitTestTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var email = new Email(
                new Sender(SenderTextBox.Text, string.Empty),
                SubjectTextBox.Text, 
                DraftMessageCheckBox.Checked,
                ReadReceiptCheckBox.Checked))
            {
                email.Recipients.AddTo(ToTextBox.Text);
                email.Recipients.AddCc(CcTextBox.Text);
                email.Recipients.AddBcc(BccTextBox.Text);
                email.Subject = SubjectTextBox.Text;
                email.BodyText = TextBodyTextBox.Text;
                email.BodyHtml = HtmlBodyTextBox.Text;
                email.SentOn = SentOnDatePicker.Value.ToUniversalTime();
                
                switch (ImportanceComboBox.Text)
                {
                    case "Low":
                        email.Importance = MessageImportance.IMPORTANCE_LOW;
                        break;

                    case "High":
                        email.Importance = MessageImportance.IMPORTANCE_HIGH;
                        break;

                    default:
                        email.Importance = MessageImportance.IMPORTANCE_NORMAL;
                        break;
                }

                email.Attachments.Add("Images\\peterpan.jpg");
                email.Attachments.Add("Images\\tinkerbell.jpg", -1, true, "tinkerbell.jpg");
                email.Save("d:\\email.msg");
            }

            System.Diagnostics.Process.Start("d:\\email.msg");
        }

        private void Eml2MsgButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            var openFileDialog1 = new OpenFileDialog
            {
                // ReSharper disable once LocalizableElement
                Filter = "E-mail|*.eml",
                FilterIndex = 1,
                Multiselect = false
            };

            if (Directory.Exists(Settings.Default.InitialDirectory))
                openFileDialog1.InitialDirectory = Settings.Default.InitialDirectory;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
                var emlFileName = openFileDialog1.FileName;
                var msgFileName = Path.ChangeExtension(emlFileName, ".msg");
                Converter.ConvertEmlToMsg(emlFileName, msgFileName);
            }
        }

        private void ReadMsgFileButton_Click(object sender, EventArgs e)
        {
            //var msg = new CompoundFile(@"d:\naamloos.msg");
            //var storage = msg.RootStorage.GetStorage("__nameid_version1.0");
            //var namedProperties = new NamedProperties(storage);
        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            using (var contact = new Contact(
                new Sender(SenderTextBox.Text, string.Empty),
                SubjectTextBox.Text,
                DraftMessageCheckBox.Checked,
                ReadReceiptCheckBox.Checked))
            {
                contact.Recipients.AddTo(ToTextBox.Text);
                contact.Recipients.AddCc(CcTextBox.Text);
                contact.Recipients.AddBcc(BccTextBox.Text);
                contact.Subject = SubjectTextBox.Text;
                contact.BodyText = TextBodyTextBox.Text;
                contact.BodyHtml = HtmlBodyTextBox.Text;
                contact.SentOn = SentOnDatePicker.Value.ToUniversalTime();

                switch (ImportanceComboBox.Text)
                {
                    case "Low":
                        contact.Importance = MessageImportance.IMPORTANCE_LOW;
                        break;

                    case "High":
                        contact.Importance = MessageImportance.IMPORTANCE_HIGH;
                        break;

                    default:
                        contact.Importance = MessageImportance.IMPORTANCE_NORMAL;
                        break;
                }

                contact.FileUnder = "File under";
                contact.InstantMessagingAddress = "Instant messaging address";
                contact.Private = false;
                contact.BirthDay = DateTime.Now;
                contact.WeddingAnniversary = DateTime.Now;
                contact.Assistant = new ContactAssistant {Name = "Assistant name", TelephoneNumber = "Assistant telephone number"};
                contact.CallBackTelePhoneNumber = "callback telephone number";
                contact.CarTelePhoneNumber = "car telephone number";
                contact.ChildrensNames = new List<string> {"First child name", "Second child name", "Third child name"};
                contact.CompanyMain = new ContactCompanyMain { Name = "Company main name", TelephoneNumber = "Company main telephone number"};
                contact.DepartmentName = "Department name";
                contact.Generation = "Generation";
                contact.GivenName = "GivenName";
                contact.Initials = "Initials";
                contact.ISDNNumber = "ISDN number";
                contact.Language = "Language";
                contact.Location = "Location";
                contact.ManagerName = "Manager name";
                contact.MiddleName = "Middle name";
                contact.MobileTelephoneNumber = "Mobile telephone number";
                contact.NickName = "Nick name";
                contact.OfficeLocation = "Office location";
                contact.PersonalHomePage = "Personal home-page";
                contact.PostalAddress = "Postal address";
                contact.PrimaryFaxNumber = "Primary fax number";
                contact.PrimaryTelephoneNumber = "Primary telephone number";
                contact.Profession = "Profession";
                contact.RadioTelephoneNumber = "Radio telephone number";
                contact.SpouseName = "Spouse name";
                contact.SurName = "Sur name";
                contact.TelexNumber = "Telex number";
                contact.Title = "Title";
                contact.TTYTDDPhoneNumber = "TTYTDD phone number";
                contact.Email1 = new Address("email1@neverland.com", "email1");
                contact.Email2 = new Address("email2@neverland.com", "email2");
                contact.Email3 = new Address("email3@neverland.com", "email3");
                //contact.Fax1 = "fax1@1234567890";
                //contact.Fax2 = "fax2@1234567890";
                //contact.Fax3 = "fax3@1234567890";
                contact.OfficeTelephoneNumber = "Office telephone number";
                contact.InstantMessagingAddress = "Instant messaging address";
                contact.Yomi = new ContactYomi { CompanyName = "Yomi company name", FirstName = "Yomi first name", LastName = "Yomi last name"};

                contact.Work = new ContactWork
                {
                    TelephoneNumber = "Contact telephone number",
                    City = "Contact city",
                    Country = "Contact country",
                    CountryCode = "Contact country code",
                    PostOfficeBox = "Contact post office box",
                    PostalCode = "Contact postal code",
                    Street = "Contact street",
                    Address = "Contact\nBla bla\nBla die bla\nBLa die bla die bla"
                };

                contact.Business = new ContactBusiness
                {
                    TelephoneNumber = "Business telephone number",
                    FaxNumber = "Business fax number",
                    HomePage = "Business home-page",
                    City = "Business city",
                    Country = "Business country",
                    PostalCode = "Business postal code",
                    State = "Business state",
                    Street = "Business street",
                    Address = "Business\nBla bla\nBla die bla\nBLa die bla die bla"
                };
                
                contact.Home = new ContactHome
                {
                    TelephoneNumber = "Home telephone number",
                    TelephoneNumber2 = "Home telephone number 2",
                    FaxNumber = "Home faxnumber",
                    City = "Home city",
                    Country = "Home country",
                    PostalCode = "Home postal code",
                    State = "Home state",
                    Street = "Home street",
                    Address = "Home\nBla bla\nBla die bla\nBLa die bla die bla"
                };

                contact.Other = new ContactOther
                {
                    TelephoneNumber = "Other telephone number",
                    City = "Other city",
                    Country = "Other country",
                    PostalCode = "Other postal code",
                    State = "Other state",
                    Street = "Other street",
                    Address = "Other\nBla bla\nBla die bla\nBLa die bla die bla"
                };

                contact.PagerTelephoneNumber = "Pager telephone number";
                contact.PostalAddressId = PostalAddressId.HOME_ADDRESS;

                contact.ContactPicture = File.ReadAllBytes("Images\\tinkerbell.jpg");
                contact.IconIndex = MessageIconIndex.UnsentMail;
                contact.Save("d:\\contact.msg");
            }

            System.Diagnostics.Process.Start("d:\\contact.msg");
        }
    }
}

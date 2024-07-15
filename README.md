## What is MsgKit?

MsgKit is a 100% managed C# .NET 4.6.2, .NET Standard 2.0 and .NET Standard 2.1 assembly (no PINVOKE or whatsoever) which may be used for the creation of messages (E-Mail, Appointments, Journals and Stickey Notes) that are Outlook compatible

## License Information

MsgKit is Copyright (C) 2015-2024 Kees van Spelde (Magic-Sessions) and is licensed under the MIT license:

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

## Installing via NuGet

[![NuGet](https://img.shields.io/nuget/v/MSGKit.svg?style=flat-square)](https://www.nuget.org/packages/MSGKit)

The easiest way to install MsgKit is via NuGet.

In Visual Studio's Package Manager Console, simply enter the following command:

    Install-Package MsgKit 

### Creating an e-mail

```csharp
using (var email = new Email(
        new Sender("peterpan@neverland.com", "Peter Pan"),
        new Representing("tinkerbell@neverland.com", "Tinkerbell"),
        "Hello Neverland subject"))
{
    email.Recipients.AddTo("captainhook@neverland.com", "Captain Hook");
    email.Recipients.AddCc("crocodile@neverland.com", "The evil ticking crocodile");
    email.Subject = "This is the subject";
    email.BodyText = "Hello Neverland text";
    email.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>";
    email.Importance = MessageImportance.IMPORTANCE_HIGH;
    email.IconIndex = MessageIconIndex.ReadMail;
    email.Attachments.Add(@"d:\crocodile.jpg");
    email.Save(@"c:\email.msg");

    // Show the E-mail
    System.Diagnostics.Process.Start(@"c:\Email.msg");
}
```

### Creating an Appointment

```csharp
using (var appointment = new Appointment(
    new Sender("peterpan@neverland.com", "Peter Pan"),
    new Representing("tinkerbell@neverland.com", "Tinkerbell"),
    "Hello Neverland subject")) 
{
    appointment.Recipients.AddTo("captainhook@neverland.com", "Captain Hook");
    appointment.Recipients.AddCc("crocodile@neverland.com", "The evil ticking crocodile");
    appointment.Subject = "This is the subject";
    appointment.Location = "Neverland";
    appointment.MeetingStart = DateTime.Now.Date;
    appointment.MeetingEnd = DateTime.Now.Date.AddDays(1).Date;
    appointment.AllDay = true;
    appointment.BodyText = "Hello Neverland text";
    appointment.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>";
    appointment.SentOn = DateTime.UtcNow;
    appointment.Importance = MessageImportance.IMPORTANCE_NORMAL;
    appointment.IconIndex = MessageIconIndex.UnsentMail;
    appointment.Attachments.Add(@"d:\crocodile.jpg");
    appointment.Save(@"c:\appointment.msg");

    // Show the Appointment
    System.Diagnostics.Process.Start(@"c:\Appointment.msg");
}
```

### Creating a contact card

```csharp
using (var contact = new Contact(
    new Sender(SenderTextBox.Text, string.Empty),
    SubjectTextBox.Text,
    DraftMessageCheckBox.Checked,
    ReadReceiptCheckBox.Checked))
{
    contact.Recipients.AddTo("captainhook@neverland.com", "Captain Hook");
    contact.Recipients.AddCc("crocodile@neverland.com", "The evil ticking crocodile");
    contact.Subject = "This is the subject";
    contact.BodyText = "Hello Neverland text";
    contact.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>"
    contact.Importance = MessageImportance.IMPORTANCE_NORMAL;
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
    contact.Save("c:\\contact.msg");
    
    System.Diagnostics.Process.Start("c:\\Contact.msg");
}
```

### Creating a task

```csharp
using (var task = new MsgKit.Task(
           new MsgKit.Sender("peterpan@neverland.com", "Peter Pan"),
           new MsgKit.Representing("tinkerbell@neverland.com", "Tinkerbell"),
           "Hello Neverland subject"))
{
    task.Recipients.AddTo("captainhook@neverland.com", "Captain Hook");
    task.Recipients.AddCc("crocodile@neverland.com", "The evil ticking crocodile");
    task.Subject = "This is the subject";
    task.Status = MsgKit.Enums.TaskStatus.NotStarted;
    task.Complete = false;
    task.PercentageComplete = 0.0;
    task.DueDate = DateTime.Now.Date.AddDays(1).Date;
    task.StartDate = DateTime.Now.Date;
    task.Mode = MsgKit.Enums.TaskMode.Accepted;
    task.Recurring = false;
    task.ReminderTime = DateTime.Now.Date;
    task.BodyRtf = @"{\rtf1\ansi\deff0{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}" +
                          @"This line is the default color\line\cf2This line is red\line\cf1" +
                          @"This line is the default color}";
    task.BodyRtfCompressed = true;
    task.BodyText = "Hello Neverland text";
    task.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>";
    task.SentOn = DateTime.UtcNow;
    task.Importance = MsgKit.Enums.MessageImportance.IMPORTANCE_NORMAL;
    task.IconIndex = MsgKit.Enums.MessageIconIndex.UnsentMail;
    task.Attachments.Add("Images\\peterpan.jpg");
    task.Attachments.Add("Images\\tinkerbell.jpg", -1, true, "tinkerbell.jpg");
    task.Save(@"d:\Task.msg");

    // Show the appointment
    System.Diagnostics.Process.Start(@"d:\Task.msg");
}
```

Core Team
=========
    Sicos1977 (Kees van Spelde)
    Seeker25 (Travis Semple) - Implemented Appointment support

Support
=======
If you like my work then please consider a donation as a thank you by using the sponsor button on the top

## Reporting Bugs

Have a bug or a feature request? [Please open a new issue](https://github.com/Sicos1977/MsgKit/issues).

Before opening a new issue, please search for existing issues to avoid submitting duplicates.

using MsgKit;
using MsgKit.Enums;
using System;

namespace MsgKitTestTool
{
    public class AppointmentTest
    {
        public void Run()
        {
            using (var appointment = new Appointment(
                new Sender("peterpan@neverland.com", "Peter Pan"),
                new Representing("tinkerbell@neverland.com", "Tinkerbell"),
                "Hello Neverland subject")) 
            {
                appointment.Recipients.AddTo("captainhook@neverland.com", "Captain Hook");
                appointment.Recipients.AddTo("AllOfDisneyLand@disney.com", "DisneyLand",objectType: MapiObjectType.MAPI_DISTLIST, displayType: RecipientRowDisplayType.DistributionList);
                appointment.Recipients.AddCc("crocodile@neverland.com", "The evil ticking crocodile");
                appointment.Subject = "This is the subject";
                appointment.Location = "Neverland";
                appointment.MeetingStart = DateTime.Now.Date;
                appointment.MeetingEnd = DateTime.Now.Date.AddDays(1).Date;
                appointment.AllDay = true;
                appointment.BodyRtf = @"{\rtf1\ansi\deff0{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}" +
                                      @"This line is the default color\line\cf2This line is red\line\cf1" + 
                                      @"This line is the default color}";
                appointment.BodyRtfCompressed = true;
                appointment.BodyText = "Hello Neverland text";
                appointment.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>";
                appointment.SentOn = DateTime.UtcNow;
                appointment.Importance = MessageImportance.IMPORTANCE_NORMAL;
                appointment.IconIndex = MessageIconIndex.UnsentMail;
                appointment.Attachments.Add("Images\\peterpan.jpg");
                appointment.Attachments.Add("Images\\tinkerbell.jpg", -1, true, "tinkerbell.jpg");
                appointment.Save(@"d:\test.msg");

                // Show the appointment
                System.Diagnostics.Process.Start(@"d:\test.msg");
            }

        }
    }
}

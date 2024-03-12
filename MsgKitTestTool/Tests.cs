using System;

namespace MsgKitTestTool
{
    public class Tests
    {
        public void CreateAppointment()
        {
            using (var appointment = new MsgKit.Appointment(
                       new MsgKit.Sender("peterpan@neverland.com", "Peter Pan"),
                       new MsgKit.Representing("tinkerbell@neverland.com", "Tinkerbell"),
                       "Hello Neverland subject"))
            {
                appointment.Recipients.AddTo("captainhook@neverland.com", "Captain Hook");
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
                appointment.Importance = MsgKit.Enums.MessageImportance.IMPORTANCE_NORMAL;
                appointment.IconIndex = MsgKit.Enums.MessageIconIndex.UnsentMail;
                appointment.Attachments.Add("Images\\peterpan.jpg");
                appointment.Attachments.Add("Images\\tinkerbell.jpg", -1, true, "tinkerbell.jpg");
                appointment.Save(@"d:\test.msg");

                // Show the appointment
                System.Diagnostics.Process.Start(@"d:\Appointment.msg");
            }
        }
    }
}
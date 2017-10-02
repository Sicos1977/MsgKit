using MsgKit;
using MsgKit.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsgKitTestTool
{
    public class AppointmentTest
    { 
        public void Run()
        {
            using (var appointment = new Appointment(
            new Sender("hello@haha.com", "Mickey Mouse"),
            "Hello Neverland subject", true))
            {
                appointment.Recipients.AddTo("super.man@haha.com", "Hello");
                appointment.Recipients.AddCc("Bestman ever", "Go guy");
                appointment.Subject = "Best Meeting ever";
                appointment.Location = "Breakfast in Bed!";
                appointment.MeetingStart = DateTime.Now.Date;
                appointment.MeetingEnd = DateTime.Now.Date.AddDays(1).Date;
                appointment.AllDay = true;
                appointment.BodyRtf = @"{\rtf1\ansi\deff0{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}This line is the default color\line\cf2This line is red\line\cf1This line is the default color}";
                appointment.BodyRtfCompressed = true;
                appointment.SentOn = DateTime.UtcNow;
                appointment.Importance = MessageImportance.IMPORTANCE_NORMAL;
                appointment.IconIndex = MessageIconIndex.UnsentMail;
                appointment.Save("test.msg");
            }
            System.Diagnostics.Process.Start("test.msg");
        }
    }
}

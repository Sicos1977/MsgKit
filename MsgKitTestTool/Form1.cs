using System;
using System.Windows.Forms;
using MsgKit;
using MsgKit.Enums;

/*
   Copyright 2015 - 2016 Kees van Spelde

   Licensed under The Code Project Open License (CPOL) 1.02;
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.codeproject.com/info/cpol10.aspx

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace MsgKitTestTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var email = new Email(
                new Sender("peterpan@neverland.com", "Peter Pan"),
                new Representing("tinkerbell@neverland.com", "Tinkerbell"),
                "Hello Neverland subject");

            email.Recipients.AddRecipientTo("captainhook@neverland.com", "Captain Hook");
            email.Recipients.AddRecipientCc("crocodile@neverland.com", "The evil ticking crocodile");
            email.Subject = "This is the subject";
            email.BodyText = "Hello Neverland text";
            email.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>";
            email.Importance = MessageImportance.IMPORTANCE_HIGH;
            email.IconIndex = MessageIconIndex.UnsentMail;
            email.Attachments.AddAttachment("Images\\peterpan.jpg");
            email.Attachments.AddAttachment("Images\\tinkerbell.jpg");
            email.Save("test.msg");
            System.Diagnostics.Process.Start("test.msg");
        }
    }
}

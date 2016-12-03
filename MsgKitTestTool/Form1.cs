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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var email = new Email(
                new Sender("peterpan@neverland.com", "Peter Pan"),
                new Representing("tinkerbell@neverland.com", "Tinkerbell"),
                "Hello Neverland subject"))
            {
                email.Recipients.AddTo(FromTextBox.Text);
                email.Recipients.AddCc(ToTextBox.Text);
                email.Recipients.AddBcc(BccTextBox.Text);
                email.Subject = SubjectTextBox.Text;
                email.BodyText = TextBodyTextBox.Text;
                email.BodyHtml = HtmlBodyTextBox.Text;
                email.SentOn = SentOnDatePicker.Value;

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

                email.IconIndex = MessageIconIndex.UnsentMail;
                email.Attachments.Add("Images\\peterpan.jpg");
                email.Attachments.Add("Images\\tinkerbell.jpg");
                email.Save("test.msg");
            }
            System.Diagnostics.Process.Start("test.msg");
        }
    }
}

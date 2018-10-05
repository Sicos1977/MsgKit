using System;
using System.IO;
using System.Windows.Forms;
using MsgKit;
using MsgKit.Enums;
using MsgKitTestTool.Properties;

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
                email.AddProperty(PropertyTags.PR_AUTO_FORWARDED, );

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
                email.Attachments.Add("Images\\tinkerbell.jpg", -1, true, "tinkerbell.jpg");
                //email.Attachments.Add("d:\\test2.msg");
                //email.Attachments.Add(@"c:\naamloos.msg");
                email.Save("d:\\test.msg");
            }
            System.Diagnostics.Process.Start("d:\\test.msg");
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
    }
}

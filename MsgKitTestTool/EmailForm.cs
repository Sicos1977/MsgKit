//
// MainForm
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2015-2018 Magic-Sessions. (www.magic-sessions.com)
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

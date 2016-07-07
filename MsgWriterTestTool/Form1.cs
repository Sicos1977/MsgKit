using System;
using System.Windows.Forms;
using MsgWriter;
using MsgWriter.Enums;

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

namespace MsgWriterTestTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var email = new Email(new Sender("magic-sessions@home.nl", "Kees van Spelde"), "Hello world subject");
            email.Recipients.AddRecipientTo("keesvanspelde@home.nl", "Kees van Spelde");
            email.Recipients.AddRecipientTo("spelde@home.nl", "Familie van Spelde");
            email.Recipients.AddRecipientCc("magic-sessions@home.nl");
            email.Subject = "This is the subject";
            email.BodyText = "Hello world text";
            email.BodyHtml = "<html><head></head><body><b>Hello world html</b></body></html>";
            email.IconIndex = MessageIconIndex.ReadMail;
            email.Attachments.AddAttachment("d:\\railroad_1024-768.jpg");
            email.Attachments.AddAttachment("d:\\Nieuwesarongs 2016.xlsx");
            email.Save("d:\\test.msg");
            System.Diagnostics.Process.Start("d:\\test.msg");
        }
    }
}

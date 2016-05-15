using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgWriter;

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
            var email = new Email();
            email.Subject = "Dit is het onderwerp";
            //email.Test();
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Save("d:\\test3.msg");
        }
    }
}

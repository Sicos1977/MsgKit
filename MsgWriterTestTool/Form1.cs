using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgWriter;

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
            //email.Test();
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Attachments.AddAttachment("d:\\WP_001128.jpg");
            email.Save("d:\\test3.msg");
        }
    }
}

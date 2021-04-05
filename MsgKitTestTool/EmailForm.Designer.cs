namespace MsgKitTestTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmailButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBodyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HtmlBodyTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ReadMsgFileButton = new System.Windows.Forms.Button();
            this.ReadReceiptCheckBox = new System.Windows.Forms.CheckBox();
            this.DraftMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.ImportanceComboBox = new System.Windows.Forms.ComboBox();
            this.SenderTextBox = new System.Windows.Forms.TextBox();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.SentOnDatePicker = new System.Windows.Forms.DateTimePicker();
            this.BccTextBox = new System.Windows.Forms.TextBox();
            this.CcTextBox = new System.Windows.Forms.TextBox();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.ContactButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmailButton
            // 
            this.EmailButton.Location = new System.Drawing.Point(446, 295);
            this.EmailButton.Margin = new System.Windows.Forms.Padding(2);
            this.EmailButton.Name = "EmailButton";
            this.EmailButton.Size = new System.Drawing.Size(91, 33);
            this.EmailButton.TabIndex = 10;
            this.EmailButton.Text = "E-mail";
            this.EmailButton.UseVisualStyleBackColor = true;
            this.EmailButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "CC:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "BCC:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sent on:";
            // 
            // TextBodyTextBox
            // 
            this.TextBodyTextBox.Location = new System.Drawing.Point(278, 30);
            this.TextBodyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TextBodyTextBox.Multiline = true;
            this.TextBodyTextBox.Name = "TextBodyTextBox";
            this.TextBodyTextBox.Size = new System.Drawing.Size(258, 116);
            this.TextBodyTextBox.TabIndex = 8;
            this.TextBodyTextBox.Text = "Hello Neverland text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Text body:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "HTML body:";
            // 
            // HtmlBodyTextBox
            // 
            this.HtmlBodyTextBox.Location = new System.Drawing.Point(278, 171);
            this.HtmlBodyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.HtmlBodyTextBox.Multiline = true;
            this.HtmlBodyTextBox.Name = "HtmlBodyTextBox";
            this.HtmlBodyTextBox.Size = new System.Drawing.Size(258, 116);
            this.HtmlBodyTextBox.TabIndex = 9;
            this.HtmlBodyTextBox.Text = "<html>\r\n   <head>\r\n      <title>Peter Pann</title>\r\n   </head>\r\n   <body>\r\n      " +
    "<b>Hello Neverland html</b><br/>\r\n     <img src=\"cid:tinkerbell.jpg\">\r\n   </body" +
    ">\r\n</html>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Subject:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sender:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 188);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Importance:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 295);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 20;
            this.button1.Text = "EML -> MSG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Eml2MsgButton_Click);
            // 
            // ReadMsgFileButton
            // 
            this.ReadMsgFileButton.Location = new System.Drawing.Point(108, 295);
            this.ReadMsgFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReadMsgFileButton.Name = "ReadMsgFileButton";
            this.ReadMsgFileButton.Size = new System.Drawing.Size(91, 33);
            this.ReadMsgFileButton.TabIndex = 21;
            this.ReadMsgFileButton.Text = "Read MSG";
            this.ReadMsgFileButton.UseVisualStyleBackColor = true;
            this.ReadMsgFileButton.Visible = false;
            this.ReadMsgFileButton.Click += new System.EventHandler(this.ReadMsgFileButton_Click);
            // 
            // ReadReceiptCheckBox
            // 
            this.ReadReceiptCheckBox.AutoSize = true;
            this.ReadReceiptCheckBox.Checked = global::MsgKitTestTool.Properties.Settings.Default.ReadReceiptCheckBox;
            this.ReadReceiptCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MsgKitTestTool.Properties.Settings.Default, "ReadReceiptCheckBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ReadReceiptCheckBox.Location = new System.Drawing.Point(70, 237);
            this.ReadReceiptCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ReadReceiptCheckBox.Name = "ReadReceiptCheckBox";
            this.ReadReceiptCheckBox.Size = new System.Drawing.Size(87, 17);
            this.ReadReceiptCheckBox.TabIndex = 23;
            this.ReadReceiptCheckBox.Text = "Read receipt";
            this.ReadReceiptCheckBox.UseVisualStyleBackColor = true;
            // 
            // DraftMessageCheckBox
            // 
            this.DraftMessageCheckBox.AutoSize = true;
            this.DraftMessageCheckBox.Checked = global::MsgKitTestTool.Properties.Settings.Default.DraftMessageCheckBox;
            this.DraftMessageCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MsgKitTestTool.Properties.Settings.Default, "DraftMessageCheckBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DraftMessageCheckBox.Location = new System.Drawing.Point(70, 216);
            this.DraftMessageCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.DraftMessageCheckBox.Name = "DraftMessageCheckBox";
            this.DraftMessageCheckBox.Size = new System.Drawing.Size(94, 17);
            this.DraftMessageCheckBox.TabIndex = 22;
            this.DraftMessageCheckBox.Text = "Draft message";
            this.DraftMessageCheckBox.UseVisualStyleBackColor = true;
            // 
            // ImportanceComboBox
            // 
            this.ImportanceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "Importance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ImportanceComboBox.FormattingEnabled = true;
            this.ImportanceComboBox.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.ImportanceComboBox.Location = new System.Drawing.Point(70, 187);
            this.ImportanceComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ImportanceComboBox.Name = "ImportanceComboBox";
            this.ImportanceComboBox.Size = new System.Drawing.Size(62, 21);
            this.ImportanceComboBox.TabIndex = 19;
            this.ImportanceComboBox.Text = global::MsgKitTestTool.Properties.Settings.Default.Importance;
            // 
            // SenderTextBox
            // 
            this.SenderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "Sender", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SenderTextBox.Location = new System.Drawing.Point(70, 11);
            this.SenderTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SenderTextBox.Name = "SenderTextBox";
            this.SenderTextBox.Size = new System.Drawing.Size(192, 20);
            this.SenderTextBox.TabIndex = 1;
            this.SenderTextBox.Text = global::MsgKitTestTool.Properties.Settings.Default.Sender;
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "Subject", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SubjectTextBox.Location = new System.Drawing.Point(70, 133);
            this.SubjectTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(192, 20);
            this.SubjectTextBox.TabIndex = 6;
            this.SubjectTextBox.Text = global::MsgKitTestTool.Properties.Settings.Default.Subject;
            // 
            // SentOnDatePicker
            // 
            this.SentOnDatePicker.Checked = false;
            this.SentOnDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.SentOnDatePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MsgKitTestTool.Properties.Settings.Default, "SentOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SentOnDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SentOnDatePicker.Location = new System.Drawing.Point(70, 161);
            this.SentOnDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.SentOnDatePicker.Name = "SentOnDatePicker";
            this.SentOnDatePicker.Size = new System.Drawing.Size(192, 20);
            this.SentOnDatePicker.TabIndex = 7;
            this.SentOnDatePicker.Value = global::MsgKitTestTool.Properties.Settings.Default.SentOn;
            // 
            // BccTextBox
            // 
            this.BccTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "Bcc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BccTextBox.Location = new System.Drawing.Point(70, 108);
            this.BccTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BccTextBox.Name = "BccTextBox";
            this.BccTextBox.Size = new System.Drawing.Size(192, 20);
            this.BccTextBox.TabIndex = 5;
            this.BccTextBox.Text = global::MsgKitTestTool.Properties.Settings.Default.Bcc;
            // 
            // CcTextBox
            // 
            this.CcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "Cc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CcTextBox.Location = new System.Drawing.Point(70, 83);
            this.CcTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CcTextBox.Name = "CcTextBox";
            this.CcTextBox.Size = new System.Drawing.Size(192, 20);
            this.CcTextBox.TabIndex = 4;
            this.CcTextBox.Text = global::MsgKitTestTool.Properties.Settings.Default.Cc;
            // 
            // ToTextBox
            // 
            this.ToTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "To", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ToTextBox.Location = new System.Drawing.Point(70, 59);
            this.ToTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(192, 20);
            this.ToTextBox.TabIndex = 3;
            this.ToTextBox.Text = global::MsgKitTestTool.Properties.Settings.Default.To;
            // 
            // FromTextBox
            // 
            this.FromTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MsgKitTestTool.Properties.Settings.Default, "From", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FromTextBox.Location = new System.Drawing.Point(70, 35);
            this.FromTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.Size = new System.Drawing.Size(192, 20);
            this.FromTextBox.TabIndex = 2;
            this.FromTextBox.Text = global::MsgKitTestTool.Properties.Settings.Default.From;
            // 
            // ContactButton
            // 
            this.ContactButton.Location = new System.Drawing.Point(351, 295);
            this.ContactButton.Margin = new System.Windows.Forms.Padding(2);
            this.ContactButton.Name = "ContactButton";
            this.ContactButton.Size = new System.Drawing.Size(91, 33);
            this.ContactButton.TabIndex = 24;
            this.ContactButton.Text = "Contact";
            this.ContactButton.UseVisualStyleBackColor = true;
            this.ContactButton.Click += new System.EventHandler(this.ContactButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 341);
            this.Controls.Add(this.ContactButton);
            this.Controls.Add(this.ReadReceiptCheckBox);
            this.Controls.Add(this.DraftMessageCheckBox);
            this.Controls.Add(this.ReadMsgFileButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ImportanceComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SenderTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SubjectTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.HtmlBodyTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBodyTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SentOnDatePicker);
            this.Controls.Add(this.BccTextBox);
            this.Controls.Add(this.CcTextBox);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.FromTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmailButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MsgKit testtool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EmailButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FromTextBox;
        private System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.TextBox CcTextBox;
        private System.Windows.Forms.TextBox BccTextBox;
        private System.Windows.Forms.DateTimePicker SentOnDatePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBodyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox HtmlBodyTextBox;
        private System.Windows.Forms.TextBox SubjectTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SenderTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ImportanceComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ReadMsgFileButton;
        private System.Windows.Forms.CheckBox DraftMessageCheckBox;
        private System.Windows.Forms.CheckBox ReadReceiptCheckBox;
        private System.Windows.Forms.Button ContactButton;
    }
}


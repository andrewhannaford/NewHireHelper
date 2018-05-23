namespace New_Hire_Helper_V2
{
    partial class User_Registration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.emailConfirmText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.passwordConfirmText = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the following information:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm E-mail Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Full Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Confirm Password:";
            // 
            // emailConfirmText
            // 
            this.emailConfirmText.Location = new System.Drawing.Point(453, 181);
            this.emailConfirmText.Name = "emailConfirmText";
            this.emailConfirmText.Size = new System.Drawing.Size(602, 38);
            this.emailConfirmText.TabIndex = 5;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(453, 233);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(602, 38);
            this.nameText.TabIndex = 6;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(453, 287);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(602, 38);
            this.passwordText.TabIndex = 7;
            // 
            // passwordConfirmText
            // 
            this.passwordConfirmText.Location = new System.Drawing.Point(453, 342);
            this.passwordConfirmText.Name = "passwordConfirmText";
            this.passwordConfirmText.Size = new System.Drawing.Size(602, 38);
            this.passwordConfirmText.TabIndex = 8;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(62, 538);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(244, 60);
            this.Submit.TabIndex = 9;
            this.Submit.Text = "OK";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Location = new System.Drawing.Point(367, 538);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(244, 60);
            this.MainMenu.TabIndex = 10;
            this.MainMenu.Text = "Main Menu";
            this.MainMenu.UseVisualStyleBackColor = true;
            this.MainMenu.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "E-mail Address:";
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(453, 124);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(602, 38);
            this.emailText.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 32);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select your title:";
            // 
            // titleComboBox
            // 
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Items.AddRange(new object[] {
            "Talent Acquisition Coordinator",
            "Admin Coordinator",
            "Chief People Officer",
            "Office Manager",
            "Accountant",
            "Controller",
            "Marketing",
            "IT"});
            this.titleComboBox.Location = new System.Drawing.Point(62, 461);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(452, 39);
            this.titleComboBox.TabIndex = 16;
            this.titleComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // User_Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 661);
            this.Controls.Add(this.titleComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.passwordConfirmText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.emailConfirmText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "User_Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Registration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.User_Registration_FormClosed);
            this.Load += new System.EventHandler(this.User_Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox emailConfirmText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox passwordConfirmText;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button MainMenu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox titleComboBox;
    }
}
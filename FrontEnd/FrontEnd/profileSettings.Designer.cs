namespace FrontEnd
{
    partial class ProfileSettings
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
            this.goBackButton = new System.Windows.Forms.Button();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.changedBirthDate = new System.Windows.Forms.DateTimePicker();
            this.changeBirthDateLabel = new System.Windows.Forms.Label();
            this.changedLoginTextBox = new System.Windows.Forms.TextBox();
            this.changeLoginLabel = new System.Windows.Forms.Label();
            this.changedSurnameTextBox = new System.Windows.Forms.TextBox();
            this.changeSurnameLabel = new System.Windows.Forms.Label();
            this.changedNameTextBox = new System.Windows.Forms.TextBox();
            this.changeNameLabel = new System.Windows.Forms.Label();
            this.profileSettingsLabel = new System.Windows.Forms.Label();
            this.errorUsername = new System.Windows.Forms.Label();
            this.errorSurname = new System.Windows.Forms.Label();
            this.errorName = new System.Windows.Forms.Label();
            this.errorDate = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NewPassLabel = new System.Windows.Forms.Label();
            this.OldPassLablel = new System.Windows.Forms.Label();
            this.ConfirmNewPassLabel = new System.Windows.Forms.Label();
            this.OLdPass = new System.Windows.Forms.TextBox();
            this.NewPass = new System.Windows.Forms.TextBox();
            this.ConfirmNewPass = new System.Windows.Forms.TextBox();
            this.errorOldPass = new System.Windows.Forms.Label();
            this.ErrorNewPass = new System.Windows.Forms.Label();
            this.ErrorConfirmNewPass = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.goBackButton.ForeColor = System.Drawing.SystemColors.Control;
            this.goBackButton.Location = new System.Drawing.Point(28, 508);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(159, 46);
            this.goBackButton.TabIndex = 26;
            this.goBackButton.Text = "Powrót";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // saveDataButton
            // 
            this.saveDataButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.saveDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveDataButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveDataButton.Location = new System.Drawing.Point(29, 261);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(159, 46);
            this.saveDataButton.TabIndex = 25;
            this.saveDataButton.Text = "Zapisz zmiany";
            this.saveDataButton.UseVisualStyleBackColor = false;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.changePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changePasswordButton.ForeColor = System.Drawing.SystemColors.Control;
            this.changePasswordButton.Location = new System.Drawing.Point(279, 508);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(138, 46);
            this.changePasswordButton.TabIndex = 24;
            this.changePasswordButton.Text = "Zmień hasło";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            this.changePasswordButton.Visible = false;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // changedBirthDate
            // 
            this.changedBirthDate.Location = new System.Drawing.Point(213, 218);
            this.changedBirthDate.Name = "changedBirthDate";
            this.changedBirthDate.Size = new System.Drawing.Size(206, 20);
            this.changedBirthDate.TabIndex = 23;
            // 
            // changeBirthDateLabel
            // 
            this.changeBirthDateLabel.AutoSize = true;
            this.changeBirthDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.changeBirthDateLabel.Location = new System.Drawing.Point(25, 216);
            this.changeBirthDateLabel.Name = "changeBirthDateLabel";
            this.changeBirthDateLabel.Size = new System.Drawing.Size(182, 22);
            this.changeBirthDateLabel.TabIndex = 22;
            this.changeBirthDateLabel.Text = "Zmień datę urodzenia";
            // 
            // changedLoginTextBox
            // 
            this.changedLoginTextBox.Location = new System.Drawing.Point(167, 171);
            this.changedLoginTextBox.Multiline = true;
            this.changedLoginTextBox.Name = "changedLoginTextBox";
            this.changedLoginTextBox.Size = new System.Drawing.Size(252, 22);
            this.changedLoginTextBox.TabIndex = 21;
            // 
            // changeLoginLabel
            // 
            this.changeLoginLabel.AutoSize = true;
            this.changeLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.changeLoginLabel.Location = new System.Drawing.Point(24, 171);
            this.changeLoginLabel.Name = "changeLoginLabel";
            this.changeLoginLabel.Size = new System.Drawing.Size(102, 22);
            this.changeLoginLabel.TabIndex = 20;
            this.changeLoginLabel.Text = "Zmień login";
            // 
            // changedSurnameTextBox
            // 
            this.changedSurnameTextBox.Location = new System.Drawing.Point(167, 128);
            this.changedSurnameTextBox.Multiline = true;
            this.changedSurnameTextBox.Name = "changedSurnameTextBox";
            this.changedSurnameTextBox.Size = new System.Drawing.Size(252, 22);
            this.changedSurnameTextBox.TabIndex = 19;
            // 
            // changeSurnameLabel
            // 
            this.changeSurnameLabel.AutoSize = true;
            this.changeSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.changeSurnameLabel.Location = new System.Drawing.Point(25, 124);
            this.changeSurnameLabel.Name = "changeSurnameLabel";
            this.changeSurnameLabel.Size = new System.Drawing.Size(137, 22);
            this.changeSurnameLabel.TabIndex = 18;
            this.changeSurnameLabel.Text = "Zmień nazwisko";
            // 
            // changedNameTextBox
            // 
            this.changedNameTextBox.Location = new System.Drawing.Point(167, 81);
            this.changedNameTextBox.Multiline = true;
            this.changedNameTextBox.Name = "changedNameTextBox";
            this.changedNameTextBox.Size = new System.Drawing.Size(252, 22);
            this.changedNameTextBox.TabIndex = 17;
            // 
            // changeNameLabel
            // 
            this.changeNameLabel.AutoSize = true;
            this.changeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.changeNameLabel.Location = new System.Drawing.Point(25, 77);
            this.changeNameLabel.Name = "changeNameLabel";
            this.changeNameLabel.Size = new System.Drawing.Size(101, 22);
            this.changeNameLabel.TabIndex = 16;
            this.changeNameLabel.Text = "Zmień imię ";
            // 
            // profileSettingsLabel
            // 
            this.profileSettingsLabel.AutoSize = true;
            this.profileSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.profileSettingsLabel.Location = new System.Drawing.Point(115, 23);
            this.profileSettingsLabel.Name = "profileSettingsLabel";
            this.profileSettingsLabel.Size = new System.Drawing.Size(204, 29);
            this.profileSettingsLabel.TabIndex = 15;
            this.profileSettingsLabel.Text = "Ustawienia profilu";
            // 
            // errorUsername
            // 
            this.errorUsername.AutoSize = true;
            this.errorUsername.BackColor = System.Drawing.Color.Transparent;
            this.errorUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.errorUsername.ForeColor = System.Drawing.Color.Red;
            this.errorUsername.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorUsername.Location = new System.Drawing.Point(25, 193);
            this.errorUsername.Name = "errorUsername";
            this.errorUsername.Size = new System.Drawing.Size(98, 16);
            this.errorUsername.TabIndex = 27;
            this.errorUsername.Text = "errorUsername";
            this.errorUsername.Visible = false;
            // 
            // errorSurname
            // 
            this.errorSurname.AutoSize = true;
            this.errorSurname.BackColor = System.Drawing.Color.Transparent;
            this.errorSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.errorSurname.ForeColor = System.Drawing.Color.Red;
            this.errorSurname.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorSurname.Location = new System.Drawing.Point(26, 146);
            this.errorSurname.Name = "errorSurname";
            this.errorSurname.Size = new System.Drawing.Size(92, 16);
            this.errorSurname.TabIndex = 29;
            this.errorSurname.Text = "error Surname";
            this.errorSurname.Visible = false;
            // 
            // errorName
            // 
            this.errorName.AutoSize = true;
            this.errorName.BackColor = System.Drawing.Color.Transparent;
            this.errorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.errorName.ForeColor = System.Drawing.Color.Red;
            this.errorName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorName.Location = new System.Drawing.Point(26, 99);
            this.errorName.Name = "errorName";
            this.errorName.Size = new System.Drawing.Size(72, 16);
            this.errorName.TabIndex = 28;
            this.errorName.Text = "error name";
            this.errorName.Visible = false;
            // 
            // errorDate
            // 
            this.errorDate.AutoSize = true;
            this.errorDate.BackColor = System.Drawing.Color.Transparent;
            this.errorDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.errorDate.ForeColor = System.Drawing.Color.Red;
            this.errorDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorDate.Location = new System.Drawing.Point(27, 238);
            this.errorDate.Name = "errorDate";
            this.errorDate.Size = new System.Drawing.Size(65, 16);
            this.errorDate.TabIndex = 30;
            this.errorDate.Text = "error date";
            this.errorDate.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(198, 272);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(222, 28);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Chcesz zmienic haslo?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.ErrorConfirmNewPass);
            this.groupBox1.Controls.Add(this.ErrorNewPass);
            this.groupBox1.Controls.Add(this.errorOldPass);
            this.groupBox1.Controls.Add(this.ConfirmNewPass);
            this.groupBox1.Controls.Add(this.NewPass);
            this.groupBox1.Controls.Add(this.OLdPass);
            this.groupBox1.Controls.Add(this.ConfirmNewPassLabel);
            this.groupBox1.Controls.Add(this.OldPassLablel);
            this.groupBox1.Controls.Add(this.NewPassLabel);
            this.groupBox1.Location = new System.Drawing.Point(28, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 162);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zmien haslo";
            this.groupBox1.Visible = false;
            // 
            // NewPassLabel
            // 
            this.NewPassLabel.AutoSize = true;
            this.NewPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NewPassLabel.Location = new System.Drawing.Point(6, 71);
            this.NewPassLabel.Name = "NewPassLabel";
            this.NewPassLabel.Size = new System.Drawing.Size(94, 20);
            this.NewPassLabel.TabIndex = 0;
            this.NewPassLabel.Text = "Nowe Haslo";
            // 
            // OldPassLablel
            // 
            this.OldPassLablel.AutoSize = true;
            this.OldPassLablel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OldPassLablel.Location = new System.Drawing.Point(6, 25);
            this.OldPassLablel.Name = "OldPassLablel";
            this.OldPassLablel.Size = new System.Drawing.Size(131, 20);
            this.OldPassLablel.TabIndex = 1;
            this.OldPassLablel.Text = "Podaj stare haslo";
            // 
            // ConfirmNewPassLabel
            // 
            this.ConfirmNewPassLabel.AutoSize = true;
            this.ConfirmNewPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConfirmNewPassLabel.Location = new System.Drawing.Point(6, 116);
            this.ConfirmNewPassLabel.Name = "ConfirmNewPassLabel";
            this.ConfirmNewPassLabel.Size = new System.Drawing.Size(165, 20);
            this.ConfirmNewPassLabel.TabIndex = 2;
            this.ConfirmNewPassLabel.Text = "Potwierdz nowe Haslo";
            // 
            // OLdPass
            // 
            this.OLdPass.Location = new System.Drawing.Point(177, 24);
            this.OLdPass.Name = "OLdPass";
            this.OLdPass.Size = new System.Drawing.Size(194, 20);
            this.OLdPass.TabIndex = 3;
            // 
            // NewPass
            // 
            this.NewPass.Location = new System.Drawing.Point(177, 71);
            this.NewPass.Name = "NewPass";
            this.NewPass.Size = new System.Drawing.Size(194, 20);
            this.NewPass.TabIndex = 4;
            // 
            // ConfirmNewPass
            // 
            this.ConfirmNewPass.Location = new System.Drawing.Point(177, 116);
            this.ConfirmNewPass.Name = "ConfirmNewPass";
            this.ConfirmNewPass.Size = new System.Drawing.Size(194, 20);
            this.ConfirmNewPass.TabIndex = 5;
            // 
            // errorOldPass
            // 
            this.errorOldPass.AutoSize = true;
            this.errorOldPass.BackColor = System.Drawing.Color.Transparent;
            this.errorOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.errorOldPass.ForeColor = System.Drawing.Color.Red;
            this.errorOldPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorOldPass.Location = new System.Drawing.Point(7, 45);
            this.errorOldPass.Name = "errorOldPass";
            this.errorOldPass.Size = new System.Drawing.Size(44, 16);
            this.errorOldPass.TabIndex = 28;
            this.errorOldPass.Text = "label1";
            this.errorOldPass.Visible = false;
            // 
            // ErrorNewPass
            // 
            this.ErrorNewPass.AutoSize = true;
            this.ErrorNewPass.BackColor = System.Drawing.Color.Transparent;
            this.ErrorNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ErrorNewPass.ForeColor = System.Drawing.Color.Red;
            this.ErrorNewPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ErrorNewPass.Location = new System.Drawing.Point(7, 91);
            this.ErrorNewPass.Name = "ErrorNewPass";
            this.ErrorNewPass.Size = new System.Drawing.Size(44, 16);
            this.ErrorNewPass.TabIndex = 29;
            this.ErrorNewPass.Text = "label2";
            this.ErrorNewPass.Visible = false;
            // 
            // ErrorConfirmNewPass
            // 
            this.ErrorConfirmNewPass.AutoSize = true;
            this.ErrorConfirmNewPass.BackColor = System.Drawing.Color.Transparent;
            this.ErrorConfirmNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ErrorConfirmNewPass.ForeColor = System.Drawing.Color.Red;
            this.ErrorConfirmNewPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ErrorConfirmNewPass.Location = new System.Drawing.Point(7, 136);
            this.ErrorConfirmNewPass.Name = "ErrorConfirmNewPass";
            this.ErrorConfirmNewPass.Size = new System.Drawing.Size(44, 16);
            this.ErrorConfirmNewPass.TabIndex = 30;
            this.ErrorConfirmNewPass.Text = "label3";
            this.ErrorConfirmNewPass.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(177, 97);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "Pokaz haslo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(177, 50);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(84, 17);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Text = "Pokaz haslo";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(177, 142);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(84, 17);
            this.checkBox4.TabIndex = 33;
            this.checkBox4.Text = "Pokaz haslo";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // ProfileSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 574);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.errorDate);
            this.Controls.Add(this.errorSurname);
            this.Controls.Add(this.errorName);
            this.Controls.Add(this.errorUsername);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.changedBirthDate);
            this.Controls.Add(this.changeBirthDateLabel);
            this.Controls.Add(this.changedLoginTextBox);
            this.Controls.Add(this.changeLoginLabel);
            this.Controls.Add(this.changedSurnameTextBox);
            this.Controls.Add(this.changeSurnameLabel);
            this.Controls.Add(this.changedNameTextBox);
            this.Controls.Add(this.changeNameLabel);
            this.Controls.Add(this.profileSettingsLabel);
            this.Name = "ProfileSettings";
            this.Text = "profileSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.DateTimePicker changedBirthDate;
        public System.Windows.Forms.Label changeBirthDateLabel;
        private System.Windows.Forms.TextBox changedLoginTextBox;
        public System.Windows.Forms.Label changeLoginLabel;
        private System.Windows.Forms.TextBox changedSurnameTextBox;
        public System.Windows.Forms.Label changeSurnameLabel;
        private System.Windows.Forms.TextBox changedNameTextBox;
        private System.Windows.Forms.Label changeNameLabel;
        private System.Windows.Forms.Label profileSettingsLabel;
        private System.Windows.Forms.Label errorUsername;
        private System.Windows.Forms.Label errorSurname;
        private System.Windows.Forms.Label errorName;
        private System.Windows.Forms.Label errorDate;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NewPassLabel;
        private System.Windows.Forms.TextBox ConfirmNewPass;
        private System.Windows.Forms.TextBox NewPass;
        private System.Windows.Forms.TextBox OLdPass;
        private System.Windows.Forms.Label ConfirmNewPassLabel;
        private System.Windows.Forms.Label OldPassLablel;
        private System.Windows.Forms.Label ErrorConfirmNewPass;
        private System.Windows.Forms.Label ErrorNewPass;
        private System.Windows.Forms.Label errorOldPass;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}
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
            this.SuspendLayout();
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.goBackButton.ForeColor = System.Drawing.SystemColors.Control;
            this.goBackButton.Location = new System.Drawing.Point(28, 342);
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
            this.saveDataButton.Location = new System.Drawing.Point(28, 290);
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
            this.changePasswordButton.Location = new System.Drawing.Point(296, 290);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(138, 46);
            this.changePasswordButton.TabIndex = 24;
            this.changePasswordButton.Text = "Zmień hasło";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            // 
            // changedBirthDate
            // 
            this.changedBirthDate.Location = new System.Drawing.Point(215, 236);
            this.changedBirthDate.Name = "changedBirthDate";
            this.changedBirthDate.Size = new System.Drawing.Size(221, 20);
            this.changedBirthDate.TabIndex = 23;
            // 
            // changeBirthDateLabel
            // 
            this.changeBirthDateLabel.AutoSize = true;
            this.changeBirthDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.changeBirthDateLabel.Location = new System.Drawing.Point(27, 234);
            this.changeBirthDateLabel.Name = "changeBirthDateLabel";
            this.changeBirthDateLabel.Size = new System.Drawing.Size(182, 22);
            this.changeBirthDateLabel.TabIndex = 22;
            this.changeBirthDateLabel.Text = "Zmień datę urodzenia";
            // 
            // changedLoginTextBox
            // 
            this.changedLoginTextBox.Location = new System.Drawing.Point(134, 187);
            this.changedLoginTextBox.Multiline = true;
            this.changedLoginTextBox.Name = "changedLoginTextBox";
            this.changedLoginTextBox.Size = new System.Drawing.Size(302, 22);
            this.changedLoginTextBox.TabIndex = 21;
            // 
            // changeLoginLabel
            // 
            this.changeLoginLabel.AutoSize = true;
            this.changeLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.changeLoginLabel.Location = new System.Drawing.Point(26, 187);
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
            this.changedSurnameTextBox.Size = new System.Drawing.Size(267, 22);
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
            this.changedNameTextBox.Location = new System.Drawing.Point(132, 81);
            this.changedNameTextBox.Multiline = true;
            this.changedNameTextBox.Name = "changedNameTextBox";
            this.changedNameTextBox.Size = new System.Drawing.Size(302, 22);
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
            this.profileSettingsLabel.Location = new System.Drawing.Point(119, 9);
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
            this.errorUsername.Location = new System.Drawing.Point(25, 171);
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
            this.errorSurname.Location = new System.Drawing.Point(24, 108);
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
            this.errorName.Location = new System.Drawing.Point(24, 61);
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
            this.errorDate.Location = new System.Drawing.Point(27, 218);
            this.errorDate.Name = "errorDate";
            this.errorDate.Size = new System.Drawing.Size(65, 16);
            this.errorDate.TabIndex = 30;
            this.errorDate.Text = "error date";
            this.errorDate.Visible = false;
            // 
            // ProfileSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 436);
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
    }
}
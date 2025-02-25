namespace FrontEnd
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.registerLabel = new System.Windows.Forms.Label();
            this.surnNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.surnNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.repeatPasswordLabel = new System.Windows.Forms.Label();
            this.repeatPasswordTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.maleRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.submitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loginInHereLabel = new System.Windows.Forms.Label();
            this.errorUsername = new System.Windows.Forms.Label();
            this.errorName = new System.Windows.Forms.Label();
            this.errorSurname = new System.Windows.Forms.Label();
            this.errorPass = new System.Windows.Forms.Label();
            this.errorConfirmPass = new System.Windows.Forms.Label();
            this.errorDate = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.CheckBox();
            this.showConfirmPass = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerLabel
            // 
            resources.ApplyResources(this.registerLabel, "registerLabel");
            this.registerLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.registerLabel.Name = "registerLabel";
            // 
            // surnNameLabel
            // 
            resources.ApplyResources(this.surnNameLabel, "surnNameLabel");
            this.surnNameLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.surnNameLabel.Name = "surnNameLabel";
            // 
            // firstNameTextBox
            // 
            resources.ApplyResources(this.firstNameTextBox, "firstNameTextBox");
            this.firstNameTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.firstNameTextBox_TextChanged);
            // 
            // surnNameTextBox
            // 
            resources.ApplyResources(this.surnNameTextBox, "surnNameTextBox");
            this.surnNameTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.surnNameTextBox.Name = "surnNameTextBox";
            this.surnNameTextBox.TextChanged += new System.EventHandler(this.surnNameTextBox_TextChanged);
            // 
            // userNameLabel
            // 
            resources.ApplyResources(this.userNameLabel, "userNameLabel");
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.userNameLabel.Name = "userNameLabel";
            // 
            // userNameTextBox
            // 
            resources.ApplyResources(this.userNameTextBox, "userNameTextBox");
            this.userNameTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.passwordLabel.Name = "passwordLabel";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // firstNameLabel
            // 
            resources.ApplyResources(this.firstNameLabel, "firstNameLabel");
            this.firstNameLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.firstNameLabel.Name = "firstNameLabel";
            // 
            // repeatPasswordLabel
            // 
            resources.ApplyResources(this.repeatPasswordLabel, "repeatPasswordLabel");
            this.repeatPasswordLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.repeatPasswordLabel.Name = "repeatPasswordLabel";
            // 
            // repeatPasswordTextBox
            // 
            resources.ApplyResources(this.repeatPasswordTextBox, "repeatPasswordTextBox");
            this.repeatPasswordTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            this.repeatPasswordTextBox.TextChanged += new System.EventHandler(this.repeatPasswordTextBox_TextChanged);
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dateLabel.Name = "dateLabel";
            // 
            // maleRadioButton
            // 
            resources.ApplyResources(this.maleRadioButton, "maleRadioButton");
            this.maleRadioButton.Checked = true;
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.femaleRadioButton);
            this.groupBox1.Controls.Add(this.maleRadioButton);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // femaleRadioButton
            // 
            resources.ApplyResources(this.femaleRadioButton, "femaleRadioButton");
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // loginInHereLabel
            // 
            resources.ApplyResources(this.loginInHereLabel, "loginInHereLabel");
            this.loginInHereLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginInHereLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.loginInHereLabel.Name = "loginInHereLabel";
            this.loginInHereLabel.Click += new System.EventHandler(this.loginInLabel_Click);
            // 
            // errorUsername
            // 
            resources.ApplyResources(this.errorUsername, "errorUsername");
            this.errorUsername.BackColor = System.Drawing.Color.Transparent;
            this.errorUsername.ForeColor = System.Drawing.Color.Red;
            this.errorUsername.Name = "errorUsername";
            // 
            // errorName
            // 
            resources.ApplyResources(this.errorName, "errorName");
            this.errorName.BackColor = System.Drawing.Color.Transparent;
            this.errorName.ForeColor = System.Drawing.Color.Red;
            this.errorName.Name = "errorName";
            // 
            // errorSurname
            // 
            resources.ApplyResources(this.errorSurname, "errorSurname");
            this.errorSurname.BackColor = System.Drawing.Color.Transparent;
            this.errorSurname.ForeColor = System.Drawing.Color.Red;
            this.errorSurname.Name = "errorSurname";
            // 
            // errorPass
            // 
            resources.ApplyResources(this.errorPass, "errorPass");
            this.errorPass.BackColor = System.Drawing.Color.Transparent;
            this.errorPass.ForeColor = System.Drawing.Color.Red;
            this.errorPass.Name = "errorPass";
            // 
            // errorConfirmPass
            // 
            resources.ApplyResources(this.errorConfirmPass, "errorConfirmPass");
            this.errorConfirmPass.BackColor = System.Drawing.Color.Transparent;
            this.errorConfirmPass.ForeColor = System.Drawing.Color.Red;
            this.errorConfirmPass.Name = "errorConfirmPass";
            // 
            // errorDate
            // 
            resources.ApplyResources(this.errorDate, "errorDate");
            this.errorDate.BackColor = System.Drawing.Color.Transparent;
            this.errorDate.ForeColor = System.Drawing.Color.Red;
            this.errorDate.Name = "errorDate";
            // 
            // showPassword
            // 
            resources.ApplyResources(this.showPassword, "showPassword");
            this.showPassword.Name = "showPassword";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.CheckedChanged += new System.EventHandler(this.showPassword_CheckedChanged);
            // 
            // showConfirmPass
            // 
            resources.ApplyResources(this.showConfirmPass, "showConfirmPass");
            this.showConfirmPass.Name = "showConfirmPass";
            this.showConfirmPass.UseVisualStyleBackColor = true;
            this.showConfirmPass.CheckedChanged += new System.EventHandler(this.showConfirmPass_CheckedChanged);
            // 
            // RegisterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showConfirmPass);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.errorDate);
            this.Controls.Add(this.errorConfirmPass);
            this.Controls.Add(this.errorPass);
            this.Controls.Add(this.errorSurname);
            this.Controls.Add(this.errorName);
            this.Controls.Add(this.errorUsername);
            this.Controls.Add(this.loginInHereLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.repeatPasswordTextBox);
            this.Controls.Add(this.repeatPasswordLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.surnNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.surnNameLabel);
            this.Controls.Add(this.registerLabel);
            this.Name = "RegisterForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.Label surnNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox surnNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label repeatPasswordLabel;
        private System.Windows.Forms.TextBox repeatPasswordTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.RadioButton maleRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton femaleRadioButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loginInHereLabel;
        private System.Windows.Forms.Label errorUsername;
        private System.Windows.Forms.Label errorName;
        private System.Windows.Forms.Label errorSurname;
        private System.Windows.Forms.Label errorPass;
        private System.Windows.Forms.Label errorConfirmPass;
        private System.Windows.Forms.Label errorDate;
        private System.Windows.Forms.CheckBox showPassword;
        private System.Windows.Forms.CheckBox showConfirmPass;
    }
}
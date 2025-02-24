namespace FrontEnd
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginLabel = new System.Windows.Forms.Label();
            this.accountIconPictureBox = new System.Windows.Forms.PictureBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.registerLabel = new System.Windows.Forms.Label();
            this.userNotFoundLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.accountIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.loginLabel.Location = new System.Drawing.Point(51, 222);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(327, 29);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Zaloguj się do swojego konta";
            // 
            // accountIconPictureBox
            // 
            this.accountIconPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("accountIconPictureBox.InitialImage")));
            this.accountIconPictureBox.Location = new System.Drawing.Point(120, 12);
            this.accountIconPictureBox.Name = "accountIconPictureBox";
            this.accountIconPictureBox.Size = new System.Drawing.Size(200, 200);
            this.accountIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.accountIconPictureBox.TabIndex = 1;
            this.accountIconPictureBox.TabStop = false;
            this.accountIconPictureBox.Click += new System.EventHandler(this.accountIconPictureBox_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.userNameLabel.Location = new System.Drawing.Point(53, 273);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(102, 13);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "Nazwa użytkownika";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameTextBox.Location = new System.Drawing.Point(56, 300);
            this.userNameTextBox.Multiline = true;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(322, 32);
            this.userNameTextBox.TabIndex = 3;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordLabel.Location = new System.Drawing.Point(53, 347);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(36, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Hasło";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordTextBox.Location = new System.Drawing.Point(56, 372);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(322, 32);
            this.passwordTextBox.TabIndex = 5;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.submitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.submitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.submitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submitButton.Location = new System.Drawing.Point(56, 457);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(322, 53);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "ZALOGUJ SIĘ";
            this.submitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.registerLabel.Location = new System.Drawing.Point(159, 438);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(219, 16);
            this.registerLabel.TabIndex = 7;
            this.registerLabel.Text = "nie masz konta? zarejestruj się";
            this.registerLabel.Click += new System.EventHandler(this.registerLabel_Click);
            // 
            // userNotFoundLabel
            // 
            this.userNotFoundLabel.ForeColor = System.Drawing.Color.Red;
            this.userNotFoundLabel.Location = new System.Drawing.Point(146, 416);
            this.userNotFoundLabel.Name = "userNotFoundLabel";
            this.userNotFoundLabel.Size = new System.Drawing.Size(154, 22);
            this.userNotFoundLabel.TabIndex = 8;
            this.userNotFoundLabel.Text = "Nie ma takiego użytkownika";
            this.userNotFoundLabel.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(432, 525);
            this.Controls.Add(this.userNotFoundLabel);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.accountIconPictureBox);
            this.Controls.Add(this.loginLabel);
            this.Name = "LoginForm";
            this.Text = "Logowanie";
            ((System.ComponentModel.ISupportInitialize)(this.accountIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.PictureBox accountIconPictureBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.Label userNotFoundLabel;
    }
}


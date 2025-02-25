namespace FrontEnd
{
    partial class MainPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageForm));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.userAvatarPictureBox = new System.Windows.Forms.PictureBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.surnNameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.userSinceLabel = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.Location = new System.Drawing.Point(230, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(290, 29);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Witaj w Serwisie Metbook";
            // 
            // userAvatarPictureBox
            // 
            this.userAvatarPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("userAvatarPictureBox.InitialImage")));
            this.userAvatarPictureBox.Location = new System.Drawing.Point(50, 53);
            this.userAvatarPictureBox.Name = "userAvatarPictureBox";
            this.userAvatarPictureBox.Size = new System.Drawing.Size(130, 114);
            this.userAvatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatarPictureBox.TabIndex = 2;
            this.userAvatarPictureBox.TabStop = false;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.firstNameLabel.Location = new System.Drawing.Point(210, 53);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(55, 24);
            this.firstNameLabel.TabIndex = 3;
            this.firstNameLabel.Text = "Imie: ";
            // 
            // surnNameLabel
            // 
            this.surnNameLabel.AutoSize = true;
            this.surnNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surnNameLabel.Location = new System.Drawing.Point(313, 53);
            this.surnNameLabel.Name = "surnNameLabel";
            this.surnNameLabel.Size = new System.Drawing.Size(90, 24);
            this.surnNameLabel.TabIndex = 4;
            this.surnNameLabel.Text = "Nazwisko";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ageLabel.Location = new System.Drawing.Point(211, 95);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(42, 18);
            this.ageLabel.TabIndex = 5;
            this.ageLabel.Text = "Wiek";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.genderLabel.Location = new System.Drawing.Point(211, 126);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(35, 17);
            this.genderLabel.TabIndex = 6;
            this.genderLabel.Text = "Płec";
            // 
            // userSinceLabel
            // 
            this.userSinceLabel.AutoSize = true;
            this.userSinceLabel.Location = new System.Drawing.Point(314, 95);
            this.userSinceLabel.Name = "userSinceLabel";
            this.userSinceLabel.Size = new System.Drawing.Size(121, 13);
            this.userSinceLabel.TabIndex = 7;
            this.userSinceLabel.Text = "Użytkownik serwisu od: ";
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.logOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.75F, System.Drawing.FontStyle.Bold);
            this.logOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logOutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logOutButton.Location = new System.Drawing.Point(50, 239);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(130, 37);
            this.logOutButton.TabIndex = 8;
            this.logOutButton.Text = "Wyloguj się";
            this.logOutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // MainPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 307);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.userSinceLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.surnNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.userAvatarPictureBox);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "MainPageForm";
            this.Text = "Strona główna";
            ((System.ComponentModel.ISupportInitialize)(this.userAvatarPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox userAvatarPictureBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label surnNameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label userSinceLabel;
        private System.Windows.Forms.Button logOutButton;
    }
}
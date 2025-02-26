namespace FrontEnd
{
    partial class ManageUsers
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
            this.profileSettingsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profileSettingsLabel
            // 
            this.profileSettingsLabel.AutoSize = true;
            this.profileSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.profileSettingsLabel.Location = new System.Drawing.Point(170, 9);
            this.profileSettingsLabel.Name = "profileSettingsLabel";
            this.profileSettingsLabel.Size = new System.Drawing.Size(204, 29);
            this.profileSettingsLabel.TabIndex = 2;
            this.profileSettingsLabel.Text = "Ustawienia profilu";
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.profileSettingsLabel);
            this.Name = "ManageUsers";
            this.Text = "ManageUsers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label profileSettingsLabel;
    }
}
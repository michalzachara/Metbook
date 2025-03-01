namespace FrontEnd
{
    partial class Manage
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.id1 = new System.Windows.Forms.Label();
            this.mod1 = new System.Windows.Forms.Button();
            this.role1 = new System.Windows.Forms.Label();
            this.delete1 = new System.Windows.Forms.Button();
            this.username1 = new System.Windows.Forms.Label();
            this.name1 = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.findUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(211, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel Adminstratora";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(760, 455);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10);
            this.button1.Size = new System.Drawing.Size(162, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Powrot";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.id1);
            this.groupBox1.Controls.Add(this.mod1);
            this.groupBox1.Controls.Add(this.role1);
            this.groupBox1.Controls.Add(this.delete1);
            this.groupBox1.Controls.Add(this.username1);
            this.groupBox1.Controls.Add(this.name1);
            this.groupBox1.Controls.Add(this.pic1);
            this.groupBox1.Location = new System.Drawing.Point(15, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // id1
            // 
            this.id1.AutoSize = true;
            this.id1.BackColor = System.Drawing.Color.Transparent;
            this.id1.ForeColor = System.Drawing.Color.Orange;
            this.id1.Location = new System.Drawing.Point(286, 10);
            this.id1.Name = "id1";
            this.id1.Size = new System.Drawing.Size(15, 13);
            this.id1.TabIndex = 5;
            this.id1.Text = "id";
            // 
            // mod1
            // 
            this.mod1.Location = new System.Drawing.Point(170, 72);
            this.mod1.Name = "mod1";
            this.mod1.Size = new System.Drawing.Size(131, 23);
            this.mod1.TabIndex = 4;
            this.mod1.Text = "nadaj moderatora";
            this.mod1.UseVisualStyleBackColor = true;
            this.mod1.Click += new System.EventHandler(this.mod1_Click);
            // 
            // role1
            // 
            this.role1.AutoSize = true;
            this.role1.BackColor = System.Drawing.Color.Transparent;
            this.role1.ForeColor = System.Drawing.Color.Orange;
            this.role1.Location = new System.Drawing.Point(226, 19);
            this.role1.Name = "role1";
            this.role1.Size = new System.Drawing.Size(24, 13);
            this.role1.TabIndex = 3;
            this.role1.Text = "rola";
            // 
            // delete1
            // 
            this.delete1.BackColor = System.Drawing.Color.IndianRed;
            this.delete1.Location = new System.Drawing.Point(89, 72);
            this.delete1.Name = "delete1";
            this.delete1.Size = new System.Drawing.Size(70, 23);
            this.delete1.TabIndex = 3;
            this.delete1.Text = "usun";
            this.delete1.UseVisualStyleBackColor = false;
            this.delete1.Click += new System.EventHandler(this.delete1_Click);
            // 
            // username1
            // 
            this.username1.AutoSize = true;
            this.username1.Location = new System.Drawing.Point(97, 44);
            this.username1.Name = "username1";
            this.username1.Size = new System.Drawing.Size(53, 13);
            this.username1.TabIndex = 2;
            this.username1.Text = "username";
            // 
            // name1
            // 
            this.name1.AutoSize = true;
            this.name1.Location = new System.Drawing.Point(97, 19);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(80, 13);
            this.name1.TabIndex = 1;
            this.name1.Text = "Imie i Nazwisko";
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(6, 10);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(77, 85);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            // 
            // findUser
            // 
            this.findUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.findUser.Location = new System.Drawing.Point(364, 70);
            this.findUser.Name = "findUser";
            this.findUser.Size = new System.Drawing.Size(196, 29);
            this.findUser.TabIndex = 3;
            this.findUser.TextChanged += new System.EventHandler(this.findUser_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(18, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Wyszukaj po imieniu / nazwisku/ loginie";
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 539);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.findUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Manage";
            this.Text = " $";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button mod1;
        private System.Windows.Forms.Label role1;
        private System.Windows.Forms.Button delete1;
        private System.Windows.Forms.Label username1;
        private System.Windows.Forms.Label name1;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.TextBox findUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label id1;
    }
}
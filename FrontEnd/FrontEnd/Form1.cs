using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            accountIconPictureBox.Image = Image.FromFile("Images/accountIcon.png");
            passwordTextBox.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void accountIconPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
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

        private async void submitButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string userPassword = passwordTextBox.Text;
            if(String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(userPassword))
            {
                MessageBox.Show("nie podales loginu lub hasla");
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                //define URL of the API endpoint
                var url = "https://metbook.onrender.com/api/login";

                // create anonymous object to send as JSON
                var data = new { username = userName, password = userPassword };
                string jsonString = JsonConvert.SerializeObject(data);

                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url,content);
                    if(response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Response: " + result);
                    }
                    else
                    {
                        userNotFoundLabel.Visible = true;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Błąd w zapytaniu" + error);
                }

            }
        }
    }
}

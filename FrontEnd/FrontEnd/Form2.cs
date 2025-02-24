using Newtonsoft.Json;
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
using static System.Net.WebRequestMethods;

namespace FrontEnd
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void loginInLabel_Click(object sender,EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string surnName = surnNameTextBox.Text;
            string userPassword = passwordTextBox.Text;
            string repeatPassword = repeatPasswordTextBox.Text;
            string userDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            bool male = maleRadioButton.Checked;
            string sex; //define kurwa plec

            if (String.IsNullOrEmpty(userName))
            {
                userNameLabel.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(firstName))
            {
                firstNameLabel.ForeColor = Color.Red;
            }

            if(String.IsNullOrEmpty(surnName))
            {
                surnNameLabel.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(userPassword))
            {
                passwordLabel.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(repeatPassword))
            {
                repeatPasswordLabel.ForeColor = Color.Red;
            }

            if (repeatPassword != userPassword)
            {
                MessageBox.Show("Podane hasła się różnią");
            }

            if (male) sex = "male";
            else sex = "female";

            MessageBox.Show(userDate);

            using(HttpClient client = new HttpClient())
            {
                var data = new {
                    username = userName,
                    surname = surnName,
                    name = firstName,
                    password = userPassword,
                    confirmPassword = repeatPassword,
                    gender = sex,
                    date = userDate
                };

                string jsonString = JsonConvert.SerializeObject(data);

                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                try
                {
                    var url = "https://metbook.onrender.com/api/signup";

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        LoginForm loginForm = new LoginForm();
                        this.Hide();
                        loginForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Zła odpowiedź serwera: " + errorContent);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Wystapil blad przy rejestracji"+ex.Message);
                }
            }
        }
    }
}

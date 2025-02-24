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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            //---------------------------to  by pasowalo globalnie zrobic bo sie powtarza w onchange
            string userName = userNameTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string surnName = surnNameTextBox.Text;
            string userPassword = passwordTextBox.Text;
            string repeatPassword = repeatPasswordTextBox.Text;
            string userDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string sex;

            bool male = maleRadioButton.Checked;
            int errors = 0;





            //!!!!!!!!!!dodac checkboxy pokaz haslo i pokaz powtorz haslo






            // --------------------------------z tego zrobic funkcje zeby przejzysciej bylo
            if (String.IsNullOrEmpty(userName))
            {
                errorUsername.Text = "Pole wymagane";
                errorUsername.Visible = true;
                errors++;
            }
            else
            {
                errorUsername.Visible = false;
                if (userName.Length < 3)
                {
                    errorUsername.Text = "Nazwa uzytkownika musi byc dluzsza niz 3 znaki";
                    errorUsername.Visible = true;
                    errors++;
                }
                else
                {
                    errorUsername.Visible = false;
                }
            }

            if (String.IsNullOrEmpty(firstName))
            {
                errorName.Text = "Pole wymagane";
                errorName.Visible = true;
                errors++;
            }
            else
            {
                errorName.Visible = false;
                if (firstName.Length < 2)
                {
                    errorName.Text = "Imie musi zawierac minimum 2 znaki";
                    errorName.Visible = true;
                    errors++;
                }
                else
                {
                    errorName.Visible = false;
                }
            }

            if (String.IsNullOrEmpty(surnName))
            {
                errorSurname.Text = "Pole wymagane";
                errorSurname.Visible = true;
                errors++;
            }
            else
            {
                errorSurname.Visible = false;
                if (surnName.Length < 2)
                {
                    errorSurname.Text = "Nazwisko musi zawierac minimum 2 znaki";
                    errorSurname.Visible = true;
                    errors++;
                }
                else
                {
                    errorSurname.Visible = false;
                }
            }

            if (String.IsNullOrEmpty(userPassword))
            {
                errorPass.Text = "Pole wymagane";
                errorPass.Visible = true;
                errors++;
            }
            else
            {
                errorPass.Visible = false;
                if (userPassword.Length < 6)
                {
                    errorPass.Text = "Haslo musi miec minimum 6 znakow";
                    errorPass.Visible = true;
                    errors++;
                }
                else
                {
                    errorPass.Visible = false;
                }
            }

            if (String.IsNullOrEmpty(repeatPassword))
            {
                errorConfirmPass.Text = "Pole wymagane";
                errorConfirmPass.Visible = true;
                errors++;
            }
            else
            {
                errorConfirmPass.Visible = false;
                if (repeatPassword != userPassword)
                {
                    errorConfirmPass.Text = "Hasla musza byc takie \nsame";
                    errorConfirmPass.Visible = true;
                    errors++;
                }
                else
                {
                    errorConfirmPass.Visible = false;
                }
            }

            if (String.IsNullOrEmpty(userDate))
            {
                errorDate.Text = "Data urodzenia jest wymagana";
                errorDate.Visible = true;
                errors++;
            }
            else
            {
                errorDate.Visible = false;
                DateTime parsedDate;
                if (DateTime.TryParse(userDate, out parsedDate))
                {
                    int age = DateTime.Today.Year - parsedDate.Year;
                    if (parsedDate > DateTime.Today.AddYears(-age))
                    {
                        age--;
                    }
                    if (age < 13)
                    {
                        errorDate.Text = "Musisz miec co najmniej 13 lat";
                        errorDate.Visible = true;
                        errors++;
                    }
                    else
                    {
                        errorDate.Visible = false;
                    }
                }
                else
                {
                    errorDate.Text = "Niepoprawny format daty";
                    errorDate.Visible = true;
                    errors++;
                }
            }


            if (male) { sex = "male"; }
            else sex = "female";


            if (errors > 0) return;

            using (HttpClient client = new HttpClient())
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
                    //czsami chwile trwa dodanie do bazy wiec zablokowac przycisk i pola
                    //tak samo trzeba w loginie zrobic
                    submitButton.Text = "Rejestrowanie...";
                    submitButton.Enabled = false;
                    userNameTextBox.Enabled = false;
                    firstNameTextBox.Enabled = false;
                    surnNameTextBox.Enabled = false;
                    passwordTextBox.Enabled = false;
                    repeatPasswordTextBox.Enabled = false;
                    dateTimePicker1.Enabled = false;

                    var url = "https://metbook.onrender.com/api/signup";

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rejestracja przebiegla pomyslnie, zaloguj sie do swojego konta", "Sukcess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginForm loginForm = new LoginForm();
                        this.Hide();
                        loginForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //w node trzeba zmienic error na error'Nazwaproblemu' zeby np wyswietlalo ze taki uzytkonik istnieje
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Zła odpowiedź serwera: " + errorContent);
                    }

                } catch (Exception ex)
                {
                    submitButton.Text = "Zarejstruj";
                    submitButton.Enabled = true;
                    userNameTextBox.Enabled = true;
                    firstNameTextBox.Enabled = true;
                    surnNameTextBox.Enabled = true;
                    passwordTextBox.Enabled = true;
                    repeatPasswordTextBox.Enabled = true;
                    dateTimePicker1.Enabled = true;

                    MessageBox.Show("Wystapil blad przy rejestracji"+ex.Message);
                }
            }
        }


        //walidacja onChange

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(userNameTextBox.Text))
            {
                errorUsername.Text = "Pole wymagane";
                errorUsername.Visible = true;
            }
            else
            {
                errorUsername.Visible = false;
                if (userNameTextBox.Text.Length < 3)
                {
                    errorUsername.Text = "Nazwa uzytkownika musi byc dluzsza niz 3 znaki";
                    errorUsername.Visible = true;
                }
                else
                {
                    errorUsername.Visible = false;
                }
            }
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(firstNameTextBox.Text))
            {
                errorName.Text = "Pole wymagane";
                errorName.Visible = true;
            }
            else
            {
                errorName.Visible = false;
                if (firstNameTextBox.Text.Length < 2)
                {
                    errorName.Text = "Imie musi zawierac minimum 2 znaki";
                    errorName.Visible = true;
                }
                else
                {
                    errorName.Visible = false;
                }
            }
        }

        private void surnNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(surnNameTextBox.Text))
            {
                errorName.Text = "Pole wymagane";
                errorName.Visible = true;
            }
            else
            {
                errorName.Visible = false;
                if (surnNameTextBox.Text.Length < 2)
                {
                    errorName.Text = "Imie musi zawierac minimum 2 znaki";
                    errorName.Visible = true;
                }
                else
                {
                    errorName.Visible = false;
                }
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                errorPass.Text = "Pole wymagane";
                errorPass.Visible = true;
            }
            else
            {
                errorPass.Visible = false;
                if (passwordTextBox.Text.Length < 6)
                {
                    errorPass.Text = "Haslo musi miec minimum 6 znakow";
                    errorPass.Visible = true;
                }
                else
                {
                    errorPass.Visible = false;
                }
            }
        }

        private void repeatPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(repeatPasswordTextBox.Text))
            {
                errorConfirmPass.Text = "Pole wymagane";
                errorConfirmPass.Visible = true;
            }
            else
            {
                errorConfirmPass.Visible = false;

                if (repeatPasswordTextBox.Text.Length < 6)
                {
                    errorConfirmPass.Text = "Haslo musi miec minimum 6 znakow";
                    errorConfirmPass.Visible = true;
                }
                else
                {
                    errorConfirmPass.Visible = false;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dateTimePicker1.Value.ToString("yyyy-MM-dd")))
            {
                errorDate.Text = "Data urodzenia jest wymagana";
                errorDate.Visible = true;
            }
            else
            {
                errorDate.Visible = false;
                DateTime parsedDate;
                if (DateTime.TryParse(dateTimePicker1.Value.ToString("yyyy-MM-dd"), out parsedDate))
                {
                    int age = DateTime.Today.Year - parsedDate.Year;
                    if (parsedDate > DateTime.Today.AddYears(-age))
                    {
                        age--;
                    }
                    if (age < 13)
                    {
                        errorDate.Text = "Musisz miec co najmniej 13 lat";
                        errorDate.Visible = true;
                    }
                    else
                    {
                        errorDate.Visible = false;
                    }
                }
                else
                {
                    errorDate.Text = "Niepoprawny format daty";
                    errorDate.Visible = true;
                }
            }
        }
    }
}

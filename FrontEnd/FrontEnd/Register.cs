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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FrontEnd
{
    public partial class RegisterForm : Form
    {

        private string userName, firstName, surnName, userPassword, repeatPassword, userDate, sex;
        bool male;
        private int errors = 0;
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
            getAllData();
            validateWholeForm();


            if (errors > 0)
            {
                errors = 0;
                return;
            }

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
                    changeFormStatus(false, "Rejestrowanie...");

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
                        string result = await response.Content.ReadAsStringAsync();

                        try
                        {
                            var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                            if (errorResponse != null && errorResponse.ContainsKey("error"))
                            {
                                errorUsername.Text = errorResponse["error"];
                                errorUsername.Visible = true;
                            }
                            errorUsername.Visible = false;
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show("Błąd w zapytaniu");
                        }
                    }

                } catch (Exception ex)
                {
                    MessageBox.Show("Wystapil blad przy rejestracji"+ex.Message);
                    changeFormStatus(true, "Zarejestruj sie");
                }
            }
        }


        //show hide password
        private void showConfirmPass_CheckedChanged(object sender, EventArgs e)
        {
            if (showConfirmPass.Checked)
                repeatPasswordTextBox.PasswordChar = '\0';
            else
                repeatPasswordTextBox.PasswordChar = '*';
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
                passwordTextBox.PasswordChar = '\0';
            else
                passwordTextBox.PasswordChar = '*';
        }

        private void changeFormStatus(bool status,  string message)
        {
            submitButton.Text = message;
            submitButton.Enabled = status;
            userNameTextBox.Enabled = status;
            firstNameTextBox.Enabled = status;
            surnNameTextBox.Enabled = status;
            passwordTextBox.Enabled = status;
            repeatPasswordTextBox.Enabled = status;
            dateTimePicker1.Enabled = status;
        }

        private void getAllData()
        {
            userName = userNameTextBox.Text;
            firstName = firstNameTextBox.Text;
            surnName = surnNameTextBox.Text;
            userPassword = passwordTextBox.Text;
            repeatPassword = repeatPasswordTextBox.Text;
            userDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            male = maleRadioButton.Checked;

            if (male) { sex = "male"; }
            else sex = "female";
        }

        //validation
        public void validateWholeForm()
        {
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
                    errorConfirmPass.Text = "Hasla musza byc\ntakie same";
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
        }

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
                    errorPass.Text = "Haslo musi miec\nminimum 6 znakow";
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
                    errorConfirmPass.Text = "Haslo musi miec\nminimum 6 znakow";
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

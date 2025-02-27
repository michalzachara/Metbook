using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FrontEnd
{
    public partial class ProfileSettings : Form
    {
        public UserData userData;
        public ProfileSettings(UserData userData)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //Center window

            this.userData = userData;
            changedBirthDate.Text = userData.Date;
            changedNameTextBox.Text = userData.Name;
            changedSurnameTextBox.Text = userData.Surname;
            changedLoginTextBox.Text = userData.Username;
            OLdPass.PasswordChar = '*';
            NewPass.PasswordChar = '*';
            ConfirmNewPass.PasswordChar = '*';
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            MainPageForm mainPageForm = new MainPageForm(userData); // after go Back Click create new page and open it with userData as constructor parameter
            this.Hide();
            mainPageForm.ShowDialog();
            this.Close();
        }

        private async void saveDataButton_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = new
                    {
                        _id = userData.Id,
                        username = changedLoginTextBox.Text,
                        surname = changedSurnameTextBox.Text,
                        name = changedNameTextBox.Text,
                        date = changedBirthDate.Value.ToString("yyyy-MM-dd")
                    };

                    string jsonString = JsonConvert.SerializeObject(data);

                    HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    changeFormStatus(false,"Zapisywanie ...");
                    try {
                        var response = client.PutAsync("http://localhost:3000/api/profile", content).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Dane zostały zapisane");

                            userData.Name = changedNameTextBox.Text;
                            userData.Surname = changedSurnameTextBox.Text;
                            userData.Username = changedLoginTextBox.Text;
                            userData.Date = changedBirthDate.Value.ToString("yyyy-MM-dd");

                            changeFormStatus(true, "Zapisz");
                        }
                        else
                        {
                            string result = await response.Content.ReadAsStringAsync();

                            try
                            {
                                var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                                if (errorResponse != null && errorResponse.ContainsKey("errorUsername"))
                                {
                                    errorUsername.Visible = true;
                                    errorUsername.Text= errorResponse["errorUsername"];    
                                }else
                                    errorUsername.Visible = false;
                            }
                            catch (JsonException)
                            {
                                MessageBox.Show("Błąd w zapytaniu");
                            }
                            MessageBox.Show("Błąd podczas zapisywania danych");
                            changeFormStatus(true, "Zapisz");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Błąd podczas zapisywania danych po stronie serwera");
                        changeFormStatus(true, "Zapisz");
                    }
                }
            }
        }
        private void changeFormStatus(bool status, string message)
        {
            saveDataButton.Enabled = status;
            changedNameTextBox.Enabled = status;
            changedSurnameTextBox.Enabled = status;
            changedLoginTextBox.Enabled = status;
            changedBirthDate.Enabled = status;
            saveDataButton.Text = message;
            NewPass.Enabled = status;
            ConfirmNewPass.Enabled = status;
            OLdPass.Enabled = status;
        }
        /// <summary>
        /// Check if form is valid
        /// </summary>
        private bool validateForm()
        {
            bool error = false;
            if (changedNameTextBox.Text.Length < 3)
            {
                errorName.Visible = true;
                errorName.Text = "Imię musi mieć co najmniej 3 znaki";
                error = true;
            }
            else
            {
                errorName.Visible = false;
            }
            if (changedSurnameTextBox.Text.Length < 3)
            {
                errorSurname.Visible = true;
                errorSurname.Text = "Nazwisko musi mieć co najmniej 3 znaki";
                error = true;
            }
            else
            {
                errorSurname.Visible = false;
            }
            if (changedLoginTextBox.Text.Length < 3)
            {
                errorUsername.Visible = true;
                errorUsername.Text = "Login musi mieć co najmniej 3 znaki";
                error = true;
            }
            else
            {
                errorUsername.Visible = false;
            }
            DateTime parsedDate;
            if (DateTime.TryParse(changedBirthDate.Value.ToString("yyyy-MM-dd"), out parsedDate))
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
                    error = true;
                }
                else
                {
                    errorDate.Visible = false;
                }
            }
            return error;
        }

        private async void changePasswordButton_Click(object sender, EventArgs e)
        {
            int error1 = 0;
            if (OLdPass.Text.Length < 1) 
            {
                errorOldPass.Visible = true;
                errorOldPass.Text = "Podaj aktualne haslo";
                error1++;
            }
            else
            {
                errorOldPass.Visible = false;
            }

            if (NewPass.Text.Length < 6)
            {
                ErrorNewPass.Visible = true;
                ErrorNewPass.Text = "Haslo musi miec co najmniej 6 znakow";
                error1++;
            }
            else
            {
                ErrorNewPass.Visible = false;
            }

            if(ConfirmNewPass.Text.Length <6)
            {
                ErrorConfirmNewPass.Visible = true;
                ErrorConfirmNewPass.Text = "Haslo musi miec co najmniej 6 znakow";
                error1++;
            }
            else
            {
                ErrorConfirmNewPass.Visible = false;
                if(NewPass.Text != ConfirmNewPass.Text)
                {
                    ErrorConfirmNewPass.Visible = true;
                    ErrorConfirmNewPass.Text = "Hasla nie sa takie same";
                    error1++;
                }else
                {
                    ErrorConfirmNewPass.Visible = false;
                }
            }

            if(OLdPass.Text == NewPass.Text)
            {
                ErrorNewPass.Visible = true;
                ErrorNewPass.Text = "Nowe haslo nie moze byc takie samo jak stare";
                error1++;
            }
            else
            {
                ErrorNewPass.Visible = false;
            }


            if (error1 > 0) return;

            using (HttpClient client = new HttpClient())
            {
                var data = new
                {
                    _id = userData.Id,
                    password = OLdPass.Text,
                    newPassword = NewPass.Text,
                    confirmNewPassword = ConfirmNewPass.Text
                };

                string jsonString = JsonConvert.SerializeObject(data);

                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                changeFormStatus(false, "Zapisywanie ...");
                try
                {
                    var response1 = client.PutAsync("http://localhost:3000/api/profile/changePassword", content).Result;

                    if (response1.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Zapisano nowe haslo");
                        changeFormStatus(true, "Zapisz");
                    }
                    else
                    {
                        string result1 = await response1.Content.ReadAsStringAsync();

                        try
                        {
                            var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result1);

                            if (errorResponse != null && errorResponse.ContainsKey("error"))
                            {
                                errorOldPass.Visible = true;
                                errorOldPass.Text = errorResponse["error"];
                            }
                            else
                                errorOldPass.Visible = false;
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show("Błąd w zapytaniu");
                        }

                        MessageBox.Show("Błąd podczas zapisywania danych");
                        changeFormStatus(true, "Zapisz");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd podczas zapisywania danych po stronie serwera");
                    changeFormStatus(true, "Zapisz");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox1.Checked;
            changePasswordButton.Visible = checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                OLdPass.PasswordChar = '\0';
            else
                OLdPass.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                NewPass.PasswordChar = '\0';
            else
                NewPass.PasswordChar = '*';
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                ConfirmNewPass.PasswordChar = '\0';
            else
                ConfirmNewPass.PasswordChar = '*';
        }
    }
}

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
                        gender = userData.Gender,
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
                            changeFormStatus(true, "Zapisz");
                        }
                        else
                        {
                            string result = await response.Content.ReadAsStringAsync();

                            try
                            {
                                var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                                if (errorResponse != null && errorResponse.ContainsKey("error"))
                                {
                                    MessageBox.Show(errorResponse["error"]);    
                                }
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
                    catch (Exception ex)
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
    }
}

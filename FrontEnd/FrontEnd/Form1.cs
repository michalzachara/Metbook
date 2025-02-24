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
                userNotFoundLabel.Text = ("Podaj poprawnie dane");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                var url = "https://metbook.onrender.com/api/login";
                var data = new { username = userName, password = userPassword };

                string jsonString = JsonConvert.SerializeObject(data);

                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url,content);
                    if(response.IsSuccessStatusCode)
                    {
                        //hide error label
                        userNotFoundLabel.Visible = false;

                        //declaration variables of response from server
                        string resId,resUsername, resName, resSurname, resGender, resDate, resProfilePic;

                        string result = await response.Content.ReadAsStringAsync();

                        try
                        {
                            var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                            if (jsonResponse != null)
                            {
                                resId = jsonResponse["_id"];
                                resUsername = jsonResponse["username"];
                                resName = jsonResponse["name"];
                                resSurname = jsonResponse["surname"];
                                resGender = jsonResponse["gender"];
                                resDate = jsonResponse["date"];
                                resProfilePic = jsonResponse["profilePic"];

                                //-------------TO DO send it to main form (profile)
                            }
                        }
                        catch (JsonException)
                        {
                            return;
                        }
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        try
                        {
                            var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                            if (errorResponse != null && errorResponse.ContainsKey("error"))
                            {
                                userNotFoundLabel.Text = errorResponse["error"];
                                userNotFoundLabel.Visible = true;
                            }
                        }
                        catch (JsonException)
                        {
                            return;
                        }
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

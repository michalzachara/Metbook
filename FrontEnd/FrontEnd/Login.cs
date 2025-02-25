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

            submitButton.Enabled = false;
            userNameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;

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

                        string result = await response.Content.ReadAsStringAsync();

                        try
                        {
                            var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                            if (jsonResponse != null)
                            {
                                var dataToSend = new {
                                    id = jsonResponse["_id"],
                                    username = jsonResponse["username"],
                                    name = jsonResponse["name"],
                                    surname = jsonResponse["surname"],
                                    gender = jsonResponse["gender"],
                                    date = jsonResponse["date"],
                                    createdAt = jsonResponse["createdAt"],
                                    profilePic = jsonResponse["profilePic"],
                                    role = jsonResponse["role"],
                                };

                                UserData userData = new UserData(
                                    dataToSend.id.ToString(),
                                    dataToSend.username.ToString(),
                                    dataToSend.name.ToString(),
                                    dataToSend.surname.ToString(),
                                    dataToSend.gender.ToString(),
                                    dataToSend.date.ToString(),
                                    dataToSend.createdAt.ToString(),
                                    dataToSend.profilePic.ToString(),
                                    dataToSend.role.ToString()
                                );
                                MainPageForm mainPageForm = new MainPageForm(userData);
                                this.Hide();
                                mainPageForm.ShowDialog();
                                this.Close();
                                //-------------send it to main form (profile)
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
                            MessageBox.Show("Błąd w zapytaniu");
                            userNotFoundLabel.Visible = true;
                            
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Błąd w zapytaniu" + error);
                }
                submitButton.Enabled = true;
                userNameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
            }
        }
    }
}

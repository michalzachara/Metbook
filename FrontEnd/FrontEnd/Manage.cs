using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class Manage : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public UserData userData;
        public UserData[] usersToShow = new UserData[6];

        public Manage(UserData userData)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userData = userData;
            _ = LoadDataAsync();  // Enable async method to run without waiting for it to complete
        }
        /// <summary>
        /// Load user data from server
        /// </summary>
        private async Task LoadDataAsync()
        {
            string url = "http://localhost:3000/api/users";

            try
            {
                var requestData = new { role = this.userData.Role };
                string json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();  // Throw an exception if HTTP response is not success

                string result = await response.Content.ReadAsStringAsync();
                List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(result);

                if (users != null && users.Count > 0)
                {
                    UpdateUI(users);
                }
                else
                {
                    UpdateUI(new List<UserData>()); // Reset UI if no users are returned
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Błąd w zapytaniu HTTP: " + httpEx.Message);
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show("Błąd parsowania JSON: " + jsonEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieoczekiwany błąd: " + ex.Message);
            }
        }


        /// <summary>
        /// Update UI with user data
        /// </summary>
        /// <param name="users">The list of the users returned form server</param>
        private void UpdateUI(List<UserData> users)
        {
            // Find or create a Panel to hold the user data
            Panel scrollablePanel = this.Controls.OfType<Panel>().FirstOrDefault();
            if (scrollablePanel == null)
            {
                scrollablePanel = new Panel();
                scrollablePanel.Width = 700;
                scrollablePanel.Location = new Point(10, 122);
                this.Controls.Add(scrollablePanel);
            }

            // reset panel
            scrollablePanel.Controls.Clear();

            // if the list is empty, return
            if (users.Count == 0)
            {
                return;
            }

            // Constants for the layout
            int groupBoxWidth = 320;
            int groupBoxHeight = 120;
            int xOffset = 10;
            int yOffset = 10;
            int spacing = 10;
            int maxPanelHeight = 400;
            int counter = 0;

            foreach (var user in users)
            {
                if (user.Role == "admin")
                {
                    continue;
                }
                if(user.Role == "moderator" && this.userData.Role == "moderator")
                {
                    continue;
                }

                // Create GroupBox
                GroupBox groupBox = new GroupBox
                {
                    Text = "Użytkownik",
                    Width = groupBoxWidth,
                    Height = groupBoxHeight,
                    Location = new Point(xOffset, yOffset)
                };

                // Create PictureBox
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(50, 50),
                    Location = new Point(10, 25),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (!string.IsNullOrEmpty(user.ProfilePic))
                {
                    pictureBox.LoadAsync(user.ProfilePic);
                }

                // creating a labels
                Label lblName = new Label 
                { 
                    Text = user.Name + " " + user.Surname, 
                    Font = new Font("Arial", 10, FontStyle.Bold), 
                    Location = new Point(70, 20), 
                    AutoSize = true 
                };

                Label lblUsername = new Label 
                { 
                    Text = "@" + user.Username, 
                    Font = new Font("Arial", 9, FontStyle.Italic), 
                    ForeColor = Color.Gray, 
                    Location = new Point(70, 40), 
                    AutoSize = true 
                };

                Label lblRole = new Label 
                { 
                    Text = "Rola: " + user.Role, 
                    ForeColor = Color.Orange, 
                    Location = new Point(70, 60), 
                    AutoSize = true 
                };

                Label lblId = new Label 
                { 
                    Text = "ID: " + user._id.ToString(), 
                    ForeColor = Color.Orange, 
                    Font = new Font("Arial", 8, FontStyle.Regular), 
                    Location = new Point(150, 40), 
                    AutoSize = true 
                };

                
                //Moderator and admins cans delte a users
                Button btnRemove = new Button()
                {
                    Text = "Usuń",
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(70, 85),
                    Size = new Size(60, 25),
                };

                btnRemove.Click += (sender, e) => delete(sender, e);

                
                Button btnMod = new Button()
                {
                    Text = user.Role == "user" ? "Mianuj na moderatora" : "Usun moderatora",
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(140, 85),
                    Size = new Size(120, 25),
                };

                btnMod.Click += (sender, e) => changeRole(sender, e);

                // Dodanie elementów do GroupBox
                groupBox.Controls.Add(pictureBox);
                groupBox.Controls.Add(lblName);
                groupBox.Controls.Add(lblUsername);
                groupBox.Controls.Add(lblRole);
                groupBox.Controls.Add(lblId);
                groupBox.Controls.Add(btnRemove);


                if (this.userData.Role == "admin") groupBox.Controls.Add(btnMod);

                scrollablePanel.Controls.Add(groupBox);

                counter++;
                if (counter % 2 == 0)
                {
                    xOffset = 10;
                    yOffset += groupBoxHeight + spacing;
                }
                else
                {
                    xOffset = groupBoxWidth + 20;
                }

                int rowCount = (int)Math.Ceiling(counter / 2.0);
                int requiredHeight = rowCount * (groupBoxHeight + spacing);
                scrollablePanel.Height = requiredHeight > maxPanelHeight ? maxPanelHeight : requiredHeight;
                scrollablePanel.AutoScroll = requiredHeight > maxPanelHeight;
            }
        }



        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPageForm mainPageForm = new MainPageForm(userData);
            mainPageForm.ShowDialog();
            this.Close();
        }
        private async void delete(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;


            GroupBox parentGroupBox = clickedButton.Parent as GroupBox;
            if (parentGroupBox == null) return;

            Label lblId = parentGroupBox.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("ID: "));
            if (lblId == null) return;

            string userId = lblId.Text.Replace("ID: ", "").Trim();

            DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć użytkownika o ID: {userId}?",
                                                  "Potwierdzenie",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            string url = "http://localhost:3000/api/users/";

            var requestData = new { _id = userId, role = this.userData.Role };
            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = content // Dodanie treści do DELETE
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Użytkownik został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadDataAsync();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Błąd usuwania użytkownika: " + errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Błąd HTTP: " + httpEx.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show("Błąd JSON: " + jsonEx.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieoczekiwany błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void changeRole(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            GroupBox parentGroupBox = clickedButton.Parent as GroupBox;
            if (parentGroupBox == null) return;

            Label lblId = parentGroupBox.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("ID: "));
            if (lblId == null) return;

            string userId = lblId.Text.Replace("ID: ", "").Trim();

            string roleOfUser = "";
            if (this.userData.Role == "moderator") roleOfUser = "user";
            else roleOfUser = "moderator";

            var requestData = new { _id = userId, role = roleOfUser };
            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                string url = "http://localhost:3000/api/changeRole";
                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    _ = LoadDataAsync();
                    MessageBox.Show($"Użytkownik o ID: {userId} został pomyślnie zaktualizowany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Błąd zmiany roli użytkownika: " + errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Błąd HTTP: " + httpEx.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show("Błąd JSON: " + jsonEx.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieoczekiwany błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void findUser_TextChanged(object sender, EventArgs e)
        {
            string query = findUser.Text.Trim().ToString(); 
            if (string.IsNullOrEmpty(query))
            {
                _ = LoadDataAsync();
                return;
            }

            string url = "http://localhost:3000/api/search/";
            var requestData = new { query = query, role = this.userData.Role }; 
            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(result);

                if (users != null && users.Count > 0)
                {
                    notFound.Visible = false;
                    UpdateUI(users);
                }
                else
                {
                    UpdateUI(new List<UserData>());
                    notFound.Visible = true;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Błąd HTTP: " + httpEx.Message);
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show("Błąd parsowania JSON: " + jsonEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void notFound_Click(object sender, EventArgs e)
        {

        }
    }
}

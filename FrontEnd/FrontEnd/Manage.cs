using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();  // Throw an exception if HTTP response is not success

                string result = await response.Content.ReadAsStringAsync();
                List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(result);

                if (users != null)
                {
                    UpdateUI(users);
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
            // Constants for dynamic layout
            int groupBoxWidth = 320;
            int groupBoxHeight = 120;
            int xOffset = 10; // Position X for first column
            int yOffset = 10; // Postion Y for first row
            int spacing = 10; // Gap between GroupBoxes
            int maxPanelHeight = 400; // Max height for scrollable panel
            int counter = 0;  // counter for dynamic layout

            // Create scrollable panel
            Panel scrollablePanel = new Panel();
            scrollablePanel.Width = 700; // Width of the panel for two columns
            scrollablePanel.Location = new Point(10, 122);
            this.Controls.Add(scrollablePanel);

            foreach (var user in users)
            {
                if(user.Role == "admin" || user.Role == "moderator") // if user is admin or moderator, skip
                {
                    continue;
                }
                // Create GroupBox for user
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "Użytkownik";
                groupBox.Width = groupBoxWidth;
                groupBox.Height = groupBoxHeight;
                groupBox.Location = new Point(xOffset, yOffset);

                // Create PictureBox for profile picture
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(50, 50);
                pictureBox.Location = new Point(10, 25);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (!string.IsNullOrEmpty(user.ProfilePic))
                {
                    pictureBox.LoadAsync(user.ProfilePic);
                }

                // Label for name
                Label lblName = new Label();
                lblName.Text = user.Name + " " + user.Surname;
                lblName.Font = new Font("Arial", 10, FontStyle.Bold);
                lblName.Location = new Point(70, 20);
                lblName.AutoSize = true;

                // Label for username
                Label lblUsername = new Label();
                lblUsername.Text = "@" + user.Username;
                lblUsername.Font = new Font("Arial", 9, FontStyle.Italic);
                lblUsername.ForeColor = Color.Gray;
                lblUsername.Location = new Point(70, 40);
                lblUsername.AutoSize = true;

                // Label for roli
                Label lblRole = new Label();
                lblRole.Text = "Rola: " + user.Role;
                lblRole.ForeColor = Color.Orange;
                lblRole.Location = new Point(70, 60);
                lblRole.AutoSize = true;

                // Label for ID
                Label lblId = new Label();
                lblId.Text = "ID: " + user._id.ToString();
                lblId.ForeColor = Color.Orange;
                lblId.Font = new Font("Arial", 8, FontStyle.Regular);
                lblId.Location = new Point(150, 40);
                lblId.AutoSize = true;

                // Button "Usuń"
                Button btnRemove = new Button();
                btnRemove.Text = "Usuń";
                btnRemove.BackColor = Color.Red;
                btnRemove.ForeColor = Color.White;
                btnRemove.FlatStyle = FlatStyle.Flat;
                btnRemove.Location = new Point(70, 85);
                btnRemove.Size = new Size(60, 25);

                // Button "Nadaj moderatora"
                Button btnMod = new Button();
                if (userData.Role == "admin") // Only admin can assign moderator role
                {
                    btnMod.Text = "Nadaj moderatora";
                    btnMod.FlatStyle = FlatStyle.Flat;
                    btnMod.Location = new Point(140, 85);
                    btnMod.Size = new Size(120, 25);
                }


                // Add controls to GroupBox
                groupBox.Controls.Add(pictureBox);
                groupBox.Controls.Add(lblName);
                groupBox.Controls.Add(lblUsername);
                groupBox.Controls.Add(lblRole);
                groupBox.Controls.Add(lblId);
                groupBox.Controls.Add(btnRemove);
                if(userData.Role == "admin") groupBox.Controls.Add(btnMod);

                // Add GroupBox to scrollable panel
                scrollablePanel.Controls.Add(groupBox);

                // **Dynamic set on the layout**
                counter++;
                if (counter % 2 == 0) // If its the second column go to next row
                {
                    xOffset = 10;
                    yOffset += groupBoxHeight + spacing; // move down
                }
                else
                {
                    xOffset = groupBoxWidth + 20; // Move right to the second column
                }
                // **Calculate height of the panel**
                int rowCount = (int)Math.Ceiling(counter / 2.0); // Number of rows
                int requiredHeight = rowCount * (groupBoxHeight + spacing); // required height

                // If required height is greater than max height, enable scrolling
                if (requiredHeight > maxPanelHeight)
                {
                    scrollablePanel.Height = maxPanelHeight;
                    scrollablePanel.AutoScroll = true;
                }
                else
                {
                    scrollablePanel.Height = requiredHeight;
                }
            }
        }


        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPageForm mainPageForm = new MainPageForm(userData);
            mainPageForm.ShowDialog();
            this.Close();
        }
        private async void delete1_Click(object sender, EventArgs e)
        {
          
        }

        private async void mod1_Click(object sender, EventArgs e)
        {
          
        }

        private async void findUser_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}

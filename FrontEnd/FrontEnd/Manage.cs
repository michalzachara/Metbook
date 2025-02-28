using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            groupBox1.Controls["label1"].Text = "Hejka";
            _ = LoadDataAsync();  // Uruchomienie bez oczekiwania, by nie blokować UI
        }

        private async Task LoadDataAsync()
        {
            string url = "http://localhost:3000/api/users";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();  // Rzuca wyjątek, jeśli kod HTTP nie jest sukcesem

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

        private void UpdateUI(List<UserData> users)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(users)));
                return;
            }

            GroupBox[] boxes = new GroupBox[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6 };

            int count = Math.Min(users.Count, boxes.Length); // Unikamy błędu, gdy użytkowników jest mniej niż 6

            for (int i = 0; i < count; i++)
            {
                var user = users[i];

                boxes[i].Visible = true;

                if (boxes[i].Controls[$"name{i}"] is Label nameLabel)
                    nameLabel.Text = $"{user.Name} {user.Surname}";

                if (boxes[i].Controls[$"username{i}"] is Label usernameLabel)
                    usernameLabel.Text = user.Username;

                if (boxes[i].Controls[$"role{i}"] is Label roleLabel)
                    roleLabel.Text = user.Role;

                if (boxes[i].Controls[$"id{i}"] is Label idLabel)
                    idLabel.Text = user.Id;

                if (!string.IsNullOrEmpty(user.ProfilePic) && boxes[i].Controls[$"pic{i}"] is PictureBox pictureBox)
                {
                    try
                    {
                        pictureBox.LoadAsync(user.ProfilePic);
                    }
                    catch
                    {
                        Console.WriteLine("Blad pobierania obraznu");
                    }
                }
            }

            groupBox1.Controls["label1"].Text = "Załadowano " + users.Count + " użytkowników";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageForm mainPageForm = new MainPageForm(userData);
            mainPageForm.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private async void delete1_Click(object sender, EventArgs e)
        {
            if (sender is Button deleteButton)
            {
                // Znalezienie GroupBox, w którym znajduje się przycisk
                GroupBox parentGroupBox = deleteButton.Parent as GroupBox;

                if (parentGroupBox != null)
                {
                    // Pobranie ID użytkownika z etykiety w GroupBox
                    Label idLabel = parentGroupBox.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.Contains("id"));

                    if (idLabel != null && !string.IsNullOrEmpty(idLabel.Text))
                    {
                        string userId = idLabel.Text;
                        DialogResult dialogResult = MessageBox.Show(
                            "Czy na pewno chcesz usunąć tego użytkownika?",
                            "Potwierdzenie",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (dialogResult == DialogResult.Yes)
                        {
                            string url = $"http://localhost:3000/api/users/{userId}";

                            try
                            {
                                HttpResponseMessage response = await client.DeleteAsync(url);
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Użytkownik został usunięty!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await LoadDataAsync(); // Załaduj dane ponownie po usunięciu użytkownika
                                }
                                else
                                {
                                    MessageBox.Show($"Błąd usuwania: {response.ReasonPhrase}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Błąd połączenia z serwerem: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie można pobrać ID użytkownika!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void mod1_Click(object sender, EventArgs e)
        {
            if (sender is Button modButton)
            {
                // Znalezienie GroupBox, w którym znajduje się przycisk
                GroupBox parentGroupBox = modButton.Parent as GroupBox;

                if (parentGroupBox != null)
                {
                    // Pobranie ID użytkownika z etykiety w GroupBox
                    Label idLabel = parentGroupBox.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.Contains("id"));
                    ComboBox roleComboBox = parentGroupBox.Controls.OfType<ComboBox>().FirstOrDefault(cmb => cmb.Name.Contains("role"));

                    if (idLabel != null && !string.IsNullOrEmpty(idLabel.Text) && roleComboBox != null)
                    {
                        string userId = idLabel.Text;
                        string newRole = roleComboBox.SelectedItem.ToString();

                        DialogResult dialogResult = MessageBox.Show(
                            "Czy na pewno chcesz zmienić rolę tego użytkownika?",
                            "Potwierdzenie",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (dialogResult == DialogResult.Yes)
                        {
                            string url = "http://localhost:3000/api/changeRole";  // Endpoint zmiany roli
                            var payload = new { _id = userId, role = newRole };

                            try
                            {
                                // Serializowanie obiektu payload do JSON
                                string jsonPayload = JsonConvert.SerializeObject(payload);

                                // Tworzenie treści zapytania HTTP
                                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                                // Wysłanie zapytania PUT
                                HttpResponseMessage response = await client.PutAsync(url, content);

                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Rola została zmieniona!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await LoadDataAsync();  // Odświeżenie danych po zmianie roli
                                }
                                else
                                {
                                    MessageBox.Show($"Błąd zmiany roli: {response.ReasonPhrase}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Błąd połączenia z serwerem: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie można pobrać ID użytkownika lub roli!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void findUser_TextChanged(object sender, EventArgs e)
        {
            TextBox searchBox = sender as TextBox;

            if (searchBox != null && !string.IsNullOrEmpty(searchBox.Text))
            {
                string query = searchBox.Text;
                string url = $"http://localhost:3000/api/search?query={query}";  // Endpoint z parametrem wyszukiwania

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();  // Rzuca wyjątek, jeśli kod HTTP nie jest sukcesem

                    string result = await response.Content.ReadAsStringAsync();
                    List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(result);

                    if (users != null)
                    {
                        UpdateUI(users);  // Uaktualnienie UI na podstawie wyników wyszukiwania
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
            else
            {
                await LoadDataAsync();  // Jeśli pole wyszukiwania jest puste, załaduj wszystkie dane
            }
        }

    }
}

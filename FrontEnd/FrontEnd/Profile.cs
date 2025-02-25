using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FrontEnd
{
    public partial class MainPageForm : Form
    {
        public UserData userData;
        public MainPageForm(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;

            userAvatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            userAvatarPictureBox.LoadAsync(userData.ProfilePic);
            firstNameLabel.Text = userData.Name.ToString();
            surnNameLabel.Text = userData.Surname.ToString();
            ageLabel.Text = "Wiek: " + CalculateAge(userData.Date).ToString();
            if (userData.Gender == "male")  genderLabel.Text = "Płeć: Mężczyzna";
            else genderLabel.Text = "Płeć: Kobieta";
            userSinceLabel.Text = "Użytkownik serwisu od "+(CalculateAge(userData.userSince)*12)+" miesięcy";
        }
        public int CalculateAge(string birthDateString)
        {
            try
            {
                DateTime birthDate = DateTime.Parse(birthDateString, null, System.Globalization.DateTimeStyles.RoundtripKind);
                DateTime today = DateTime.Today;

                int age = today.Year - birthDate.Year;

                // Sprawdzenie, czy osoba już miała urodziny w tym roku
                if (birthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd parsowania daty: {ex}");
                  return -1;
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}

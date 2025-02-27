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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userData = userData;

            //Set a UserData to labels
            userAvatarPictureBox.LoadAsync(userData.ProfilePic);
            firstNameLabel.Text = userData.Name.ToString();
            surnNameLabel.Text = userData.Surname.ToString();
            ageLabel.Text = "Wiek: " + CalculateAge(userData.Date).ToString();
            if (userData.Gender == "male") genderLabel.Text = "Płeć: Mężczyzna";
            else genderLabel.Text = "Płeć: Kobieta";
            userSinceLabel.Text = "Użytkownik serwisu od " + (CalculateMonths(userData.UserSince)) + " miesięcy";
            if (userData.Role == "admin")
            {
                userRole.Text = "Twoja rola to administrator";
                manageUsersButton.Visible = true;
            }
            else if (userData.Role == "moderator")
            {
                userRole.Text = "Twoja rola to moderator";
                manageUsersButton.Visible = true;
            }
        }
        /// <summary>This function return a user age</summary>
        /// <param name="birthDateString">BirthDate in string format</param>
        /// <returns>age of user</returns>
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
        /// <summary>
        /// This function calculate a how long user is on the service
        /// </summary>
        /// <param name="userSinceDate">Date when user create account</param>
        /// <returns>How many months user is on the service</returns>
        public int CalculateMonths(string userSinceDate)
        {
            DateTime userSince = DateTime.Parse(userSinceDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
            DateTime today = DateTime.Today;
            int monthsDifference = Math.Abs((userSince.Year - today.Year) * 12 + (userSince.Month - today.Month));

            return monthsDifference;
        }
        /// <summary>
        /// Close window if user want to logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void manageUsersButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Open a profile settings window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profileSettingsButton_Click(object sender, EventArgs e)
        {
            ProfileSettings profileSettingsForm = new ProfileSettings(userData);
            this.Hide();
            profileSettingsForm.ShowDialog();
            this.Close();
        }
    }
}

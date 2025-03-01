using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    /// <summary>
    /// Store user data
    /// </summary>
    public class UserData
    {
        public string _id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Date { get; set; }

        public string UserSince { get; set; }
        public string ProfilePic { get; set; }
        public string Role { get; set; }
        
        public UserData(string id, string username, string name, string surname, string gender, string date, string userSince ,string profilePic, string role)
        {
            _id = id;
            Username = username;
            Name = name;
            Surname = surname;
            Gender = gender;
            Date = date;
            UserSince = userSince;
            ProfilePic = profilePic;
            Role = role;
        }
    }
}

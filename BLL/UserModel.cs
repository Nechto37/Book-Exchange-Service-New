using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UserModel
    {
        public short Id { get; set; }
        public string C_name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? Date_of_birth { get; set; }
        public string Phone_number { get; set; }
        public string Settlement { get; set; }

        public UserModel() { }
        public UserModel(User u)
        {
            Id = u.Id;
            C_name = u.C_name;
            Surname = u.Surname;
            Login = u.Login;
            Password = u.Password;
            Date_of_birth = u.Date_of_birth;
            Phone_number = u.Phone_number;
            Settlement = u.Settlement;
        }
    }
}

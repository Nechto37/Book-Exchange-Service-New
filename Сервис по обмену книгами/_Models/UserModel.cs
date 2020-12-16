using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Сервис_по_обмену_книгами.Models
{
   public class UserModel:INotifyPropertyChanged
    {
        private short id { get; set; }
        private string c_name { get; set; }
        private string surname { get; set; }
        private string login { get; set; }
        private string password { get; set; }
        private DateTime? date_of_birth { get; set; }
        private string phone_number { get; set; }
        private string settlement { get; set; }


        public short Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string C_name
        {
            get { return c_name; }
            set
            {
                c_name = value;
                OnPropertyChanged("C_name");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public DateTime? Date_of_birth
        {
            get { return date_of_birth; }
            set
            {
                date_of_birth = value;
                OnPropertyChanged("Date_of_birth");
            }
        }

        public string Phone_number
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
                OnPropertyChanged("Phone_number");
            }
        }

        public string Settlement
        {
            get { return settlement; }
            set
            {
                settlement = value;
                OnPropertyChanged("Settlement");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
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

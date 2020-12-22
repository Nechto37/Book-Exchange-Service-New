using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сервис_по_обмену_книгами.Models;
using Сервис_по_обмену_книгами.Help;
using System.Windows;

namespace Сервис_по_обмену_книгами.ViewModels
{
   public class LoginViewModel : Base
    {

        private BookExchangeDatabase db;

        private MainWindowViewModel mv;
        public MainWindowViewModel Mv
        {
            get { return mv; }
            set { mv = value; OnPropertyChanged("Mv"); }
        }

        private List<User> users { get; set; }

        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        private string loginTextBox = null;
        public string LoginTextBox
        {
            get { return loginTextBox; }
            set
            {
                loginTextBox = value;
                OnPropertyChanged("LoginTextBox");
            }
        }

        private string passwordTextBox = null;
        public string PasswordTextBox
        {
            get { return passwordTextBox; }
            set
            {
                passwordTextBox = value;
                OnPropertyChanged("PasswordTextBox");
            }
        }
        public LoginViewModel(MainWindowViewModel m)
        {
            // db = new BookExchangeDatabase();
            Users = m.Users.ToList();
            Mv = m;
        }

        private RelayCommand toLogIn;
        public RelayCommand ToLogIn
        {
            get
            {
                return toLogIn ??
                  (toLogIn = new RelayCommand(obj => {
                      foreach(User u in Users)    
                          if (u.Login == loginTextBox && u.Password == passwordTextBox)
                             Mv.CurrentUser = u;
                      if (Mv.CurrentUser == null) MessageBox.Show("Проверьте корректность введённых данных");
                  },

                //условие, при котором будет доступна команда
                (obj) => (passwordTextBox != null && loginTextBox != null)));
            }
        }

    }
}

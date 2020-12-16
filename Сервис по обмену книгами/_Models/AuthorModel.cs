
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Сервис_по_обмену_книгами.Models
{
   public class AuthorModel:INotifyPropertyChanged
    {
        private short author_Id { get; set; }
        private string surname { get; set; }
        private string c_name { get; set; }

        public short Author_Id
        {
            get { return author_Id; }
            set
            {
                author_Id = value;
                OnPropertyChanged("Author_Id");
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
        public string C_name
        {
            get { return c_name; }
            set
            {
                c_name = value;
                OnPropertyChanged("C_name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public AuthorModel() { }
        public AuthorModel(Author a)
        {
            Author_Id = a.Author_Id;
            Surname = a.Surname;
            C_name = a.C_name;
        }
    }
}

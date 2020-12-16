
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Сервис_по_обмену_книгами.Models
{
   public class GenreModel:INotifyPropertyChanged
    {
        private string genre_name { get; set; }

        public string Genre_name
        {
            get { return genre_name; }
            set
            {
                genre_name = value;
                OnPropertyChanged("Genre_name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public GenreModel() { }
        public GenreModel(Genre g)
        {
            Genre_name = g.Genre_name;
        }
    }
}

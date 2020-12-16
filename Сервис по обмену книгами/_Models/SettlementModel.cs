
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Сервис_по_обмену_книгами.Models
{
   public class SettlementModel:INotifyPropertyChanged
    {
        private string settlement_name { get; set; }
        private string type { get; set; }
        private long? population { get; set; }

        public string Settlement_name
        {
            get { return settlement_name; }
            set
            {
                settlement_name = value;
                OnPropertyChanged("Settlement_name");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public long? Population
        {
            get { return population; }
            set
            {
                population = value;
                OnPropertyChanged("Population");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public SettlementModel() { }
        public SettlementModel(Settlement s)
        {
            Settlement_name = s.Settlement_name;
            Type = s.Type;
            Population = s.Population;
        }
    }
}

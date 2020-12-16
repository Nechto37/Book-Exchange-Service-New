using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class SettlementModel
    {
        public string Settlement_name { get; set; }
        public string Type { get; set; }
        public long? Population { get; set; }
        public SettlementModel() { }
        public SettlementModel(Settlement s)
        {
            Settlement_name = s.Settlement_name;
            Type = s.Type;
            Population = s.Population;
        }
    }
}

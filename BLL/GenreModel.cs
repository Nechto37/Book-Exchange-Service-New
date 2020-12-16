using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class GenreModel
    {
        public string Genre_name { get; set; }

        public GenreModel() { }
        public GenreModel(Genre g)
        {
            Genre_name = g.Genre_name;
        }
    }
}

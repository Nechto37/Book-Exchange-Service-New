using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class AuthorModel
    {
        public short Author_Id { get; set; }
        public string Surname { get; set; }
        public string C_name { get; set; }

        public AuthorModel() { }
        public AuthorModel(Author a)
        {
            Author_Id = a.Author_Id;
            Surname = a.Surname;
            C_name = a.C_name;
        }
    }
}

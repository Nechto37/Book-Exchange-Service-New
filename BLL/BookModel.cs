using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookModel
    {
        public short Book_Id { get; set; }
        public string Book_title { get; set; }
        public short? Number_of_pages { get; set; }
        public DateTime? Publication_date { get; set; }

        public BookModel() { }
        public BookModel(Book b)
        {
            Book_Id = b.Book_Id;
            Book_title = b.Book_title;
            Number_of_pages = b.Number_of_pages;
            Publication_date = b.Publication_date;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Сервис_по_обмену_книгами.Models
{
    public class BookModel:INotifyPropertyChanged
    {

        public BookExchangeDatabase db = new BookExchangeDatabase();
        private short book_Id { get; set; }
        private string book_title { get; set; }
        private short? number_of_pages { get; set; }
        private DateTime? publication_date { get; set; }
        private List<Genre> genres { get; set; }
        private List<Author> authors { get; set; }

        public short Book_Id
        {
            get { return book_Id; }
            set
            {
                book_Id = value;
                OnPropertyChanged("Book_Id");
            }
        }

        public string Book_title
        {
            get { return book_title; }
            set
            {
                book_title = value;
                OnPropertyChanged("Book_title");
            }
        }

        public short? Number_of_pages
        {
            get { return number_of_pages; }
            set
            {
                number_of_pages = value;
                OnPropertyChanged("Number_of_pages");
            }
        }

        public DateTime? Publication_date
        {
            get { return publication_date; }
            set
            {
                publication_date = value;
                OnPropertyChanged("Publication_date");
            }
        }

        public List<Genre> Genres
        {
            get { return genres; }
            set
            {
                genres = value;
                OnPropertyChanged("Genres");
            }
        }

        public List<Author> Authors
        {
            get { return authors; }
            set
            {
                authors = value;
                OnPropertyChanged("Authors");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public BookModel() { }
        public BookModel(Book b)
        {
            Book_Id = b.Book_Id;
            Book_title = b.Book_title;
            Number_of_pages = b.Number_of_pages;
            Publication_date = b.Publication_date;
            //Genres = db.Book_Genre.Where(bg => bg.BookID == b.Book_Id).ToList();

            //Genres = db.Book_Genre.Join(db.Book, bg => bg.BookID, book => book.Book_Id, (bg, book) => new
            //{
            //    GenreName = bg.GenreName,
            //    BookID = book.Book_Id,
            //}
            //).Where(bg => bg.BookID == b.Book_Id).Select(i => i).ToList();

            //Genres = db.Book_Genre.Join(db.Genre, g => g.GenreName, genre => genre.Genre_name, (g, genre) => new
            //{
            //    GenreName = g.GenreName,
            //    BookID = g.BookID,
            //}).Join(db.Book, g => g.BookID, book => book.Book_Id, (g, book) => new
            //{
            //    GenreName = g.GenreName,
            //    BookID = g.BookID,
            //})/*.Where(g => g.Book_Id == b.Book_Id)*/
            /*.Where(g => g.Book_Id == b.Book_Id)*/
            /*.Select(i => i).ToList();*/

            //Genres = db.Genre
            //    .Join(db.Manufacturers, ph => ph.ManufacturerId, m => m.Id, (ph, m) => ph)
            //    .Where(i => i.ManufacturerId == manufId)
            //    .Select(i => new ReportData() { PhoneName = i.Name, Cost = i.Cost })
            //    .ToList();
        }
    }
}

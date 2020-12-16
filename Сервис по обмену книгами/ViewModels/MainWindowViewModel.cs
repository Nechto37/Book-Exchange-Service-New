using Сервис_по_обмену_книгами.Models;
using Сервис_по_обмену_книгами.Help;
using Сервис_по_обмену_книгами;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.Entity;


namespace Сервис_по_обмену_книгами.ViewModels
{
    class MainWindowViewModel : Base
    {
        /*static */
        private BookExchangeDatabase db /*= new BookExchangeDatabase()*/;
        // Book SelectedBook = new Book();
        private List<Book> books { get; set; }

        public List<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        }

        public List<Author> Authors { get; set; }

        public List<Genre> Genres { get; set; }

        //public List<Genre> CurrentGenres { get; set; }

        private string authorTextBox = " ";
        public string AuthorTextBox
        {
            get { return authorTextBox; }
            set
            {
                authorTextBox = value;
                OnPropertyChanged("AuthorTextBox");
            }
        }

        private string bookTitleTextBox = " ";
        public string BookTitleTextBox
        {
            get { return bookTitleTextBox; }
            set
            {
                bookTitleTextBox = value;
                OnPropertyChanged("BookTitleTextBox");
            }
        }

        private Book selectedBook = null;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set { selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        private int selectedAuthor_ID = 1;
        public int SelectedAuthor_ID
        {
            get { return selectedAuthor_ID; }
            set { selectedAuthor_ID = value; OnPropertyChanged("SelectedAuthor_ID"); }
        }

        private string selectedGenre_Name = "nothing";
        public string SelectedGenre_Name
        {
            get { return selectedGenre_Name; }
            set { selectedGenre_Name = value; OnPropertyChanged("SelectedGenre_Name"); }
        }

        public MainWindowViewModel()
        {
            db = new BookExchangeDatabase();
            Books = db.Book.ToList();
            Authors = db.Author.ToList();
            Genres = db.Genre.ToList();
            //CurrentGenres = null;
        }

        public List<Book> SearchBook(string author, string bookTitle)
        {
            List<Book> buf = new List<Book>();
            buf = db.Book.ToList();
            List<Book> answer = new List<Book>();
            foreach(Book b in buf)
            {
                if (/*b.Author.ToString() == author && */b.Book_title == bookTitle)
                    answer.Add(b);
            }
            return answer;
        }

        private RelayCommand bookSearch;

        public RelayCommand BookSearch
        {
            get
            {
                return bookSearch ??
                  (bookSearch = new RelayCommand(obj =>
                  {
                      Books = SearchBook(authorTextBox, bookTitleTextBox);
                      //eve.AllEvents = eve.AllEvents;
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((authorTextBox != " " && authorTextBox != null && bookTitleTextBox != null && bookTitleTextBox != " "))));
            }
        }
    }

 }


    

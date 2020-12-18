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
using System.Windows;

namespace Сервис_по_обмену_книгами.ViewModels
{
   public class MainWindowViewModel : Base
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

        private string logIn = "Войти";
        public string LogIn
        {
            get { return logIn; }
            set
            {
                logIn = value;
                OnPropertyChanged("LogIn");
            }
        }

        private string userName = "гость";
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }


        private string upperLabel = "Вы вошли как: гость";
        public string UpperLabel
        {
            get { return upperLabel; }
            set
            {
                if(CurrentUser != null)
                upperLabel = "Вы вошли как: " + CurrentUser.Login;
                else upperLabel = "Вы вошли как: гость";
                OnPropertyChanged("UpperLabel");
            }
        }

        private string authorTextBox = null;
        public string AuthorTextBox
        {
            get { return authorTextBox; }
            set
            {
                authorTextBox = value;
                OnPropertyChanged("AuthorTextBox");
            }
        }

        private string bookTitleTextBox = null;
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

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                if (currentUser != null)
                {
                    LogIn = "Выйти";
                    UpperLabel = "Вы вошли как:" + currentUser.Login;
                }
                OnPropertyChanged("CurrentUser");
            }
        }

        //private int selectedAuthor_ID = 1;
        //public int SelectedAuthor_ID
        //{
        //    get { return selectedAuthor_ID; }
        //    set { selectedAuthor_ID = value; OnPropertyChanged("SelectedAuthor_ID"); }
        //}

        //private string selectedGenre_Name = "nothing";
        //public string SelectedGenre_Name
        //{
        //    get { return selectedGenre_Name; }
        //    set { selectedGenre_Name = value; OnPropertyChanged("SelectedGenre_Name"); }
        //}

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
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((authorTextBox != null && bookTitleTextBox != null))));
            }
        }

        private RelayCommand addBook;

        public RelayCommand AddBook
        {
            get
            {
                return addBook ??
                  (addBook = new RelayCommand(obj =>
                  {
                      foreach(Book b in db.User.Find(CurrentUser.Id).Offers)
                          if(b.Book_Id == SelectedBook.Book_Id) { MessageBox.Show("В списке уже имеется данная книга."); return; }
                      db.User.Find(CurrentUser.Id).Offers.Add(SelectedBook);
                      db.SaveChanges();
                      //eve.AllEvents = eve.AllEvents;
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((CurrentUser != null && SelectedBook != null))));
            }
        }
    }

 }


    

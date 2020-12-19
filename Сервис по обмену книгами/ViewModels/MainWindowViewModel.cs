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

        public MainWindowViewModel()
        {
            db = new BookExchangeDatabase();
            Books = new ObservableCollection<Book>(db.Book);
            Authors = new ObservableCollection<Author>(db.Author);
            Genres = new ObservableCollection<Genre>(db.Genre);
            Users = new ObservableCollection<User>(db.User);
            uh = new ObservableCollection<UserHelp>();
        }
        /*static */
        private BookExchangeDatabase db /*= new BookExchangeDatabase()*/;
        // Book SelectedBook = new Book();
        private ObservableCollection<Book> books { get; set; }

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        }

        public class UserHelp
        {
            public User user;
            public Book book;
            public string status;
        }

        public ObservableCollection<UserHelp> uh;

        public ObservableCollection<Author> Authors { get; set; }

        public ObservableCollection<Genre> Genres { get; set; }

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

        private ObservableCollection<Book> offers { get; set; }

        public ObservableCollection<Book> Offers
        {
            get { return offers; }
            set
            {
                offers = value;
                OnPropertyChanged("Offers");
            }
        }

        private ObservableCollection<User> users { get; set; }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        private ObservableCollection<Book> wishes { get; set; }

        public ObservableCollection<Book> Wishes
        {
            get { return wishes; }
            set
            {
                wishes = value;
                OnPropertyChanged("Wishes");
            }
        }

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                Filling(CurrentUser);
                if (currentUser != null)
                {
                    LogIn = "Выйти";
                    UpperLabel = "Вы вошли как:" + currentUser.Login;
                    Wishes = new ObservableCollection<Book>(value.Wishes);
                    Offers = new ObservableCollection<Book>(value.Offers);
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

   

        public ObservableCollection<Book> SearchBook(string author, string bookTitle)
        {
            ObservableCollection<Book> buf = new ObservableCollection<Book>();
            buf = db.Book.Local;
            ObservableCollection<Book> answer = new ObservableCollection<Book>();
            foreach(Book b in buf)
            {
                if (/*b.Author.ToString() == author && */b.Book_title == bookTitle)
                    answer.Add(b);
            }
            return answer;
        }

        public void Filling(User user)
        {
            if(user == null) { uh = null; return; }
            foreach(Book b in user.Offers)
            {
                foreach(User u in Users)
                {
                    if (u.Id == user.Id) continue;
                    foreach(Book book in u.Wishes)
                    {
                        if(book.Book_Id == b.Book_Id)
                        {
                            UserHelp userHelp = new UserHelp();
                            userHelp.user = u;
                            userHelp.book = book;
                            userHelp.status = "Нужна мне";
                            uh.Add(userHelp);
                        }
                    }
                }
            }
            foreach (Book b in user.Wishes)
            {
                foreach (User u in Users)
                {
                    if (u.Id == user.Id) continue;
                    foreach (Book book in u.Offers)
                    {
                        if (book.Book_Id == b.Book_Id)
                        {
                            UserHelp userHelp = new UserHelp();
                            userHelp.user = u;
                            userHelp.book = book;
                            userHelp.status = "Готов обменять";
                            uh.Add(userHelp);
                        }
                    }
                }
            }
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

        private RelayCommand addBookOffers;

        public RelayCommand AddBookOffers
        {
            get
            {
                return addBookOffers ??
                  (addBookOffers = new RelayCommand(obj =>
                  {
                      foreach(Book b in db.User.Find(CurrentUser.Id).Offers)
                          if(b.Book_Id == SelectedBook.Book_Id) { MessageBox.Show("В списке уже имеется данная книга."); return; }
                      db.User.Find(CurrentUser.Id).Offers.Add(SelectedBook);
                      db.SaveChanges();
                      Offers = new ObservableCollection<Book>(db.User.Find(CurrentUser.Id).Offers);
                      MessageBox.Show("Книга " + SelectedBook.Book_title + " успешно добавлена в список предложений.");
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((CurrentUser != null && SelectedBook != null))));
            }
        }

        private RelayCommand addBookWishes;

        public RelayCommand AddBookWishes
        {
            get
            {
                return addBookWishes ??
                  (addBookWishes = new RelayCommand(obj =>
                  {
                      foreach (Book b in db.User.Find(CurrentUser.Id).Wishes)
                          if (b.Book_Id == SelectedBook.Book_Id) { MessageBox.Show("В списке уже имеется данная книга."); return; }
                      db.User.Find(CurrentUser.Id).Wishes.Add(SelectedBook);
                      db.SaveChanges();
                      Wishes = new ObservableCollection<Book>(db.User.Find(CurrentUser.Id).Wishes);
                      MessageBox.Show("Книга " + SelectedBook.Book_title + " успешно добавлена в список пожеланий.");
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((CurrentUser != null && SelectedBook != null))));
            }
        }


        private RelayCommand deleteWish;

        public RelayCommand DeleteWish
        {
            get
            {
                return deleteWish ??
                  (deleteWish = new RelayCommand(obj =>
                  {
                      string title = SelectedBook.Book_title;
                      db.User.Find(CurrentUser.Id).Wishes.Remove(SelectedBook);
                      db.SaveChanges();
                      Wishes = new ObservableCollection<Book>(db.User.Find(CurrentUser.Id).Wishes);
                      MessageBox.Show("Книга " + title + " успешно удалена из списка пожеланий.");
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((CurrentUser != null && SelectedBook != null))));
            }
        }

        private RelayCommand deleteOffer;

        public RelayCommand DeleteOffer
        {
            get
            {
                return deleteOffer ??
                  (deleteOffer = new RelayCommand(obj =>
                  {
                      string title = SelectedBook.Book_title;
                      db.User.Find(CurrentUser.Id).Offers.Remove(SelectedBook);
                      db.SaveChanges();
                      Offers = new ObservableCollection<Book>(db.User.Find(CurrentUser.Id).Offers);
                      MessageBox.Show("Книга " + title + " успешно удалена из списка предложений.");
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((CurrentUser != null && SelectedBook != null))));
            }
        }
    }

 }


    

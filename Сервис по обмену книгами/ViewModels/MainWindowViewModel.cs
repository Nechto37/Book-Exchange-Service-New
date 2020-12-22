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
using Сервис_по_обмену_книгами.Views;

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
        }

        private BookExchangeDatabase db;
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

        public class UserHelp: Base
        {
            private User user { get; set; }
            public User User
            {
                get { return user; }
                set
                {
                    user = value;
                    OnPropertyChanged("User");
                }
            }

            private Book book { get; set; }
            public Book Book
            {
                get { return book; }
                set
                {
                    book = value;
                    OnPropertyChanged("Book");
                }
            }

            private string status { get; set; }
            public string Status
            {
                get { return status; }
                set
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        private ObservableCollection<UserHelp> uh { get; set; }

        public ObservableCollection<UserHelp> Uh
        {
            get { return uh; }
            set
            {
                uh = value;
                OnPropertyChanged("Uh");
            }
        }

        private UserHelp selectedLine { get; set; }

        public UserHelp SelectedLine
        {
            get { return selectedLine; }
            set
            {
                selectedLine = value;
                OnPropertyChanged("SelectedLine");
            }
        }

        private ObservableCollection<Message> currentUserSendedMessages { get; set; }

        public ObservableCollection<Message> CurrentUserSendedMessages
        {
            get { return currentUserSendedMessages; }
            set
            {
                currentUserSendedMessages = value;
                OnPropertyChanged("CurrentUserSendedMessages");
            }
        }

        private ObservableCollection<Message> currentUserReceivedMessages { get; set; }

        public ObservableCollection<Message> CurrentUserReceivedMessages
        {
            get { return currentUserReceivedMessages; }
            set
            {
                currentUserReceivedMessages = value;
                OnPropertyChanged("CurrentUserReceivedMessages");
            }
        }
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }

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

        private string tabPageIndex = "0";
        public string TabPageIndex
        {
            get { return tabPageIndex; }
            set
            {
                tabPageIndex = value;
                SelectedBook = null;
                SelectedLine = null;
                SelectedMessage = null;
                OnPropertyChanged("TabPageIndex");
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

        private Visibility sendMessageVisibility = Visibility.Collapsed;
        public Visibility SendMessageVisibility
        {
            get { return sendMessageVisibility; }
            set
            {
                sendMessageVisibility = value;
                OnPropertyChanged("SendMessageVisibility");
            }
        }

        private Visibility sendedMessagesVisibility = Visibility.Visible;
        public Visibility SendedMessagesVisibility
        {
            get { return sendedMessagesVisibility; }
            set
            {
                sendedMessagesVisibility = value;
                OnPropertyChanged("SendedMessagesVisibility");
            }
        }

        private Visibility receivedMessagesVisibility = Visibility.Collapsed;
        public Visibility ReceivedMessagesVisibility
        {
            get { return receivedMessagesVisibility; }
            set
            {
                receivedMessagesVisibility = value;
                OnPropertyChanged("ReceivedMessagesVisibility");
            }
        }



        private bool isExp = false;
        public bool IsExp
        {
            get { return isExp; }
            set
            {
                isExp = value;
                OnPropertyChanged("IsExp");
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

        private Message selectedMessage = null;
        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                selectedMessage = value;
                OnPropertyChanged("SelectedMessage");
            }
        }

        private string message = null;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }


        private string comInc = "Отправленные сообщения";
        public string ComInc
        {
            get { return comInc; }
            set
            {
                comInc = value;
                OnPropertyChanged("ComInc");
            }
        }

        private bool forExpander = false;

        public bool ForExpander
        {
            get { return forExpander; }
            set
            {
                forExpander = value;
                OnPropertyChanged("ForExpander");
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

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                Flag = !Flag;
                Uh = Filling(CurrentUser);
                CurrentUserSendedMessages = null;
                CurrentUserReceivedMessages = null;
                if (currentUser != null)
                {
                    LogIn = "Выйти";
                    UpperLabel = "Вы вошли как:" + currentUser.Login;
                    CurrentUserSendedMessages = new ObservableCollection<Message>(value.SendedMessages);
                    CurrentUserReceivedMessages = new ObservableCollection<Message>(value.ReceivedMessages);
                    Wishes = new ObservableCollection<Book>(value.Wishes);
                    Offers = new ObservableCollection<Book>(value.Offers);
                }
                OnPropertyChanged("CurrentUser");
            }
        }


        private bool flag { get; set; }

        public bool Flag
        {
            get { return flag; }
            set
            {
                flag = value;
                OnPropertyChanged("Flag");
            }
        }

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
        public ObservableCollection<UserHelp> Filling(User user)
        {
            if(user == null) { Uh = null; return null; }
            else uh = new ObservableCollection<UserHelp>();
            foreach (Book b in user.Offers)
            {
                foreach(User u in Users)
                {
                    if (u.Id == user.Id) continue;
                    foreach(Book book in u.Wishes)
                    {
                        if(book.Book_Id == b.Book_Id)
                        {
                            UserHelp userHelp = new UserHelp();
                            userHelp.User = u;
                            userHelp.Book = book;
                            userHelp.Status = "Нужна мне";
                            Uh.Add(userHelp);
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
                            userHelp.User = u;
                            userHelp.Book = book;
                            userHelp.Status = "Готов обменять";
                            uh.Add(userHelp);
                        }
                    }
                }
            }
            return uh;
        }

        //private RelayCommand toLogIn;
        //public RelayCommand ToLogIn
        //{
        //    get
        //    {
        //        return toLogIn ??
        //          (toLogIn = new RelayCommand(obj =>
        //          {
        //              if (CurrentUser != null)
        //              {
        //                  CurrentUser = null;
        //                  UpperLabel = "Вы вошли как: гость";
        //                  LogIn = "Войти";
        //                  Wishes = null;
        //                  Offers = null;
        //              }
        //              else
        //              {
        //                  Login loginwindow = new Login(mv);
        //                  loginwindow.ShowDialog();
        //              }
        //          },

        //         //условие, при котором будет доступна команда
        //         (obj) => ((authorTextBox != null && bookTitleTextBox != null))));
        //    }
        //}

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

        private RelayCommand writeMessage;
        public RelayCommand WriteMessage
        {
            get
            {
                return writeMessage ??
                  (writeMessage = new RelayCommand(obj =>
                  {
                      ForExpander = true;
                      SendMessageVisibility = Visibility.Visible;
                      IsExp = true;
                  },

                 //условие, при котором будет доступна команда
                 (obj) => (((SelectedLine != null || SelectedMessage != null) && CurrentUser != null))));
            }
        }

        private RelayCommand sendMessage;
        public RelayCommand SendMessage
        {
            get
            {
                return sendMessage ??
                  (sendMessage = new RelayCommand(obj =>
                  {
                      Message outcoming = new Message();
                      outcoming.Sender_Id = CurrentUser.Id;
                      if (SelectedLine != null)
                      {
                          outcoming.Receiver_Id = SelectedLine.User.Id;
                          outcoming.Receiver = SelectedLine.User;
                      }
                      else
                      {
                          outcoming.Receiver_Id = SelectedMessage.Receiver_Id;
                          outcoming.Receiver = SelectedMessage.Receiver;
                      }
                      outcoming.Text = Message;
                      outcoming.Sender = CurrentUser;
                      outcoming.Date = DateTime.Now;
                      db.Message.Add(outcoming);
                      db.User.Find(CurrentUser.Id).SendedMessages.Add(outcoming);
                      if (SelectedLine != null)
                          db.User.Find(SelectedLine.User.Id).ReceivedMessages.Add(outcoming);
                      else
                          db.User.Find(SelectedMessage.Receiver_Id).ReceivedMessages.Add(outcoming);
                      db.SaveChanges();
                      IsExp = false;
                      Message = null;
                      if (SelectedLine != null)
                      MessageBox.Show("Сообщение успешно отправлено пользователю " + SelectedLine.User.Login);
                      else 
                      MessageBox.Show("Сообщение успешно отправлено пользователю " + SelectedMessage.Receiver.Login);
                      CurrentUserSendedMessages = new ObservableCollection<Message>(CurrentUser.SendedMessages);
                      CurrentUserReceivedMessages = new ObservableCollection<Message>(CurrentUser.ReceivedMessages);
                  },

                 //условие, при котором будет доступна команда
                 (obj) => (((SelectedLine != null || SelectedMessage != null) && CurrentUser != null && Message != null && Message.Length > 10))));
            }
        }

        private RelayCommand swap;
        public RelayCommand Swap
        {
            get
            {
                return swap ??
                  (swap = new RelayCommand(obj =>
                  {
                  if (SendedMessagesVisibility == Visibility.Visible)
                  {
                      SendedMessagesVisibility = Visibility.Collapsed;
                      ReceivedMessagesVisibility = Visibility.Visible;
                      ComInc = "Входящие сообщения";
                  }
                      else
                      {
                          SendedMessagesVisibility = Visibility.Visible;
                          ReceivedMessagesVisibility = Visibility.Collapsed;
                          ComInc = "Отправленные сообщения";
                      }
                  },

                 //условие, при котором будет доступна команда
                 (obj) => ((CurrentUser != null))));
            }
        }
    }

 }


    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Сервис_по_обмену_книгами.Models
{
   public class DbOperations
    {
        private BookExchangeDatabase db;
        public DbOperations()
        {
            db = new BookExchangeDatabase();
        }

        public List<BookModel> GetAllBooks()
        {
            return db.Book.ToList().Select(i => new BookModel(i)).ToList();
        }

        public List<AuthorModel> GetAllAuthors()
        {
            return db.Author.ToList().Select(i => new AuthorModel(i)).ToList();
        }

        public List<GenreModel> GetAllGenres()
        {
            return db.Genre.ToList().Select(i => new GenreModel(i)).ToList().OrderBy(i => i).ToList();
        }

        public List<UserModel> GetAllUsers()
        {
            return db.User.ToList().Select(i => new UserModel(i)).ToList().OrderBy(i => i).ToList();
        }

        public List<SettlementModel> GetAllSettlements()
        {
            return db.Settlement.ToList().Select(i => new SettlementModel(i)).ToList().OrderBy(i => i).ToList();
        }

        public BookModel GetBook(int Id)
        {
            return new BookModel(db.Book.Find(Id));
        }

        public AuthorModel GetAuthor (int Id)
        {
            return new AuthorModel(db.Author.Find(Id));
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}

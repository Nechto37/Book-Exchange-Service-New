namespace Сервис_по_обмену_книгами.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookExchangeDatabase : DbContext
    {
        public BookExchangeDatabase()
            : base("name=BookExchangeDatabase")
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Settlement> Settlement { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.C_name)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Book)
                .WithMany(e => e.Author)
                .Map(m => m.ToTable("Book_Author").MapLeftKey("AuthorID").MapRightKey("BookID"));

            modelBuilder.Entity<Book>()
                .Property(e => e.Book_title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Genre)
                .WithMany(e => e.Book)
                .Map(m => m.ToTable("Book_Genre").MapLeftKey("BookID").MapRightKey("GenreName"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.User)
                .WithMany(e => e.Offers)
                .Map(m => m.ToTable("Offers").MapLeftKey("Book_Id"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.User1)
                .WithMany(e => e.Wishes)
                .Map(m => m.ToTable("Wishes").MapLeftKey("Book_Id"));

            modelBuilder.Entity<Genre>()
                .Property(e => e.Genre_name)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.Settlement_name)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .HasMany(e => e.User)
                .WithRequired(e => e.SettlementTable)
                .HasForeignKey(e => e.Settlement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.C_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Settlement)
                .IsUnicode(false);
        }
    }
}

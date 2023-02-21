using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DBContext
{
    public class Context : DbContext
    {
        

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public Context() : base()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options) { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server=WILLIAMTRUNG\\MYSQL;database=eStoreDb;uid=sa;pwd=123;trusted_connection=true");           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(c => new { c.author_id, c.book_id });

            //modelBuilder.Entity<BookAuthor>().HasQueryFilter(b => b.Book.book_id == b.book_id);
            //modelBuilder.Entity<Book>().HasMany(b => b.BookAuthor).WithOne(ba => ba.Book);
            //modelBuilder.Entity<Publisher>().HasMany(c => c.Users).WithOne(ba => ba.Publisher);
            //modelBuilder.Entity<User>().HasOne(c => c.Role).WithMany(c => c.Users);
            //modelBuilder.Entity<User>().HasOne(c => c.Publisher).WithMany(c => c.Users);
            modelBuilder.Seed();
        }
    }
}

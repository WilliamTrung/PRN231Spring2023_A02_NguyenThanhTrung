using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Context
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    role_id = 1,
                    role_desc = "Administrator"
                },
                new Role
                {
                    role_id = 2,
                    role_desc = "Member",
                }
            );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    pub_id = 1,
                    publisher_name = "Hoyoverse",
                    city = "London",
                    state = "",
                    country = "England"
                },
                new Publisher
                {
                    pub_id = 2,
                    publisher_name = "Arknights",
                    city = "Ho Chi Minh",
                    state = "",
                    country = "Viet Nam"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    user_id = 1,
                    email_address = "member1@gmail.com",
                    password = "1",
                    source = "Member1SourceLink.com",
                    first_name = "Hao",
                    last_name = "Nam",
                    role_id = 2,
                    pub_id = 1,
                    hire_date = DateTime.Parse("12112001")
                },

                new User
                {
                    user_id = 2,
                    email_address = "member2@gmail.com",
                    password = "2",
                    source = "Member2SourceLink.com",
                    first_name = "Lien",
                    last_name = "Huong",
                    role_id = 2,
                    pub_id = 2,
                    hire_date = DateTime.Parse("09102001")
                }
                ); ;


            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    book_id = 1,
                    title = "The life of Author 1",
                    type = "Romantic",
                    price = 300000,
                    advanced = "",
                    royalty = "Copyright of Author 1",
                    ytd_date = DateTime.Today.AddDays(365),
                    note = "",
                    published_date = DateTime.Today
                },
                new Book
                {
                    book_id = 2,
                    title = "The adventure of Author 2",
                    type = "Adventure",
                    price = 300000,
                    advanced = "",
                    royalty = "Copyright of Author 2",
                    ytd_date = DateTime.Today.AddDays(-65),
                    note = "",
                    published_date = DateTime.Today.AddDays(-300),
                }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    author_id = 1,
                    last_name = "Nguyen",
                    first_name = "Thanh Trung",
                    phone = "0908456789",
                    address = "237 Lê Văn Việt",
                    city = "Hồ Chí Minh",
                    state = "Hồ Chí Minh",
                    zip = "700000",
                    email_address = "thanhtrung@gmai.com"
                },
                new Author
                {
                    author_id = 2,
                    last_name = "Tran",
                    first_name = "Anh Khoa",
                    phone = "0908123456",
                    address = "123 đường 1",
                    city = "Ha Noi",
                    state = "Ha Noi",
                    zip = "123456",
                    email_address = "anhkhoa@gmail.com"
                }
                );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor
                {
                    author_id = 1,
                    book_id = 1,
                    author_order = "",
                    royality_percentage = 60
                },
                new BookAuthor
                {
                    author_id = 2,
                    book_id = 2,
                    author_order = "",
                    royality_percentage = 25
                }
                );          
        }
    }
}

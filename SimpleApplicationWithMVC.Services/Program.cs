using AutoMapper;
using SimpleApplicationWithMVC.Database;
using SimpleApplicationWithMVC.Services.Interfaces;
using SimpleApplicationWithMVC.Services.Services;
using System;

namespace SimpleApplicationWithMVC.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            config.CreateMapper();
            var mapper = config.CreateMapper();

            DatabaseContext databaseContext = new DatabaseContext();
            IUserServices userServices = new UserServices(databaseContext);
            IReservationService reservationService = new ReservationService(databaseContext, mapper);
            IBookServices bookServices = new BookServices(databaseContext, mapper);

            userServices.AddUser("User1", "Password1");
            userServices.AddUser("User2", "Password2");
            bookServices.AddBook(new DTO.BookDTO() { AuthorName = "Author1", Description = "Description", Name = "Book1", ReleaseDate = DateTime.Today });
            bookServices.AddBook(new DTO.BookDTO() { AuthorName = "Author2", Description = "Description", Name = "Book2", ReleaseDate = DateTime.Today });
            bookServices.AddBook(new DTO.BookDTO() { AuthorName = "Author1", Description = "Description", Name = "Book3", ReleaseDate = DateTime.Today });
            bookServices.AddBook(new DTO.BookDTO() { AuthorName = "Author3", Description = "Description", Name = "Book4", ReleaseDate = DateTime.Today });
            bookServices.AddBook(new DTO.BookDTO() { AuthorName = "Author3", Description = "Description", Name = "Book5", ReleaseDate = DateTime.Today });
        }
    }
}

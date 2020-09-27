using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;
using System.Collections.Generic;

namespace SimpleApplicationWithMVC.Services.Interfaces
{
    public interface IBookServices
    {
        int AddBook(BookDTO book);
        Book GetBook(int id);
        List<Book> GetAll();
        bool UpdateBook(BookDTO book, int id);
    }
}

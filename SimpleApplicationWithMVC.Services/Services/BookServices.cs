using AutoMapper;
using SimpleApplicationWithMVC.Database;
using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;
using SimpleApplicationWithMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApplicationWithMVC.Services.Services
{
    public class BookServices : IBookServices
    {
        public BookServices(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;

        }

        private DatabaseContext databaseContext;
        private IMapper mapper;

        public int AddBook(BookDTO bookDTO)
        {
            int authorId = CheckAuthor(bookDTO.AuthorName);
            Book book = mapper.Map<Book>(bookDTO);
            book.AuthorId = authorId;
            book = databaseContext.Books.Add(book);
            databaseContext.SaveChanges();
            return book.Id;
        }

        public List<Book> GetAll()
        {
            return databaseContext.Books.Include(x => x.Author).ToList();
        }

        public bool UpdateBook(BookDTO bookDTO, int id)
        {
            Book book = mapper.Map<Book>(bookDTO);
            book.Id = id;

            Book bookToUpdate = databaseContext.Books.Find(id);
            book.AuthorId = bookToUpdate.AuthorId;

            if (bookToUpdate == null)
                return false;

            databaseContext.Entry(bookToUpdate).CurrentValues.SetValues(book);
            databaseContext.SaveChanges();
            return true;
        }

        private int CheckAuthor(string authorName)
        {
            Author author = databaseContext.Authors.Where(x => x.Name.Equals(authorName)).FirstOrDefault();

            if (author == null)
            {
                author = new Author();
                author.Name = authorName;
                author = databaseContext.Authors.Add(author);
                databaseContext.SaveChanges();
            }

            return author.Id;
        }

        public Book GetBook(int id)
        {
            return databaseContext.Books.Find(id);
        }
    }
}

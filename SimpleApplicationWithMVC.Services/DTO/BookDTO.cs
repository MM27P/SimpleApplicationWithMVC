using System;

namespace SimpleApplicationWithMVC.Services.DTO
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}

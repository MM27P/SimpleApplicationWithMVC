using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApplicationWithMVC.Database.Model
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}

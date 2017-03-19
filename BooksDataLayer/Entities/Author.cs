using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace BooksDataLayer.Entities
{
    public class Author : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Biography { get; set; }
        public List<Book> Books { get; set; }
    }
}
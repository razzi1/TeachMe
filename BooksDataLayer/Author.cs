using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksDataLayer
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Biography { get; set; }
        public List<Book> Books { get; set; }
    }
}
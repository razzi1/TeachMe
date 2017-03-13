using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BooksDataLayer;

namespace TeachMeArabic.Models
{
    public class BookModel
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Level;
        public int Pages { get; set; }
        public BookType BookType { get; set; }
        public Language Language { get; set; }
        public List<Author> Authors { get; set; }
        public List<string> Keywords { get; set; }
    }
}

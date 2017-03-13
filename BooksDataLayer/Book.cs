using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksDataLayer
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public BookLevel Level { get; set; }
        public int Pages { get; set; }
        public int BookTypeId { get; set; }
        public BookType BookType { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public List<Author> Authors { get; set; }
        public List<string> Keywords { get; set; }
    }
}

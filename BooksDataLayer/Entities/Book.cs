using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace BooksDataLayer.Entities
{
    public class Book : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string ContentLocation { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearPublished { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
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

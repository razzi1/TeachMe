using System.ComponentModel.DataAnnotations;
using Repository;

namespace BooksDataLayer.Entities
{
    public class BookType : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}

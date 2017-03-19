using System.Collections.Generic;
using Repository;

namespace BooksDataLayer.Entities
{
    public class Publisher : IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Book> PublishedBooks { get; set; }

    }
}
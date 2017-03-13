using System.Linq;
using BooksDataLayer;
using System.Web.Http;
using AutoMapper;
using TeachMeArabic.Models;

namespace TeachMeArabic.Controllers
{
    public class BookController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(Search search)
        {
            BookRepository repository = new BookRepository();
            var books = repository.Search(search);
            var result = books.Select(Mapper.Map<Book, BookModel>);
            return Ok(result);
        }

        public IHttpActionResult Get(string id)
        {
            BookRepository repository = new BookRepository();
            var book = repository.GetBookById(id);
            return Ok(Mapper.Map<Book, BookModel>(book));
        }
    }
}

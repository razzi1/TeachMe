using System.Linq;
using BooksDataLayer;
using System.Web.Http;

namespace TeachMeArabic.Controllers
{
    public class BookTypesController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookRepository repository = new BookRepository();
            var bookTypes = repository.BookTypes().Select(bt => bt.Type).ToList();
            bookTypes.Insert(0, "All (الكل)");
            return Ok(bookTypes);
        }
    }
}

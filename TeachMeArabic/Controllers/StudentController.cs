using System.Linq;
using BooksDataLayer;
using System.Web.Http;

namespace TeachMeArabic.Controllers
{
    public class StudentController : ApiController
    {

        public IHttpActionResult Get(int id)
        {
            BookRepository repository = new BookRepository();
            var author = repository.GetAuthorById(id);
            return Ok(author);
        }
    }
}

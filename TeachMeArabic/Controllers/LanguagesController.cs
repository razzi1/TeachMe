using System.Linq;
using BooksDataLayer;
using System.Web.Http;

namespace TeachMeArabic.Controllers
{
    public class LanguagesController : ApiController
    {

        public IHttpActionResult Get()
        {
            BookRepository repository = new BookRepository();
            var languages = repository.Languages().Select(l => l.Name).ToList();
            languages.Insert(0, "All (الكل)");
            return Ok(languages);
        }
    }
}

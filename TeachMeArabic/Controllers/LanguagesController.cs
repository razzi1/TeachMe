using System.Linq;
using BooksDataLayer;
using System.Web.Http;
using BooksDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class LanguagesController : ApiController
    {
        private readonly IRepository<Language> repository;

        public LanguagesController(IRepository<Language> repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            var languages = repository.GetAll().Select(l => l.Name).ToList();
            languages.Insert(0, "All (الكل)");
            return Ok(languages);
        }
    }
}

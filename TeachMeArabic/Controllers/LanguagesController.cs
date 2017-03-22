using MediaDataLayer.Entities;
using Repository;
using System.Linq;
using System.Web.Http;

namespace TeachMeArabic.Controllers
{
    public class LanguagesController : ApiController
    {
        private readonly IRepository repository;

        public LanguagesController(IRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            var languages = repository.GetAll<Language>().Select(l => l.Name).ToList();
            languages.Insert(0, "All (الكل)");
            return Ok(languages);
        }
    }
}

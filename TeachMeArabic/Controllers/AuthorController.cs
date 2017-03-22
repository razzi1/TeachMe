using System.Data.Entity;
using System.Linq;
using MediaDataLayer.Entities;
using Repository;
using System.Web.Http;

namespace TeachMeArabic.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly IRepository repository;

        public AuthorController(IRepository repository)
        {
            this.repository = repository;
        }
        public IHttpActionResult Get(int id)
        {
            var author = repository
                .GetAll<Author>()
                .Include(a => a.MediaList)
                .Single(a => a.Id == id);
            return Ok(author);
        }
    }
}

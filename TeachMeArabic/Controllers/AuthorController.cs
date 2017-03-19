using MediaDataLayer.Entities;
using Repository;
using System.Web.Http;
using MediaDataLayer.Entities;

namespace TeachMeArabic.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly IRepository<Author> repository;

        public AuthorController(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public IHttpActionResult Get(int id)
        {
            var author = repository.GetById(id);
            return Ok(author);
        }
    }
}

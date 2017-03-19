using System.Linq;
using BooksDataLayer;
using System.Web.Http;
using BooksDataLayer.Entities;
using Repository;

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

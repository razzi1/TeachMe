using System.Linq;
using BooksDataLayer;
using System.Web.Http;
using BooksDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class BookTypesController : ApiController
    {
        private readonly IRepository<BookType> repository;

        public BookTypesController(IRepository<BookType> repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            var bookTypes = repository.GetAll().Select(bt => bt.Type).ToList();
            bookTypes.Insert(0, "All (الكل)");
            return Ok(bookTypes);
        }
    }
}

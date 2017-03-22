using System.Linq;
using MediaDataLayer;
using System.Web.Http;
using MediaDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IRepository repository;

        public StudentController(IRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get(int id)
        {
            var author = repository.GetById<Student>(id);
            return Ok(author);
        }
    }
}

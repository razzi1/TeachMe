using System.Linq;
using MediaDataLayer;
using System.Web.Http;
using MediaDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IRepository<Student> repository;

        public StudentController(IRepository<Student> repository)
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

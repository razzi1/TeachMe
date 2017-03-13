using BooksDataLayer;
using System.Web.Http;

namespace TeachMeArabic.Controllers
{
    public class StudentLoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(Login login)
        {
            BookRepository repository = new BookRepository();
            var student = repository.StudentLogin(login);
            return Ok(new { IsSuccessful = true, StudentId = student.Id });
        }
    }
}

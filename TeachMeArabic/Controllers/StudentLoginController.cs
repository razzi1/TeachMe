using System.Data.Entity;
using System.Linq;
using BooksDataLayer;
using System.Web.Http;
using BooksDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class StudentLoginController : ApiController
    {
        private readonly IRepository<Student> repository;
        private const int StudentNotFound = 0;

        public StudentLoginController(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IHttpActionResult Post(Login login)
        {
            var encryptedPassword = Hash.GetHashSha256(login.Password);
            var student = repository
                .GetAll()
                .Include(s => s.Parent)
                .SingleOrDefault(s => s.Username == login.Username && s.EncryptedPassword == encryptedPassword);
            return student != null ? Ok(new { IsSuccessful = true, StudentId = student.Id }) : Ok(new { IsSuccessful = false, StudentId = StudentNotFound });
        }
    }
}

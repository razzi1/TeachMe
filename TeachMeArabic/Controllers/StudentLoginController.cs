using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using MediaDataLayer;
using MediaDataLayer.Entities;
using Repository;
using TeachMeArabic.Models;
using TeachMeArabic.Utilities;

namespace TeachMeArabic.Controllers
{
    public class StudentLoginController : ApiController
    {
        private readonly IRepository repository;
        private const int StudentNotFound = 0;

        public StudentLoginController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IHttpActionResult Post(Login login)
        {
            var encryptedPassword = Encrypt.EncryptString(login.Password);
            var student = repository
                .GetAll<Student>()
                .Include(s => s.Parent)
                .SingleOrDefault(s => s.Username == login.Username && s.EncryptedPassword == encryptedPassword);
            return student != null ? Ok(new { IsSuccessful = true, StudentId = student.Id }) : Ok(new { IsSuccessful = false, StudentId = StudentNotFound });
        }
    }
}

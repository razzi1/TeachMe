using System.Data.Entity;
using System.Linq;
using BooksDataLayer;
using System.Web.Http;
using AutoMapper;
using BooksDataLayer.Entities;
using Repository;
using TeachMeArabic.Models;

namespace TeachMeArabic.Controllers
{
    public class BookController : ApiController
    {
        private readonly IRepository<Book> repository;

        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IHttpActionResult Post(Search search)
        {
            var books = repository
                .GetAll()
                .Include(b => b.Authors)
                .Include(b => b.Language)
                .Include(b => b.BookType)
                .Where(b =>
                    (search.SelectedLanguage.Equals("All (الكل)") || b.Language.Name == search.SelectedLanguage) &&
                    (search.SelectedBookType.Equals("All (الكل)") || b.BookType.Type == search.SelectedBookType) &&
                    (string.IsNullOrEmpty(search.Title) || b.Title.Contains(search.Title) || b.Description.Contains(search.Title)) &&
                    (string.IsNullOrEmpty(search.Author) || b.Authors.Any(a => a.Fullname.Contains(search.Author))))
                .ToList();

            var result = books.Select(Mapper.Map<Book, BookModel>);
            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var book = repository.GetById(id);
            return Ok(Mapper.Map<Book, BookModel>(book));
        }
    }
}

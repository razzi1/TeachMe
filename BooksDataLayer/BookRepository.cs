using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BooksDataLayer
{
    public class BookRepository
    {
        private BookContext dbContext;
        public BookRepository()
        {
           dbContext = new BookContext(); 
        }

        public Student StudentLogin(Login login)
        {
            var encryptedPassword = Hash.GetHashSha256(login.Password);
            var student = dbContext.Students.Include(s => s.Parent).SingleOrDefault(s => s.Username == login.Username && s.EncryptedPassword == encryptedPassword);
            return student; 
        }

        public Student GetStudentById(int id)
        {
            return dbContext.Students
                .Include(s => s.Parent)
                .Single(s => s.Id == id);
        }

        public List<BookType> BookTypes()
        {
            return dbContext.BookTypes.ToList();
        }

        public List<Language> Languages()
        {
            return dbContext.Languages.ToList();
        }

        public Book GetBookById(string id)
        {
            return dbContext.Books
                .Include(b => b.Authors)
                .Include(b => b.Language)
                .Include(b => b.BookType)
                .Single(b => b.Id == id);
        }

        public List<Book> Search(Search search)
        {
            return dbContext.Books
                .Include(b => b.Authors)
                .Include(b => b.Language)
                .Include(b => b.BookType)
                .Where(b => 
                    ( search.SelectedLanguage.Equals("All (الكل)") || b.Language.Name == search.SelectedLanguage) &&
                    (search.SelectedBookType.Equals("All (الكل)") || b.BookType.Type == search.SelectedBookType) &&
                    ( string.IsNullOrEmpty(search.Title) || b.Title.Contains(search.Title) || b.Description.Contains(search.Title)) &&
                    ( string.IsNullOrEmpty(search.Author) || b.Authors.Any(a => a.Fullname.Contains(search.Author))))
                .ToList();
        }

        public Author GetAuthorById(int id)
        {
            return dbContext.Authors
                .Include(a => a.Books)
                .Single(a => a.Id == id);
        }

    }
}

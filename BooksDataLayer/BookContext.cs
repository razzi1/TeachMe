using System.Data.Entity;

namespace BooksDataLayer
{
    public partial class BookContext : DbContext
    {
        public BookContext() : base("name=Books") { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

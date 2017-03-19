using System;
using System.Data.Entity;
using BooksDataLayer.Entities;
using Repository;

namespace BooksDataLayer
{
    public partial class BookContext : DbContext, IDbConctext
    {
        public BookContext() : base("name=Books") { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        IDbSet<TEntity> IDbConctext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        int IDbConctext.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

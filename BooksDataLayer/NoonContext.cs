using MediaDataLayer.Entities;
using Repository;
using System.Data.Entity;

namespace MediaDataLayer
{
    public partial class NoonContext : DbContext, IDbConctext
    {
        public NoonContext() : base("name=Noon") { }

        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<MediaCollection> MediaCollections { get; set; }
        public virtual DbSet<StudentMediaScore> StudentMediaScores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Media>()
                .HasMany(me => me.Categories)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Media_Id");
                    m.MapRightKey("Category_Id");
                    m.ToTable("MediaCategories");
                });

            //modelBuilder.Entity<Media>()
            //    .HasMany(me => me.Authors)
            //    .WithMany()
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("Media_Id");
            //        m.MapRightKey("Author_Id");
            //        m.ToTable("MediaAuthors");
            //    });
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

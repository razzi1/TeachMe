using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class, IHaveId
    {
        private readonly IDbConctext dbContext;

        public Repository(IDbConctext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Single(entity => entity.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConctext dbContext;

        public Repository(IDbConctext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : class, IHaveId
        {
            return dbContext.Set<T>().Single(entity => entity.Id == id);
        }

        public IQueryable<T>GetAll<T>() where T : class, IHaveId
        {
            return dbContext.Set<T>();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
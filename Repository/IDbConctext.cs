using System.Data.Entity;

namespace Repository
{
    public interface IDbConctext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
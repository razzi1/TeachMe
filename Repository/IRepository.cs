using System.Linq;

namespace Repository
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : class, IHaveId;
        IQueryable<T> GetAll<T>() where T : class, IHaveId;
        void SaveChanges();
    }
}

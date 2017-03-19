using System.Linq;

namespace Repository
{
    public interface IRepository<out T> where T : class, IHaveId
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void SaveChanges();
    }
}

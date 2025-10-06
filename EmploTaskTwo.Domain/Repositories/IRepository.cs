using System.Linq;

namespace EmploTaskTwo.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();
        T GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

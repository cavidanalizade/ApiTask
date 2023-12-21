using Api_TEST.Entities;
using System.Linq.Expressions;

namespace Api_TEST.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<T> GetById(int id);
        Task Create(T entity);
        void Update(T entity);
        void delete(int id);
        void Save();
    }
}

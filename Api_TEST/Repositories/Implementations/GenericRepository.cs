using Api_TEST.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Api_TEST.Repositories.Interfaces;
using Api_TEST.Entities;

namespace Api_TEST.Repositories.Implementations
{
    public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _table;



        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void delete(int id)
        {
            var car = _table.FirstOrDefault(b => b.Id == id);

            _table.Remove(car);
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public async Task<T> GetById(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}

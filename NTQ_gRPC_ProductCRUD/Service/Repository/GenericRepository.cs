using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NTQTRAININGContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(NTQTRAININGContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T enitty)
        {
            _dbSet.Add(enitty);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}

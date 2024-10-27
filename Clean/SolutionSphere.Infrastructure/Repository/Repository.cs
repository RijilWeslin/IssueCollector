using Microsoft.EntityFrameworkCore;
using SolutionSphere.Application.IRepository;

namespace SolutionSphere.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {                        
            return Queryable.AsQueryable(_dbSet);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }


        public void Add(TEntity entity) {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}

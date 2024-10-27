using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Application.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Query();
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}

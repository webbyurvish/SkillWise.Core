using Microsoft.EntityFrameworkCore;
using SkillWise.Core.Data;
using SkillWise.Core.Repository.Contracts;
using System.Linq.Expressions;

namespace SkillWise.Core.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly SWDbContext _sWDbContext;

        public RepositoryBase(SWDbContext sWDbContext)
        {
            _sWDbContext = sWDbContext;
        }
        public void Create(T entity)
        {
            _sWDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _sWDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _sWDbContext.Set<T>().AsNoTracking() : _sWDbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _sWDbContext.Set<T>().Where(expression).AsNoTracking() : _sWDbContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

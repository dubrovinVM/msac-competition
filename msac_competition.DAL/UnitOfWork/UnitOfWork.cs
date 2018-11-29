using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using msac_competition.DAL.EF;
using msac_competition.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace msac_competition.DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext dataContext)
        {
            _applicationContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _applicationContext.Set<T>().Add(entity);
        }

        public async Task CommitAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _applicationContext.SaveChanges();
        }

        public virtual DbContext GetContext()
        {
            return _applicationContext;
        }

        public virtual T GetSingle<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Get<T>().FirstOrDefault(predicate);
        }

        public virtual async Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await Get<T>().FirstOrDefaultAsync(predicate);
        }

        public void Dispose()
        {
            _applicationContext.Dispose();
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return _applicationContext.Set<T>();
        }

        public void Remove<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _applicationContext.Set<T>().Remove(entity);
        }
    }
}

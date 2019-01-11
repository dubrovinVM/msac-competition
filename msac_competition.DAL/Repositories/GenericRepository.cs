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
    public class GenericRepository<TEntity,TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly ApplicationContext _applicationContext;

        public GenericRepository(ApplicationContext dataContext)
        {
            _applicationContext = dataContext;
        }

        public async Task CommitAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }

        public void Update(TEntity item)
        {
            if (item == null) return;
            var exist = _applicationContext.Set<TEntity>().Find(item.Id);
            if (exist != null)
            {
                _applicationContext.Entry(exist).CurrentValues.SetValues(item);
            }
            //_applicationContext.Set<TEntity>().Update(item);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _applicationContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _applicationContext.Set<TEntity>().FirstOrDefaultAsync(e => Equals(e.Id, id));
        }

        public async Task<TEntity> GetByIdAsNoTrack(TKey id)
        {
            return await _applicationContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => Equals(e.Id, id));
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _applicationContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task Delete(TKey id)
        {
            var entity = await GetById(id);
            _applicationContext.Set<TEntity>().Remove(entity);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public DbContext GetContext()
        //{
        //    return _applicationContext;
        //}

        //public void Dispose()
        //{
        //    _applicationContext.Dispose();
        //}

    }
}

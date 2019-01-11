using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Identity;
using Microsoft.EntityFrameworkCore;

namespace msac_competition.DAL.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class, IEntity<TKey>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsNoTrack(TKey id);
        Task<TEntity> GetById(TKey id);
        Task<TEntity> Create(TEntity entity);
        Task Delete(TKey id);
        Task CommitAsync();
        void Update(TEntity item);
    }
}

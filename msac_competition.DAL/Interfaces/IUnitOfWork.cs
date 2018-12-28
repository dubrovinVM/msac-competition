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
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<T> Get<T>() where T : class;
        void Add<T>(T entity) where T : class;
        Task AddAsync<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;
        T GetSingle<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        DbContext GetContext();
        void Commit();
        Task CommitAsync();
        IQueryable<T> GetAsNoTr<T>() where T : class;

        void Update<T>(T entity) where T : class;


        //IRepository<Competition> Competitions { get; }
        //IRepository<Team> Teams { get; }
        //void Save();

        //ApplicationUserManager UserManager { get; }
        //IClientManager ClientManager { get; }
        //Task SaveAsync();
        //void SaveChanges();
        //DbContext GetContext();
    }
}

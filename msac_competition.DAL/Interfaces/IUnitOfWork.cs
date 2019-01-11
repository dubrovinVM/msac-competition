using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using msac_competition.DAL.Entities;

namespace msac_competition.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Coach, int> Coaches { get; }
        IRepository<Team, int> Teams { get; }
        IRepository<City, int> Cities { get; }
        IRepository<Sportman, int> Sportmen { get; }
        IRepository<Fst, int> Fsts { get; }
        Task CommitAsync();
        void Commit();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Identity;
using Microsoft.EntityFrameworkCore;

namespace msac_competition.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Competition> Competitions { get; }
        IRepository<Team> Teams { get; }
        void Save();

        //ApplicationUserManager UserManager { get; }
        //IClientManager ClientManager { get; }
        //Task SaveAsync();
        //void SaveChanges();
        //DbContext GetContext();
    }
}

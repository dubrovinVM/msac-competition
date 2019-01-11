using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using msac_competition.DAL.EF;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        private IRepository<Coach,int> _coachRepository;
        private IRepository<Team, int> _teamRepository;
        private IRepository<Sportman, int> _sportmanRepository;
        private IRepository<City, int> _cityRepository;
        private IRepository<Fst, int> _fstRepository;

        public EFUnitOfWork(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public IRepository<Coach, int> Coaches => _coachRepository ?? (_coachRepository = new GenericRepository<Coach, int>(db));
        public IRepository<Team, int> Teams => _teamRepository ?? (_teamRepository = new GenericRepository<Team, int>(db));
        public IRepository<Sportman, int> Sportmen => _sportmanRepository ?? (_sportmanRepository = new GenericRepository<Sportman, int>(db));
        public IRepository<City, int> Cities => _cityRepository ?? (_cityRepository = new GenericRepository<City, int>(db));
        public IRepository<Fst, int> Fsts => _fstRepository ?? (_fstRepository = new GenericRepository<Fst, int>(db));

        public async Task CommitAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

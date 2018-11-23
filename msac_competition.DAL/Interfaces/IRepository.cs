using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace msac_competition.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Commit();
    }
}

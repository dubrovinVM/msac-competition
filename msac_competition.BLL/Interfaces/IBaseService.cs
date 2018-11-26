using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msac_competition.BLL.Interfaces
{
    public interface IBaseService<T, TKey> where T : class
    {
        T Get(TKey id);
        Task<T> GetAsync(TKey id);
        T Create(T newItem, bool shouldBeCommited = false);
        void Update(T item, bool shouldBeCommited = false);
        IQueryable<T> GetAll();
        void Remove(T removeItem, bool shouldBeCommited = false);
        void Commit(bool shouldBeCommited = false);
        Task CommitAsync(bool shouldBeCommited = false);

    }
}

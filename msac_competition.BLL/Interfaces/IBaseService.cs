using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msac_competition.BLL.Interfaces
{
    public interface IBaseService<T, TKey> where T : class
    {
        void Update(T item, bool shouldBeCommited = false);
        void Remove(T removeItem, bool shouldBeCommited = false);
        void Commit(bool shouldBeCommited = false);
        Task CommitAsync(bool shouldBeCommited = false);
    }
}

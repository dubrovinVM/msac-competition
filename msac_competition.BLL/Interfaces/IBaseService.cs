using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace msac_competition.BLL.Interfaces
{
    public interface IBaseService<T, TKey> where T : class
    {
        void Update(T item, bool shouldBeCommited = false);
        T Create(T item, bool shouldBeCommited = false);
        void Remove(T removeItem, bool shouldBeCommited = false);
        void Commit(bool shouldBeCommited = false);
        Task CommitAsync(bool shouldBeCommited = false);
        Task<string> SaveAavatarAsync(IFormFile file, string surname, string imageFolder);
        void RemoveAavatar(string fileName, string imageFolder);
    }
}

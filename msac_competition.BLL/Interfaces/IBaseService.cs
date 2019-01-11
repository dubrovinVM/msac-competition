using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace msac_competition.BLL.Interfaces
{
    public interface IBaseService<TEntity, TPrimaryId> where TEntity : class 
    {
        //Task Update(TDto item, bool shouldBeCommited = false);
        //Task Create(TDto item, bool shouldBeCommited = false);
        //Task Remove(TPrimaryId id, bool shouldBeCommited = false);
        //Task CommitAsync(bool shouldBeCommited = false);
        Task<string> SaveAvatarAsync(IFormFile file, string surname, string imageFolder);
        void RemoveAvatar(string fileName, string imageFolder);
        void Dispose();
    }
}

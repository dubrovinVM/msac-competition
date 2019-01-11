using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msac_competition.BLL.DTO;
using msac_competition.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace msac_competition.BLL.Interfaces
{
    public interface IFstService : IBaseService<Fst, int>
    {
        IList<FstDTO> GetAll();
        Task<FstDTO> GetById(int id);
        Task<FstDTO> GetByIdAsNoTrack(int id);
        Task<FstDTO> Create(FstDTO fstDto, IFormFile ava, bool shouldBeCommited = false);
        Task Delete(FstDTO fstDto, bool shouldBeCommited = false);
        Task UpdateFst(FstDTO fstDto, IFormFile ava, bool shouldBeCommited = false);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msac_competition.BLL.DTO;
using msac_competition.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace msac_competition.BLL.Interfaces
{
    public interface ISportmanService : IBaseService<Sportman, int>
    {
        Task<SportmanDTO> GetByIdAsNoTrack(int id);
        Task<SportmanDTO> GetById(int id);
        IEnumerable<SelectListItem> GetTeamsSelectList();
        IQueryable<SportmanDTO> GetAllAsNoTrack();
        IQueryable<SportmanDTO> GetAll();
        Task Update(SportmanDTO coachDto, bool shouldBeCommited = false);
    }
}

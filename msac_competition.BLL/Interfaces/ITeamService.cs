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
    public interface ITeamService: IBaseService<Team, int>
    {
        Task<TeamDTO> GetAsNoTrack(int id);
        Task<TeamDTO> Get(int id);
        IEnumerable<SelectListItem> GetTeamsSelectList();
        IQueryable<TeamDTO> GetAllAsNoTrack();
        IQueryable<TeamDTO> GetAll();
        Task Update(TeamDTO coachDto, bool shouldBeCommited = false);
    }
}

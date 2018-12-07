using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using msac_competition.BLL.DTO;

namespace msac_competition.BLL.Interfaces
{
    public interface ITeamService: IBaseService<TeamDTO, int>
    {
        IQueryable<TeamDTO> GetAll();
    }
}

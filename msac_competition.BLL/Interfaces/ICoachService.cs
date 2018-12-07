using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using msac_competition.BLL.DTO;

namespace msac_competition.BLL.Interfaces
{
    public interface ICoachService : IBaseService<CoachDTO, int>
    {
        IQueryable<CoachDTO> GetAll();
    }
}

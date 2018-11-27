using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.Services
{
    public class TeamService : BaseService<TeamDTO, int>, ITeamService
    {
        public TeamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}

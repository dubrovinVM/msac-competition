using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.Services
{
    public class CompetitionService: BaseService<CompetitionDTO, int>, ICompetitionService
    {
        public CompetitionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}

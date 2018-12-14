using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msac_competition.BLL.DTO;

namespace msac_competition.BLL.Interfaces
{
    public interface ICoachService : IBaseService<CoachDTO, int>
    {
        string CoachFolder { get; set; }
        IQueryable<CoachDTO> GetAll();
        CoachDTO Get(int id);
        CoachDTO GetAsNoTrck(int id);
        Task CreateAsync(CoachDTO coachDTO, bool shouldBeCommited = false);
        void Delete(CoachDTO coachDTO, bool shouldBeCommited = false);
    }
}

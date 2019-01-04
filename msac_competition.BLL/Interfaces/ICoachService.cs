using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msac_competition.BLL.DTO;
using msac_competition.DAL.Entities;

namespace msac_competition.BLL.Interfaces
{
    public interface ICoachService : IBaseService<Coach, int>, IDisposable
    {
        string CoachFolder { get; set; }
        IList<CoachDTO> GetAll();
        Task<CoachDTO> Get(int id);
        Task <CoachDTO> GetAsNoTrack(int id);
        Task Create(CoachDTO coachDto, bool shouldBeCommited = false);
        void Delete(CoachDTO coachDto, bool shouldBeCommited = false);
        Task UpdateCoach(CoachDTO coachDto, bool shouldBeCommited = false);
    }
}

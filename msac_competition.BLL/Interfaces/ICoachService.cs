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
    public interface ICoachService : IBaseService<Team, int>
    {
        string CoachFolder { get; set; }
        IList<CoachDTO> GetAll();
        Task<CoachDTO> GetById(int id);
        Task <CoachDTO> GetByIdAsNoTrack(int id);
        Task<CoachDTO> Create(CoachDTO coachDto, IFormFile ava, bool shouldBeCommited = false);
        Task Delete(CoachDTO coachDto, bool shouldBeCommited = false);
        Task UpdateCoach(CoachDTO coachDto, IFormFile ava, bool shouldBeCommited = false);
    }
}

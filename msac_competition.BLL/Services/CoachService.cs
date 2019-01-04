using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.BusinessModels;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace msac_competition.BLL.Services
{
    public class CoachService: BaseService<Coach, int>, ICoachService
    {
        public string CoachFolder { get; set; }

        protected readonly IRepository<Coach, int> __repository;

        public CoachService(IRepository<Coach, int> repository) : base(repository)
        {
            __repository = _repository ?? repository;
        }

        public async Task<CoachDTO> Get(int id)
        {
            var item = await __repository.GetById(id);
            var itemDto = Mapper.Map<Coach, CoachDTO>(item);
            return itemDto;
        }

        public async Task<CoachDTO> GetAsNoTrack(int id)
        {
            var item = await __repository.GetById(id);
            var itemDto = Mapper.Map<Coach,CoachDTO>(item);
            return itemDto;
        }

        public async Task Create(CoachDTO coachDto, bool shouldBeCommited = false)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDto);
            await __repository.Create(coach);
        }

        public IList<CoachDTO> GetAll()
        {
            var items = __repository.GetAll().Include(a => a.Team);
            var itemDtos = Mapper.Map<IEnumerable<Coach>, IEnumerable<CoachDTO>>(items);
            return itemDtos.ToList();
        }

        public void Delete(CoachDTO coachDTO, bool shouldBeCommited = false)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            RemoveAvatar(coach.Avatar, CoachFolder);
            __repository.Delete(coachDTO.Id);
            if (shouldBeCommited)
            {
                _repository.CommitAsync();
            }
        }

        public async Task UpdateCoach(CoachDTO coachDTO, bool commit)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            //coach.Team.CoachId = coach.Id;
            __repository.Update(coach);
            if (commit)
            {
                await __repository.CommitAsync();
            }
        }

    }
}

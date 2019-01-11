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
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace msac_competition.BLL.Services
{
    public class CoachService: BaseService<Coach, int>, ICoachService
    {

        IUnitOfWork __repository { get; set; }
        private IConfiguration _configuration;
        public string CoachFolder { get; set; }
        private ITeamService _teamService;

        public CoachService(IUnitOfWork repository, IConfiguration configuration, ITeamService teamService)
        {
            _configuration = configuration;
            CoachFolder = _configuration.GetValue<string>("avatar:coach");
            __repository = repository;
            _teamService = teamService;
        }

        public async Task<CoachDTO> GetById(int id)
        {
            var item = await __repository.Coaches.GetById(id);
            var itemDto = Mapper.Map<Coach, CoachDTO>(item);
            return itemDto;
        }

        public async Task<CoachDTO> GetByIdAsNoTrack(int id)
        {
            var item = await __repository.Coaches.GetByIdAsNoTrack(id);
            var itemDto = Mapper.Map<Coach,CoachDTO>(item);
            return itemDto;
        }

        public async Task<CoachDTO> Create(CoachDTO coachDto, IFormFile ava, bool shouldBeCommited = false)
        {
            if (ava != null)
            {
                coachDto.Avatar = await SaveAvatarAsync(ava, coachDto.Surname, CoachFolder);
            }
            var coach = Mapper.Map<CoachDTO, Coach>(coachDto);
            var newItem = await __repository.Coaches.Create(coach);
            await __repository.CommitAsync();
            return Mapper.Map<Coach,CoachDTO>(newItem);
        }

        public IList<CoachDTO> GetAll()
        {
            var items = __repository.Coaches.GetAll().Include(a=>a.Team).Include(b=>b.City);
            var itemDtos = Mapper.Map<IEnumerable<Coach>, IEnumerable<CoachDTO>>(items);
            return itemDtos.ToList();
        }

        public async Task Delete(CoachDTO coachDTO, bool shouldBeCommited = false)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            RemoveAvatar(coach.Avatar, CoachFolder);
            await _teamService.SetTeamCoachToNull(coachDTO.Id);
            await __repository.Coaches.Delete(coachDTO.Id);
            if (shouldBeCommited)
            {
                __repository.Commit();
            }
        }

        public async Task UpdateCoach(CoachDTO coachDTO, IFormFile ava, bool commit)
        {
            if (ava != null)
            {
                RemoveAvatar(coachDTO.Avatar, CoachFolder);
                coachDTO.Avatar = await SaveAvatarAsync(ava, coachDTO.Surname, CoachFolder);
            }

            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            __repository.Coaches.Update(coach);
            if (commit)
            {
                await __repository.CommitAsync();
            }
        }

        public virtual async Task CommitAsync(bool shouldBeCommited = false)
        {
            if (shouldBeCommited)
            {
                await __repository.CommitAsync();
            }
        }

        public override void Dispose()
        {
            __repository.Dispose();
        }

    }
}

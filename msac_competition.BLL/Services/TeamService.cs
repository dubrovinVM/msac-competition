using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;
using msac_competition.DAL.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace msac_competition.BLL.Services
{
    public class TeamService : BaseService<Team, int>, ITeamService
    {
        protected readonly IRepository<Team, int> __repository;

        public TeamService(IRepository<Team, int> repository) : base(repository)
        {
            __repository = _repository ?? repository;
        }

        public IQueryable<TeamDTO> GetAll()
        {
            var items = __repository.GetAll().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task Update(TeamDTO coachDto, bool shouldBeCommited = false)
        {
            var team = Mapper.Map<TeamDTO, Team>(coachDto);
            //coach.Team.CoachId = coach.Id;
            __repository.Update(team);
            if (shouldBeCommited)
            {
                await __repository.CommitAsync();
            }
        }

        public IQueryable<TeamDTO> GetAllAsNoTrack()
        {
            var items = __repository.GetAll().AsNoTracking().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task<TeamDTO> Get(int id)
        {
            var item = await __repository.GetById(id);
            var itemDto = Mapper.Map<Team, TeamDTO>(item);
            return itemDto;
        }

        public async Task<TeamDTO> GetAsNoTrack(int id)
        {
            var item = await __repository.GetById(id);
            var itemDto = Mapper.Map<Team, TeamDTO>(item);
            return itemDto;
        }

        public IEnumerable<SelectListItem> GetTeamsSelectList()
        {
            List<SelectListItem> teams = GetAllAsNoTrack()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();
            var teamsNullable = new SelectListItem()
            {
                Value = null,
                Text = "--- оберіть значення ---"
            };
            teams.Insert(0, teamsNullable);
            return new SelectList(teams, "Value", "Text");
        }
        
    }
}

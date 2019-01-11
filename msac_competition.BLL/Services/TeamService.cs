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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace msac_competition.BLL.Services
{
    public class TeamService : BaseService<Team, int>, ITeamService
    {
        IUnitOfWork __repository { get; set; }

        public TeamService(IUnitOfWork repository)
        {
            __repository = repository;
        }

        public IQueryable<TeamDTO> GetAll()
        {
            var items = __repository.Teams.GetAll().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task Update(TeamDTO coachDto, bool shouldBeCommited = false)
        {
            await SetTeamCoachToNull(coachDto.Id);
            var team = Mapper.Map<TeamDTO, Team>(coachDto);
            __repository.Teams.Update(team);
            if (shouldBeCommited)
            {
                await __repository.CommitAsync();
            }
        }

        public IQueryable<TeamDTO> GetAllAsNoTrack()
        {
            var items = __repository.Teams.GetAll().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task<TeamDTO> GetById(int id)
        {
            var item = await __repository.Teams.GetById(id);
            var itemDto = Mapper.Map<Team, TeamDTO>(item);
            return itemDto;
        }

        public async Task<TeamDTO> GetByIdAsNoTrack(int id)
        {
            var item = await __repository.Teams.GetByIdAsNoTrack(id);
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

        public async Task SetTeamCoachToNull(int? coachId)
        {
            if (coachId == null) return;
            var oldTeamDto = GetAll().FirstOrDefault(a => a.CoachId == coachId);
            if (oldTeamDto != null)
            {
                oldTeamDto.CoachId = null;
                await Update(oldTeamDto);
            }
        }

        public async Task SetTeamFstToNull(int? fstId)
        {
            if (fstId == null) return;
            var oldTeamDto = GetAll().FirstOrDefault(a => a.FstId == fstId);
            if (oldTeamDto != null)
            {
                oldTeamDto.FstId = null;
                await Update(oldTeamDto);
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

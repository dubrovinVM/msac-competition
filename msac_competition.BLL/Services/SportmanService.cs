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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace msac_competition.BLL.Services
{
    public class SportmanService : BaseService<Sportman, int>, ISportmanService
    {
        IUnitOfWork __repository { get; set; }

        public SportmanService(IUnitOfWork repository)
        {
            __repository = repository;
        }

        public IQueryable<SportmanDTO> GetAll()
        {
            var items = __repository.Sportmen.GetAll().Include(a=>a.Team).ThenInclude(b=>b.Coach).ToList();
            var itemDtos = Mapper.Map<IEnumerable<Sportman>, IEnumerable<SportmanDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task Update(SportmanDTO sportmanDto, bool shouldBeCommited = false)
        {
            var sportman = Mapper.Map<SportmanDTO, Sportman>(sportmanDto);
            __repository.Sportmen.Update(sportman);
            if (shouldBeCommited)
            {
                await __repository.CommitAsync();
            }
        }

        public IQueryable<SportmanDTO> GetAllAsNoTrack()
        {
            var items = __repository.Sportmen.GetAll().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Sportman>, IEnumerable<SportmanDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task<SportmanDTO> GetById(int id)
        {
            var item = await __repository.Sportmen.GetById(id);
            var itemDto = Mapper.Map<Sportman, SportmanDTO>(item);
            return itemDto;
        }

        public async Task<SportmanDTO> GetByIdAsNoTrack(int id)
        {
            var item = await __repository.Sportmen.GetByIdAsNoTrack(id);
            var itemDto = Mapper.Map<Sportman, SportmanDTO>(item);
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

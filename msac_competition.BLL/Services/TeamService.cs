using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace msac_competition.BLL.Services
{
    public class TeamService : BaseService<TeamDTO, int>, ITeamService
    {
        public TeamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IQueryable<TeamDTO> GetAll()
        {
            var items = UnitOfWork.Get<Team>().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public override TeamDTO Get(int id)
        {
            var item = UnitOfWork.Get<Team>().FirstOrDefault(a=>a.Id==id);
            var itemDto = Mapper.Map<Team, TeamDTO>(item);
            return itemDto;
        }

        public IEnumerable<SelectListItem> GetTeamsSelectList()
        {
            List<SelectListItem> teams = GetAll().AsNoTracking()
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

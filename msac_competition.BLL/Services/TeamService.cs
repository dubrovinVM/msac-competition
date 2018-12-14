using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
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
            var teams_nullable = new SelectListItem()
            {
                Value = null,
                Text = "--- оберіть значення ---"
            };
            teams.Insert(0, teams_nullable);
            return new SelectList(teams, "Value", "Text");

        }
    }
}

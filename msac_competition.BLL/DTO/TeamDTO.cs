using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class TeamDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CompetitionDTO> Competitions { get; set; }
    }
}

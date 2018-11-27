using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class CompetitionDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamDTO> Teams { get; set; }
    }
}

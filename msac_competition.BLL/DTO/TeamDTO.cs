using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.BLL.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CompetitionDTO> Competitions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.BLL.DTO
{
    public class CompetitionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamDTO> Teams { get; set; }
    }
}

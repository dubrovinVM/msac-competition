using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class TeamCompetition
    {
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int? CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
        
    }
}

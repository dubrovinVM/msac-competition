using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.DAL.Entities
{
   public class SportmanCompetition
    {

        public int? SportmanId { get; set; }
        public virtual Sportman Sportman { get; set; }

        public int? CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

    }
}

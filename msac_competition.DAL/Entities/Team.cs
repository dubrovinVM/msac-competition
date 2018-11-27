using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Team : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TeamCompetition> TeamCompetitions { get; set; }

        public Team()
        {
            this.TeamCompetitions = new HashSet<TeamCompetition>();
        }
    }
}

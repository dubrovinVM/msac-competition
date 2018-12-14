using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Competition : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string Comment { get; set; }
        public CompetitionStatus Status { get; set; }
        public Rank Rank { get; set; }
        public string Afisha { get; set; }

        public virtual ICollection<TeamCompetition> TeamCompetitions { get; set; }
        public virtual ICollection<SportmanCompetition> SportmenCompetitions { get; set; }

        public Competition()
        {
            TeamCompetitions = new List<TeamCompetition>();
            SportmenCompetitions = new List<SportmanCompetition>();
        }
    }
}

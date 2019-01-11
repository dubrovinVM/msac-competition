using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Team : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<TeamCompetition> TeamCompetitions { get; set; }

        public virtual List<Sportman> Sportmen { get; set; }

        public int? FstId { get; set; }
        public virtual Fst Fst { get; set; }

        public int? CoachId { get; set; }
        public virtual Coach Coach { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }

        public Team()
        {
            TeamCompetitions = new List<TeamCompetition>();
            Sportmen = new List<Sportman>();
        }


        public string Logo { get; set; }

    }
}

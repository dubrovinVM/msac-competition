using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class City : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual List<Team> Teams { get; set; }
        public virtual List<Coach> Coaches { get; set; }
        public City()
        {
            Teams = new List<Team>();
            Coaches = new List<Coach>();
        }
    }
}
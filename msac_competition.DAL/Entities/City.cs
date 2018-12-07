using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace msac_competition.DAL.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual List<Team> Teams { get; set; }

        public City()
        {
            Teams = new List<Team>();
        }
    }
}
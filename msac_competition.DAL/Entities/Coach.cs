using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Coach : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime? DaTeOfBirth { get; set; }
        public SportRank? SportRank { get; set; }
        public Sex Sex { get; set; }

        public virtual Team Team { get; set; }
        public virtual List<Sportman> Sportmen { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }

        public string Avatar { get; set; }

        public Coach()
        {
            Sportmen = new List<Sportman>();
        }
    }
}

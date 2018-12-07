using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class Sportman
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime DaTeOfBirth { get; set; }
        public SportRank SportRank { get; set; }

        public int? CoachId { get; set; }
        public virtual Coach Coach { get; set; }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public string Avatar { get; set; }

    }
}

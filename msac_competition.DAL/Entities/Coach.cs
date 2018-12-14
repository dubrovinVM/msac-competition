using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class Coach
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

        public string Avatar { get; set; }

        public Coach()
        {
            Sportmen = new List<Sportman>();
        }
    }
}

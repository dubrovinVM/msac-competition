using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using msac_competition.DAL.Entities;

namespace msac_competition.Models
{
    public class SportmanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime DaTeOfBirth { get; set; }
        public SportRank SportRank { get; set; }
        public int? CoachId { get; set; }
        public CoachViewModel Coach { get; set; }
        public int? TeamId { get; set; }
        public TeamViewModel Team { get; set; }
        public string Avatar { get; set; }

        public string CoachName { get; set; }

        public SportmanViewModel()
        {
            this.CoachName = String.Format($"{Coach?.Surname} { Coach?.Name.Substring(0,2)}.{Coach?.Surname.Substring(0,2)}.");
        }

    }
}

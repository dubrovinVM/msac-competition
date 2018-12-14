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
        public Sex Sex { get; set; }
        public int? CoachId { get; set; }
        public CoachViewModel Coach { get; set; }
        public int? TeamId { get; set; }
        public TeamViewModel Team { get; set; }
        public string Avatar { get; set; }
        [NotMapped]
        public string CoachPib { get; set; }

        public ICollection<CompetitionViewModel> Competitions { get; set; }

        public SportmanViewModel()
        {
            Competitions = new List<CompetitionViewModel>();
        }
    }
}

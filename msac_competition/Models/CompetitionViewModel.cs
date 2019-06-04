using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using msac_competition.DAL.Entities;

namespace msac_competition.Models
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamViewModel> Teams { get; set; }
        public ICollection<SportmanViewModel> Sportmen { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string Comment { get; set; }
        public CompetitionStatus Status { get; set; }
        public Rank Rank { get; set; }

        public CompetitionViewModel()
        {
            Teams = new List<TeamViewModel>();
            Sportmen = new List<SportmanViewModel>();
        }
        public string Afisha { get; set; }
    }
}

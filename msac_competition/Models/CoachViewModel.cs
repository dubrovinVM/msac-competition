using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msac_competition.Models
{
    public class CoachViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime DaTeOfBirth { get; set; }
        public int SportRank { get; set; }

        public TeamViewModel Team { get; set; }

        public List<SportmanViewModel> Sportmen { get; set; }

        public string Avatar { get; set; }

        public CoachViewModel()
        {
            Sportmen = new List<SportmanViewModel>();
        }
    }
}

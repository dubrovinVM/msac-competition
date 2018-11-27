using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msac_competition.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CompetitionViewModel> Competitions { get; set; }
    }
}

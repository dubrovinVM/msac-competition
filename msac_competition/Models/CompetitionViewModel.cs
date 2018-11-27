using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msac_competition.Models
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamViewModel> Teams { get; set; }
    }
}

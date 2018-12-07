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
        public ICollection<SportmanViewModel> Sportmen { get; set; }
        public string ShortName { get; set; }

        public int? FstId { get; set; }
        public virtual FstViewModel Fst { get; set; }

        public int? CoachId { get; set; }
        public virtual CoachViewModel Coach { get; set; }

        public int? CityId { get; set; }
        public virtual CityViewModel City { get; set; }

        public string Logo { get; set; }

        public TeamViewModel()
        {
            Competitions = new List<CompetitionViewModel>();
            Sportmen = new List<SportmanViewModel>();
        }

    }
}

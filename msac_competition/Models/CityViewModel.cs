using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msac_competition.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? RegionId { get; set; }
        public RegionViewModel Region { get; set; }

        public List<TeamViewModel> Teams { get; set; }

        public CityViewModel()
        {
            Teams = new List<TeamViewModel>();
        }
    }
}

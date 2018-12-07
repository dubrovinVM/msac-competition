using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msac_competition.Models
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CityViewModel> Cities { get; set; }

        public RegionViewModel()
        {
            Cities = new List<CityViewModel>();
        }
    }
}

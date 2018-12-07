using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msac_competition.Models
{
    public class FstViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<TeamViewModel> Teams { get; set; }

        public FstViewModel()
        {
            Teams = new List<TeamViewModel>();
        }
    }
}

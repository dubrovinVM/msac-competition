using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Competition> Competitions { get; set; }
    }
}

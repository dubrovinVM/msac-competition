using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}

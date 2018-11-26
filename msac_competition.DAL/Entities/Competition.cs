using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Competition : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}

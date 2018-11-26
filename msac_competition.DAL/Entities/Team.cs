using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Team : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Competition> Competitions { get; set; }
    }
}

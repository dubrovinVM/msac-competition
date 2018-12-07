using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class CompetitionDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamDTO> Teams { get; set; }
        public DateTime StatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string Comment { get; set; }
        public CompetitionStatus Status { get; set; }
        public Rank Rank { get; set; }

        public CompetitionDTO()
        {
            Teams = new List<TeamDTO>();
        }
        public string Afisha { get; set; }
    }
}

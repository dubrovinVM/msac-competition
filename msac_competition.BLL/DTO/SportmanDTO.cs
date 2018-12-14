using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class SportmanDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime DaTeOfBirth { get; set; }
        public SportRank SportRank { get; set; }
        public Sex Sex { get; set; }
        public string Avatar { get; set; }

        public int? CoachId { get; set; }
        public CoachDTO Coach { get; set; }

        public int? TeamId { get; set; }
        public TeamDTO Team { get; set; }

        public ICollection<CompetitionDTO> Competitions { get; set; }

        public SportmanDTO()
        {
            Competitions = new List<CompetitionDTO>();
        }

    }
}

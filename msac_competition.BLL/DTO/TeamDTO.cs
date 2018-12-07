using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class TeamDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CompetitionDTO> Competitions { get; set; }
        public ICollection<SportmanDTO> Sportmen { get; set; }
        public string ShortName { get; set; }

        public int? FstId { get; set; }
        public virtual FstDTO Fst { get; set; }

        public int? CoachId { get; set; }
        public virtual CoachDTO Coach { get; set; }

        public int? CityId { get; set; }
        public virtual CityDTO City { get; set; }

        public TeamDTO()
        {
            Competitions = new List<CompetitionDTO>();
            Sportmen = new List<SportmanDTO>();
        }
        public string Logo { get; set; }

    }
}

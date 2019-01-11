using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class CoachDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime? DaTeOfBirth { get; set; }
        public Sex Sex { get; set; }
        public SportRank? SportRank { get; set; }

        public TeamDTO Team { get; set; }

        public int? CityId { get; set; }
        public CityDTO City { get; set; }

        public List<SportmanDTO> Sportmen { get; set; }

        public string Avatar { get; set; }

        public CoachDTO()
        {
            Sportmen = new List<SportmanDTO>();
        }

    }
}

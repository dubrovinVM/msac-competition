using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class CityDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? RegionId { get; set; }
        public virtual RegionDTO Region { get; set; }

        public virtual List<TeamDTO> Teams { get; set; }

        public CityDTO()
        {
            Teams = new List<TeamDTO>();
        }
    }
}

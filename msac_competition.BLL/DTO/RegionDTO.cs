using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.BLL.DTO
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CityDTO> Cities { get; set; }

        public RegionDTO()
        {
            Cities = new List<CityDTO>();
        }
    }
}

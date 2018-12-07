using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.DTO
{
    public class FstDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<TeamDTO> Teams { get; set; }

        public FstDTO()
        {
            Teams = new List<TeamDTO>();
        }
    }
}

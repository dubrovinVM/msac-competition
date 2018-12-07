using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using msac_competition.BLL.DTO;

namespace msac_competition.BLL.Interfaces
{
    public interface IFstService : IBaseService<FstDTO, int>
    {
        IQueryable<FstDTO> GetAll();
    }
}

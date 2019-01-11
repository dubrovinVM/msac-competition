using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msac_competition.BLL.DTO;
using msac_competition.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace msac_competition.BLL.Interfaces
{
    public interface ICityService : IBaseService<City, int>
    {
        Task<CityDTO> GetByIdAsNoTrack(int id);
        Task<CityDTO> GetById(int id);
        IEnumerable<SelectListItem> GetCitysSelectList();
        IQueryable<CityDTO> GetAllAsNoTrack();
        IQueryable<CityDTO> GetAll();
        Task Update(CityDTO coachDto, bool shouldBeCommited = false);
        Task SetCityCoachToNull(int? coachId);
    }
}

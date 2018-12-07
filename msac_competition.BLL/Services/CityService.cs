using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.Services
{
    public class CityService: BaseService<CityDTO, int>, ICityService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public CityService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public CityDTO Get(int id)
        {
            var item = UnitOfWork.Get<City>().FirstOrDefault(a => a.Id == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()).CreateMapper();
            var itemDto = mapper.Map<City, CityDTO>(item);
            return itemDto;
        }

        public IQueryable<CityDTO> GetAll()
        {
            var items = UnitOfWork.Get<City>().ToList();
            var itemDtos = Mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(items);
            return itemDtos.AsQueryable();
        }
    }
}

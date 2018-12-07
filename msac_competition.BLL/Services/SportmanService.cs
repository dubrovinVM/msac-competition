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
    public class SportmanService : BaseService<SportmanDTO, int>, ISportmanService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public SportmanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public SportmanDTO Get(int id)
        {
            var item = UnitOfWork.Get<Sportman>().FirstOrDefault(a => a.Id == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sportman, SportmanDTO>()).CreateMapper();
            var itemDto = mapper.Map<Sportman, SportmanDTO>(item);
            return itemDto;
        }

        public IQueryable<SportmanDTO> GetAll()
        {
            var items = UnitOfWork.Get<Sportman>().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Sportman>, IEnumerable<SportmanDTO>>(items);
            return itemDtos.AsQueryable();
        }
    }
}

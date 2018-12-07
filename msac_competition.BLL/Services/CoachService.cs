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
    public class CoachService : BaseService<CoachDTO, int>, ICoachService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public CoachService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public CoachDTO Get(int id)
        {
            var item = UnitOfWork.Get<Coach>().FirstOrDefault(a => a.Id == id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coach, CoachDTO>()).CreateMapper();
            var itemDto = mapper.Map<Coach, CoachDTO>(item);
            return itemDto;
        }

        public IQueryable<CoachDTO> GetAll()
        {
            var items = UnitOfWork.Get<Coach>().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Coach>, IEnumerable<CoachDTO>>(items);
            return itemDtos.AsQueryable();
        }
    }
}

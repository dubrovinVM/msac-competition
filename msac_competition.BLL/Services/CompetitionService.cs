using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;

namespace msac_competition.BLL.Services
{
    public class CompetitionService: BaseService<CompetitionDTO, int>, ICompetitionService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public CompetitionService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public CompetitionDTO Get(int id)
        {
            var item = UnitOfWork.Get<Competition>().FirstOrDefault(a=>a.Id==id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Competition, CompetitionDTO>()).CreateMapper();
            var itemDto = mapper.Map<Competition, CompetitionDTO>(item);
            return itemDto;
        }

        public IQueryable<CompetitionDTO> GetAll()
        {
            var items = UnitOfWork.Get<Competition>().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Competition>, IEnumerable<CompetitionDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public Task<CompetitionDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CompetitionDTO Create(CompetitionDTO newItem, bool shouldBeCommited = false)
        {
            throw new NotImplementedException();
        }

        public void Update(CompetitionDTO item, bool shouldBeCommited = false)
        {
            throw new NotImplementedException();
        }

        

        public void Remove(CompetitionDTO removeItem, bool shouldBeCommited = false)
        {
            throw new NotImplementedException();
        }
    }
}

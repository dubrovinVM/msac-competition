//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using msac_competition.BLL.DTO;
//using msac_competition.BLL.Interfaces;
//using msac_competition.DAL.Entities;
//using msac_competition.DAL.Interfaces;

//namespace msac_competition.BLL.Services
//{
//    public class FstService : BaseService<Fst, FstDTO, int>, IFstService
//    {
//        protected readonly IRepository UnitOfWork;

//        public FstService(IRepository unitOfWork) : base(unitOfWork)
//        {
//            UnitOfWork = unitOfWork;
//        }

//        public FstDTO Get(int id)
//        {
//            var item = UnitOfWork.Get<Fst>().FirstOrDefault(a => a.Id == id);
//            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Fst, FstDTO>()).CreateMapper();
//            var itemDto = mapper.Map<Fst, FstDTO>(item);
//            return itemDto;
//        }

//        public IQueryable<FstDTO> GetAll()
//        {
//            var items = UnitOfWork.Get<Fst>().ToList();
//            var itemDtos = Mapper.Map<IEnumerable<Fst>, IEnumerable<FstDTO>>(items);
//            return itemDtos.AsQueryable();
//        }

//        public Task<FstDTO> GetAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public FstDTO Create(TEntity newItem, bool shouldBeCommited = false)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(FstDTO item, bool shouldBeCommited = false)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(FstDTO removeItem, bool shouldBeCommited = false)
//        {
//            throw new NotImplementedException();
//        }
        
//    }
//}

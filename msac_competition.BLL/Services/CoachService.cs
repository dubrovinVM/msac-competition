using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.BusinessModels;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Entities;
using msac_competition.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace msac_competition.BLL.Services
{
    public class CoachService : BaseService<CoachDTO, int>, ICoachService
    {
        public string CoachFolder { get; set; }

        //protected readonly IUnitOfWork UnitOfWork_internal;

        public CoachService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //UnitOfWork_internal = UnitOfWork;
        }

        public CoachDTO GetAsNoTrck(int id)
        {
            var item = UnitOfWork.GetAsNoTr<Coach>().FirstOrDefault(a => a.Id == id);
            var itemDto = Mapper.Map<Coach, CoachDTO>(item);
            return itemDto;
        }

        public override CoachDTO Get(int id)
        {
            var item = UnitOfWork.Get<Coach>().AsNoTracking().FirstOrDefault(a => a.Id == id);
            var itemDto = Mapper.Map<Coach, CoachDTO>(item);
            return itemDto;
        }

        public override IQueryable<CoachDTO> GetAll()
        {
            var items = UnitOfWork.Get<Coach>().ToList();
            var itemDtos = Mapper.Map<IEnumerable<Coach>, IEnumerable<CoachDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task CreateAsync(CoachDTO coachDTO, bool commit)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            await UnitOfWork.AddAsync(coach);
            if (commit)
            {
                await UnitOfWork.CommitAsync();
            }
        }

        public void Delete(CoachDTO coachDTO, bool shouldBeCommited = false)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            RemoveAvatar(coach.Avatar, CoachFolder);
            UnitOfWork.Remove(coach);
            if (shouldBeCommited)
            {
                UnitOfWork.Commit();
            }
        }

        public async Task Update(CoachDTO coachDTO, bool commit)
        {
            var coach = Mapper.Map<CoachDTO, Coach>(coachDTO);
            UnitOfWork.Update(coach);
            if (commit)
            {
                await UnitOfWork.CommitAsync();
            }
        }

    }
}

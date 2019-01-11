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
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace msac_competition.BLL.Services
{
    public class FstService : BaseService<Fst, int>, IFstService
    {
        IUnitOfWork __repository { get; set; }
        private ITeamService _teamService;

        public FstService(IUnitOfWork repository, ITeamService teamService)
        {
            __repository = repository;
            _teamService = teamService;
        }

        public async Task<FstDTO> GetById(int id)
        {
            var item = await __repository.Fsts.GetById(id);
            var itemDto = Mapper.Map<Fst, FstDTO>(item);
            return itemDto;
        }

        public async Task<FstDTO> GetByIdAsNoTrack(int id)
        {
            var item = await __repository.Fsts.GetByIdAsNoTrack(id);
            var itemDto = Mapper.Map<Fst, FstDTO>(item);
            return itemDto;
        }

        public async Task<FstDTO> Create(FstDTO FstDto, IFormFile ava, bool shouldBeCommited = false)
        {
            var Fst = Mapper.Map<FstDTO, Fst>(FstDto);
            var newItem = await __repository.Fsts.Create(Fst);
            await __repository.CommitAsync();
            return Mapper.Map<Fst, FstDTO>(newItem);
        }

        public IList<FstDTO> GetAll()
        {
            var items = __repository.Fsts.GetAll().Include(a => a.Teams);
            var itemDtos = Mapper.Map<IEnumerable<Fst>, IEnumerable<FstDTO>>(items);
            return itemDtos.ToList();
        }

        public async Task Delete(FstDTO FstDTO, bool shouldBeCommited = false)
        {
            var Fst = Mapper.Map<FstDTO, Fst>(FstDTO);
            await _teamService.SetTeamFstToNull(FstDTO.Id);
            await __repository.Fsts.Delete(FstDTO.Id);
            if (shouldBeCommited)
            {
                __repository.Commit();
            }
        }

        public async Task UpdateFst(FstDTO FstDTO, IFormFile ava, bool commit)
        {
            var Fst = Mapper.Map<FstDTO, Fst>(FstDTO);
            __repository.Fsts.Update(Fst);
            if (commit)
            {
                await __repository.CommitAsync();
            }
        }

        public virtual async Task CommitAsync(bool shouldBeCommited = false)
        {
            if (shouldBeCommited)
            {
                await __repository.CommitAsync();
            }
        }

        public override void Dispose()
        {
            __repository.Dispose();
        }

    }
}

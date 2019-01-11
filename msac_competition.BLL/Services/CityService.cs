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
using msac_competition.DAL.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace msac_competition.BLL.Services
{
    public class CityService : BaseService<City, int>, ICityService
    {
        IUnitOfWork __repository { get; set; }

        public CityService(IUnitOfWork repository)
        {
            __repository = repository;
        }

        public IQueryable<CityDTO> GetAll()
        {
            var items = __repository.Cities.GetAll().ToList();
            var itemDtos = Mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task Update(CityDTO coachDto, bool shouldBeCommited = false)
        {
            await SetCityCoachToNull(coachDto.Id);
            var City = Mapper.Map<CityDTO, City>(coachDto);
            __repository.Cities.Update(City);
            if (shouldBeCommited)
            {
                await __repository.CommitAsync();
            }
        }

        public IQueryable<CityDTO> GetAllAsNoTrack()
        {
            var items = __repository.Cities.GetAll().ToList();
            var itemDtos = Mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(items);
            return itemDtos.AsQueryable();
        }

        public async Task<CityDTO> GetById(int id)
        {
            var item = await __repository.Cities.GetById(id);
            var itemDto = Mapper.Map<City, CityDTO>(item);
            return itemDto;
        }

        public async Task<CityDTO> GetByIdAsNoTrack(int id)
        {
            var item = await __repository.Cities.GetByIdAsNoTrack(id);
            var itemDto = Mapper.Map<City, CityDTO>(item);
            return itemDto;
        }

        public IEnumerable<SelectListItem> GetCitysSelectList()
        {
            List<SelectListItem> cities = GetAllAsNoTrack()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();
            var CitysNullable = new SelectListItem()
            {
                Value = null,
                Text = "--- оберіть значення ---"
            };
            cities.Insert(0, CitysNullable);
            return new SelectList(cities, "Value", "Text");
        }

        public async Task SetCityCoachToNull(int? coachId)
        {
            //if (coachId == null) return;
            //var oldCityDto = GetAll().FirstOrDefault(a => a.CoachId == coachId);
            //if (oldCityDto != null)
            //{
            //    oldCityDto.CoachId = null;
            //    await Update(oldCityDto);
            //}
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

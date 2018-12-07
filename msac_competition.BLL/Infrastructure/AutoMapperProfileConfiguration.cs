using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.DAL.Entities;

namespace msac_competition.BLL.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration(): this("MyProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName): base(profileName)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Competition, CompetitionDTO>()
                    .ForMember(m => m.Name, opt => opt.MapFrom(a => a.Name))
                    .ForMember(m => m.Teams, opt => opt.MapFrom(x => x.TeamCompetitions.Select(c=>c.Team).ToList()));

                cfg.CreateMap<Team, TeamDTO>()
                    .ForMember(m => m.Name, opt => opt.MapFrom(a => a.Name))
                    .ForMember(m => m.Competitions, opt => opt.MapFrom(a => a.TeamCompetitions.Select(c => c.Competition).ToList()));

                cfg.CreateMap<Fst, FstDTO>();

                cfg.CreateMap<City, CityDTO>();

                CreateMap<Coach, CoachDTO>();

                cfg.CreateMap<Sportman, SportmanDTO>().
                    ForMember(m => m.CoachId, opt => opt.MapFrom(a => a.CoachId)).
                    ForMember(m => m.TeamId, opt => opt.MapFrom(a => a.TeamId));
            });
        }

        
    }
}

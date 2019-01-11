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
        public AutoMapperProfileConfiguration(): this("DALProfile")
        {
        }

        public AutoMapperProfileConfiguration(string profileName): base(profileName)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Competition, CompetitionDTO>()
                    .ForMember(m => m.Teams, opt => opt.MapFrom(x => x.TeamCompetitions.Select(c=>c.Team).ToList()));

                cfg.CreateMap<Team, TeamDTO>()
                    .ForMember(m => m.Competitions, opt => opt.MapFrom(a => a.TeamCompetitions.Select(c => c.Competition).ToList()));

                cfg.CreateMap<TeamDTO, Team>();

                cfg.CreateMap<Fst, FstDTO>();
                cfg.CreateMap<FstDTO, Fst>();

                cfg.CreateMap<City, CityDTO>();

                cfg.CreateMap<Coach, CoachDTO>()
                .ForMember(dto => dto.Team, opt => opt.MapFrom(x => x.Team))
                .ForMember(dto => dto.City, opt => opt.MapFrom(x => x.City));
                    
                cfg.CreateMap<CoachDTO, Coach>()
                    .ForMember(dto => dto.Team, opt => opt.MapFrom(x => x.Team));

                cfg.CreateMap<SportmanDTO, Sportman>();
                cfg.CreateMap<Sportman, SportmanDTO>().
                    ForMember(m => m.CoachId, opt => opt.MapFrom(a => a.CoachId)).
                    ForMember(m => m.TeamId, opt => opt.MapFrom(a => a.TeamId)).
                    ForMember(m => m.Competitions, opt => opt.MapFrom(a => a.SportmanCompetitions.Select(c => c.Competition).ToList()));
            });
        }

        
    }
}

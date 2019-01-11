using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.Models;

namespace msac_competition.Classes
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CompetitionDTO, CompetitionViewModel>()
                //.ForMember(dto => dto.Teams, opt => opt.MapFrom(x => x.Teams.Select(y => y.Competitions).ToList()));
                .ForMember(dto => dto.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(dto => dto.Teams, opt => opt.MapFrom(x => x.Teams));

            CreateMap<TeamDTO, TeamViewModel>();

            CreateMap<CityDTO, CityViewModel>();

            CreateMap<FstDTO, FstViewModel>()
                .ForMember(dto => dto.Teams, opt => opt.MapFrom(x => x.Teams));

            CreateMap<CoachDTO, CoachViewModel>();

            CreateMap<CoachDTO, CoachEditViewModel>()
                .ForMember(dto => dto.SelectedTeam, opt => opt.Ignore());

            CreateMap<CoachEditViewModel, CoachDTO>();


            CreateMap<SportmanDTO, SportmanViewModel>()
                .ForMember(dto => dto.CoachPib, opt => opt.MapFrom(x => (x.Coach.Surname +" "+ x.Coach.Name.Substring(0,1) +"."+ x.Coach.Lastname.Substring(0, 1) + ".") ));

            //CreateMap<CityDTO, CityViewModel>()
            //    .ForMember(dto => dto.SelectedTeam, opt => opt.Ignore());

        }
    }
}

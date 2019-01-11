//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using AutoMapper;
//using msac_competition.BLL.DTO;
//using msac_competition.BLL.Infrastructure;
//using msac_competition.BLL.Interfaces;
//using msac_competition.Controllers;
//using msac_competition.DAL.Interfaces;
//using msac_competition.Models;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Xunit;
//using AutoMapper;
//using msac_competition.Classes;

//namespace msac_competition.Tests
//{
//    public class HomeControllerTests
//    {
//        private readonly Mock<ICompetitionService> _competitionServicMock;
//        private readonly Mock<ITeamService> _teamServicMock;
//        private readonly IMapper _mapperMock;

//        public HomeControllerTests()
//        {
//            _competitionServicMock = new Mock<ICompetitionService>();
//            _competitionServicMock.Setup(repo => repo.GetAll()).Returns(GetTestCompetitions().AsQueryable);

//            _teamServicMock = new Mock<ITeamService>();

//            var mockMapper = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(new DomainProfile());
//            });
//            _mapperMock = mockMapper.CreateMapper();
//        }

//        [Fact]
//        public void IndexReturnsViewWithData()
//        {
//            try
//            {
//                // Arrange
//                HomeController controller = new HomeController(_teamServicMock.Object, _competitionServicMock.Object, _mapperMock);
//                var result = controller.Index();
//                // Assert
//                Assert.NotNull(result);

//                var viewResult = Assert.IsType<ViewResult>(result);
//                var model = Assert.IsAssignableFrom<IEnumerable<CompetitionViewModel>>(viewResult.ViewData.Model);
//                Assert.Equal(3, model.Count());
//                var resViewName = (ViewResult)result;
//                Assert.Equal("Index", resViewName?.ViewName);
//            }
//            catch (Exception ex)
//            {
//                //Assert
//                Assert.False(false, ex.Message);
//            }
//        }

//        private IList<CompetitionDTO> GetTestCompetitions()
//        {
//            var competitions = new List<CompetitionDTO>
//            {
//                new CompetitionDTO { Id=1, Name="World Champ", Teams = new List<TeamDTO>(){ new TeamDTO(){Id = 1, Name = "Kiev"}}},
//                new CompetitionDTO { Id=2, Name="Ukraine champ", Teams = new List<TeamDTO>(){ new TeamDTO(){Id = 2, Name = "Kharkiv"}}},
//                new CompetitionDTO { Id=3, Name="Ukraine cup" , Teams = new List<TeamDTO>(){ new TeamDTO(){Id = 3, Name = "Zhytomyr"}}}
//            };
//            return competitions;
//        }

//        private IList<CompetitionViewModel> GetTestCompetitionViewModels()
//        {
//            var competitions = new List<CompetitionViewModel>
//            {
//                new CompetitionViewModel { Id=1, Name="World Champ", Teams = new List<TeamViewModel>(){ new TeamViewModel(){Id = 1, Name = "Kiev"}}},
//                new CompetitionViewModel { Id=2, Name="Ukraine champ", Teams = new List<TeamViewModel>(){ new TeamViewModel(){Id = 2, Name = "Kharkiv"}}},
//                new CompetitionViewModel { Id=3, Name="Ukraine cup" , Teams = new List<TeamViewModel>(){ new TeamViewModel(){Id = 3, Name = "Zhytomyr"}}}
//            };
//            return competitions;
//        }

//        private IList<TeamViewModel> GetTestTeamsViewModels()
//        {
//            var teams = new List<TeamViewModel>
//            {
//                new TeamViewModel { Id=1, Name="World Champ", Competitions = new List<CompetitionViewModel>(){ new CompetitionViewModel(){Id = 1, Name = "World Champ" } }},
//                new TeamViewModel { Id=2, Name="Ukraine champ", Competitions = new List<CompetitionViewModel>(){ new CompetitionViewModel(){Id = 2, Name = "Ukraine champ" } }},
//                new TeamViewModel { Id=3, Name="Ukraine cup" , Competitions = new List<CompetitionViewModel>(){ new CompetitionViewModel(){Id = 3, Name = "Ukraine cup" } }}
//            };
//            return teams;
//        }
//    }
//}

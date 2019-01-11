using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.Classes;
using msac_competition.Controllers;
using msac_competition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace msac_competition.Tests
{
    public class CoachControllerTest
    {
        private readonly Mock<ICoachService> _coachService;
        private readonly Mock<ITeamService> _teamServicMock;
        private readonly Mock<ICityService> _cityServicMock;
        private readonly Mock<IBaseService<CoachDTO,int>> _baseServicMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IConfiguration> _configuration;
        private string coachFolder { get; set; }


        public CoachControllerTest()
        {
            var coaches = GetTestCoaches();
            var teams = GetTestTeams();

            _baseServicMock = new Mock<IBaseService<CoachDTO, int>>();
            _baseServicMock.Setup(repo => repo.SaveAvatarAsync(new FormFile(null, 0, 0, string.Empty, string.Empty), "Ivanov", "coach")).ReturnsAsync("avatar.png");

            _coachService = new Mock<ICoachService>();
            _coachService.Setup(repo => repo.GetAll()).Returns(GetTestCoaches());
            _coachService.Setup(repo => repo.Create(It.IsAny<CoachDTO>(), null, It.IsAny<bool>())).ReturnsAsync(coaches.First);
            _coachService.Setup(repo => repo.Create(It.IsAny<CoachDTO>(), It.IsAny<IFormFile>(), It.IsAny<bool>())).ReturnsAsync(coaches.First);
            _coachService.Setup(repo => repo.Delete(It.IsAny<CoachDTO>(), It.IsAny<bool>())).Verifiable();
            //_coachService.Setup(repo => repo.Commit(false)).Verifiable();
            //_coachService.Setup(repo => repo.CommitAsync(false)).Returns(Task.CompletedTask).Verifiable();
            _coachService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(coaches.First);
            _coachService.Setup(repo => repo.UpdateCoach(It.IsAny<CoachDTO>(), It.IsAny<IFormFile>(), It.IsAny<bool>())).Verifiable();
            _coachService.Setup(repo => repo.GetByIdAsNoTrack(It.IsAny<int>())).ReturnsAsync(coaches.First);


            _teamServicMock = new Mock<ITeamService>();
            _teamServicMock.Setup(repo => repo.GetAll()).Returns(GetTestTeams().AsQueryable);
            _teamServicMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(teams.First);
            _teamServicMock.Setup(repo => repo.Update(It.IsAny<TeamDTO>(), It.IsAny<bool>())).Returns(Task.CompletedTask);
            _teamServicMock.Setup(repo => repo.SetTeamCoachToNull(It.IsAny<int?>())).Returns(Task.CompletedTask);

            _configuration = new Mock<IConfiguration>();
            this._configuration.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);

            _cityServicMock = new Mock<ICityService>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainProfile());
            });
            _mapperMock = mockMapper.CreateMapper();
        }

        [Fact]
        public void IndexReturnsViewWithData()
        {
            try
            {
               // Arrange
               CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
                var result = controller.Index();
                //Assert
                Assert.NotNull(result);
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<CoachViewModel>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
                var resViewName = (ViewResult)result;
                Assert.Equal("Index", resViewName?.ViewName);
            }
            catch (Exception ex)
            {
               // Assert
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public async Task Create_ReturnsErrorView_WhenModelIsNotValid()
        {
            //Arrange 
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
            controller.ModelState.AddModelError("Error", "Some error");
            //Act
            var result = await controller.Create(new CoachViewModel(), ava: null);
            var resViewName = (ViewResult)result;
            var errorKey = ((ViewResult)result).ViewData.Keys.First();
            var errorValue = ((ViewResult)result).ViewData.Values.First();
           // Assert
            Assert.Equal("Error", resViewName?.ViewName);
            Assert.Equal("Some error", errorValue);
            Assert.Equal("Error", errorKey);
        }

        [Fact]
        public async Task Create_ReturnsError_GivenNullModel()
        {
            // Arrange
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
            // Act
            var result = await controller.Create(coach: null, ava: null);
            var resViewName = (ViewResult)result;
            // Assert
            Assert.Equal("Error", resViewName?.ViewName);
        }

        [Fact]
        public async Task Create_ReturnsIndexView_GivenNormalModel()
        {
            //Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
            var item = GetTestCoach();
            //Act
            var result = await controller.Create(item, ava: null);
            var resViewName = (RedirectToActionResult)result;
            //Assert
            _teamServicMock.Verify(m => m.SetTeamCoachToNull(It.IsAny<int?>()), Times.AtLeast(1));
            _teamServicMock.Verify(m => m.Update(It.IsAny<TeamDTO>(), It.IsAny<bool>()), Times.Once);
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public async Task Create_ReturnsModel_GivenNormalAvatar()
        {
            //Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
            var item = GetTestCoach();
            //Act
            var result = await controller.Create(item, new FormFile(null, 0, 0, string.Empty, string.Empty));
            var resViewName = (RedirectToActionResult)result;
            //Assert
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public async Task Create_ReturnsModel_GivenNullAvatar()
        {
            //Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
            var item = GetTestCoach();
            //Act
            var result = await controller.Create(item, null);
            var resViewName = (RedirectToActionResult)result;
            //Assert
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public void Remove_NullIdPassed_ReturnsNotFoundResponse()
        {
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["Error"] = @Resources.Exceptions.notCorrectRequest;
            //Arrange
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object)
            {
                TempData = tempData
            }; 
            //Act
            var result = controller.Delete(null);
            //Assert
            var resViewName = (RedirectToActionResult)result.Result;
            //Assert
            Assert.Equal("Error", resViewName.ActionName);
            Assert.Equal("Home", resViewName.ControllerName);
        }

        [Fact]
        public void Remove_NotExistObject_ReturnsNotFoundResponse()
        {
           // Arrange
           CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
           // Act
           var badResponse = controller.Delete(6).Result;
           // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistObject_RemoveMethodVerified()
        {
            //Arrange
           CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
           // Act
           var result = controller.Delete(1).Result;
            var resViewName = (RedirectToActionResult)result;
           // Assert
            _coachService.Verify(m => m.Delete(It.IsAny<CoachDTO>(), false), Times.Once);
            Assert.Equal("Index", resViewName?.ActionName);
        }

        //[Fact]
        //public async Task Edit_ReturnsErrorView_WhenIdNull()
        //{
        //    //Arrange & Act
        //    CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
        //    controller.ModelState.AddModelError("Error", "Some error");
        //    //Act
        //   var badResponse = controller.Edit(id: null).ExecuteResultAsync();
        //    //Assert
        //    Assert.IsType<NotFoundResult>(badResponse);
        //}

        //[Fact]
        //public async Task Edit_ReturnsErrorView_WhenIdNotInDb()
        //{
        //   // Arrange & Act
        //    CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
        //    controller.ModelState.AddModelError("Error", "Some error");
        //    //Act
        //   var badResponse = controller.Edit(id: 6).Result;
        //    //Assert
        //    Assert.IsType<NotFoundResult>(badResponse);
        //}

        //[Fact]
        //public void Edit_ExistObject_EditMethodVerified()
        //{
        //    Arrange
        //   CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object, _cityServicMock.Object);
        //    Act
        //   var result = controller.Edit(2).Result;
        //    var resViewName = (ViewResult)result;
        //    Assert
        //    _coachService.Verify(m => m.Update(It.IsAny<CoachDTO>(), It.IsAny<bool>()), Times.Once);
        //    Assert.Equal("Edit", resViewName?.ViewName);
        //    Assert.IsNotType<NotFoundResult>(result);

        //}


        private IList<CoachDTO> GetTestCoaches()
        {
            var coaches = new List<CoachDTO>
            {
                new CoachDTO { Id=1, Name="Viktor", Team = new TeamDTO(){ Id = 1, Name = "Oleksadriya"}},
                new CoachDTO { Id=2, Name="Artur", Team = new TeamDTO(){ Id = 2, Name = "Oleksadriya2"}}
            };
            return coaches;
        }

        private IList<TeamDTO> GetTestTeams()
        {
            var teams = new List<TeamDTO>
            {
                new TeamDTO() { Id=1, Name="Kiev", CoachId = 1},
                new TeamDTO { Id=2, Name="Kharkiv",  CoachId = 2}
            };
            return teams;
        }

        private CoachViewModel GetTestCoach()
        {
            var coach = new CoachViewModel { Name = "Alex", Lastname = "Olegovich", Surname = "Porada", TeamId = 1};
            return coach;
        }

        private CoachDTO GetTestCoachDto()
        {
            var coach = new CoachDTO { Name = "Alex", Lastname = "Olegovich", Surname = "Porada" };
            return coach;
        }
    }
}

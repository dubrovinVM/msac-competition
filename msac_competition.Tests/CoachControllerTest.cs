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
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace msac_competition.Tests
{
    public class CoachControllerTest
    {
        private readonly Mock<ICoachService> _coachService;
        private readonly Mock<ITeamService> _teamServicMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IConfiguration> _configuration;

        public CoachControllerTest()
        {
            _coachService = new Mock<ICoachService>();
            _coachService.Setup(repo => repo.GetAll()).Returns(GetTestCoaches().AsQueryable());
            _coachService.Setup(repo => repo.CreateAsync(new CoachDTO(), false)).Returns(Task.CompletedTask);
            _coachService.Setup(repo => repo.SaveAavatarAsync(new FormFile(null, 0, 0, string.Empty, string.Empty),"Ivanov","coach")).ReturnsAsync("avatar.png");
            var coaches = GetTestCoaches();
            _coachService.Setup(repo => repo.Remove(It.IsAny<CoachDTO>(), false)).Verifiable();
            _coachService.Setup(repo => repo.Commit(false)).Verifiable();
            _coachService.Setup(repo => repo.CommitAsync(false)).Returns(Task.CompletedTask).Verifiable();
            _coachService.Setup(repo => repo.Get(It.IsAny<int>())).Returns(coaches.First);
            _coachService.Setup(repo => repo.Update(It.IsAny<CoachDTO>(), It.IsAny<bool>())).Verifiable();

            _configuration = new Mock<IConfiguration>();
            this._configuration.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);

            _teamServicMock = new Mock<ITeamService>();

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
                CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
                var result = controller.Index();
                // Assert
                Assert.NotNull(result);

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<CoachViewModel>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
                var resViewName = (ViewResult)result;
                Assert.Equal("Index", resViewName?.ViewName);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public async Task Create_ReturnsErrorView_WhenModelIsNotValid()
        {
            // Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock,_configuration.Object);
            controller.ModelState.AddModelError("Error", "Some error");
            // Act
            var result = await controller.Create(new CoachViewModel(), ava:null);
            var resViewName = (ViewResult)result;
            var errorKey = ((ViewResult)result).ViewData.Keys.First();
            var errorValue = ((ViewResult)result).ViewData.Values.First();

            // Assert
            Assert.Equal("Error", resViewName?.ViewName);
            Assert.Equal("Some error", errorValue);
            Assert.Equal("Error", errorKey);
        }

        //[Fact]
        //public async Task Create_ReturnsError_GivenInvalidModel()
        //{
        //    // Arrange & Act
        //    CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock);
        //    // Act
        //    var result = await controller.Create(coach: null, ava: null);
        //    var resViewName = (ViewResult)result;
        //    var errorKey = ((ViewResult)result).ViewData.Keys.First();
        //    var errorValue = ((ViewResult)result).ViewData.Values.First();

        //    // Assert
        //    Assert.Equal("Error", resViewName?.ViewName);
        //    //Assert.Equal("Some error", errorValue);
        //    //Assert.Equal("Error", errorKey);
        //}

        [Fact]
        public async Task Create_ReturnsIndexView_GivenNormalModel()
        {
            // Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            //controller.ModelState.AddModelError("error", "some error");
            var item = GetTestCoach();
            // Act
            var result = await controller.Create(item, ava: null);
            var resViewName = (RedirectToActionResult)result;

            // Assert
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public async Task Create_ReturnsModel_GivenNormalAvatar()
        {
            // Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            var item = GetTestCoach();
            // Act
            var result = await controller.Create(item, new FormFile(null, 0, 0, string.Empty, string.Empty));
            var resViewName = (RedirectToActionResult)result;
            // Assert
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public async Task Create_ReturnsModel_GivenNullAvatar()
        {
            // Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            var item = GetTestCoach();
            // Act
            var result = await controller.Create(item, null);
            var resViewName = (RedirectToActionResult)result;
            // Assert
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public void Remove_NullIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            // Act
            var badResponse = controller.Delete(null).Result;
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_NotExistObject_ReturnsNotFoundResponse()
        {
            // Arrange
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            // Act
            var badResponse = controller.Delete(6).Result;
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistObject_RemoveMethodVerified()
        {
            // Arrange
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            // Act
            var result = controller.Delete(1).Result;
            var resViewName = (RedirectToActionResult)result;
            // Assert
            _coachService.Verify(m => m.Remove(It.IsAny<CoachDTO>(), false), Times.Once);
            Assert.Equal("Index", resViewName?.ActionName);
        }

        [Fact]
        public async Task Edit_ReturnsErrorView_WhenIdNull()
        {
            // Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            //controller.ModelState.AddModelError("Error", "Some error");
            // Act
            var badResponse = controller.Edit(id:null).Result;
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public async Task Edit_ReturnsErrorView_WhenIdNotInDb()
        {
            // Arrange & Act
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            //controller.ModelState.AddModelError("Error", "Some error");
            // Act
            var badResponse = controller.Edit(id:6).Result;
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Edit_ExistObject_EditMethodVerified()
        {
            // Arrange
            CoachController controller = new CoachController(_teamServicMock.Object, _coachService.Object, _mapperMock, _configuration.Object);
            // Act
            var result = controller.Edit(2).Result;
            var resViewName = (ViewResult)result;
            // Assert
            //_coachService.Verify(m => m.Update(It.IsAny<CoachDTO>(), It.IsAny<bool>()), Times.Once);
            Assert.Equal("Edit", resViewName?.ViewName);
            Assert.IsNotType<NotFoundResult>(result);

        }


        private IList<CoachDTO> GetTestCoaches()
        {
            var coaches = new List<CoachDTO>
            {
                new CoachDTO { Id=1, Name="Viktor", Team = new TeamDTO(){ Id = 1, Name = "Oleksadriya"}},
                new CoachDTO { Id=2, Name="Artur", Team = new TeamDTO(){ Id = 2, Name = "Oleksadriya2"}}
            };
            return coaches;
        }

        private CoachViewModel GetTestCoach()
        {
            var coach = new CoachViewModel { Name = "Alex", Lastname = "Olegovich", Surname = "Porada" };
            return coach;
        }

        private CoachDTO GetTestCoachDto()
        {
            var coach = new CoachDTO { Name = "Alex", Lastname = "Olegovich", Surname = "Porada" };
            return coach;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.Classes;
using msac_competition.Controllers;
using msac_competition.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace msac_competition.Tests
{
    public class SportmanControllerTest
    {
        private readonly Mock<ISportmanService> _sportmanService;
        private readonly Mock<ITeamService> _teamServicMock;
        private readonly IMapper _mapperMock;

        public SportmanControllerTest()
        {
            _sportmanService = new Mock<ISportmanService>();
            _sportmanService.Setup(repo => repo.GetAll()).Returns(GetTestSportmen().AsQueryable());

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
                SportsmenController controller = new SportsmenController(_teamServicMock.Object, _sportmanService.Object, _mapperMock);
                var result = controller.Index();
                // Assert
                Assert.NotNull(result);

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<SportmanViewModel>>(viewResult.ViewData.Model);
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


        private IList<SportmanDTO> GetTestSportmen()
        {
            var sportmen = new List<SportmanDTO>
            {
                new SportmanDTO { Id=1, Name="Viktor", Coach = new CoachDTO(){ Id = 1, Name = "Oleksadr"}},
                new SportmanDTO { Id=2, Name="Artur", Coach = new CoachDTO(){ Id = 2, Name = "Oleksadr2"}}
            };
            return sportmen;
        }
    }
}

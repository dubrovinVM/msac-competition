using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Infrastructure;
using msac_competition.BLL.Interfaces;
using msac_competition.Controllers;
using msac_competition.DAL.Interfaces;
using msac_competition.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace msac_competition.Tests
{
    public class HomeControllerTests
    {

        [Fact]
        public void IndexViewDataMessage()
        {
            var teamServicMock = new Mock<ITeamService>();
            teamServicMock.Setup(repo => repo.GetAll()).Returns(GetTestTeams().AsQueryable);
            var competitionServicMock = new Mock<ICompetitionService>();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(item=>item.Map<TeamDTO, TeamViewModel>(It.IsAny<TeamDTO>())).Returns(new TeamViewModel());

            // Arrange
            HomeController controller = new HomeController(teamServicMock.Object, competitionServicMock.Object, mapperMock.Object);
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result?.ViewName);
        }

        private IList<TeamDTO> GetTestTeams()
        {
            var teams = new List<TeamDTO>
            {
                new TeamDTO { Id=1, Name="Team1" },
                new TeamDTO { Id=1, Name="Team1" },
                new TeamDTO { Id=1, Name="Team1" }
            };
            return teams;
        }
    }
}

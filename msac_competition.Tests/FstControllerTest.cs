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
    public class FstControllerTest
    {
        private readonly Mock<IFstService> _fstServicMock;
        private readonly Mock<ITeamService> _teamServicMock;
        private readonly IMapper _mapperMock;

        public FstControllerTest()
        {
            _fstServicMock = new Mock<IFstService>();
            _fstServicMock.Setup(repo => repo.GetAll()).Returns(GetTestFsts().AsQueryable());

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
                FstController controller = new FstController(_teamServicMock.Object, _fstServicMock.Object, _mapperMock);
                var result = controller.Index();
                // Assert
                Assert.NotNull(result);

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<CompetitionViewModel>>(viewResult.ViewData.Model);
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


        private IList<FstDTO> GetTestFsts()
        {
            var fsts = new List<FstDTO>
            {
                new FstDTO { Id=1, Name="Dinamo", Teams = new List<TeamDTO>(){ new TeamDTO(){Id = 1, Name = "Kiev"}}},
                new FstDTO { Id=2, Name="ZSU", Teams = new List<TeamDTO>(){ new TeamDTO(){Id = 2, Name = "Kharkiv"}}}
            };
            return fsts;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.Controllers;
using msac_competition.DAL.Interfaces;
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
            var mock = new Mock<IRepository<T>>();
            mock.Setup(repo => repo.GetAll()).Returns();
            // Arrange
            HomeController controller = new HomeController(mock.Object, mock.Object);
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
            Assert.NotNull(result);
            Assert.Equal("Index", result?.ViewName);
        }
    }
}

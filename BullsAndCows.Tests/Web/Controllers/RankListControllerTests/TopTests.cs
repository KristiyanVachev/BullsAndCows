using BullsAndCows.Models;
using BullsAndCows.Services.Contracts;
using BullsAndCows.Web.Controllers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace BullsAndCows.Tests.Web.Controllers.RankListControllerTests
{
    [TestFixture]
    public class TopTests
    {
        [Test]
        public void Top_ShouldReturnCorrectView()
        {
            //Arrange
            var rankListService = new Mock<IRankListService>();
            
            rankListService.Setup(x => x.GetTopPlayerGames(It.IsAny<int>())).Returns(new List<Game>());

            var controller = new RankListController(rankListService.Object);

            //Act
            controller.Top();

            //Assert
            controller.WithCallTo(x => x.Top()).ShouldRenderView("Top");
        }
    }
}

using BullsAndCows.Commom.Contracts;
using BullsAndCows.Data.Contracts;
using BullsAndCows.Factories;
using BullsAndCows.Models;
using BullsAndCows.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace BullsAndCows.Tests.Services.Utillities
{
    [TestFixture]
    public class GetBullsTests
    {
        [TestCase("1234", "1234", 4)]
        [TestCase("1234", "1264", 3)]
        [TestCase("1234", "4321", 0)]
        public void GetBulls_ShouldReturnCorrectly(string rightNumber, string guess, int bullsExpected)
        {
            //Arrange
            var mockGameRepository = new Mock<IRepository<Game>>();
            var mockGameFactory = new Mock<IGameFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utillity = new GameUtility(mockGameRepository.Object,
                mockGameFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object);

            //Act 
            var result = utillity.GetBulls(rightNumber, guess);

            //Assert
            Assert.AreEqual(bullsExpected, result);
        }

        //Some negative and edge case tests would be good as well.
    }
}

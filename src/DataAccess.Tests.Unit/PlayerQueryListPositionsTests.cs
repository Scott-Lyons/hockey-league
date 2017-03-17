using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Query;
using Domain;
using Moq;
using NUnit.Framework;

namespace DataAccess.Tests.Unit
{
    [TestFixture]
    public class PlayerQueryListPositionsTests
    {
        private List<PlayerPosition> _expectedPlayerPositions;
        private List<PlayerPosition> _actualPlayerPositions;

        private Mock<IHockeyLeagueContext> _mockHockeyLeagueContext;

        [SetUp]
        public void GivenAPlayerQuery_WhenListPositionsIsCalled()
        {
            _expectedPlayerPositions = new List<PlayerPosition>
            {
                new PlayerPosition
                {
                    Id = 0,
                    Idx = Guid.NewGuid(),
                    Name = "Paul Smith"
                },
                new PlayerPosition
                {
                    Id = 125,
                    Idx = Guid.NewGuid(),
                    Name = "Ringo Starr"
                }
            };
        
            _mockHockeyLeagueContext = new Mock<IHockeyLeagueContext>();
            _mockHockeyLeagueContext.Setup(context => context.GetEntities<PlayerPosition>()).Returns(_expectedPlayerPositions.AsQueryable);

            var playerQuery = new PlayerQuery(_mockHockeyLeagueContext.Object);
            _actualPlayerPositions = playerQuery.ListPositions().ToList();
        }

        [Test]
        public void ThenTheExpectedPositionsShouldBeReturned()
        {
            Assert.That(_expectedPlayerPositions, Is.EqualTo(_actualPlayerPositions));
        }
}
}

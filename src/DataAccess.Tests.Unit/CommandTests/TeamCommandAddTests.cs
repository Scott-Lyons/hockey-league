using System;
using DataAccess.Command;
using Domain;
using Moq;
using NUnit.Framework;

namespace DataAccess.Tests.Unit.CommandTests
{
    [TestFixture]
    public class TeamCommandAddTests
    {
        private Mock<IHockeyLeagueContext> _mockHockeyLeagueContext;
        private Team _expectedTeam;

        [SetUp]
        public void GivenATeamCommand_WhenAddIsCalled()
        {
            _mockHockeyLeagueContext = new Mock<IHockeyLeagueContext>();

            _expectedTeam = new Team
            {
                Idx = Guid.NewGuid(),
                Name = "Team A"
            };

            var teamCommand = new TeamCommand(_mockHockeyLeagueContext.Object);
            teamCommand.Add(_expectedTeam);
        }

        [Test]
        public void ThenTheContextShouldBeCalled()
        {
            _mockHockeyLeagueContext.Verify(context => context.InsertEntity(_expectedTeam), Times.Once);
        }
    }
}

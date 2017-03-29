using System.Web.Mvc;
using DataAccess.Command;
using Domain;
using Moq;
using NUnit.Framework;
using Web.Controllers;

namespace Web.Tests.Unit.TeamControllerTests
{
    [TestFixture]
    public class TeamControllerGetCreateTests
    {
        private Mock<ITeamCommand> _mockTeamCommand;

        private ActionResult _actualResult;

        [SetUp]
        public void GivenATeamController_WhenPostCreateIsCalled()
        {
            _mockTeamCommand = new Mock<ITeamCommand>();

            var teamController = new TeamController(_mockTeamCommand.Object);
            _actualResult = teamController.Create();
        }

        [Test]
        public void AddTeamShouldBeCalled()
        {
            _mockTeamCommand.Verify(
                command => command.Add(It.Is<Team>(team => team.Idx != null && team.Name == "Test")),
                Times.Once);
        }

        [Test]
        public void ThenTheViewResultShouldNotBeNull()
        {
            Assert.That(_actualResult, Is.Not.EqualTo(null));
        }
    }
}

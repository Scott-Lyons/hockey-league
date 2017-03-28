using System.Web.Mvc;
using DataAccess.Command;
using Domain;
using Moq;
using NUnit.Framework;
using Web.Controllers;
using Web.Models;

namespace Web.Tests.Unit.TeamControllerTests
{
    [TestFixture]
    public class TeamControllerPostCreateTests
    {
        private Mock<ITeamCommand> _mockTeamCommand;

        private TeamModel _teamModel;
        private RedirectToRouteResult _actualResult;

        [SetUp]
        public void GivenATeamController_WhenPostCreateIsCalled()
        {
            _teamModel = new TeamModel
            {
                Name = "Test"
            };

            _mockTeamCommand = new Mock<ITeamCommand>();

            var teamController = new TeamController(_mockTeamCommand.Object);
            _actualResult = teamController.Create(_teamModel) as RedirectToRouteResult;
        }

        [Test]
        public void AddTeamShouldBeCalled()
        {
            _mockTeamCommand.Verify(command => command.Add(It.Is<Team>(team => team.Name == "Test")), Times.Once);
        }

        [Test]
        public void ThenTheActionShouldRedirectToTheIndex()
        {
            Assert.That(_actualResult.RouteValues["action"], Is.EqualTo("Index"));
            Assert.That(_actualResult.RouteValues["controller"], Is.EqualTo("Home"));
        }
    }
}

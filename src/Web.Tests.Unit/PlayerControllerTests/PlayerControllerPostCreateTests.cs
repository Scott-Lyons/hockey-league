using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.Command;
using DataAccess.Query;
using Domain;
using Moq;
using NUnit.Framework;
using Web.Controllers;
using Web.Models;

namespace Web.Tests.Unit.PlayerControllerTests
{
    [TestFixture]
    public class PlayerControllerPostCreateTests
    {
        private Mock<IPlayerCommand> _mockPlayerCommand;
        private Mock<IPlayerQuery> _mockPlayerQuery;

        private RedirectToRouteResult _actualResult;

        [OneTimeSetUp]
        public void GivenAPlayerController_WhenGETCreateIsCalled()
        {
            var playerPositions = new List<PlayerPosition>
            {
                new PlayerPosition {Id = 1, Name = "Defence"},
                new PlayerPosition {Id = 2, Name = "Enforcer"}
            };

            _mockPlayerCommand = new Mock<IPlayerCommand>();
            _mockPlayerQuery = new Mock<IPlayerQuery>();
            _mockPlayerQuery.Setup(query => query.ListPositions()).Returns(playerPositions);
            
            var playerModel = new PlayerModel
            {
                Age = 19,
                Name = "John Smith",
                Position = new PlayerPositionModel {Idx = Guid.NewGuid(), Name = "ABC"},
                TimeInTeam = DateTime.Now
            };

            var playerController = new PlayerController(_mockPlayerCommand.Object, _mockPlayerQuery.Object);
            _actualResult = playerController.Create(playerModel) as RedirectToRouteResult;
        }

        [Test]
        public void ThenThePlayerCommandShouldBeCalled()
        {
            _mockPlayerCommand.Verify(command => command.Add(It.Is<Player>(player => player.Name == "John Smith")),
                Times.Once);
        }

        [Test]
        public void ThenTheActionShouldRedirectToTheIndex()
        {
            Assert.That(_actualResult.RouteValues["action"], Is.EqualTo("Index"));
            Assert.That(_actualResult.RouteValues["controller"], Is.EqualTo("Home"));
        }
    }
}
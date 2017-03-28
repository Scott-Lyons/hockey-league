using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.Command;
using DataAccess.Query;
using Domain;
using FluentAssertions;
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

        private Guid _defencePositionIdx;
        private Player _expectedPlayer;
        private Player _actualPlayer;

        [OneTimeSetUp]
        public void GivenAPlayerController_WhenGETCreateIsCalled()
        {
            _defencePositionIdx = Guid.NewGuid();

            var playerPositions = new List<PlayerPosition>
            {
                new PlayerPosition {Idx = _defencePositionIdx, Id = 1, Name = "Defence"},
                new PlayerPosition {Id = 2, Name = "Enforcer"}
            };

            _mockPlayerCommand = new Mock<IPlayerCommand>();
            _mockPlayerCommand.Setup(command => command.Add(It.IsAny<Player>())).Callback<Player>(player => _actualPlayer = player);

            _mockPlayerQuery = new Mock<IPlayerQuery>();
            _mockPlayerQuery.Setup(query => query.ListPositions()).Returns(playerPositions);
            
            var playerModel = new PlayerModel
            {
                Age = 19,
                Name = "John Smith",
                PositionIdx = _defencePositionIdx,
                TimeInTeam = DateTime.Today,
                DateOfBirth = DateTime.Today
            };

            _expectedPlayer = new Player
            {
                Name = "John Smith",
                DateOfBirth = DateTime.Now.Date,
                TimeInTeam = DateTime.Now.Date,
                PlayerPositionIdx = _defencePositionIdx
            };

            var playerController = new PlayerController(_mockPlayerCommand.Object, _mockPlayerQuery.Object);
            _actualResult = playerController.Create(playerModel) as RedirectToRouteResult;
        }

        [Test]
        public void ThenThePlayerCommandShouldBeCalled()
        {
            _mockPlayerCommand.Verify(
                command =>
                    command.Add(It.IsAny<Player>()),
                Times.Once);
        }

        [Test]
        public void ThenThePlayerCommandShouldBeCalledWithTheExpectedPlayer()
        {
            _actualPlayer.ShouldBeEquivalentTo(_expectedPlayer);
        }

        [Test]
        public void ThenTheActionShouldRedirectToTheIndex()
        {
            Assert.That(_actualResult.RouteValues["action"], Is.EqualTo("Index"));
            Assert.That(_actualResult.RouteValues["controller"], Is.EqualTo("Home"));
        }
    }
}
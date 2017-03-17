using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;
using Moq;
using DataAccess.Command;
using DataAccess.Query;
using Domain;
using FluentAssertions;
using Web.Models;

namespace Web.Tests.Unit.PlayerControllerTests
{
    [TestFixture]
    public class PlayerControllerGetCreateTests
    {
        private Mock<IPlayerCommand> _mockPlayerCommand;
        private Mock<IPlayerQuery> _mockPlayerQuery;
        private ViewResult _actionResult;
        private IEnumerable<PlayerPositionModel> _expectedPlayerPositions;

        [OneTimeSetUp]
        public void GivenAPlayerController_WhenGETCreateIsCalled()
        {
            var defencePositionIdx = Guid.NewGuid();
            var enforcerPositionIdx = Guid.NewGuid();

            _expectedPlayerPositions = new List<PlayerPositionModel>
            {
                new PlayerPositionModel {Idx = defencePositionIdx, Name = "Defence"},
                new PlayerPositionModel {Idx = enforcerPositionIdx, Name = "Enforcer"}
            };

            var playerPositions = new List<PlayerPosition>
            {
                new PlayerPosition {Idx = defencePositionIdx, Name = "Defence"},
                new PlayerPosition {Idx = enforcerPositionIdx, Name = "Enforcer"}
            };

            _mockPlayerCommand = new Mock<IPlayerCommand>();
            _mockPlayerQuery = new Mock<IPlayerQuery>();
            _mockPlayerQuery.Setup(query => query.ListPositions()).Returns(playerPositions);

            var playerController = new PlayerController(_mockPlayerCommand.Object, _mockPlayerQuery.Object);
            _actionResult = playerController.Create() as ViewResult;
        }

        [Test]
        public void ThenAViewContainingAListOfPositionsShouldBeReturned()
        {
            var actualModel = (PlayerModel) _actionResult.Model;

            actualModel.PlayerPositions.ShouldBeEquivalentTo(_expectedPlayerPositions);
        }
    }
}

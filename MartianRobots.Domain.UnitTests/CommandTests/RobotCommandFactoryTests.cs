using MartianRobots.Domain.Commands;
using MartianRobots.Domain.Entities;
using System;
using Xunit;

namespace MartianRobots.Domain.UnitTests.CommandTests
{
    public class RobotCommandFactoryTests
    {
        [Fact]
        public void GetCommand_WithLeftRotateKey_ReturnsValidRotateCommand()
        {
            // Arrange
            var commandFactory = new RobotCommandFactory();

            // Act
            var resultCommand = commandFactory.GetCommand('L');

            // Asset
            Assert.IsType<RotateCommand>(resultCommand);
            Assert.Equal(RotateDirections.Left, ((RotateCommand)resultCommand).RotateDirection);
        }

        [Fact]
        public void GetCommand_WithRightRotateKey_ReturnsValidRotateCommand()
        {
            // Arrange
            var commandFactory = new RobotCommandFactory();

            // Act
            var resultCommand = commandFactory.GetCommand('R');

            // Asset
            Assert.IsType<RotateCommand>(resultCommand);
            Assert.Equal(RotateDirections.Right, ((RotateCommand)resultCommand).RotateDirection);
        }

        [Fact]
        public void GetCommand_WithFrontMoveKey_ReturnsFrontMoveCommand()
        {
            // Arrange
            var commandFactory = new RobotCommandFactory();

            // Act
            var resultCommand = commandFactory.GetCommand('F');

            // Asset
            Assert.IsType<FrontMoveCommand>(resultCommand);
        }

        [Fact]
        public void GetCommand_WithUnsupportedKey_ThrowsInvalidOperationException()
        {
            // Arrange
            var commandFactory = new RobotCommandFactory();

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() => commandFactory.GetCommand('A'));
        }
    }
}

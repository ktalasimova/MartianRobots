using MartianRobots.Domain.Entities;
using Xunit;

namespace MartianRobots.Domain.UnitTests.ModelTests
{
    public class SurfaceTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(10, 1)]
        [InlineData(1, 10)]
        [InlineData(10, 10)]
        [InlineData(5, 7)]
        public void OutOfTheBound_WithInnerCoordinates_ReturnsFalse(int x, int y)
        {
            // Arrange
            var surface = new Surface(new Coordinate(10, 10));
            var testCoordinates = new Coordinate(x, y);

            // Act
            var result = surface.OutOfTheBound(testCoordinates);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(5, 6)]
        [InlineData(6, 5)]
        [InlineData(1, 7)]
        [InlineData(7, 1)]
        [InlineData(7, 7)]
        public void OutOfTheBound_WithOutsideCoordinates_ReturnsTrue(int x, int y)
        {
            // Arrange
            var surface = new Surface(new Coordinate(5, 5));
            var testCoordinates = new Coordinate(x, y);

            // Act
            var result = surface.OutOfTheBound(testCoordinates);

            // Assert
            Assert.True(result);
        }
    }
}

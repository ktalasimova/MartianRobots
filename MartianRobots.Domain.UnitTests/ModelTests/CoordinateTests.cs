using MartianRobots.Domain.Entities;
using Xunit;

namespace MartianRobots.Domain.UnitTests.ModelTests
{
    public class CoordinateTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(21)]
        [InlineData(-1)]
        [InlineData(-15)]
        public void SetX_WithValidCoordinate_SetsValue(int x)
        {
            // Act
            var coordinate = new Coordinate(x, 0);

            // Assert
            Assert.Equal(x, coordinate.X);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(-1)]
        [InlineData(-15)]
        public void SetY_WithValidCoordinate_SetsValue(int y)
        {
            // Act
            var coordinate = new Coordinate(0, y);

            // Assert
            Assert.Equal(y, coordinate.Y);
        }

        [Fact]
        public void ToString_ReturnsValidCoordinateString()
        {
            // Arrange
            var x = 1;
            var y = 5;

            var expectedString = "1 5";

            // Act
            var coordinate = new Coordinate(x, y);
            var recievedString = coordinate.ToString();

            // Assert
            Assert.Equal(expectedString, recievedString);
        }
    }
}

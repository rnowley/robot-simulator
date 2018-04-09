using System.Drawing;
using Moq;
using Xunit;

namespace robot_simulator.Tests
{
    public class SensorTests
    {
        [Fact]
        public void IsInBounds_InBounds_ReturnsTrue()
        {
            var mockBounds = new Mock<IBoard>();
            mockBounds.Setup(b => b.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var mockPoint = new Point(2, 2);
            var sensor = new Sensor(mockBounds.Object);

            var result = sensor.IsWithinBounds(mockPoint);
            
            Assert.True(result);
        }
        
        [Fact]
        public void IsInBounds_OutBounds_ReturnsFalse()
        {
            var mockBounds = new Mock<IBoard>();
            mockBounds.Setup(b => b.IsWithinBounds(It.IsAny<Point>()))
                .Returns(false);
            var mockPoint = new Point(2, 2);
            var sensor = new Sensor(mockBounds.Object);

            var result = sensor.IsWithinBounds(mockPoint);
            
            Assert.False(result);
        }
    }
}
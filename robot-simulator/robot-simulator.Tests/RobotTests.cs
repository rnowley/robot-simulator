using System.Drawing;
using Moq;
using Xunit;

namespace robot_simulator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void PlaceRobot_InvalidLocation_ReturnsFalse()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(false);
            var robotUnderTest = new Robot(mockSensor.Object);

            var result = robotUnderTest.PlaceRobot(new Point(-1, -1), Orientation.North);

            Assert.False(result);
        }
        
        [Fact]
        public void PlaceRobot_ValidLocation_ReturnsTrue()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);

            var result = robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            Assert.True(result);
        }

        [Fact]
        public void ReportLocation_RobotInitialised_ReturnsLocation()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            var location = robotUnderTest.ReportLocation();
            
            Assert.Equal("2,1,NORTH", location);
        }
        
        [Fact]
        public void ReportLocation_RobotNotInitialised_ReturnsUninitialised()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(false);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(-1, -1), Orientation.North);

            var location = robotUnderTest.ReportLocation();
            
            Assert.Equal("UNINITIALISED", location);
        }

        [Fact]
        public void TurnLeft_CurrentOrientationNorth_FacingWest()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            robotUnderTest.TurnLeft();

            var location = robotUnderTest.ReportLocation();
            Assert.Equal("2,1,WEST", location);
        }
        
        [Fact]
        public void TurnLeftFourTimes_CurrentOrientationNorth_FacingNorth()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            robotUnderTest.TurnLeft();
            robotUnderTest.TurnLeft();
            robotUnderTest.TurnLeft();
            robotUnderTest.TurnLeft();

            var location = robotUnderTest.ReportLocation();
            Assert.Equal("2,1,NORTH", location);
        }
        
        [Fact]
        public void TurnRight_CurrentOrientationNorth_FacingEast()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            robotUnderTest.TurnRight();

            var location = robotUnderTest.ReportLocation();
            Assert.Equal("2,1,EAST", location);
        }
        
        [Fact]
        public void TurnRightFourTimes_CurrentOrientationNorth_FacingNorth()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            robotUnderTest.TurnRight();
            robotUnderTest.TurnRight();
            robotUnderTest.TurnRight();
            robotUnderTest.TurnRight();

            var location = robotUnderTest.ReportLocation();
            Assert.Equal("2,1,NORTH", location);
        }
        
        [Fact]
        public void TurnLeft_RobotNotInitialised_ReturnsUninitialised()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(false);
            var robotUnderTest = new Robot(mockSensor.Object);
            
            robotUnderTest.TurnLeft();

            var location = robotUnderTest.ReportLocation();
            
            Assert.Equal("UNINITIALISED", location);
        }
        
        [Fact]
        public void TurnRight_RobotNotInitialised_ReturnsUninitialised()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(false);
            var robotUnderTest = new Robot(mockSensor.Object);
            
            robotUnderTest.TurnRight();

            var location = robotUnderTest.ReportLocation();
            
            Assert.Equal("UNINITIALISED", location);
        }
    }
}
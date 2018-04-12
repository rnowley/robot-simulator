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
        public void TurnLeftFourTimes_CurrentOrientationNorth_GoesThroughCorrectOrientationSequence()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            robotUnderTest.TurnLeft();
            var location1 = robotUnderTest.ReportLocation();
            robotUnderTest.TurnLeft();
            var location2 = robotUnderTest.ReportLocation();
            robotUnderTest.TurnLeft();
            var location3 = robotUnderTest.ReportLocation();
            robotUnderTest.TurnLeft();
            var location4 = robotUnderTest.ReportLocation();
            
            Assert.Equal("2,1,WEST", location1);
            Assert.Equal("2,1,SOUTH", location2);
            Assert.Equal("2,1,EAST", location3);
            Assert.Equal("2,1,NORTH", location4);
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
        public void TurnRightFourTimes_CurrentOrientationNorth_GoesThroughCorrectOrientationSequence()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(2, 1), Orientation.North);

            robotUnderTest.TurnRight();
            var location1 = robotUnderTest.ReportLocation();
            robotUnderTest.TurnRight();
            var location2 = robotUnderTest.ReportLocation();
            robotUnderTest.TurnRight();
            var location3 = robotUnderTest.ReportLocation();
            robotUnderTest.TurnRight();
            var location4 = robotUnderTest.ReportLocation();
            
            Assert.Equal("2,1,EAST", location1);
            Assert.Equal("2,1,SOUTH", location2);
            Assert.Equal("2,1,WEST", location3);
            Assert.Equal("2,1,NORTH", location4);
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

        [Fact]
        public void MoveForward_FacingNorthCanMoveForward_InCorrectLocation()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(1, 1), Orientation.North);

            var result = robotUnderTest.MoveForward();
            
            var location = robotUnderTest.ReportLocation();
            Assert.True(result);
            Assert.Equal("1,2,NORTH", location);
        }
        
        [Fact]
        public void MoveForward_FacingEastCanMoveForward_InCorrectLocation()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(1, 1), Orientation.East);

            var result = robotUnderTest.MoveForward();
            
            var location = robotUnderTest.ReportLocation();
            Assert.True(result);
            Assert.Equal("2,1,EAST", location);
        }
        
        [Fact]
        public void MoveForward_FacingSouthCanMoveForward_InCorrectLocation()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(1, 1), Orientation.South);

            var result = robotUnderTest.MoveForward();
            
            var location = robotUnderTest.ReportLocation();
            Assert.True(result);
            Assert.Equal("1,0,SOUTH", location);
        }
        
        [Fact]
        public void MoveForward_FacingWestCanMoveForward_InCorrectLocation()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.IsWithinBounds(It.IsAny<Point>()))
                .Returns(true);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(new Point(1, 1), Orientation.West);

            var result = robotUnderTest.MoveForward();
            
            var location = robotUnderTest.ReportLocation();
            Assert.True(result);
            Assert.Equal("0,1,WEST", location);
        }
        
        [Fact]
        public void MoveForward_CannotMoveForward_ReturnsFalse()
        {
            var mockSensor = new Mock<ISensor>();
            var startLocation = new Point(0, 0);
            var endLocation = new Point(0, -1);
            mockSensor.Setup(s => s.IsWithinBounds(It.Is<Point>(p => p == startLocation)))
                .Returns(true);
            mockSensor.Setup(s => s.IsWithinBounds(It.Is<Point>(p => p == endLocation)))
                .Returns(false);
            var robotUnderTest = new Robot(mockSensor.Object);
            robotUnderTest.PlaceRobot(startLocation, Orientation.South);

            var result = robotUnderTest.MoveForward();
            
            var location = robotUnderTest.ReportLocation();
            Assert.False(result);
            Assert.Equal("0,0,SOUTH", location);
        }
    }
}
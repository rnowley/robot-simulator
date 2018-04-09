using System.Drawing;
using Xunit;

namespace robot_simulator.Tests
{
    public class BoardTests
    {
        [Fact]
        public void IsInBounds_PointXOutsideOfLeftBound_ReturnsFalse()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(-1, 2);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.False(result);
        }
        
        [Fact]
        public void IsInBounds_PointYOutsideOfBottomBound_ReturnsFalse()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(1, -1);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.False(result);
        }
        
        [Fact]
        public void IsInBounds_PointXOutsideOfRightBound_ReturnsFalse()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(3, 2);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.False(result);
        }
        
        [Fact]
        public void IsInBounds_PointYOutsideOfTopBound_ReturnsFalse()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(1, 3);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.False(result);
        }
        
        [Fact]
        public void IsInBounds_PointInsideBounds_ReturnsTrue()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(1, 1);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.True(result);
        }
        
        [Fact]
        public void IsInBounds_PointXOnLeftBoundary_ReturnsTrue()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(0, 1);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.True(result);
        }
        
        [Fact]
        public void IsInBounds_PointYOnBottomBoundary_ReturnsTrue()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(1, 0);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.True(result);
        }
        
        [Fact]
        public void IsInBounds_PointXOnRightBound_ReturnsTrue()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(2, 1);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.True(result);
        }
        
        [Fact]
        public void IsInBounds_PointYOnTopBoundary_ReturnsTrue()
        {
            var boardToTest = new Board(3, 3);    // A 3x3 board.
            var pointToTest = new Point(1, 2);

            var result = boardToTest.IsWithinBounds(pointToTest);

            Assert.True(result);
        }
    }
}
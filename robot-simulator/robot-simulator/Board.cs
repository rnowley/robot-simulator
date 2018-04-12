using System.Drawing;

namespace robot_simulator
{
    /// <summary>
    /// Implements a board that the robot can move about on.
    /// </summary>
    public class Board : IBoard
    {
        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// Creates a new instance of a board.
        /// </summary>
        /// <param name="width">The width of the board in units.</param>
        /// <param name="height">The height of the board in units.</param>
        public Board(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
        /// <summary>
        /// Used to determine whether the provided point is with the
        /// bounds of the board.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>
        /// True if the point is within the bounds of the board and False
        /// if the point is outside the bounds of the board.
        /// </returns>
        public bool IsWithinBounds(Point point)
        {
            if (point.X < 0 || point.X >= _width)
            {
                return false;
            }

            return point.Y >= 0 && point.Y < _height;
        }
    }
}
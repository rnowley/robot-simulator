using System.Drawing;

namespace robot_simulator
{
    /// <summary>
    /// Provides an implementation of a sensor that the robot can use to navigate with.
    /// </summary>
    public class Sensor : ISensor
    {
        private readonly IBoard _board;

        /// <summary>
        /// Creates a new instance of Sensor object.
        /// </summary>
        /// <param name="board">The board that represents the environment that the
        /// robot can move around in.</param>
        public Sensor(IBoard board)
        {
            _board = board;
        }

        /// <summary>
        /// Determines if the provided point is within the bounds of the
        /// board.
        /// </summary>
        /// <param name="pointToCheck">The point to test.</param>
        /// <returns>True if the point is within the bounds of the board and false
        /// if it is not.</returns>
        public bool IsWithinBounds(Point pointToCheck)
        {
            return _board.IsWithinBounds(pointToCheck);
        }
    }
}
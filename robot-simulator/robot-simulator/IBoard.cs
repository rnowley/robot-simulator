using System.Drawing;

namespace robot_simulator
{
    /// <summary>
    /// Provides an interface for the environment that the toy robot
    /// can move around in.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Used to determine whether the provided point is with the
        /// bounds of the board.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>
        /// True if the point is within the bounds of the board and False
        /// if the point is outside the bounds of the board.
        /// </returns>
        bool IsWithinBounds(Point point);
    }
}
using System.Drawing;

namespace robot_simulator
{
    /// <summary>
    /// Provides a sensor interface for a sensor that the robot uses for
    /// navigating around the board.
    /// </summary>
    public interface ISensor
    {
        /// <summary>
        /// Determines if the provided point is within the bounds of the
        /// board.
        /// </summary>
        /// <param name="pointToCheck">The point to test.</param>
        /// <returns>True if the point is within the bounds of the board and false
        /// if it is not.</returns>
        bool IsWithinBounds(Point pointToCheck);
    }
}
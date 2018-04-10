using System;
using System.Drawing;

namespace robot_simulator
{
    /// <summary>
    /// Simulates a robot moving around a board.
    /// </summary>
    public class Robot
    {
        private Point _location;
        private Orientation _orientation;
        private bool _initialised;
        private readonly ISensor _sensor;

        /// <summary>
        /// Creates a new instance of a robot.
        /// </summary>
        /// <param name="sensor">The sensor that the robot can use to navigate around its environment.</param>
        public Robot(ISensor sensor)
        {
            _sensor = sensor;
        }

        /// <summary>
        /// Moves the robot to the next forward location if possible.
        /// </summary>
        /// <returns>true if the robot can move to the next forward location and false if not possible.</returns>
        public bool MoveForward()
        {
            var newLocation = CalculateForwardLocation();

            if (!_sensor.IsWithinBounds(newLocation))
            {
                return false;
            }

            _location = newLocation;
            return true;
        }

        /// <summary>
        /// Caclulates the new location after moving forwards.
        /// </summary>
        /// <returns>Returns the new forward location considering the current location and the current orientation</returns>
        /// <exception cref="ArgumentOutOfRangeException">Indicates that the current orientaion contains an invalid value.</exception>
        private Point CalculateForwardLocation()
        {
            Point newLocation;
            
            switch (_orientation)
            {
                case Orientation.North:
                    newLocation = new Point(_location.X, _location.Y + 1);
                    break;
                case Orientation.East:
                    newLocation = new Point(_location.X + 1, _location.Y);
                    break;
                case Orientation.South:
                    newLocation = new Point(_location.X, _location.Y - 1);
                    break;
                case Orientation.West:
                    newLocation = new Point(_location.X - 1, _location.Y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return newLocation;
        }

        /// <summary>
        /// Places the robot in its initial location on the board.
        /// </summary>
        /// <param name="location">The (x, y) location to place the robot on the board.</param>
        /// <param name="orientation">The direction the robot is to face in.</param>
        /// <returns>true if the place operation is successful and false if it is not.</returns>
        public bool PlaceRobot(Point location, Orientation orientation)
        {

            if (!_sensor.IsWithinBounds(location))
            {
                _initialised = false;
                return false;
            }

            _initialised = true;
            _location = location;
            _orientation = orientation;

            return true;
        }

        /// <summary>
        /// Reports the current location and orientation of the robot on the board.
        /// </summary>
        /// <returns>A string with format "{x},{y},{Orientation}" or "UNINITIALISED" if the robot has not been initialised.</returns>
        public string ReportLocation()
        {

            if (!_initialised)
            {
                return "UNINITIALISED";
            }

            return $"{_location.X},{_location.Y},{_orientation.ToString().ToUpperInvariant()}";
        }

        /// <summary>
        /// Turns the robot one turn to the left.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Indicates that robot's orientation is invalid.</exception>
        public void TurnLeft()
        {

            if (!_initialised)
            {
                return;
            }

            switch (_orientation)
            {
                case Orientation.North:
                    _orientation = Orientation.West;
                    break;
                case Orientation.West:
                    _orientation = Orientation.South;
                    break;
                case Orientation.South:
                    _orientation = Orientation.East;
                    break;
                case Orientation.East:
                    _orientation = Orientation.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_orientation), "Invalid value");
            }

        }
        
        /// <summary>
        /// Turns the robot one turn to the right
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Indicates that orientation of the robot is invalid.</exception>
        public void TurnRight()
        {

            if (!_initialised)
            {
                return;
            }

            switch (_orientation)
            {
                case Orientation.North:
                    _orientation = Orientation.East;
                    break;
                case Orientation.East:
                    _orientation = Orientation.South;
                    break;
                case Orientation.South:
                    _orientation = Orientation.West;
                    break;
                case Orientation.West:
                    _orientation = Orientation.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_orientation), "Invalid value");
            }
        }

    }
    
    
}
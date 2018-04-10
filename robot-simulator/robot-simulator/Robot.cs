using System;
using System.Drawing;
using System.Linq;

namespace robot_simulator
{
    public class Robot
    {
        private Point _location;
        private Orientation _orientation;
        private bool _initialised;
        private readonly ISensor _sensor;

        public Robot(ISensor sensor)
        {
            _sensor = sensor;
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
        /// 
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

        public void TurnLeft()
        {

            if (!_initialised)
            {
                return;
            }

            var minimumValue = Enum.GetValues(typeof(Orientation)).Cast<int>().Min();
            var maximumValue = Enum.GetValues(typeof(Orientation)).Cast<int>().Max();

            var currentValue = (int) _orientation;
            --currentValue;

            if (currentValue < minimumValue)
            {
                currentValue = maximumValue;
            }

            _orientation = (Orientation) currentValue;
        }
        
        public void TurnRight()
        {

            if (!_initialised)
            {
                return;
            }

            var minimumValue = Enum.GetValues(typeof(Orientation)).Cast<int>().Min();
            var maximumValue = Enum.GetValues(typeof(Orientation)).Cast<int>().Max();

            var currentValue = (int) _orientation;
            ++currentValue;

            if (currentValue > maximumValue)
            {
                currentValue = minimumValue;
            }

            _orientation = (Orientation) currentValue;
        }

    }
    
    
}
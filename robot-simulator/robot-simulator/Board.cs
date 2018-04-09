using System.Drawing;

namespace robot_simulator
{
    public class Board : IBoard
    {
        private int _width;
        private int _height;

        public Board(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
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
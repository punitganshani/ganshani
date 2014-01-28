using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    /// <summary>
    /// Represents a coordinate of grid.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        private int _x;

        /// <summary>
        /// X coordinate
        /// </summary>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// Y coordinate
        /// </summary>
        private int _y;

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// Constructor to create instance of a point.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Checks if the input point is within the area formed by (0,0) and (X, Y)
        /// </summary>
        /// <param name="input">Point which needs to be checked</param>
        /// <returns>True, if it lies within the area. False, otherwise</returns>
        public bool IsWithinArea(Point input)
        {
            return this.IsWithinArea(input.X, input.Y);
        }

        /// <summary>
        /// Checks if the input point is within the area formed by (0,0) and (X, Y)
        /// </summary>
        /// <param name="x">X coordinate of the point which needs to be checked</param>
        /// <param name="y">Y coordinate of the point which needs to be checked</param>
        /// <returns>True, if it lies within the area. False, otherwise</returns>
        internal bool IsWithinArea(int x, int y)
        {
            // same as/lesser than current area
            if (x >= 0 && y >= 0 && x <= _x && y <= _y)
                return true;
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", _x, _y);
        }
    }
}

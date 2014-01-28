using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover
{
    /// <summary>
    /// Defines location of the rover.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Regular Expression to validate location
        /// </summary>
        private const string REGEX_LOCATION = @"^(?<X>[0-9]*)[\s](?<Y>[0-9]*)[\s](?<Direction>[S|N|E|W]{0,1})$";

        /// <summary>
        /// Point (x,y)
        /// </summary>
        private Point _point;

        /// <summary>
        /// Point (x,y)
        /// </summary>
        public Point Point
        {
            get { return _point; }
        }

        /// <summary>
        /// Direction - N, S, E, W
        /// </summary>
        private Direction _direction;

        /// <summary>
        /// Direction - N, S, E, W
        /// </summary>
        public Direction Direction
        {
            get { return _direction; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="point">Defines position</param>
        /// <param name="direction">Default Value is North</param>
        public Location(Point point, Direction direction = MarsRover.Direction.N)
        {
            // Location must have a definite coordinate
            if (point == null)
                throw new ArgumentNullException("point");

            // Negative coordinates are not allowed.
            if (point.X < 0 || point.Y < 0)
                throw new Exception("Coordinates (X,Y) can not be negative");

            _point = point;
            _direction = direction;
        }

        /// <summary>
        /// Gets the location based on the input.
        /// </summary>
        /// <param name="directionInput">This is typically of the form X Y D, 
        /// where X and Y represent coordinates in the grid and D represents the direction (N, S, E, W)</param>
        /// <returns>Location</returns>
        public static Location GetLocation(string directionInput)
        {
            if (string.IsNullOrEmpty(directionInput))
                throw new ArgumentNullException("directionInput");

            Regex regex = new Regex(REGEX_LOCATION);
            Match match = regex.Match(directionInput);

            if (!match.Success)
                throw new ArgumentException("Invalid directions.");

            // If validated correctly, then parse and store values in variables.
            int x = Int32.Parse(match.Groups["X"].Value);
            int y = Int32.Parse(match.Groups["Y"].Value);
            Direction direction = (Direction)Enum.Parse(typeof(Direction), match.Groups["Direction"].Value);

            // form the location object as per the directionInput.
            return new Location(new Point(x, y), direction);
        }

        /// <summary>
        /// Overrides ToString()
        /// </summary>
        /// <returns>Location in form of X Y D.</returns>
        public override string ToString()
        {
            return String.Format("{0} {1}", _point, _direction);
        }
    }
}

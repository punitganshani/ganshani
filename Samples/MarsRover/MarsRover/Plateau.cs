using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    /// <summary>
    /// Singleton class representing Mars Plateau.
    /// </summary>
    /// <remarks>
    /// Chosen to be singleton as there is only one Plateau for all the rovers.
    /// </remarks>
    public sealed class Plateau
    {
        /// <summary>
        /// Static instance of plateau.
        /// </summary>
        private static Plateau _instance;

        /// <summary>
        /// Size of the plateau
        /// </summary>
        private Point _size;

        /// <summary>
        /// Size of the plateau
        /// </summary>
        internal Point Size
        {
            get { return _size; }
            private set { _size = value; }
        }

        /// <summary>
        /// Private constructor.
        /// </summary>
        private Plateau()
        { }

        /// <summary>
        /// Creates the instance of plateau of a particular size.
        /// </summary>
        /// <param name="width">Width of the plateau</param>
        /// <param name="height">Height of the plateau</param>
        /// <returns></returns>
        internal static Plateau FormSize(int width, int height)
        {
            if (width < 1 || height < 1)
                throw new ArgumentException("Plateau width/height should be greater than zero");

            // Check if the instance already exists.
            // If it does not create an instance of Plateau
            if (_instance == null)
                _instance = new Plateau();

            // Max bounds of the Plateau
            _instance.Size = new Point(width, height);

            return _instance;
        }

        /// <summary>
        /// Checks if the point is within the area of the plateau
        /// </summary>
        /// <param name="point">Point which is to be checked</param>
        /// <returns>True, if it lies within the plateau. False, otherwise</returns>
        internal static bool Contains(Point point)
        {
            return _instance.Size.IsWithinArea(point);
        }

        /// <summary>
        /// Checks if the point is within the area of the plateau
        /// </summary>
        /// <param name="x">X coordinate of point</param>
        /// <param name="y">Y coordinate of point</param>
        /// <returns>True, if it lies within the plateau. False, otherwise</returns>
        internal static bool Contains(int x, int y)
        {
            return _instance.Size.IsWithinArea(x, y);
        }
    }
}

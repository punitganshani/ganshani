using System;
namespace MarsRover
{
    /// <summary>
    /// Abstract class for Rover.
    /// </summary>
    /// <remarks>
    /// Can be extended for multiple types of rovers.
    /// </remarks>
    public abstract class RoverBase
    {
        public virtual Location BaseLocation { get; protected set; }
        public virtual Location CurrentLocation { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual Plateau Plateau { get; protected set; }
        public abstract void Move(string movements);

        public RoverBase(Plateau plateau, string baseLocation, string name)
        {
            if (plateau == null)
                throw new ArgumentNullException("plateau");

            if (string.IsNullOrEmpty(baseLocation))
                throw new ArgumentNullException("baseLocation");

            Plateau = plateau;
            Name = name;

            this.SetBaseLocation(baseLocation);
        }

        /// <summary>
        /// Sets the base location of the rover. It first checks whether the base location is within the bounds of plateau
        /// and then sets the base location.
        /// </summary>
        protected virtual void SetBaseLocation(string baseLocation)
        {
            // remove trailing spaces and make it upper-case before getting location.
            Location location = Location.GetLocation(baseLocation);

            // Check if the location is within Plateau
            if (!Plateau.Contains(location.Point))
                throw new ArgumentException(String.Format("Rover {0} : The direction ({1}, {2}) is out of bounds ({3}, {4})",
                                                                    Name,
                                                                    location.Point.X, location.Point.Y,
                                                                    Plateau.Size.X, Plateau.Size.Y));

            // If location is perfect, set it to current location.
            CurrentLocation = location;
            BaseLocation = location;
        }
    }
}

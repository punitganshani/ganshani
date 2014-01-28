using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Basic type of rover.
    /// </summary>
    public class Rover : RoverBase
    {
        /// <summary>
        /// Regular Expression to validate the movements.
        /// </summary>
        private const string REGEX_MOVEMENT = "^(?<movement>[L|M|R]*)$";

        /// <summary>
        /// Default constructor to instantiate an object of rover.
        /// </summary>
        /// <param name="plateau">Instance of plateau</param>
        /// <param name="baseLocation">Base Location</param>
        /// <param name="name">Name of the rover</param>
        public Rover(Plateau plateau, string baseLocation, string name)
            : base(plateau, baseLocation, name)
        {    }

        /// <summary>
        /// Move the rover as the directions.
        /// </summary>
        /// <param name="movements">Combination of L, M, and R that form the command for the rover to move.</param>
        public override void Move(string movements)
        {
            movements = movements.ToUpper().Trim();

            Regex regex = new Regex(REGEX_MOVEMENT);
            Match match = regex.Match(movements);

            if (!match.Success)
                throw new ArgumentException(String.Format("Rover {0}: Movement can only be L, R or M", Name));

            // Process all movements.
            char[] movement = movements.ToCharArray();

            int currentX = CurrentLocation.Point.X;
            int currentY = CurrentLocation.Point.Y;
            Direction newDirection = CurrentLocation.Direction;

            for (int i = 0; i < movement.Length; i++)
            {
                switch (movement[i])
                {
                    case 'M':
                        switch (newDirection)
                        {
                            case Direction.N:
                                currentY++;
                                break;
                            case Direction.S:
                                currentY--;
                                break;
                            case Direction.E:
                                currentX++;
                                break;
                            case Direction.W:
                                currentX--;
                                break;
                        }

                        if (!Plateau.Contains(currentX, currentY))
                            throw new Exception(String.Format("Rover {0} : Incorrect movement as it exceeds bounds of plateau.", Name));
                        else
                            CurrentLocation = new Location(new Point(currentX, currentY), newDirection);

                        //Console.WriteLine(String.Format("\t{0} {1} {2}", CurrentLocation.Point.X, CurrentLocation.Point.Y, CurrentLocation.Direction));

                        break;
                    default:
                        newDirection = this.GetNewDirection(newDirection, movement[i]);

                        //Console.WriteLine(String.Format("\t{0} {1} {2}", CurrentLocation.Point.X, CurrentLocation.Point.Y, CurrentLocation.Direction));

                        break;
                }
            }
        }

        /// <summary>
        /// Gets the new direction based on the current direction and the movement
        /// </summary>
        /// <param name="direction">Represents the current direction of the rover.</param>
        /// <param name="command">The movement command (L or R).</param>
        /// <returns>New direction the rover points to.</returns>
        private Direction GetNewDirection(Direction direction, char command)
        {
            if (direction == Direction.N && command == 'L' ||
                direction == Direction.S && command == 'R')
                return Direction.W;
            else if (direction == Direction.N && command == 'R' ||
                direction == Direction.S && command == 'L')
                return Direction.E;
            else if (direction == Direction.E && command == 'L' ||
                direction == Direction.W && command == 'R')
                return Direction.N;
            else if (direction == Direction.E && command == 'R' ||
                direction == Direction.W && command == 'L')
                return Direction.S;
            else
                throw new Exception(String.Format("Rover {0} : Unknown combination of movement found", Name));
        }
    }
}

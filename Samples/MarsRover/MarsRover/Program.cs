using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Plateau plateau = Plateau.FormSize(5, 5);
                RoverBase rover = new Rover(plateau, "1 2 N", "rover1");
                rover.Move("LMLMLMLMM");
                Console.WriteLine(String.Format("Position {0}: {1} --> {2}", rover.Name, rover.BaseLocation, rover.CurrentLocation));

                // Second rover
                rover = new Rover(plateau, "3 3 E", "rover2");
                rover.Move("MMRMMRMRRM");
                Console.WriteLine(String.Format("Position {0}: {1} --> {2}", rover.Name, rover.BaseLocation, rover.CurrentLocation));
            }
            catch (Exception ex)
            {
                // If there were any problems in movements or in the base location of the rover, then display it on the screen.
                Console.WriteLine(ex.Message);
            }

            // Wait for a key stroke from user.
            Console.ReadKey();
        }
    }
}

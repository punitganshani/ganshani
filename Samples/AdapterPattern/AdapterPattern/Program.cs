using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create some pegs.
            RoundPeg roundPeg = new RoundPeg();
            SquarePeg squarePeg = new SquarePeg();

            // Do an insert using the square peg.
            squarePeg.Insert("Inserting square peg...");
            
            // Create a two-way adapter and do an insert with it.
            ISquarePeg roundToSquare = new PegAdapter(roundPeg);
            roundToSquare.Insert("Inserting round peg...");

            // Do an insert using the round peg.
            roundPeg.InsertIntoHole("Inserting round peg...");

            // Create a two-way adapter and do an insert with it.
            IRoundPeg squareToRound = new PegAdapter(squarePeg);
            squareToRound.InsertIntoHole("Inserting square peg...");

            Console.ReadKey();
        }
    }
}

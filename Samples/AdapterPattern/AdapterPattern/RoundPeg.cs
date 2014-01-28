using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    public class RoundPeg : IRoundPeg
    {
        public void InsertIntoHole(string value)
        {
            Console.WriteLine("RoundPeg: " + value);
        }
    }
}

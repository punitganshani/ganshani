using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    public class SquarePeg : ISquarePeg
    {
        public void Insert(string value)
        {
            Console.WriteLine("SquarePeg: " + value);
        }
    }
}

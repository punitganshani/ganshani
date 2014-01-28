using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    public class PegAdapter : ISquarePeg, IRoundPeg
    {
        private RoundPeg _roundPeg;
        private SquarePeg _squarePeg;

        public PegAdapter(RoundPeg roundPeg)
        {
            _roundPeg = roundPeg;
        }

        public PegAdapter(SquarePeg squarePeg)
        {
            _squarePeg = squarePeg;
        }

        public void Insert(string value)
        {
            _roundPeg.InsertIntoHole(value);
        }

        public void InsertIntoHole(string msg)
        {
            _squarePeg.Insert(msg);
        }
    }
}

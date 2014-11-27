using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSample
{
    public class MyNullException : ArgumentNullException
    {
        public int Occurence { get; private set; }

        public MyNullException(string name, int occurence) : base (name)
        {
            Occurence = occurence;
        }
    }
}

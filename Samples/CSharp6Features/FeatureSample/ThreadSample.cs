using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathSample
{
    public class ThreadSample
    {
        Random rand = new Random();
        public async Task<int> DoSomething()
        {
            var nextRand = rand.Next(1000);
            Thread.Sleep(nextRand);

            return nextRand;
        }
 
    }
}

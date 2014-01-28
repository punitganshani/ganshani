using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockImpact.Interfaces;
using LockImpact.Worker;

namespace LockImpact
{
    class Program
    {
        static void Main(string[] args)
        {
            const int capacity = 10000000;

            var queue = new ArrayWorkerQueue<string>(2 * capacity);
            var queueWithLock = new ArrayWorkerQueueWithLock<string>(2 * capacity);

            MeasurePerformance(capacity, queueWithLock, "Array with lock "); 
            MeasurePerformance(capacity, queue, "Array without lock ");

            Console.WriteLine("press any key to exit..");
            Console.ReadKey();
        }

        private static void MeasurePerformance(int capacity, IArrayWorker<string> queue, string message)
        {
            DateTime dt = DateTime.Now;
            Parallel.Invoke(new Action[]
            {
                ()=>Parallel.For(0, capacity, x => queue.Push("xItem " + x)),
                ()=>Parallel.For(0, capacity, x => queue.Push("yItem " + x))
            });

            Parallel.For(0, 2 * capacity, x => queue.Pop());
            Console.WriteLine(message + " completed in " + DateTime.Now.Subtract(dt).TotalMilliseconds + " ms");
        }
    }
}

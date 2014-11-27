using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathSample
{
    public static class MyTaskHelper
    {
        public static async Task DoSomethingAsync()
        {
            Thread.Sleep(1000);
        }

        public static async Task LogAsync(Exception ex) {
            // do some logging
        }

        public static void DoSomething()
        {
            Thread.Sleep(1000);
        }

        public static void Log(Exception ex)
        {
            // do some logging
        }

        internal static async Task CloseAsync()
        {
            // do something here
        }
    }
}

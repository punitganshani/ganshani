using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<OwinSampleStartup>("http://localhost:2259"))
            {
                Console.WriteLine("Open the address in the browser or");
                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
            }
        }
    }

    public class OwinSampleStartup
    {
        public void Configuration(IAppBuilder sampleapp)
        {
            sampleapp.Run(sample =>
            {
                sample.Response.ContentType = "text/plain";
                return sample.Response.WriteAsync("Hello from OWIN");
            });
        }
    }
}

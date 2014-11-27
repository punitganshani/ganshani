using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MathSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Refactoring Sample
            if (args.Length >= 2 && args[0] != null && args[1] != null)
            {
                //TODO: We can refactor this
                var circleArea = Math.PI * Convert.ToDouble(args[0]) * Convert.ToDouble(args[0]);
                //TODO: We can refactor this
                var cylinderVolume = circleArea * Convert.ToDouble(args[1]);

                Console.WriteLine("Cylinder volume of radius {0} and height {1} is {2}",
                   Convert.ToDouble(args[0]), Convert.ToDouble(args[1]), cylinderVolume);
            }
            #endregion

            #region Index Init

            Dictionary<int, string> indexedStrings = new Dictionary<int, string>();
            indexedStrings.Add(1, "Sam");
            indexedStrings.Add(2, "Tan");

            #endregion

            #region Exceptions


            //int? x = null;
            //int i = 0;
            //do
            //{
            //    i++;
            //    try
            //    {
            //        // some wierd logic to set x = null so that we get exception
            //        if (i % 2 == 0) { x = i; }
            //        else { x = null; }

            //        if (x.HasValue == false)
            //        {
            //            throw new MyNullException("x", i);
            //        }
            //    }
            //    catch (MyNullException nullEx) 
            //    {
            //        //TODO: Why log every exception
            //        //if (nullEx.Occurence >= 5)
            //        Console.WriteLine("MyNullException Occured: " + nullEx.Occurence);

            //    }
            //    catch (Exception exception)
            //    {
            //        // dont do anything
            //    }

            //} while (i < 5);
             
            #endregion

            #region Async Exceptions
            //DemoExceptions();
            #endregion

            #region NULL checks

            ////TODO: Null checks can be optimized
            //List<Customer> customers = null;
            //Customer firstCustomer = customers?[0];
            //Console.WriteLine(firstCustomer);

            //customers = CustomerDb.GetCustomers();
            //var lastCustomer = customers.Last();
            //var lastCustomerName = lastCustomer?.Name;
            //Console.WriteLine(lastCustomerName);
            //firstCustomer = customers.First();

            ////TODO: Guess how these Null checks will work
            //Console.WriteLine("First Customer Order: " + firstCustomer?.Orders.Count);
            //Console.WriteLine("Last Customer Order: " + lastCustomer?.Orders?.Count);

            //Console.WriteLine("First Customer : " + firstCustomer?.ToString());
            //Console.WriteLine("Last Customer : " + lastCustomer?.ToString());


            #endregion

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async void DemoExceptions()
        {
            await ShowAsyncExceptions();
        }

        private static async Task ShowAsyncExceptions()
        {
            try
            {
                await MyTaskHelper.DoSomethingAsync();

            }
            catch (Exception ex)
            {
                await MyTaskHelper.LogAsync(ex);
            }
            finally
            {
                await MyTaskHelper.CloseAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace MathSample
{
    internal class CustomerDb
    {
        internal static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            var punit = new Customer { Name = "Punit", Address = "Simei", Orders = new List<Order>() };
            punit.Orders.Add(new Order { OrderId = 8000, Item = "Surface Pro 3", Price = 2000 });

            var sam = new Customer { Name = "Sam", Address = "Bedok" };

            customers.Add(punit);
            customers.Add(sam);
            return customers;
        }
    }
}
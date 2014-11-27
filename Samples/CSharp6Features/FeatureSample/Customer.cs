using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSample
{
    public class Customer
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<Order> Orders { get; set; }
        public override string ToString()
        {
            //TODO: String is a static class in System

            if (Orders != null)
                return String.Format("Name: {0}, Address: {1} => Order Count: {2}", Name, Address, Orders.Count);
            else
                return String.Format("Name: {0}, Address: {1} => Order Count: 0", Name, Address);

            //TODO: Simplify this above statement
        }
    }
}









//            return "Name: \{Name}, Address: \{Address},  Order Count: \{(Orders?.Count != null ? Orders?.Count.ToString() : "0")}"; 


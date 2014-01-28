using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serializers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            { 
                new Employee("Tim", 1392902),
                new Employee("Shawn", 156902),
            };

            ISerializer<List<Employee>> xmlSerializer = SerializerFactory.Create<List<Employee>>(SerializerType.Xml);
            string xml = xmlSerializer.Serialize(employees);

            ISerializer<List<Employee>> jsonSerializer = SerializerFactory.Create<List<Employee>>(SerializerType.JSON);
            string json = jsonSerializer.Serialize(employees);

            ISerializer<List<Employee>> clrSerializer = SerializerFactory.Create<List<Employee>>(SerializerType.CLR);
            string clr = clrSerializer.Serialize(employees);

            ISerializer<List<Employee>> wcfSerializer = SerializerFactory.Create<List<Employee>>(SerializerType.WCF);
            string wcf = wcfSerializer.Serialize(employees);

            Console.ReadKey();
        }
    }
}

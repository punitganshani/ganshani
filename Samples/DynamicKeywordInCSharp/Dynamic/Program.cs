using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            /* Simple Examples
             * Will work on any data type 
             * on which + can be applied
             */
            Console.WriteLine(program.Add(2, 3));
            Console.WriteLine(program.Add(2.0d, 3.0d));
            Console.WriteLine(program.Add("Punit", "G"));

            /* Will work on any data type 
             * on which = can be applied */
            Console.WriteLine(program.Equals(2, 3));
            Console.WriteLine(program.Equals("Punit", "G"));
            //Console.WriteLine(program.Add(program, program));


            dynamic sample = new SampleDynamicObject();
            // TryGetMember will be invoked sample.Name
            // Since the return value is true, it will not
            // throw an exception even if there is no property
            // called Name
            Console.WriteLine(sample.Name);

            // TryInvokeMember will be invoked PrintDetails
            // However it will throw not implemented exception
            // as it is not handled in TryInvokedMember method
            sample.PrintDetails();
            
            string a = sample.Name;
            // This will compile but will throw exception at runtime
            Program b = sample.Name;

            Console.WriteLine(a);
            Console.ReadKey();
        }

        public dynamic Add(dynamic number, dynamic number2)
        {
            return number + number2;
        }

        public bool Equals(dynamic o1, dynamic o2)
        {
            return o1 == o2;
        }
    }

    public class SampleDynamicObject : System.Dynamic.DynamicObject
    {
        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder,
                object[] args, out object result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder,
                out object result)
        {
            // Property:= Name
            if (binder.Name == "Name")
            {
                result = "Punit";
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }
    }

}

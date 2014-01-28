using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lazy
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<Database> database = new Lazy<Database>(() =>
            {
                Database internalObject = new Database("MyNewName");
                return internalObject;
            }, System.Threading.LazyThreadSafetyMode.PublicationOnly);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessDatabase), database);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessDatabase), database);

            Console.ReadKey();
        }

        static void ProcessDatabase(object input)
        {
            Lazy<Database> database = input as Lazy<Database>;
            Thread.Sleep(10);
            database.Value.Counter++;
            Console.WriteLine("Counter : " + database.Value.Counter + " at " + DateTime.Now.ToString());
        }

        private static void BasicLazyLoading()
        {
            // Defining database 
            // For parameter-less constructor
            // Lazy<Database> database = new Lazy<Database>();

            // For parameter-based constructor
            Lazy<Database> database = new Lazy<Database>(() =>
            {
                Database internalObject = new Database("MyNewName");
                return internalObject;
            });

            Console.WriteLine("Defined database object. Is database object created?");

            // Check if database object has been initialized
            if (database.IsValueCreated)
                Console.WriteLine("Database is initialized now!");
            else
                Console.WriteLine("Database is not initialized yet!");

            // Will throw an exception.. as it does not have parameter-less constructor
            Console.WriteLine("Database: Name =" + database.Value.Name);

            // Check if database object has been initialized
            if (database.IsValueCreated)
                Console.WriteLine("Database is initialized now!");
        }
    }

    public class Database
    {
        public string Name { get; set; }

        public int Counter { get; set; }
        public Database(string name)
        {
            Console.WriteLine("Database object constructor called");
            Name = name;
            Counter = 0;
        }
    }
}

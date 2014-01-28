using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Serializers
{
    ///// <summary>
    ///// Employee class for all other serializers
    ///// </summary>
    //[DataContract]
    //public class Employee
    //{
    //    [DataMember]
    //    public string Name { get; set; }
    //    [DataMember]
    //    public int EmployeeId { get; set; }

    //    /// <summary>
    //    /// Note: Default constructor is not mandatory
    //    /// </summary>
    //    public Employee(string name, int employeeId)
    //    {
    //        this.Name = name;
    //        this.EmployeeId = employeeId;
    //    }
    //}

    /// <summary>
    /// Employee class for XmlSerializer
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }

        /// <summary>
        /// Parameter-less constructor is mandatory
        /// </summary>
        public Employee() { }
        public Employee(string name, int employeeId)
        {
            this.Name = name;
            this.EmployeeId = employeeId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_2.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee()
        {
            Console.WriteLine("This is default constructor");
        }

        public Employee(int id) : this()
        {
            this.Id = id;
            Console.WriteLine("this is parameterized constructor");
        }
        public void PrintDetails()
        {
            Console.WriteLine($"NAME : {Name} id :{Id} Salary :{Salary}");
        }

    }
}

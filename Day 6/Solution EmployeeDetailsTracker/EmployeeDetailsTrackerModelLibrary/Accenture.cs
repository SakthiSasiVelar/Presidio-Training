using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsTrackerModelLibrary
{
    public class Accenture : Employee , GovtRules
    {
        public Accenture(int empid, string empName, string dept, string desg, double basicSalary) : base(empid , empName , dept , desg , basicSalary)
        {
            NameOfCompany = "Accenture";
        }

        public double EmployeePF(double basicSalary)
        {


            return ((12.0 / 100) * basicSalary) * 2;
        }

        public string LeaveDetails()
        {
            return " 2 day of Casual Leave per month\n 5 days of Sick Leave per year \n 5 days of Previlage Leave per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public void printDetails()
        {
            Console.WriteLine("Enter year of experience :");
            int serviceCompleted = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"id : {EmployeeId}\n name : {EmployeeName}\n dept : {Department} \n desg : {Designation} \n basicSalary : {BasicSalary} : name of the company : {NameOfCompany}\n " +
                $" Employee pf : {EmployeePF(BasicSalary)}\n  Employee LeaveDetails : {LeaveDetails()}\n Employee gratuity amount : {GratuityAmount(serviceCompleted, BasicSalary)} ");
        }
    }
}

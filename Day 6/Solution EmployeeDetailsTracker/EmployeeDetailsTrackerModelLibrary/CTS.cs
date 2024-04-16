using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsTrackerModelLibrary
{
    public class CTS : Employee , GovtRules
    {

        public CTS(int empid, string empName, string dept, string desg, double basicSalary) : base(empid, empName, dept, desg, basicSalary)
        {
            NameOfCompany = "CTS" ;
        }

         public  double EmployeePF(double basicSalary)
        {

            return ((12.0 / 100) * basicSalary) + ((8.33 / 100) * basicSalary) + ((3.67 / 100) * basicSalary);
        }

         public string LeaveDetails()
        {
            return " 1 day of Casual Leave per month\n 12 days of Sick Leave per year\n 10 days of Privilege Leave per year";
        }

         public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20) return 3 * basicSalary;
            else if (serviceCompleted > 10) return 2 * basicSalary;
            else if (serviceCompleted > 5) return basicSalary;
            else return 0;
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

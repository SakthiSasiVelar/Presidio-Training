using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsTrackerModelLibrary
{
    public class AccentureEmployee : Employee , IGovtRules
    {
        public AccentureEmployee(int empid, string empName, string dept, string desg, double basicSalary) : base(empid , empName , dept , desg , basicSalary)
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

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($" EmployeePF : {EmployeePF(BasicSalary)}\n Leave Details : {LeaveDetails()}\n Gratuity Amount : {GratuityAmount(serviceCompleted, BasicSalary)}");
        }
    }
}

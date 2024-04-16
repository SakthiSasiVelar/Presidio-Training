using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsTrackerModelLibrary
{
    public class CTSEmployee : Employee , IGovtRules
    {

        public CTSEmployee(int empid, string empName, string dept, string desg, double basicSalary) : base(empid, empName, dept, desg, basicSalary)
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

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($" EmployeePF : {EmployeePF(BasicSalary)}\n Leave Details : {LeaveDetails()}\n Gratuity Amount : {GratuityAmount(serviceCompleted, BasicSalary)}");
        }


    }
}

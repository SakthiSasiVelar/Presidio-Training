using EmployeeDetailsTrackerModelLibrary;
namespace EmployeeDetailsTracker
{
    internal class Program
    {

        Employee[] employees = new Employee[2]; 

         void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employee");
            Console.WriteLine("0. Exit");
        }

         Employee GetEmployeeDetails(int id)
        {
            int empid = 1001 + id;
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter department");
            string dept = Console.ReadLine();
            Console.WriteLine("Enter desgination");
            string desg = Console.ReadLine();
            Console.WriteLine("Enter salary");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter name of the company");
            string nameOfCompany = Console.ReadLine();

            Employee employee ;

            if (nameOfCompany == "CTS")
            {
                 employee = new CTSEmployee(empid, name, dept, desg, salary);
            }
            else if(nameOfCompany == "Accenture")
            {
                employee = new AccentureEmployee(empid, name, dept, desg, salary);
            }
            else return new Employee();

            return employee;
            
        }

         void AddEmployee()
        {
           if(employees[employees.Length - 1] != null)
           {
                Console.WriteLine("Employee array is full.");
                return;
           }
           for(int i = 0; i< employees.Length; i++)
           {
                if (employees[i] == null)
                {
                  employees[i] = GetEmployeeDetails(i);
                }
           }
        }

        void PrintAllEmployee()
        {
            for(int i=0;i< employees.Length;i++)
            {
                if (employees[i] !=null)
                {
                    employees[i].PrintDetails();
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int choice;
            do
            {
                program.PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thank you");
                        break;
                    case 1:
                        program.AddEmployee();
                        break;
                    case 2:
                        program.PrintAllEmployee();
                        break;
                }

            } while (choice != 0);
        }
    }
}

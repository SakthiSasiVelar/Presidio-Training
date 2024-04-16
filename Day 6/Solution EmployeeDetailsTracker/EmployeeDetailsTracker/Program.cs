using EmployeeDetailsTrackerModelLibrary;
namespace EmployeeDetailsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            CTS cts;
            Accenture accenture;
            if (nameOfCompany == "CTS")
            {
                cts = new CTS(101, name, dept, desg, salary);
                cts.printDetails();

            }
            else if (nameOfCompany == "Accenture")
            {
                accenture = new Accenture(101, name, dept, desg, salary);
                accenture.printDetails();
            }
        }
    }
}


namespace demo_2.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(3);
            employee.Name = "Test";
            employee.Salary = 10;

            employee.PrintDetails();
        }
    }
}

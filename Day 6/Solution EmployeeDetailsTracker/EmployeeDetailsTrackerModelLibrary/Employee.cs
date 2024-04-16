namespace EmployeeDetailsTrackerModelLibrary
{
    public class Employee
    {
        public float serviceCompleted;
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department {  get; set; }
        public string Designation { get; set; }
        public double BasicSalary {  get; set; }
        public string NameOfCompany { get; set; }



        public Employee()
        {
            EmployeeId = 0;
            EmployeeName = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            BasicSalary = 0.0;
            serviceCompleted = 0;
        }

        public Employee(int empid, string empName, string dept, string desg, double basicSalary)
        {
            EmployeeId = empid;
            EmployeeName = empName;
            Department = dept;
            Designation = desg;
            BasicSalary = basicSalary;
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine("Enter year of experience :");
            serviceCompleted = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"Employee id : {EmployeeId}\n Employee name : {EmployeeName}\n Employee department : {Department} \n Employee designation : {Designation} \n Employee basicSalary : {BasicSalary} : Name of the company : {NameOfCompany}");
        }





    }
}

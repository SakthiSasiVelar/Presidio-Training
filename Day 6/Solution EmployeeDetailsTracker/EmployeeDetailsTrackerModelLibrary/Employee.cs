namespace EmployeeDetailsTrackerModelLibrary
{
    public class Employee
    {
        
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
        }

        public Employee(int empid, string empName, string dept, string desg, double basicSalary)
        {
            EmployeeId = empid;
            EmployeeName = empName;
            Department = dept;
            Designation = desg;
            BasicSalary = basicSalary;
        }



       


    }
}

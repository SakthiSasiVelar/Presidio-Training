namespace EmployeeTracker.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string? Role { get; set; }

        public ICollection<Request> RequestRaised { get; set; }

        public ICollection<Request> RequestClosed { get; set; } 

        public ICollection<User> Users { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        public Employee Employee { get; set; }

        public string Status { get; set; }

    }
}

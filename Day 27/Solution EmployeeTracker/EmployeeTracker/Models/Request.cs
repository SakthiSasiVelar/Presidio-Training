namespace EmployeeTracker.Models
{
    public class Request
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime RaisedDateTime { get; set; }

        public DateTime? ClosedDateTime { get; set; } = null;

        public string RequestStatus { get; set; }

        public int RaisedBy { get; set; }

        public int? ClosedBy { get; set; } = null;

        public Employee RaisedByEmployee { get; set; }

        public Employee ClosedByEmployee { get;set; }   
    }
}

namespace EmployeeTracker.Models.DTOs
{
    public class RaiseRequestDTO
    {
        public string RequestMessage { get; set; }

        public DateTime RaisedDateTime { get; set; }

        public int RaisedBy { get; set; }
    }
}

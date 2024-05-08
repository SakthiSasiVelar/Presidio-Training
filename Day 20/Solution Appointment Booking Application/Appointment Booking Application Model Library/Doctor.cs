namespace Appointment_Booking_Application_Model_Library
{
    public class Doctor 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactNumber { get; set; }
        public string  Specialization { get; set; }

        public List<DateTime> AppointmentScheduleList { get; set; }
    }
}

namespace Appointment_Booking_Application_Model_Library
{
    public class Doctor : Person
    {
        public string  Specialization { get; set; }

        public List<DateTime> appointmentScheduleList;
    }
}

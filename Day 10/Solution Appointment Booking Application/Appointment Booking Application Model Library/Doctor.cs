namespace Appointment_Booking_Application_Model_Library
{
    public class Doctor : Person
    {
        public string  Specialization { get; set; }

        public List<DateTime> AppointmentScheduleList { get; set; }

        public Doctor(string name , string phNumber , string specialization , List<DateTime> appointmentScheduleList) : base(name , phNumber)
        {
            Specialization = specialization;
            AppointmentScheduleList = appointmentScheduleList;
        }
    }

   
}

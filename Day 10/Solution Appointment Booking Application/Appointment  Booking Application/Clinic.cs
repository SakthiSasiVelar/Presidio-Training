using Appointment_Booking_Application_Model_Library;

namespace Appointment__Booking_Application
{
    internal class Clinic
    {
        List<Doctor> doctorsList;
        List<Appointment> appointmentsList;

        void printMenu()
        {
            Console.WriteLine(" 1. Add Doctor \n 2. Schedule Appointment");
        }

        static void Main(string[] args)
        {
           
        }
    }
}

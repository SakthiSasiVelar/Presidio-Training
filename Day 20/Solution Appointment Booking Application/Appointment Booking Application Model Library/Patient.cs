using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking_Application_Model_Library
{
    public  class Patient 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactNumber { get; set; }
        int age;
        DateTime dob;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }

        public string MedicalProblem { get; set; }

    }
}

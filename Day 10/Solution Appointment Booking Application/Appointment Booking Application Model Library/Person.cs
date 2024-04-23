using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking_Application_Model_Library
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public Person( string name , string phNumber)
        {
            Name = name;
            ContactNumber = phNumber;
        }
    }
}

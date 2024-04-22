using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Model_library
{
    /// <summary>
    /// Customer have customer information
    /// </summary>
    /// <parameter name="Id"> customer Id </parameter>
    /// <parameter name="Name"> name of the customer </parameter>
    /// <parameter name="Address">address of the customer  </parameter>
    /// <parameter name="Phone number"> phone number of the customer </parameter>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public Customer( string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}

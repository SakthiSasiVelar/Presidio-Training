using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Store_Model_library;

namespace Pizza_Store_BL_Library
{
    public interface ICustomerService
    {
        public int AddCustomer(Customer customer);

        public int UpdateCustomer(Customer customer);

        public int DeleteCustomer(int customerId);

        public Customer GetCustomerById(int customerId);

        public List<Customer> GetAllCustomers();
    }
}

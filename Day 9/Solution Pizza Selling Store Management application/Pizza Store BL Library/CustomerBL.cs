using Pizza_Store_Model_library;

using Pizza_Store_DAL_library;

using Pizza_Store_Exception_Library;

namespace Pizza_Store_BL_Library
{
    public class CustomerBL : ICustomerService
    {
        readonly CustomerRepository _customerRepository;

        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }
        public int AddCustomer(Customer customer)
        {
            Customer result = _customerRepository.Add(customer);
            if(result != null)
            {
                return customer.Id;
            }
            throw new AddCustomerException();
        }

        public int DeleteCustomer(int customerId)
        {
            Customer result = _customerRepository.Delete(customerId);
            if(result != null)
            {
                return result.Id;
            }
            throw new DeleteCustomerException();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = _customerRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new GetAllCustomerException();
        }

        public Customer GetCustomerById(int id)
        {
            Customer result = _customerRepository.Get(id);
            if(result != null)
            {
                return result;
            }
            throw new GetCustomerException();
        }

        public int UpdateCustomer(Customer customer)
        {
            Customer result = _customerRepository.Update(customer);
            if(result != null)
            {
                return result.Id;
            }
            throw new UpdateCustomerException();
        }
    }
}

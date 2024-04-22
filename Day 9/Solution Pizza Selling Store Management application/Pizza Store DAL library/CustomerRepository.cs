using Pizza_Store_Model_library;

namespace Pizza_Store_DAL_library
{
    public class CustomerRepository : IRepository<int , Customer>
    {
        readonly Dictionary<int, Customer> _customers;

        public CustomerRepository()
        {
            _customers = new Dictionary<int, Customer>();
        }

        int GenerateId()
        {
            if (_customers.Count == 0) return 1;
            int id = _customers.Keys.Max();
            return ++id;
        }
        public Customer Add(Customer item)
        {
            if (_customers.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _customers.Add(item.Id, item);
            return item;
        }

        public Customer Delete(int key)
        {
            if (_customers.ContainsKey(key))
            {
                Customer customer = _customers[key];
                _customers.Remove(key);
                return customer;
            }
            return null; 
        }

        public Customer Get(int key)
        {
            if (_customers.ContainsKey(key))
            {
                return _customers[key];
            }
            return null;
        }

        public List<Customer> GetAll()
        {
           if( _customers.Count > 0)
            {
                return _customers.Values.ToList();
            }
            return null;
        }

        public Customer Update(Customer item)
        {
            if (_customers.ContainsKey(item.Id))
            {
                _customers[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}

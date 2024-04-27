using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shopping_Model_Library;
using Shopping_Model_Library.Exceptions;

namespace Shopping_DAL_Library
{
    public class CustomerRepository : AbstractRepository<int , Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            try
            {
                Customer customer = await GetByKey(key);
                items.Remove(customer);
                return customer;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
             
           
        }

        public override async Task<Customer> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
            int index = items.FindIndex((element) => element.Id == item.Id);
            if (index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}

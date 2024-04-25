using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shopping_Model_Library;
using Shopping_Model_Library.Exceptions;

namespace Shopping_DAL_Library
{
    public class ProductRepository : AbstractRepository<int , Product>
    {
        public override Product GetByKey(int key)
        {
            Product product = items.Find(x => x.Id == key);
            if(product != null)
            {
                return product;
            }
            throw new NoProductWithGivenIdException();
        }

        public override Product Delete(int key)
        {
            try
            {
                Product product = GetByKey(key);
                items.Remove(product);
                return product;  
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public override Product Update(Product item)
        {
            int index = items.FindIndex(element => element.Id == item.Id);
            if(index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoProductWithGivenIdException();
        }
    }
}

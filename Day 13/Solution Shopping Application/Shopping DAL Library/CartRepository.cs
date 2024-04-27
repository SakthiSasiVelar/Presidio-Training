using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shopping_Model_Library;
using Shopping_Model_Library.Exceptions;

namespace Shopping_DAL_Library
{
    public class CartRepository : AbstractRepository<int , Cart>
    {
        public override async Task<Cart> GetByKey(int key)
        {
            Cart cart = items.Find((item)=>item.Id == key);
            if(cart != null)
            {
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }

        public override async  Task<Cart> Delete(int key)
        {
            try
            {
                Cart cart = await GetByKey(key);
                items.Remove(cart);
                return cart;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public override async Task<Cart> Update(Cart item)
        {
            int index = items.FindIndex((element) => element.Id == item.Id);
            if(index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}

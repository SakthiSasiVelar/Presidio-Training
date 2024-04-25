using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shopping_Model_Library;
using Shopping_Model_Library.Exceptions;

namespace Shopping_DAL_Library
{
    public class CartItemRepository : AbstractRepository<int , CartItem>
    {
        public override CartItem GetByKey(int key)
        {
            CartItem cartItem = items.Find((item)=>item.Id == key);
            if(cartItem != null)
            {
                return cartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public override CartItem Delete(int key)
        {
            try
            {
                CartItem cartItem = GetByKey(key);
                items.Remove(cartItem);
                return cartItem; 
            }
           catch(Exception ex)
            {
                throw new Exception(ex.Message);
            } 
            
        }

        public override CartItem Update(CartItem item)
        {
            int index = items.FindIndex((element)=>element.Id == item.Id);
            if(index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoCartItemWithGivenIdException();
        }
    }
}

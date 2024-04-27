using Shopping_Model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_BL_Library
{
    public interface ICartItemService
    {
        public  Task<int> GetCartItemQuantity(int id);
        public Task<CartItem> GetCartItem(int id);

        public Task<double> GetCartItemPrice(CartItem item);
    }
}

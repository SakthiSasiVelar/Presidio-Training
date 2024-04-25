using Shopping_Model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shopping_DAL_Library;

using Shopping_Model_Library;
using System.Dynamic;

namespace Shopping_BL_Library
{
    public class CartItemBL : ICartItemService
    {
        IRepository<int, CartItem> cartItemRepository;
        public CartItemBL() {
            cartItemRepository = new CartItemRepository();
        }
        public int GetCartItemQuantity(int id)
        {
            try
            {
              CartItem cartItem = cartItemRepository.GetByKey(id);
              return cartItem.Quantity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CartItem GetCartItem(int id) {
            try
            {
                return cartItemRepository.GetByKey(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double GetCartItemPrice(CartItem item)
        {
            double price = item.Price;
            double discount = item.Discount;
            double quantity = item.Quantity;

            double totalAmount = (price - discount) * quantity;
            return totalAmount;
        }
    }
}

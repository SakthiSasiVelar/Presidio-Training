using Shopping_Model_Library;

using Shopping_Model_Library.Exceptions;

using Shopping_DAL_Library;

namespace Shopping_BL_Library
{
    public class CartBL : ICartService
    {
        public CartItemBL  cartItemBL;
        IRepository<int, Cart> cartRepository;
        public CartBL() {
            cartItemBL = new CartItemBL();
            cartRepository = new CartRepository();
        }
        public int AddCart(Cart item)
        {
            int currentCartItemQuantity = cartItemBL.GetCartItemQuantity(item.Id);
            try
            {
                if (currentCartItemQuantity < 5)
                {
                    Cart result = cartRepository.Add(item);
                    return result.Id;

                }
                throw new CannotAddItemInCartException();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public double GetCartItemsAmount(Cart cart)
        {
            double totalAmount = 0;
            foreach(CartItem item in cart.CartItems)
            {
                double itemPrice = cartItemBL.GetCartItemPrice(item);
                totalAmount += itemPrice;
            }

            
            if(cart.CartItems.Count <= 3 && totalAmount >= 1500)
            {
                totalAmount -= (totalAmount * 5 / 100);
            }
            else if(totalAmount < 100)
            {
                totalAmount += 100;      //shipping charge
            }       
            return totalAmount;
        }
    }
}

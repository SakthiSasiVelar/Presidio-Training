using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Model_Library
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart(int id, int customerId, Customer customer, List<CartItem> CartItems)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            this.CartItems = CartItems;
         }
    }

    
}

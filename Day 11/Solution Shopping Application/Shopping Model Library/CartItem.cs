using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Model_Library
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public CartItem(int id , int cartId , int productId , Product product , int quantity , double price , double discount , DateTime priceExpiryDate){
            Id = id;
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }
    }
}

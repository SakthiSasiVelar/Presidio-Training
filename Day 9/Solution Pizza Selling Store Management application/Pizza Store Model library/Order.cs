using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Model_library
{
    public class Order
    {
        public int Id { get; set; }

        public Customer customer;

        public List<int> orderedItems;

        public string DeliveryPreference { get; set; }

        public double TotalAmount {  get; set; }

        public string DeliveryAddress { get; set; }



        public Order(Customer customer,List<int> orderedItems , string deliveryPreference , double totalAmount , string deliveryAddress ) {
            this.customer = customer;
            this.orderedItems = orderedItems;
            DeliveryAddress = deliveryAddress;
            TotalAmount = totalAmount;
            DeliveryPreference = deliveryPreference;
        }

    }
}

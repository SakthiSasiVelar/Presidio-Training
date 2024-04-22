using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Model_library
{
    /// <summary>
    /// Order Class which contains orders of customers
    /// </summary>
    /// <parameter name="Id"> pizza Id </parameter>
    /// <parameter name="customer"> customer object contains customer information </parameter>
    /// <parameter name="orderedItems">contains ordered pizza id  </parameter>
    /// <parameter name="DeliveryPreference"> Delivery preference for the particular order </parameter>
    /// <parameter name="TotalAmount"> total amount for the order </parameter>
    /// <parameter name="DeliveryAddress"> delivery address for the order</parameter>
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

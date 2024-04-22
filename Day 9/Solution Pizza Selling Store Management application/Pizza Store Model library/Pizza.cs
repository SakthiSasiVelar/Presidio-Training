using System.Security;

namespace Pizza_Store_Model_library
{

    /// <summary>
    /// Pizza Class which contains properties of pizza
    /// </summary>
    /// <parameter name="Id"> pizza Id </parameter>
    /// <parameter name="Name"> name of the pizza </parameter>
    /// <parameter name="Ingredients"> ingredients of the pizza </parameter>
    /// <parameter name="Size"> size of the pizza </parameter>
    /// <parameter name="Price"> price of the pizza </parameter>
    /// <parameter name="AvailabilityStatus"> availability status of the pizza</parameter>
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }

        public string Size {  get; set; }

        public double Price { get; set; }

        public string AvailabilityStatus { get; set; }

        public Pizza( string name, string ingredients, string size, double price , string availabilityStatus)                 
        {
            Name = name;
            Ingredients = ingredients;
            Size = size;
            Price = price;
            AvailabilityStatus = availabilityStatus;
        }
    }
}

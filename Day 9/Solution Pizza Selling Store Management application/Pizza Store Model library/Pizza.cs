namespace Pizza_Store_Model_library
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }

        public string Size {  get; set; }

        public double Price { get; set; }

        public string AvailabilityStatus { get; set; }

        public Pizza( string name, string ingredients, string size, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Size = size;
            Price = price;
            AvailabilityStatus = "yes";
        }
    }
}

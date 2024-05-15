using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PizzaHutAPI.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QtyInHand { get; set; }
        public string Size { get; set; }
    }
}

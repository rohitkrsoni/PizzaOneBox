
namespace PizzaOneBox.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string PizzaName { get; set; }
        public string PhotoPath { get; set; }
        public decimal DefaultCost { get; set; }

        public string PizzaDescription { get; set; }
    }
}

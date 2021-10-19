
namespace PizzaOneBox.Models
{
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public class PizzaSize
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
}

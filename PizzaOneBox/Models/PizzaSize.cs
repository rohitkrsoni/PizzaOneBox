
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
        public Size size { get; set; }
        public decimal sizeCost { get; set; }
    }
}

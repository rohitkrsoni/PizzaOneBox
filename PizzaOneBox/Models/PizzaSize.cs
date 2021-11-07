namespace PizzaOneBox.Models
{
    public enum Size
    {
        Small=1,
        Medium,
        Large
    }
    public class PizzaSize
    {
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public decimal SizeCost { get; set; }
    }
}
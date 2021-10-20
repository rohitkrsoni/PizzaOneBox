
using System.ComponentModel.DataAnnotations;

namespace PizzaOneBox.Models
{
    public enum Size
    {
        Small = 1,
        Medium,
        Large
    }

    public class PizzaSize
    {
        public int Id { get; set; }

       // [EnumDataType(typeof(Size))]
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
}

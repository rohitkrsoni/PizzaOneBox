
using System.ComponentModel.DataAnnotations;

namespace PizzaOneBox.Models
{
    public enum BaseName
    {
        [Display(Name = "Hand Tossed")]
        HandTossed = 1,

        [Display(Name = "Cheese Burst")]
        CheeseBurst,

        [Display(Name = "Wheat Thin Crust")]
        WheatThinCrust,

        [Display(Name = "Fresh Pan Pizza")]
        FreshPanPizza,

        [Display(Name = "Italian")]
        Italian
    }
    public class PizzaBase
    {
        public int BaseId { get; set; }
        public BaseName BaseName { get; set; }
        public decimal BaseCost { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaOneBox.Models
{
    public class ToppingsValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var toppings = value as List<Topping>;
            foreach (var topping in toppings)
            {
                if (topping.CheckBoxAnswer) return true;
            }
            return false;
        }
    }
}

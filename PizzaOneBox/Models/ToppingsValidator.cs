using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class ToppingsValidator:ValidationAttribute
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

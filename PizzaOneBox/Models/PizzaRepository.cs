﻿using System.Collections.Generic;
using System.Linq;

namespace PizzaOneBox.Models
{
    public class PizzaRepository : IPizzaRepository
    {
        public IEnumerable<Pizza> GetAllPizzas()
        {
            return DataSource();
        }

        public Pizza GetPizza(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        private List<Pizza> DataSource()
        {
            return new List<Pizza>()
            {
                new Pizza(){Id=1, ImagePath="/Pizza_images/margherita.jpg",PizzaToppings="A hugely popular margherita, with a deliciously tangy single cheese topping",PizzaName="Margherita",PizzaPrice=14.49m},
                new Pizza(){Id=2, ImagePath="/Pizza_images/Farmhouse.jpg",PizzaToppings="Onion, Capsicum, Tomato, Grilled Mushroom",PizzaName="Farm House",PizzaPrice=15.49m},
                new Pizza(){Id=3, ImagePath="/Pizza_images/Peppy_Paneer.jpg",PizzaToppings="Paneer, Crisp Capsicum, Red Paprika",PizzaName="Peppy Paneer",PizzaPrice=15.49m},
                new Pizza(){Id=4, ImagePath="/Pizza_images/Corn_&_Cheese.jpg",PizzaToppings="Golden Corn",PizzaName="Cheese Corn",PizzaPrice=14.49m},
                new Pizza(){Id=5, ImagePath="/Pizza_images/VeggiParadise.jpg",PizzaToppings="Golden Corn, Black Olives, Capsicum, Red Paprika",PizzaName="Veggi Paradise",PizzaPrice=14.49m},
                new Pizza(){Id=6, ImagePath="/Pizza_images/Veg_Extravaganz.jpg",PizzaToppings="Mushroom, Corn, Tomato, Jalapeno",PizzaName="Veg Extravaganz",PizzaPrice=16.49m},
            };
        }



    }
}

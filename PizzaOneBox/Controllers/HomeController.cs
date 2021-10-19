using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using System.Collections.Generic;
namespace PizzaOneBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepositroy;

        public HomeController(IPizzaRepository pizzaRepositroy)
        {
            _pizzaRepositroy = pizzaRepositroy;
        }
        [HttpGet]
        public ActionResult HomePage()
        {
            var pizzaList = _pizzaRepositroy.GetAllPizza();
            //var pizzaList = new List<HomePagePizzaModel>()
            //{
            //    new HomePagePizzaModel(){Id=1, PhotoPath="/Pizza_images/margherita.jpg",PizzaDescription="A hugely popular margherita, with a single cheese topping",PizzaName="Margherita",PizzaCost=14.49m},
            //    new HomePagePizzaModel(){Id=2, PhotoPath="/Pizza_images/Farmhouse.jpg",PizzaDescription="Onion, Capsicum, Tomato, Grilled Mushroom",PizzaName="Farm House",PizzaCost=15.49m},
            //    new HomePagePizzaModel(){Id=3, PhotoPath="/Pizza_images/Peppy_Paneer.jpg",PizzaDescription="Paneer, Crisp Capsicum, Red Paprika",PizzaName="Peppy Paneer",PizzaCost=15.49m},
            //    new HomePagePizzaModel(){Id=4, PhotoPath="/Pizza_images/Corn_&_Cheese.jpg",PizzaDescription="Golden Corn",PizzaName="Cheese Corn",PizzaCost=14.49m},
            //    new HomePagePizzaModel(){Id=5, PhotoPath="/Pizza_images/VeggiParadise.jpg",PizzaDescription="Golden Corn, Black Olives, Capsicum, Red Paprika",PizzaName="Veggi Paradise",PizzaCost=14.49m},
            //    new HomePagePizzaModel(){Id=6, PhotoPath="/Pizza_images/Veg_Extravaganz.jpg",PizzaDescription="Mushroom, Corn, Tomato, Jalapeno",PizzaName="Veg Extravaganz",PizzaCost=16.49m},

            //};
            return View(pizzaList);
        }
                 
       

    }
}

using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        public IActionResult Index()
        {
            Random r = new Random();
            var userView = new UserView();
            userView.OrderId = r.Next()%1000000; //Model "order " store all info displayed
            if (userView.PizzaPrize != 20)
            {
                ViewBag.Message = String.Format("Congratulations you are served with 15% discount!!!");
            }

            userView.PizzaPrize = userView.PizzaPrize - userView.PizzaPrize*0.15m;

            return View("ConfirmationPg");
        }
    }
}

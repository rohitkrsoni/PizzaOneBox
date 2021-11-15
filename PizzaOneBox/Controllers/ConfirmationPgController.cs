using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Text.Json;


namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        public static Order _order;
        [HttpGet]
        public IActionResult SaveOrder(string order)
        {
            _order = JsonSerializer.Deserialize<Order>(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            Random r = new Random();
            ViewBag.Discount = 0;
            _order.OrderId = r.Next()%1000000; //Model "order " store all info displayed
            if (_order.Pizza.PizzaCost >= 20m)
            {
                ViewBag.Discount = 1;
                _order.Pizza.PizzaCost -=
                    _order.Pizza.PizzaCost * 0.15m;
                _order.Pizza.PizzaCost = Math.Round(_order.Pizza.PizzaCost, 2);
            }
            return View("ConfirmationPg",_order);
        }

    }
}

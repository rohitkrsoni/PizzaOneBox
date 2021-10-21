using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using PizzaOneBox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        [HttpGet]
        public IActionResult Index(OrderViewModel orderView)
        {
            orderView.Order = JsonSerializer.Deserialize<Order>(orderView.OrderToJson);
            orderView.Order.CustomerDetails = JsonSerializer.Deserialize<CustomerDetailsModel>(orderView.Order.Customer);
            orderView.OrderDetail = JsonSerializer.Deserialize<OrderDetail>(orderView.OrderDetailToJson);
            orderView.OrderDetail.Pizzas = JsonSerializer.Deserialize<Pizza>(orderView.OrderDetail.Pizza);
            orderView.OrderDetail.TotalCost = orderView.OrderDetail.Pizzas.Price;

            Random r = new Random();

            orderView.Order.CustomerDetails.OrderId = r.Next() % 1000000; //Model "order " store all info displayed
            if (orderView.OrderDetail.TotalCost >= 20m)
            {
                ViewBag.Message = string.Format("Congratulations you are served with 15% discount!!!");
                orderView.OrderDetail.TotalCost -=
                    orderView.OrderDetail.TotalCost * 0.15m;
            }
            return View("ConfirmationPg", orderView);
        }
    }
}

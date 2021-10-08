using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class DeliveryController : Controller
    {
        public string Index(Pizza pizza)
        {            
            return pizza.PizzaName;
        }
    }
}

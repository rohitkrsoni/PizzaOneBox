using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.DataAccessLayer;
namespace PizzaOneBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
   
        [HttpGet]
        public ActionResult HomePage()
        {
            return View(_pizzaRepository.GetPizzas());
        }
                 
       

    }
}

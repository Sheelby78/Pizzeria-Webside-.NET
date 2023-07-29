using pizzeriaWebside.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using pizzeriaWebside.Repositories;
using System.Text.Json;

namespace pizzeriaWebside.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllPizzas()
        {
            IEnumerable<Pizza> pizzas = _pizzaRepository.GetAll();
            return View(pizzas);
        }

        public IActionResult PizzaDetails(int id)
        {
            Pizza? pizza = _pizzaRepository.GetPizza(id);
            return View(pizza);
        }

        public IActionResult EditPizzaDescription(int id)
        {
            Pizza? pizza = _pizzaRepository.GetPizza(id);
            return View(pizza);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult EditDescription(int idVal, String inputVal)
        {
            _pizzaRepository.SetPizzaDescription(idVal, inputVal);
            return Ok();
        }
    }
}
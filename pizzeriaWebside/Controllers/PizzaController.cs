using KredekLab4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KredekLab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = (PizzaService?)pizzaService;
        }

        [HttpGet]
        public IActionResult GetAllPizzas()
        {
            var pizzas = _pizzaService.GetAll();
            return Ok(pizzas);
        }

        [HttpPost]
        public IActionResult CreatePizza(PizzaController pizza)
        {
            var id = _pizzaService.Create(pizza);
            return Created($"/api/pizza/{id}", pizza);
        }

    }
}

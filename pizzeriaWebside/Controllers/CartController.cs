using System.Text.Json;
using pizzeriaWebside.Models;
using pizzeriaWebside.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace pizzeriaWebside.Controllers
{
    public class CartController : Controller
    {
        private const string ItemsList = "ItemsList";
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IOrderRepository _orderRepository;

        public CartController(IPizzaRepository pizzaRepository, IOrderRepository orderRepository)
        {
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sessionItems = HttpContext.Session.GetString(ItemsList);
            var items = string.IsNullOrEmpty(sessionItems)
                ? Enumerable.Empty<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(sessionItems);

            return View(items);
        }

        [HttpGet]
        public IActionResult Orders()
        {
            IEnumerable<Order> orders = _orderRepository.GetAll();
            return View(orders);
        }

        public IActionResult OrderDetails(Guid id)
        {
            Order? order = _orderRepository.GetOrder(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult AddItem(int itemId)
        {
            var pizza = _pizzaRepository.GetPizza(itemId);

            if (pizza == null)
                return BadRequest();

            var sessionItems = HttpContext.Session.GetString(ItemsList);
            var items = string.IsNullOrEmpty(sessionItems)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(sessionItems);

            var cartItem = items!.FirstOrDefault(i => i.Id == pizza.Id);

            if (cartItem == null)
            {
                items!.Add(new CartItem()
                {
                    Name = pizza.Name,
                    Price = pizza.Price,
                    Count = 1,
                    Id = pizza.Id
                });
            }
            else
            {
                cartItem.Count += 1;
            }

            var serializedItems = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString(ItemsList, serializedItems);

            return Ok(cartItem);
        }

        [HttpPost]
        public IActionResult DeleteItem(int itemId)
        {
            var pizza = _pizzaRepository.GetPizza(itemId);

            if (pizza == null)
                return NotFound();

            var sessionItems = HttpContext.Session.GetString(ItemsList);

            if (string.IsNullOrEmpty(sessionItems))
                return BadRequest();

            var items = JsonSerializer.Deserialize<List<CartItem>>(sessionItems);

            var cartItem = items!.FirstOrDefault(i => i.Id == itemId);

            if (cartItem == null)
                return BadRequest();

            if(cartItem.Count > 0)
                cartItem.Count -= 1;

            if(cartItem.Count == 0)
                items!.Remove(cartItem);

            var serializedItems = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString(ItemsList, serializedItems);

            return Ok(cartItem);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder([Bind("Phone,City,Address,Id,Date")] Order order)
        {
            ModelState.Remove("OrderPizzas");
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            order.Id = Guid.NewGuid();
            order.Date = DateTime.Now;
            var items = JsonSerializer.Deserialize<List<CartItem>>(HttpContext.Session.GetString(ItemsList));
            if (items != null)
            {
                order.OrderPizzas = items.Select(i => new OrderPizza {OrderId = order.Id, PizzaId = i.Id, Count = i.Count}).ToList();
            }
            _orderRepository.SaveOrder(order);

            return View("PlacedOrder", order);
        }
    }
}

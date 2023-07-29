using pizzeriaWebside.Models;

namespace pizzeriaWebside.Repositories
{
    public class FakePizzaRepository 
    {
        private static readonly ICollection<Pizza> _pizzas = new List<Pizza>()
        {

        };

        public IEnumerable<Pizza> GetAll()
        {
            return _pizzas.ToList();
        }

        public Pizza? GetPizza(int id)
        {
            return _pizzas.FirstOrDefault(pizza => pizza.Id == id);
        }

        public Pizza? SetPizzaDescription(int id, String description)
        {
            _pizzas.FirstOrDefault(pizza => pizza.Id == id).Description = description;
            return _pizzas.FirstOrDefault(pizza => pizza.Id == id);
        }
    }
}

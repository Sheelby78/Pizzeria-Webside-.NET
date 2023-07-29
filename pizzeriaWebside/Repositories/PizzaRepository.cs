using pizzeriaWebside.Models;

namespace pizzeriaWebside.Repositories
{
    public class PizzaRepository: IPizzaRepository
    {
        private DatabaseContext context;

        public PizzaRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public int Create(Pizza pizza)
        {
            context.Pizzas.Add(pizza);
            context.SaveChanges();

            return pizza.Id;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return context.Pizzas.ToList();
        }

        public Pizza? GetPizza(int id)
        {
            return context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
        }

        public Pizza? SetPizzaDescription(int id, String description)
        {
            var pizza = context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
            pizza.Description = description;
            context.SaveChanges();
            return pizza;
        }

        public bool Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}

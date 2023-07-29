using KredekLab4.Controllers;
using pizzeriaWebside.Models;
using pizzeriaWebside.Repositories;

namespace KredekLab4.Services
{
    public class PizzaService : IPizzaService
    {
        IPizzaRepository _pizzaRepository;
        public PizzaService(IPizzaRepository pizzaRepository) 
        {
            _pizzaRepository = pizzaRepository;
        }
        public int Create(Pizza pizza)
        {
            var id = _pizzaRepository.Create(pizza);
            return id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizza> GetAll()
        {
            var allPizzas = _pizzaRepository.GetAll();
            //Put some logic here
            var pizzaToReturn = allPizzas
                .Where(x => x.Price > 0)
                .ToList();

            return pizzaToReturn;
        }

        public PizzaService? GetById()
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }

        internal object Create(PizzaController pizza)
        {
            throw new NotImplementedException();
        }
    }
}

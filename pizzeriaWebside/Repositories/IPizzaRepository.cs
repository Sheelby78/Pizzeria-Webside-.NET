using pizzeriaWebside.Models;

namespace pizzeriaWebside.Repositories
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAll();

        Pizza? GetPizza(int id);

        Pizza? SetPizzaDescription(int id, String description);

        int Create(Pizza pizza);

        bool Update (int  id, Pizza pizza);
    }
}

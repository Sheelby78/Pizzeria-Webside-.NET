using pizzeriaWebside.Models;

namespace KredekLab4.Services
{
    public interface IPizzaService
    {
        IEnumerable<Pizza> GetAll();
        PizzaService? GetById();

        int Create(Pizza pizza);

        bool Update(int id, Pizza pizza);

        bool Delete(int id);
    }
}

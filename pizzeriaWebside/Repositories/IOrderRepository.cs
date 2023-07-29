using pizzeriaWebside.Models;

namespace pizzeriaWebside.Repositories
{
    public interface IOrderRepository
    {
        public void SaveOrder(Order order);

        IEnumerable<Order> GetAll();

        Order? GetOrder(Guid id);
    }
}

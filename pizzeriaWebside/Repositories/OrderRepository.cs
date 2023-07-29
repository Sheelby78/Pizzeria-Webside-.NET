using pizzeriaWebside.Models;

namespace pizzeriaWebside.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DatabaseContext context;

        public OrderRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void SaveOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order? GetOrder(Guid id)
        {
            Order orderr;
            orderr = context.Orders.FirstOrDefault(order => order.Id == id);
            return orderr;
        }
    }
}

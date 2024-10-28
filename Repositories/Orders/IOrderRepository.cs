using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Repositories.Orders;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
    Task SaveOrder(Order order);
    Task UpdateOrder(Order order, int id);
    Task DeleteOrder(int id);
}

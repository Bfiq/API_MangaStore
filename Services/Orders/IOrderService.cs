using API_Manga_ecommerce.DTOs.Orders;
using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Orders;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
    Task SaveOrder(Order order);
    Task PartialUpdateOrder(OrderPatchDto orderPatchDto, int id);
    Task CheckIfOrderExists(int id);
}

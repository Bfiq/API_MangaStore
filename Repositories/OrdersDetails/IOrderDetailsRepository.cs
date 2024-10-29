using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Repositories.OrdersDetails;

public interface IOrderDetailsRepository
{
    Task<IEnumerable<OrderDetails>> getAllOrdersDetails();
    Task<OrderDetails?> getOrderDetailsById(int id);
    Task SaveOrderDetails(OrderDetails orderDetails);
    Task UpdateOrderDetails(OrderDetails orderDetails, int id);
    Task DeleteOrderDetails(int id);
}

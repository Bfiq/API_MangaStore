using API_Manga_ecommerce.DTOs.OrdersDetails;
using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.OrdersDetails;

public interface IOrdersDetailsService
{
    Task<IEnumerable<OrderDetails>> GetAllOrderDetails();
    Task<OrderDetails?> GetOrderDetailsById(int id);
    Task SaveOrderDetails(OrderDetails orderDetails);
    Task UpdateOrderDetails(OrderDetails orderDetails, int id);
    Task PartialUpdateOrderDetails(OrderDetailsPatchDto orderDetailsPatchDto, int id);
    Task DeleteOrderDetails(int id);
    Task CheckIfOrderDetailsExist(int id);
}

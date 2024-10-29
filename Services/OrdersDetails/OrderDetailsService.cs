using API_Manga_ecommerce.DTOs.OrdersDetails;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Repositories.OrdersDetails;

namespace API_Manga_ecommerce.Services.OrdersDetails;

public class OrderDetailsService:IOrdersDetailsService
{
    private IOrderDetailsRepository _orderDetailsRepository;

    public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
    {
        _orderDetailsRepository = orderDetailsRepository;
    }

    //Get all
    public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
    {
        return await _orderDetailsRepository.getAllOrdersDetails();
    }

    //Get id
    public async Task<OrderDetails?> GetOrderDetailsById(int id)
    {
        return await _orderDetailsRepository.getOrderDetailsById(id);
    }

    //Post
    public async Task SaveOrderDetails(OrderDetails orderDetails)
    {
        await _orderDetailsRepository.SaveOrderDetails(orderDetails);
    }

    //Put
    public async Task UpdateOrderDetails(OrderDetails orderDetails, int id)
    {
        var updateOrder = new OrderDetails{ 
            OrderId = orderDetails.OrderId,
            ProductId = orderDetails.ProductId,
            Quantity = orderDetails.Quantity,
            UnitPrice = orderDetails.UnitPrice,
            Discount = orderDetails.Discount
        };

        await _orderDetailsRepository.UpdateOrderDetails(updateOrder, id);
    }

    //Patch
    public async Task PartialUpdateOrderDetails(OrderDetailsPatchDto orderDetailsPatchDto,int id)
    {
        var currentOrderDetails = await _orderDetailsRepository.getOrderDetailsById(id);

        if (orderDetailsPatchDto.OrderId.HasValue) currentOrderDetails!.OrderId = orderDetailsPatchDto.OrderId.Value;
        if (orderDetailsPatchDto.ProductId.HasValue) currentOrderDetails!.ProductId = orderDetailsPatchDto.ProductId.Value;
        if (orderDetailsPatchDto.Quantity.HasValue) currentOrderDetails!.Quantity = orderDetailsPatchDto.Quantity.Value;
        if (orderDetailsPatchDto.UnitPrice.HasValue) currentOrderDetails!.UnitPrice = orderDetailsPatchDto.UnitPrice.Value;
        if (orderDetailsPatchDto.Discount.HasValue) currentOrderDetails!.Discount = orderDetailsPatchDto.Discount.Value;

        await _orderDetailsRepository.UpdateOrderDetails(currentOrderDetails!, id);
    }

    //Delete
    public async Task DeleteOrderDetails(int id)
    {
        await _orderDetailsRepository.DeleteOrderDetails(id);
    }

    //CheckId
    public async Task CheckIfOrderDetailsExist(int id)
    {
        _ = await _orderDetailsRepository.getOrderDetailsById(id) ?? throw new KeyNotFoundException("No se encontro los detalles de la orden");
    }
}

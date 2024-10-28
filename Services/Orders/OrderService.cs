using API_Manga_ecommerce.DTOs.Orders;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Repositories.Orders;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API_Manga_ecommerce.Services.Orders;

public class OrderService: IOrderService
{
    private IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    //Get All
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _orderRepository.GetAllOrders();
    }

    //Get Id
    public async Task<Order?> GetOrderById(int id)
    {
        return await _orderRepository.GetOrderById(id);
    }

    //Post
    public async Task SaveOrder(Order order)
    {
        await _orderRepository.SaveOrder(order);
    }

    //Patch
    public async Task PartialUpdateOrder(OrderPatchDto orderPatchDto, int id)
    {
        var currentOrder = await _orderRepository.GetOrderById(id);

        currentOrder!.OrderStatus = orderPatchDto.OrderStatus;
        await _orderRepository.UpdateOrder(currentOrder, id);
    }

    //Verify id
    public async Task CheckIfOrderExists(int id)
    {
        _ = await _orderRepository.GetOrderById(id) ?? throw new KeyNotFoundException($"No se encontro la orden con id: {id}");
    }
}

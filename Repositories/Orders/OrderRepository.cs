using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce.Repositories.Orders;

public class OrderRepository:IOrderRepository
{
    private readonly DatabaseContext _dbContext;

    public OrderRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Get All
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _dbContext.Orders.Include(t => t.User).ToListAsync();
    }

    //Get Id
    public async Task<Order?> GetOrderById(int id)
    {
        return await _dbContext.Orders.Include(t => t.User).FirstOrDefaultAsync(t=> t.OrderId == id);
    }

    //Post
    public async Task SaveOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
    }

    //Put
    public async Task UpdateOrder(Order order, int id)
    {
        var currentOrder = await _dbContext.Orders.FindAsync(id);

        currentOrder!.UserId = order.UserId;
        currentOrder.OrderDate = order.OrderDate;
        currentOrder.TotalAmount = order.TotalAmount;
        currentOrder.OrderStatus = order.OrderStatus;

        await _dbContext.SaveChangesAsync();
    }

    //Delete
    public async Task DeleteOrder(int id)
    {
        var currentOrder = await _dbContext.Orders.FindAsync(id);
        _dbContext.Orders.Remove(currentOrder!);
        await _dbContext.SaveChangesAsync();
    }
}

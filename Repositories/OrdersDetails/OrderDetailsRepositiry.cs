using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce.Repositories.OrdersDetails;

public class OrderDetailsRepositiry:IOrderDetailsRepository
{
    private readonly DatabaseContext _dbContext;

    public OrderDetailsRepositiry(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Get All
    public async Task<IEnumerable<OrderDetails>> getAllOrdersDetails()
    {
        return await _dbContext.OrdersDetails.Include(t => t.Order).Include(t=> t.Product).ToListAsync();
    }

    //Get id
    public async Task <OrderDetails?> getOrderDetailsById(int id)
    {
        return await _dbContext.OrdersDetails.Include(t => t.Order).Include(t => t.Product).FirstOrDefaultAsync(t => t.OrderDetailsId == id);
    }

    //Post
    public async Task SaveOrderDetails(OrderDetails orderDetails)
    {
        _dbContext.OrdersDetails.Add(orderDetails);
        await _dbContext.SaveChangesAsync();
    }

    //Put
    public async Task UpdateOrderDetails(OrderDetails orderDetails,int id)
    {
        var currentOrderDetails = await _dbContext.OrdersDetails.FindAsync(id);

        currentOrderDetails!.OrderId = orderDetails.OrderId;
        currentOrderDetails!.ProductId = orderDetails.ProductId;
        currentOrderDetails.Quantity = orderDetails.Quantity;
        currentOrderDetails.UnitPrice = orderDetails.UnitPrice;
        currentOrderDetails.Discount = orderDetails.Discount;

        await _dbContext.SaveChangesAsync();
    }

    //Delete
    public async Task DeleteOrderDetails(int id)
    {
        var currentOrderDetails = await _dbContext.OrdersDetails.FindAsync(id);
        _dbContext.OrdersDetails.Remove(currentOrderDetails!);
        await _dbContext.SaveChangesAsync();
    }
}

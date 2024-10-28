using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.DTOs.Orders;

public class OrderPatchDto
{
    public OrderStatus OrderStatus { get; set; }
}

namespace API_Manga_ecommerce.DTOs.OrdersDetails;

public class OrderDetailsPutDto
{
    public required int OrderId { get; set; }
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public required decimal Discount { get; set; }
}

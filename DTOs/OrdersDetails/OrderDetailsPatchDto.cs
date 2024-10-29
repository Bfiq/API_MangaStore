namespace API_Manga_ecommerce.DTOs.OrdersDetails;

public class OrderDetailsPatchDto
{
    public int? OrderId { get; set; }
    public int? ProductId { get; set; }
    public int? Quantity { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal? Discount { get; set; }
}

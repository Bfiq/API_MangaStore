namespace API_Manga_ecommerce.Models;

public class OrderDetails
{
    public int OrderDetailsId { get; set; }
    public required int OrderId { get; set; }
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public decimal? Discount { get; set; }
    public virtual Product Product { get; set; }
    public virtual Order Order { get; set; }
}

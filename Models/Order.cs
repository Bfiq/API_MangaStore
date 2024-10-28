using System.Text.Json.Serialization;

namespace API_Manga_ecommerce.Models;

public class Order
{
    public int OrderId { get; set; }
    public required int UserId { get; set; }
    public required DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public required OrderStatus OrderStatus { get; set; }
    public virtual User? User { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
    [JsonIgnore]
    public virtual ICollection<Payment>? Payments { get; set; }

}

public enum OrderStatus
{
    InProggress,
    SentTo,
    Received
}

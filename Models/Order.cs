using System.Text.Json.Serialization;

namespace API_Manga_ecommerce.Models;

public class Order
{
    public int OrderId { get; set; }
    public required int UserId { get; set; }
    public required DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public required OrderStatus OrderStatus { get; set; }
    public string OrderStatusName => OrderStatus.ToString();
    public virtual User? User { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
    [JsonIgnore]
    public virtual ICollection<Payment>? Payments { get; set; }

}

public enum OrderStatus
{
    Pending, //pedido creado
    InProgress, // confirmado y preparación de pedido
    Shipped, // Enviado
    Delivered, //Entregado
    Cancelled //Cancelado
}

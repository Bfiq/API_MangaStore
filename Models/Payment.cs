using System.Text.Json.Serialization;

namespace API_Manga_ecommerce.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public required int OrderId { get; set; }
    public string? Status { get; set; }
    public decimal? Amount { get; set; }
    public required DateTime CreatedAt { get; set; }
    public string? PaymontMethodType { get; set; }
    public Order Order { get; set; }
}

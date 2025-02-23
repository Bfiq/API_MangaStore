namespace API_Manga_ecommerce.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Comment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required string UserId { get; set; }
    public required string ProductId { get; set; }
    public string Content { get; set; } = null!;
    public int Rating { get; set; }
}

//? puede ser nulo
// == null!  inicialización tardia

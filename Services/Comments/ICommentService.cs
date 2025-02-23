using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Comments;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetCommentsByProductId(string productId);
    Task CreateComment(Comment comment);
}

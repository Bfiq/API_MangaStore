using API_Manga_ecommerce.Models;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetCommentsByProduct(string productId);
    Task CreateComments(Comment comment);
}

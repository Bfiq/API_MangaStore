using API_Manga_ecommerce.Models;
using MongoDB.Driver;

namespace API_Manga_ecommerce.Repositories.Comments;

public class CommentRepository: ICommentRepository
{
    private readonly IMongoCollection<Comment> _commentCollection;

    public CommentRepository(IMongoDatabase database) {
        _commentCollection = database.GetCollection<Comment>("Comments");
    }

    //Get by product
    public async Task<IEnumerable<Comment>> GetCommentsByProduct(string productId)
    {
        return await _commentCollection.Find(c => c.ProductId == productId).ToListAsync();
    }

    public async Task CreateComments(Comment comment)
    {
        await _commentCollection.InsertOneAsync(comment);
    }
}

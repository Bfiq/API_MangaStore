using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Comments;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    //GetByProduct
    public Task<IEnumerable<Comment>> GetCommentsByProductId(string productId)
    {
        return _commentRepository.GetCommentsByProduct(productId);
    }

    //create
    public async Task CreateComment(Comment comment)
    {
        await _commentRepository.CreateComments(comment);
    }
}

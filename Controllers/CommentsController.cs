using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.Comments;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    //Get by productId
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetCommentsByProductId([FromRoute] string productId)
    {
        try
        {
            var comments = await _commentService.GetCommentsByProductId(productId);
            return Ok(comments);
        }catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }
    //Post
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] Comment comment)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _commentService.CreateComment(comment);
            return Created();
        }
        catch
        {
            return StatusCode(500, "Error");
        }
    }
}

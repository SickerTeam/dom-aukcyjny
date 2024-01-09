using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync()
        {
            IEnumerable<CommentDTO> comments = await _commentService.GetCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("count/{postId}")]
        public async Task<IActionResult> GetAmountOfCommentsForPostById(int postId)
        {
            int count = await _commentService.GetAmountOfCommentsForPostById(postId);
            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByIdAsync(int id)
        {
            CommentDTO comment = await _commentService.GetCommentsByIdAsync(id);
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentsAsync([FromBody] CommentCreationDTO commentDto)
        {
            await _commentService.AddCommentsAsync(commentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentsAsync(int id)
        {
            await _commentService.DeleteCommentsAsync(id);
            return Ok();
        }
    }
}

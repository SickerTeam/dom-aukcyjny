using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync()
        {
            var comments = await _commentService.GetCommentsAsync();
            return Ok(_mapper.Map<IEnumerable<CommentDTO>>(comments));
        }

        [HttpGet("count/{postId}")]
        public async Task<IActionResult> GetAmountOfCommentsForPostById(int postId)
        {
            var count = await _commentService.GetAmountOfCommentsForPostById(postId);
            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByIdAsync(int id)
        {
            var comment = await _commentService.GetCommentsByIdAsync(id);
            return Ok(_mapper.Map<CommentDTO>(comment));
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

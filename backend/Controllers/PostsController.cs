using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController(IPostService postService) : ControllerBase
    {
        private readonly IPostService _postService = postService;

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstaBuyDTO>> GetInstaBuyById(int id)
        {
            var posts = await _postService.GetPostByIdAsync(id);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> AddPostAsync(PostRegistrationDTO postDto)
        {
            await _postService.AddPostAsync(postDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePostAsync(PostDTO postDto)
        {
            await _postService.UpdatePostAsync(postDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstaBuy(int id)
        {
            await _postService.DeletePostsAsync(id);
            return Ok();
        }
    }
}
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

        [HttpGet("{id}")]
        public async Task<ActionResult<FixedPriceListingDTO>> GetFixedPriceListingById(int id)
        {
            var posts = await _postService.GetPostByIdAsync(id);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostAsync(PostCreationDTO postDto)
        {
            var dbPost = await _postService.CreatePostAsync(postDto);
            var dto = await _postService.GetPostByIdAsync(dbPost.Id);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePostAsync(PostDTO postDto)
        {
            await _postService.UpdatePostAsync(postDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedPriceListing(int id)
        {
            await _postService.DeletePostsAsync(id);
            return Ok();
        }
    }
}
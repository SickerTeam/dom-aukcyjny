using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.JsonPatch;
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
            PostDTO posts = await _postService.GetPostByIdAsync(id);
            return Ok(posts);
        }

        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostAsync(PostCreationDTO postDto)
        {
            PostDTO dbPost = await _postService.CreatePostAsync(postDto);
            return Ok(dbPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostAsync(int id, [FromBody] JsonPatchDocument<PostDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            PostDTO? result = await _postService.UpdatePostAsync(id, patchDoc);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedPriceListing(int id)
        {
            await _postService.DeletePostsAsync(id);
            return Ok();
        }
    }
}
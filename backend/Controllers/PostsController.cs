using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /// <summary>
    /// Controller class for handling HTTP requests related to posts.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PostsController(IPostService postService) : ControllerBase
    {
        private readonly IPostService _postService = postService;

        /// <summary>
        /// Retrieves a fixed price listing by its ID.
        /// </summary>
        /// <param name="id">The ID of the fixed price listing.</param>
        /// <returns>An ActionResult containing the fixed price listing as a FixedPriceListingDTO.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FixedPriceListingDTO>> GetFixedPriceListingById(int id)
        {
            PostDTO posts = await _postService.GetPostByIdAsync(id);
            return Ok(posts);
        }

        /// <summary>
        /// Retrieves all posts.
        /// </summary>
        /// <returns>An ActionResult containing a list of posts.</returns>
        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        /// <summary>
        /// Creates a new post asynchronously based on the provided PostCreationDTO.
        /// </summary>
        /// <param name="postDto">The PostCreationDTO containing the data for the new post.</param>
        /// <returns>An ActionResult containing the created post as a PostDTO.</returns>
        [HttpPost]
        public async Task<ActionResult> CreatePostAsync(PostCreationDTO postDto)
        {
            PostDTO dbPost = await _postService.CreatePostAsync(postDto);
            return Ok(dbPost);
        }

        /// <summary>
        /// Updates a post asynchronously based on the provided ID and JsonPatchDocument.
        /// </summary>
        /// <param name="id">The ID of the post to update.</param>
        /// <param name="patchDoc">The JsonPatchDocument containing the changes to apply to the post.</param>
        /// <returns>An ActionResult containing the updated post as a PostDTO.</returns>
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

        /// <summary>
        /// Deletes a fixed price listing by its ID.
        /// </summary>
        /// <param name="id">The ID of the fixed price listing to delete.</param>
        /// <returns>An ActionResult indicating the success of the deletion.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedPriceListing(int id)
        {
            await _postService.DeletePostsAsync(id);
            return Ok();
        }
    }
}
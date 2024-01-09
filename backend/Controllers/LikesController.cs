using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikesController(ILikeService likeService) : ControllerBase
    {
        private readonly ILikeService _likeService = likeService;

        [HttpGet]
        public async Task<IActionResult> GetLikesAsync()
        {
            IEnumerable<LikeDTO> likes = await _likeService.GetLikesAsync();
            return Ok(likes);
        }

        [HttpGet("count/{postId}")]
        public async Task<IActionResult> GetAmountOfLikesForPostById(int postId)
        {
            int count = await _likeService.GetAmountOfLikesForPostById(postId);
            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLikeByIdAsync(int id)
        {
            LikeDTO like = await _likeService.GetLikeByIdAsync(id);
            return Ok(like);
        }

        [HttpPost]
        public async Task<IActionResult> AddLikeAsync(LikeCreationDTO likeDto)
        {
            await _likeService.AddLikeAsync(likeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikeAsync(int id)
        {
            await _likeService.DeleteLikeAsync(id);
            return Ok();
        }
    }
}

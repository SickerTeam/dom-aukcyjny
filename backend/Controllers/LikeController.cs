using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikeController(ILikeService likeService, IMapper mapper) : ControllerBase
    {
        private readonly ILikeService _likeService = likeService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetLikesAsync()
        {
            var likes = await _likeService.GetLikesAsync();
            return Ok(_mapper.Map<IEnumerable<LikeDTO>>(likes));
        }

        [HttpGet("count/{postId}")]
        public async Task<IActionResult> GetAmountOfLikesForPostById(int postId)
        {
            var count = await _likeService.GetAmountOfLikesForPostById(postId);
            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLikesByIdAsync(int id)
        {
            var like = await _likeService.GetLikesByIdAsync(id);
            return Ok(_mapper.Map<LikeDTO>(like));
        }

        [HttpPost]
        public async Task<IActionResult> AddLikesAsync(LikeRegistrationDTO likeDto)
        {
            await _likeService.AddLikesAsync(likeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikesAsync(int id)
        {
            await _likeService.DeleteLikesAsync(id);
            return Ok();
        }
    }
}

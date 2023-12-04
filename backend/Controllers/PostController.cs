using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController(IPostService postService, IMapper mapper) : ControllerBase
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
        public async Task<ActionResult> AddInstaBuy(InstaBuyDTO instaBuyDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInstaBuy(int id, InstaBuyDTO instaBuyDto)
        {
           throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstaBuy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
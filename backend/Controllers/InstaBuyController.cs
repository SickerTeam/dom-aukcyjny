using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstaBuyController(IInstaBuyService instaBuyService) : ControllerBase
    {
        private readonly IInstaBuyService _instaBuyService = instaBuyService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstaBuyDTO>>> GetAllInstaBuys()
        {
            var instaBuys = await _instaBuyService.GetAllInstaBuysAsync();
            return Ok(instaBuys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstaBuyDTO>> GetInstaBuyById(int id)
        {
            var instaBuy = await _instaBuyService.GetInstaBuyByIdAsync(id);
            if (instaBuy == null) return NotFound();
            return Ok(instaBuy);
        }

        [HttpPost]
        public async Task<ActionResult> AddInstaBuy(InstaBuyRegistrationDTO instaBuyDto)
        {
            await _instaBuyService.AddInstaBuyAsync(instaBuyDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInstaBuy(int id, InstaBuyDTO instaBuyDto)
        {
            await _instaBuyService.UpdateInstaBuyAsync(instaBuyDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstaBuy(int id)
        {
            await _instaBuyService.DeleteInstaBuyAsync(id);
            return Ok();
        }
    }

}

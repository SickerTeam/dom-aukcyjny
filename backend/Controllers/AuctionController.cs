using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController(IAuctionService auctionService, IMapper mapper) : ControllerBase
    {
        private readonly IAuctionService _auctionService = auctionService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAuctions()
        {
            var listings = await _auctionService.GetAuctionsAsync();
            return Ok(listings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            var listing = await _auctionService.GetAuctionByIdAsync(id);
            return Ok(listing);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuction(AuctionDTO auctionDto)
        {
            await _auctionService.AddAuctionAsync(auctionDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuction(AuctionDTO auctionDto)
        {
            await _auctionService.UpdateAuctionAsync(auctionDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            await _auctionService.DeleteAuctionsAsync(id);
            return Ok();
        }

    }
}

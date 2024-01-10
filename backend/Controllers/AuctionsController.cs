using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionsController(IAuctionService auctionService) : ControllerBase
    {
        private readonly IAuctionService _auctionService = auctionService;

        [HttpGet]
        public async Task<IActionResult> GetAuctions()
        {
            var auctions = await _auctionService.GetAuctionsAsync();
            return Ok(auctions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            var auction = await _auctionService.GetAuctionByIdAsync(id);
            return Ok(auction);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(AuctionCreationDTO auctionDto)
        {
            auctionDto.Product.SellerId = 1; // change it to the current user id
            var auction = await _auctionService.CreateAuctionAsync(auctionDto);
            var dto = await _auctionService.GetAuctionByIdAsync(auction.Id);
            return Ok(dto);
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

using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.JsonPatch;
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
            IEnumerable<AuctionDTO> auctions = await _auctionService.GetAuctionsAsync();
            return Ok(auctions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            AuctionDTO auction = await _auctionService.GetAuctionByIdAsync(id);
            return Ok(auction);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetNumberOfAuctions()
        {
            int numberOfAuctions = await _auctionService.GetNumberOfAuctions();
            return Ok(numberOfAuctions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(AuctionCreationDTO auctionDto)
        {
            auctionDto.Product.SellerId = 1; // change it to the current user id
            var auction = await _auctionService.CreateAuctionAsync(auctionDto);
            var dto = await _auctionService.GetAuctionByIdAsync(auction.Id);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuction(int id, [FromBody] JsonPatchDocument<AuctionDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            AuctionDTO? result = await _auctionService.UpdateAuctionAsync(id, patchDoc);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            await _auctionService.DeleteAuctionsAsync(id);
            return Ok();
        }
    }
}

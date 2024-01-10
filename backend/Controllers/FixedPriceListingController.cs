using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixedPriceListingsController(IFixedPriceListingService fixedPriceListingService) : ControllerBase
    {
        private readonly IFixedPriceListingService _fixedPriceListingService = fixedPriceListingService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixedPriceListingDTO>>> GetAllFixedPriceListings()
        {
            var fixedPriceListings = await _fixedPriceListingService.GetAllFixedPriceListingsAsync();
            return Ok(fixedPriceListings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FixedPriceListingDTO>> GetFixedPriceListingById(int id)
        {
            var fixedPriceListing = await _fixedPriceListingService.GetFixedPriceListingByIdAsync(id);
            if (fixedPriceListing == null) return NotFound();
            return Ok(fixedPriceListing);
        }

        [HttpPost]
        public async Task<ActionResult> AddFixedPriceListing(FixedPriceListingCreationDTO fixedPriceListingDto)
        {
            fixedPriceListingDto.Product.SellerId = 1; // change it to the current user id
            var fixedPriceListing = await _fixedPriceListingService.AddFixedPriceListingAsync(fixedPriceListingDto);
            var dto = await _fixedPriceListingService.GetFixedPriceListingByIdAsync(fixedPriceListing.Id);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateFixedPriceListing(FixedPriceListingDTO fixedPriceListingDto)
        {
            await _fixedPriceListingService.UpdateFixedPriceListingAsync(fixedPriceListingDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedPriceListing(int id)
        {
            await _fixedPriceListingService.DeleteFixedPriceListingAsync(id);
            return Ok();
        }
    }

}

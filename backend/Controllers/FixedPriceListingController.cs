using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.JsonPatch;
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
            IEnumerable<FixedPriceListingDTO> fixedPriceListings = await _fixedPriceListingService.GetAllFixedPriceListingsAsync();
            return Ok(fixedPriceListings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FixedPriceListingDTO>> GetFixedPriceListingById(int id)
        {
            FixedPriceListingDTO fixedPriceListing = await _fixedPriceListingService.GetFixedPriceListingByIdAsync(id);
            if (fixedPriceListing == null) return NotFound();
            return Ok(fixedPriceListing);
        }

        [HttpPost]
        public async Task<ActionResult> AddFixedPriceListing(FixedPriceListingCreationDTO fixedPriceListingDto)
        {
            await _fixedPriceListingService.AddFixedPriceListingAsync(fixedPriceListingDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFixedPriceListing(int id, [FromBody] JsonPatchDocument<FixedPriceListingDTO> patchDoc)
        {

            if (patchDoc == null)
            {
                return BadRequest();
            }

            FixedPriceListingDTO? result = await _fixedPriceListingService.UpdateFixedPriceListingAsync(id, patchDoc);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedPriceListing(int id)
        {
            await _fixedPriceListingService.DeleteFixedPriceListingAsync(id);
            return Ok();
        }
    }

}

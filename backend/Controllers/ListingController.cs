using backend.Repository;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        [Route("listings/{id}")]
        public IActionResult GetListingById(int id)
        {
            var listing = _listingService.GetListing(id);
            return Ok(listing);
        }

        [HttpGet]
        [Route("listings")]
        public IActionResult GetListings()
        {
            var listings = _listingService.GetListings();
            return Ok(listings);
        }
    }
}

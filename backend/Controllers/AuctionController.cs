using AutoMapper;
using backend.DTOs;
using backend.Repository;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace backend.Controllers
{
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AuctionController(IListingService listingService, IMapper mapper)
        {
            _listingService = listingService;
            _mapper = mapper;
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


//        public async Task<IActionResult> UpdateListing(int id)
//        {
//            var listing = await _listingService.GetListing(id) (u => u.Id == id);
//
//            var model = _mapper.Map<ListingDTO>(listing);
//        }
    }
}

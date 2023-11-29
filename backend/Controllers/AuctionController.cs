using AutoMapper;
using backend.DTOs;
using backend.Repositories;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace backend.Controllers
{
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;
        private readonly IMapper _mapper;

        public AuctionController(IAuctionService auctionService, IMapper mapper)
        {
            _auctionService = auctionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("auctions/{id}")]
        public IActionResult GetAuctionById(int id)
        {
            var listing = _auctionService.GetAuctionById(id);
            return Ok(listing);
        }

        [HttpGet]
        [Route("auctions")]
        public IActionResult GetAuctions()
        {
            var listings = _auctionService.GetAuctions();
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

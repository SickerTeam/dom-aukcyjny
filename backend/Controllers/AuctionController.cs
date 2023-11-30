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
    [Route("auctions")]
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
        public async Task<IActionResult> GetAuctions()
        {
            var listings = await _auctionService.GetAuctions();
            return Ok(listings);
        }

        [HttpGet("{id}")]
        // public IActionResult GetAuctionById(int id)
        // {
        //     var listing = _auctionService.GetAuctionById(id);
        //     return Ok(listing);
        // }
        public async Task<IActionResult> GetAuctionById(int id)
        {
            var listing = await _auctionService.GetAuctionById(id);
            return Ok(listing);
        }

//        public async Task<IActionResult> UpdateListing(int id)
//        {
//            var listing = await _listingService.GetListing(id) (u => u.Id == id);
//
//            var model = _mapper.Map<ListingDTO>(listing);
//        }
    }
}

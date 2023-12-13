using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DTOs;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HTTPBidController(IBidService bidService) : ControllerBase
    {
        private readonly IBidService _bidService = bidService;

        [HttpGet("{auctionId}")]
        public async Task<IEnumerable<BidDTO>> GetAllBidsForAuction(int auctionId)
        {
            return await _bidService.GetAllBidsForAuctionAsync(auctionId);
        }

        [HttpPost]
        public async Task<BidDTO> AddBid(BidRegistrationDTO bidRegistrationDTO)
        {
            return await _bidService.AddBidAsync(bidRegistrationDTO);
        }
    }
}
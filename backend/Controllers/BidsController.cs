using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace backend.Controllers
{
    [ApiController]
    [Route("auctions/{auctionId}/[controller]")]
    public class BidsController : ControllerBase
    {
        private readonly IBidService _bidService;
        private readonly IAuctionService _auctionService;
        private readonly IHubContext<BidHub> _hubContext;

        public BidsController(IBidService bidService, IAuctionService auctionService, IHubContext<BidHub> hubContext)
        {
            _bidService = bidService;
            _auctionService = auctionService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBidsForAuction([FromRoute] int auctionId)
        {
            var bids = await _bidService.GetAllBidsForAuction(auctionId);
            return Ok(bids);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBid([FromRoute] int auctionId, BidCreationDTO bid)
        {
            bid.UserId = 1; // change to currently logged in user

            var auction = await _auctionService.GetAuctionByIdAsync(auctionId);  

            if(bid.CreatedAt > auction.EndsAt)
            {
                return BadRequest("Auction has ended");
            }

            bid.AuctionId = auctionId;

            var createdBid = await _bidService.CreateBid(bid);

            var dto = await _bidService.GetBidById(createdBid.Id);
            await _hubContext.Clients.All.SendAsync("CurrentPriceChanged", dto.Amount);

            return Ok(dto);
        }
    }
}

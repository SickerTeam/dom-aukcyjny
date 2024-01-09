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
        private readonly IHubContext<ChatHub> _hubContext;

        public BidsController(IBidService bidService, IHubContext<ChatHub> hubContext)
        {
            _bidService = bidService;
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
            bid.AuctionId = auctionId;

            var createdBid = await _bidService.CreateBid(bid);

            var dto = await _bidService.GetBidById(createdBid.Id);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", dto.Amount);

            return Ok(dto);
        }
    }
}

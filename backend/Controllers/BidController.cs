using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using backend.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class BidController(BidService bidService) : ControllerBase
{
    private readonly BidService _bidService = bidService;

    [HttpGet]
    public async Task<IEnumerable<BidDTO>> GetAllBidsAsync(int auctionId)
    {
        return await _bidService.GetAllBidsAsync(auctionId);
    }

    [HttpPost]
    public async Task<ActionResult<BidDTO>> AddBidAsync(BidRegistrationDTO bidRegistrationDTO)
    {
        var bidDTO = await _bidService.AddBidAsync(bidRegistrationDTO);
        if (bidDTO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetBid), new { id = bidDTO.Id }, bidDTO);
    }
}

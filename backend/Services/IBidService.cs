using backend.Models;
using backend.DTOs;

namespace backend.Services
{
  public interface IBidService
  {
    Task<IEnumerable<BidDTO>> GetAllBidsForAuctionAsync(int auctionId);
    Task<BidDTO> AddBidAsync(BidRegistrationDTO bidRegistrationDTO);
  }
}
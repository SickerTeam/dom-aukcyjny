using backend.Models;
using backend.DTOs;

namespace backend.Repositories
{
  public interface IBidService
  {
    Task<IEnumerable<BidDTO>> GetAllBidsForAuctionAsync(int auctionId);
    Task AddBidAsync(BidRegistrationDTO bidRegistrationDTO);
  }
}
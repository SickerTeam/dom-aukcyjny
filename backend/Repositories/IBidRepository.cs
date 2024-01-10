using backend.Data.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IBidRepository
    {
        Task<List<BidDTO>> GetAllBidsForAuction(int auctionId);
        Task<DbBid> CreateBidAsync(BidCreationDTO bid);
        Task<BidDTO> GetBidById(int bidId);
    }
}
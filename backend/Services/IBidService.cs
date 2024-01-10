using backend.Data.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IBidService
    {
        Task<List<BidDTO>> GetAllBidsForAuction(int auctionId);
        Task<DbBid> CreateBid(BidCreationDTO bid);
        Task<BidDTO> GetBidById(int bidId);
    }
}
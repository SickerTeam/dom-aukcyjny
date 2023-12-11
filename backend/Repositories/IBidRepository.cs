using backend.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IBidRepository
    {
        Task<IEnumerable<Bid>> GetAllBidsAsync(int auctionId);
        Task AddBidAsync(Bid bid);
    }
}

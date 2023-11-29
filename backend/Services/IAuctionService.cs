using backend.DTOs;

namespace backend.Services
{
    public interface IAuctionService
    {
        AuctionDTO GetAuctionById(int id);
        Task<IEnumerable<AuctionDTO>> GetAuctions();
        AuctionDTO CreateAuction();

    }
}

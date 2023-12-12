using backend.Data.Models;
using backend.Models;
using backend.DTOs; 

namespace backend.Repositories
{
    public interface IAuctionRepository
    {
        Task<IList<DbAuction>> GetAuctionsAsync();
        Task<DbAuction> GetAuctionByIdAsync(int id);
        Task<DbAuction> CreateAuctionAsync(AuctionCreationDTO auction, int productId);
        Task UpdateAuctionAsync(Auction auction);
        Task DeleteAuctionAsync(int id);
    }
}

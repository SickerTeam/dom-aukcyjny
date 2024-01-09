using backend.Data.Models;

namespace backend.Repositories
{
    public interface IAuctionRepository
    {
        Task<IList<DbAuction>> GetAuctionsAsync();
        Task<DbAuction> GetAuctionByIdAsync(int id);
        Task<DbAuction> CreateAuctionAsync(DbAuction auction);
        Task UpdateAuctionAsync(DbAuction auction);
        Task DeleteAuctionAsync(int id);
    }
}

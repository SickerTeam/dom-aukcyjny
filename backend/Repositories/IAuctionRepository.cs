using backend.Data.Models;

namespace backend.Repositories
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<DbAuction>> GetAuctionsAsync();
        Task<DbAuction> GetAuctionByIdAsync(int id);
        Task<DbAuction> CreateAuctionAsync(DbAuction auction);
        Task UpdateAuctionAsync(DbAuction auction);
        Task DeleteAuctionAsync(DbAuction auction);
    }
}

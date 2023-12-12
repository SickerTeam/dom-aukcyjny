using backend.DTOs;
using backend.Data.Models;

namespace backend.Services
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionDTO>> GetAuctionsAsync();
        Task<AuctionDTO> GetAuctionByIdAsync(int id);
        Task<DbAuction> CreateAuctionAsync(AuctionCreationDTO auction);
        Task UpdateAuctionAsync(AuctionDTO auctionDto);
        Task DeleteAuctionsAsync(int id);
    }
}

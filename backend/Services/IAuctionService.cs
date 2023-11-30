using backend.DTOs;

namespace backend.Services
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionDTO>> GetAuctionsAsync();
        Task<AuctionDTO> GetAuctionByIdAsync(int id);
        Task AddAuctionAsync(AuctionDTO auctionDto);
        Task UpdateAuctionAsync(AuctionDTO auctionDto);
        Task DeleteAuctionsAsync(int id);
    }
}

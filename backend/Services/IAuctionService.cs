using backend.DTOs;
using backend.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionDTO>> GetAuctionsAsync();
        Task<AuctionDTO> GetAuctionByIdAsync(int id);
        Task<AuctionDTO> CreateAuctionAsync(AuctionCreationDTO auction);
        Task<AuctionDTO?> UpdateAuctionAsync(int id, JsonPatchDocument<AuctionDTO> patchDoc);
        Task DeleteAuctionsAsync(int id);
    }
}

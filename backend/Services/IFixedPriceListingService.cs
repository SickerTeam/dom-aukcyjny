using backend.Data.Models;
using backend.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public interface IFixedPriceListingService
    {
        Task<DbFixedPriceListing> AddFixedPriceListingAsync(FixedPriceListingCreationDTO fixedPriceListingDto);
        Task<FixedPriceListingDTO?> UpdateFixedPriceListingAsync(int id, JsonPatchDocument<FixedPriceListingDTO> patchDoc);
        Task DeleteFixedPriceListingAsync(int id);
        Task<IEnumerable<FixedPriceListingDTO>> GetAllFixedPriceListingsAsync();
        Task<FixedPriceListingDTO> GetFixedPriceListingByIdAsync(int id);
    }
}

using backend.DTOs;

namespace backend.Services
{
    public interface IFixedPriceListingService
    {
        Task AddFixedPriceListingAsync(FixedPriceListingCreationDTO fixedPriceListingDto);
        Task UpdateFixedPriceListingAsync(FixedPriceListingDTO fixedPriceListingDto);
        Task DeleteFixedPriceListingAsync(int id);
        Task<IEnumerable<FixedPriceListingDTO>> GetAllFixedPriceListingsAsync();
        Task<FixedPriceListingDTO> GetFixedPriceListingByIdAsync(int id);
    }
}

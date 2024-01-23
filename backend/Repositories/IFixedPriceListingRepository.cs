using backend.Data.Models;

namespace backend.Repositories
{
    public interface IFixedPriceListingRepository
    {
        Task<DbFixedPriceListing> AddFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing);
        Task UpdateFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing);
        Task DeleteFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing);
        Task<DbFixedPriceListing> GetFixedPriceListingByIdAsync(int id);
        Task<int> GetNumberOfFixedPriceListingsAsync();
        Task<IEnumerable<DbFixedPriceListing>> GetAllFixedPriceListingsAsync();
    }
}

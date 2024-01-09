using backend.Data.Models;

namespace backend.Repositories
{
    public interface IFixedPriceListingRepository
    {
        Task AddFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing);
        Task UpdateFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing);
        Task DeleteFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing);
        Task<DbFixedPriceListing> GetFixedPriceListingByIdAsync(int id);
        Task<IEnumerable<DbFixedPriceListing>> GetAllFixedPriceListingsAsync();
    }
}

using backend.DTOs;
using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IFixedPriceListingRepository
    {
        Task AddFixedPriceListingAsync(FixedPriceListing fixedPriceListing);
        Task UpdateFixedPriceListingAsync(FixedPriceListing fixedPriceListing);
        Task DeleteFixedPriceListingAsync(int id);
        Task<FixedPriceListing> GetFixedPriceListingByIdAsync(int id);
        Task<IEnumerable<FixedPriceListing>> GetAllFixedPriceListingsAsync();
    }
}

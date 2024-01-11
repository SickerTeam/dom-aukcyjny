using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
public class FixedPriceListingRepository(DatabaseContext context) : IFixedPriceListingRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<DbFixedPriceListing>> GetAllFixedPriceListingsAsync()
        {
            return await _context.FixedPriceListings
            .Include(fixedPriceListing => fixedPriceListing.Product)
            .Include(fixedPriceListing => fixedPriceListing.Product.Seller)
            .ToListAsync();
        }

        public async Task<DbFixedPriceListing> AddFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing)
        {
            await _context.FixedPriceListings.AddAsync(fixedPriceListing);
            await _context.SaveChangesAsync();
            return fixedPriceListing;
        }

        public async Task UpdateFixedPriceListingAsync(DbFixedPriceListing listing)
        {
            _context.FixedPriceListings.Update(listing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFixedPriceListingAsync(DbFixedPriceListing listing)
        {
            _context.FixedPriceListings.Remove(listing);
            await _context.SaveChangesAsync();
        }

        public async Task<DbFixedPriceListing> GetFixedPriceListingByIdAsync(int id)
        {
            DbFixedPriceListing? listing = await _context.FixedPriceListings.Where(x => x.Id == id)
                .Include(fixedPriceListing => fixedPriceListing.Product)
                .Include(fixedPriceListing => fixedPriceListing.Product.Seller)
                .FirstOrDefaultAsync();
                
            return listing ?? throw new ArgumentException("Fixed price listing not found");
        }
    }
}

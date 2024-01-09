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

        public async Task AddFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing)
        {
            _context.FixedPriceListings.Add(fixedPriceListing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFixedPriceListingAsync(DbFixedPriceListing fixedPriceListing)
        {
            _context.FixedPriceListings.Update(fixedPriceListing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFixedPriceListingAsync(int id)
        {
            var fixedPriceListing = await _context.FixedPriceListings.FindAsync(id)  ?? throw new ArgumentException("FixedPriceListing not found");

            _context.FixedPriceListings.Remove(fixedPriceListing);
            await _context.SaveChangesAsync();
        }

        public async Task<DbFixedPriceListing> GetFixedPriceListingByIdAsync(int id)
        {
            var fixedPriceListing = await _context.FixedPriceListings.Where(x => x.Id == id)
                .Include(fixedPriceListing => fixedPriceListing.Product)
                .Include(fixedPriceListing => fixedPriceListing.Product.Seller)
                .FirstOrDefaultAsync();
                
            return fixedPriceListing ?? throw new ArgumentException("FixedPriceListing not found");
        }
    }
}

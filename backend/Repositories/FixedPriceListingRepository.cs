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
            return await _context.FixedPriceListings.Include(fixedPriceListing => fixedPriceListing.Product)
            .ThenInclude(product => product.Artist)
            .ToListAsync();
        }

        public async Task AddFixedPriceListingAsync(FixedPriceListing fixedPriceListing)
        {
            _context.FixedPriceListings.Add(fixedPriceListing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFixedPriceListingAsync(FixedPriceListing fixedPriceListing)
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

        public async Task<FixedPriceListing> GetFixedPriceListingByIdAsync(int id)
        {
            var fixedPriceListing = await _context.FixedPriceListings.Where(x => x.Id == id)
            .Include(fixedPriceListing => fixedPriceListing.Product)
            .ThenInclude(product => product.Artist)
            .FirstOrDefaultAsync();
            return fixedPriceListing ?? throw new ArgumentException("FixedPriceListing not found");
        }
    }
}

using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AuctionRepository(DatabaseContext context) : IAuctionRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<DbAuction>> GetAuctionsAsync()
        {
            return await _context.Auctions
                .Include(auction => auction.Product)
                .Include(auction => auction.Product != null ? auction.Product.Seller : null)
                .ToListAsync();
        }

        public async Task<DbAuction> GetAuctionByIdAsync(int id)
        {
            var auction = await _context.Auctions
                .Where(x => x.Id == id)
                .Include(auction => auction.Product)
                .Include(auction => auction.Product != null ? auction.Product.Seller : null)
                .FirstOrDefaultAsync();

            return auction ?? throw new ArgumentException("Auction not found");
        }

        public async Task<DbAuction> CreateAuctionAsync(DbAuction dbAuction)
        {
            await _context.Auctions.AddAsync(dbAuction);
            await _context.SaveChangesAsync();

            return dbAuction;
        }

        public async Task UpdateAuctionAsync(DbAuction auction)
        {
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuctionAsync(int id)
        {
            var auction = await _context.Auctions.FindAsync(id) ?? throw new ArgumentException("Auction not found");
            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();
        }
    }
}

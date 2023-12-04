using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AuctionRepository(DatabaseContext context) : IAuctionRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<Auction>> GetAuctionsAsync()
        {
            return await _context.Auctions.Include(a => a.Product).ToListAsync();
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            return auction ?? throw new ArgumentException("Auction not found");
        }

         public async Task AddAuctionAsync(Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuctionAsync(Auction auction)
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

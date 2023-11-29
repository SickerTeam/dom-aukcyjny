using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DatabaseContext _context;

        public AuctionRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Task AddAuctionAsync(Auction auction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuctionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            return await _context.Auctions.FindAsync(id);
        }

        public async Task<IEnumerable<Auction>> GetAuctionsAsync()
        {
            return await _context.Auctions.ToListAsync();
        }

        public Task UpdateAuctionAsync(Auction auction)
        {
            throw new NotImplementedException();
        }
    }
}

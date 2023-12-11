
using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.DTOs;

namespace backend.Repositories
{
public class BidRepository(DatabaseContext context) : IBidRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<Bid>> GetAllBidsAsync(int auctionId)
        {
            return await _context.Bids.Where(b => b.AuctionId == auctionId).ToListAsync();
        }

        public async Task AddBidAsync(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }
    }
}

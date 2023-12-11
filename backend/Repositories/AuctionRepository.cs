using backend.Data;
using backend.Data.Models;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AuctionRepository(DatabaseContext context) : IAuctionRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IList<DbAuction>> GetAuctionsAsync()
        {
            return await _context.Auction
                .Include(auction => auction.Product)
                .ToListAsync();
        }

        public async Task<DbAuction> GetAuctionByIdAsync(int id)
        {
            var auction = await _context.Auction
                .Where(x => x.Id == id)
                .Include(auction => auction.Product)
                .FirstOrDefaultAsync();

            return auction ?? throw new ArgumentException("Auction not found");
        }

        public async Task<DbAuction> CreateAuctionAsync(AuctionCreationDTO auction, int productId)
        {
            var dbAuction = new DbAuction
            {
                EndsAt = auction.EndsAt,
                EstimatedMinimum = auction.EstimatedMinimum,
                EstimatedMaximum = auction.EstimatedMaximum,
                StartingPrice = auction.StartingPrice,
                MinimumPrice = auction.MinimumPrice,
                ProductId = productId,
            };

            await _context.Auction.AddAsync(dbAuction);
            await _context.SaveChangesAsync();

            return dbAuction;
        }

        public async Task UpdateAuctionAsync(Auction auction)
        {
            // _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuctionAsync(int id)
        {
            var auction = await _context.Auction.FindAsync(id) ?? throw new ArgumentException("Auction not found");
            _context.Auction.Remove(auction);
            await _context.SaveChangesAsync();
        }
    }
}

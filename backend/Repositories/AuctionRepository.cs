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
            return await _context.Auctions
                .Include(auction => auction.Product)
                .Include(auction => auction.Product.Seller)
                .Include(auction => auction.Bids)
                .ToListAsync();
        }

        public async Task<DbAuction> GetAuctionByIdAsync(int id)
        {
            var auction = await _context.Auctions
                .Where(x => x.Id == id)
                .Include(auction => auction.Product)
                .Include(auction => auction.Product.Seller)
                .FirstOrDefaultAsync();

            return auction ?? throw new ArgumentException("Auction not found");
        }

        public async Task<DbAuction> CreateAuctionAsync(AuctionCreationDTO auction, int productId)
        {
            var dbAuction = new DbAuction
            {
                EndsAt = auction.EndsAt,
                EstimateMinPrice = auction.EstimatedMinimum,
                EstimateMaxPrice = auction.EstimatedMaximum,
                StartingPrice = auction.StartingPrice,
                ReservePrice = auction.MinimumPrice,
                ProductId = productId,
            };

            await _context.Auctions.AddAsync(dbAuction);
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
            var auction = await _context.Auctions.FindAsync(id) ?? throw new ArgumentException("Auction not found");
            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();
        }
    }
}

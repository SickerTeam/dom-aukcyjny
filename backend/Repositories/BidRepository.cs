using AutoMapper;
using AutoMapper.QueryableExtensions;
using backend.Data;
using backend.Data.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BidRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BidDTO>> GetAllBidsForAuction(int auctionId)
        {
            var bids = await _context.Bids
                .Where(x => x.AuctionId == auctionId)
                .Include(x => x.Auction)
                .Include(x => x.User)
                .ToListAsync();

            return _mapper.Map<List<BidDTO>>(bids);
        }

        public async Task<DbBid> CreateBidAsync(BidCreationDTO bid)
        {
            var dbBid = new DbBid
            {
                UserId = bid.UserId,
                AuctionId = bid.AuctionId,
                Amount = bid.Amount
            };

            await _context.Bids.AddAsync(dbBid);
            await _context.SaveChangesAsync();

            return dbBid;
        }

        public async Task<BidDTO> GetBidById(int bidId)
        {
            var bid = await _context.Bids
                .Where(x => x.Id == bidId)
                .Include(x => x.Auction)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            return _mapper.Map<BidDTO>(bid);
        }
    }
}
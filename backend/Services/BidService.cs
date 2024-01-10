using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Repositories;

namespace backend.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;

        public BidService(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }

        public async Task<List<BidDTO>> GetAllBidsForAuction(int auctionId)
        {
            return await _bidRepository.GetAllBidsForAuction(auctionId);
        }

        public async Task<DbBid> CreateBid(BidCreationDTO bid)
        {
            return await _bidRepository.CreateBidAsync(bid);
        }

        public async Task<BidDTO> GetBidById(int bidId)
        {
            return await _bidRepository.GetBidById(bidId);
        }
    }
}
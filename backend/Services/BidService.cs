using System.Runtime.CompilerServices;
using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
   public class BidService(IBidRepository bidRepository, IMapper mapper) : IBidService
   {
        private readonly IBidRepository _bidRepository = bidRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BidDTO>> GetAllBidsForAuctionAsync(int auctionId)
        {
            var bids = await _bidRepository.GetAllBidsAsync(auctionId);
            return _mapper.Map<IEnumerable<BidDTO>>(bids);
        }

        public async Task AddBidAsync(BidRegistrationDTO bidRegistrationDTO)
        {
           Bid bid = _mapper.Map<Bid>(bidRegistrationDTO);
           bid.PlacedAt = DateTime.Now;
           await _bidRepository.AddBidAsync(bid);
        }
    }
}
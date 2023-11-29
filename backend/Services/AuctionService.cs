using AutoMapper;
using backend.DTOs;
using backend.Repositories;

namespace backend.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public AuctionService(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public AuctionDTO CreateAuction()
        {
            throw new NotImplementedException();
        }

        public AuctionDTO GetAuctionById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuctionDTO>> GetAuctions()
        {
            var auctions = await _auctionRepository.GetAuctionsAsync();
            var auctionDTOs = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
            return auctionDTOs;
        }
    }
}

using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
   public class AuctionService(IAuctionRepository auctionRepository, IMapper mapper) : IAuctionService
   {
        private readonly IAuctionRepository _auctionRepository = auctionRepository;
        private readonly IMapper _mapper = mapper;

            public async Task<IEnumerable<AuctionDTO>> GetAuctionsAsync()
        {
            var auctions = await _auctionRepository.GetAuctionsAsync();
            var auctionDTOs = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
            return auctionDTOs;
        }

        public async Task<AuctionDTO> GetAuctionByIdAsync(int id)
        {
            Auction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            return _mapper.Map<AuctionDTO>(auction);
        }

        public async Task AddAuctionAsync(AuctionRegistrationDTO auctionDto)
        {
           var auction = _mapper.Map<Auction>(auctionDto);
           auction.CreatedAt = DateTime.Now;
           auction.IsArchived = false;
           await _auctionRepository.AddAuctionAsync(auction);
        }  

        public async Task UpdateAuctionAsync(AuctionDTO auctionDto)
        {
            var auction = await _auctionRepository.GetAuctionByIdAsync(auctionDto.Id);
            if (auction == null) return;

            _mapper.Map(auctionDto, auction);

            await _auctionRepository.UpdateAuctionAsync(auction);
        } 

        public async Task DeleteAuctionsAsync(int id)
        {
            var auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return;
            if (auction.Id != null)
            {
                await _auctionRepository.DeleteAuctionAsync((int)auction.Id);
            }
        }
    }
}
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

        public async Task AddAuctionAsync(AuctionDTO auctionDto)
        {
            var auction = new Auction
            {
                CreatedAt = auctionDto.CreatedAt,
                EndsAt = auctionDto.EndsAt,
                FirstPrice = (decimal)auctionDto.FirstPrice,
                EstimatedMinimum = auctionDto.EstimatedMinimum.HasValue 
                    ? (decimal)auctionDto.EstimatedMinimum.Value 
                    : null,
                EstimatedMaximum = auctionDto.EstimatedMaximum.HasValue 
                    ? (decimal)auctionDto.EstimatedMaximum.Value 
                    : null,
                IsArchived = auctionDto.IsArchived,
                ProductId = auctionDto.Product?.Id
            };

            await _auctionRepository.AddAuctionAsync(auction);
        }   

        public async Task UpdateAuctionAsync(AuctionDTO auctionDto)
        {
            var auction = await _auctionRepository.GetAuctionByIdAsync(auctionDto.Id);
            if (auction == null) return;

            auction.CreatedAt = auctionDto.CreatedAt;
            auction.EndsAt = auctionDto.EndsAt;
            auction.FirstPrice = (decimal)auctionDto.FirstPrice;
            auction.EstimatedMinimum = auctionDto.EstimatedMinimum.HasValue 
                ? (decimal)auctionDto.EstimatedMinimum.Value 
                : null;
            auction.EstimatedMaximum = auctionDto.EstimatedMaximum.HasValue 
                ? (decimal)auctionDto.EstimatedMaximum.Value 
                : null;
            auction.IsArchived = auctionDto.IsArchived;
            auction.ProductId = auctionDto.Product?.Id;

            await _auctionRepository.UpdateAuctionAsync(auction);
        }  

        public async Task DeleteAuctionsAsync(int id)
        {
            var auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return;
            await _auctionRepository.DeleteAuctionAsync(auction.Id);
        }
     }
}

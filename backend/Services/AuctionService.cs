using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;

namespace backend.Services
{
   public class AuctionService(IAuctionRepository auctionRepository, IMapper mapper, IProductRepository productRepository) : IAuctionService
   {
        private readonly IAuctionRepository _auctionRepository = auctionRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AuctionDTO>> GetAuctionsAsync()
        {
            var auctions = await _auctionRepository.GetAuctionsAsync();
            return  _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
        }

        public async Task<AuctionDTO> GetAuctionByIdAsync(int id)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            return _mapper.Map<AuctionDTO>(auction);
        }

        public async Task<DbAuction> CreateAuctionAsync(AuctionCreationDTO auctionDto)
        {
            var product = await _productRepository.CreateProductAsync(auctionDto.Product);

            var dbAuction = new DbAuction
            {
                EndsAt = auctionDto.EndsAt,
                EstimateMinPrice = auctionDto.EstimatedMinimum,
                EstimateMaxPrice = auctionDto.EstimatedMaximum,
                StartingPrice = auctionDto.StartingPrice,
                ReservePrice = auctionDto.MinimumPrice,
                ProductId = product.Id,
            };

            return await _auctionRepository.CreateAuctionAsync(dbAuction);
        }

        public async Task UpdateAuctionAsync(AuctionDTO auctionDto)
        {
            var auction = await _auctionRepository.GetAuctionByIdAsync(auctionDto.Id);
            if (auction == null) return;

            await _auctionRepository.UpdateAuctionAsync(_mapper.Map<DbAuction>(auctionDto));
        } 

        public async Task DeleteAuctionsAsync(int id)
        {
            var auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return;
            await _auctionRepository.DeleteAuctionAsync(auction.Id);
        }
    }
}
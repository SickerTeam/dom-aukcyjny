using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;

namespace backend.Services
{
   public class AuctionService(IAuctionRepository auctionRepository, IMapper mapper, IProductService productService) : IAuctionService
   {
        private readonly IAuctionRepository _auctionRepository = auctionRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AuctionDTO>> GetAuctionsAsync()
        {
            IEnumerable<DbAuction> auctions = await _auctionRepository.GetAuctionsAsync();
            return  _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
        }

        public async Task<AuctionDTO> GetAuctionByIdAsync(int id)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            return _mapper.Map<AuctionDTO>(auction);
        }

        public async Task<AuctionDTO> CreateAuctionAsync(AuctionCreationDTO auctionDto)
        {
            ProductDTO product = await _productService.AddProductAsync(auctionDto.Product);

            DbAuction dbAuction = new()
            {
                EndsAt = auctionDto.EndsAt,
                CreatedAt = DateTime.Now,
                EstimateMinPrice = auctionDto.EstimatedMinimum,
                EstimateMaxPrice = auctionDto.EstimatedMaximum,
                StartingPrice = auctionDto.StartingPrice,
                ReservePrice = auctionDto.MinimumPrice,
                ProductId = product.Id,
                IsArchived = false
            };

            DbAuction auction = await _auctionRepository.CreateAuctionAsync(dbAuction);
            return _mapper.Map<AuctionDTO>(auction);
        }

        public async Task UpdateAuctionAsync(AuctionDTO auctionDto)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(auctionDto.Id);
            if (auction == null) return;

            _mapper.Map(auctionDto, auction);
            await _auctionRepository.UpdateAuctionAsync(auction);
        } 

        public async Task DeleteAuctionsAsync(int id)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return;
            
            await _auctionRepository.DeleteAuctionAsync(auction.Id);
        }
    }
}
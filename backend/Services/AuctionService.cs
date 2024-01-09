using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;

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
                EndsAt = DateTime.UtcNow.AddDays(14),
                CreatedAt = DateTime.UtcNow,
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

        public async Task<AuctionDTO?> UpdateAuctionAsync(int id, JsonPatchDocument<AuctionDTO> patchDoc)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null)
            {
                return null;
            }

            AuctionDTO auctionDto = _mapper.Map<AuctionDTO>(auction);
            patchDoc.ApplyTo(auctionDto);

            _mapper.Map(auctionDto, auction);
            await _auctionRepository.UpdateAuctionAsync(auction);

            return _mapper.Map<AuctionDTO>(auction);
        } 

        public async Task DeleteAuctionsAsync(int id)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return;

            await _auctionRepository.DeleteAuctionAsync(auction.Id);
        }
    }
}
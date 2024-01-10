using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
   public class AuctionService(IAuctionRepository auctionRepository, IMapper mapper, IProductService productService) : IAuctionService
   {
        private readonly IAuctionRepository _auctionRepository = auctionRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;
        protected internal ModelStateDictionary modelState = new();

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
            DbAuction dbAuction = _mapper.Map<DbAuction>(auctionDto);

            dbAuction.EndsAt = DateTime.UtcNow.AddDays(14);
            dbAuction.CreatedAt = DateTime.UtcNow;
            dbAuction.EstimateMinPrice = auctionDto.EstimatedMinimum;
            dbAuction.EstimateMaxPrice = auctionDto.EstimatedMaximum;
            dbAuction.StartingPrice = auctionDto.StartingPrice;
            dbAuction.ReservePrice = auctionDto.MinimumPrice;
            dbAuction.IsArchived = false;

            DbAuction auction = await _auctionRepository.CreateAuctionAsync(dbAuction);
            return _mapper.Map<AuctionDTO>(auction);
        }

        public async Task<AuctionDTO?> UpdateAuctionAsync(int id, JsonPatchDocument<AuctionDTO> patchDoc)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return null;
            
            foreach (var operation in patchDoc.Operations)
            {
                if (operation.path == "id" || operation.path == "createdAt" ||
                    operation.path.StartsWith("/product/seller") || operation.path.StartsWith("/product/sellerId") ||
                    operation.op != "replace")
                {
                    throw new InvalidOperationException("Updating one or more fields is not allowed.");
                }
            }

            AuctionDTO auctionDto = _mapper.Map<AuctionDTO>(auction);
            patchDoc.ApplyTo(auctionDto, modelState);

            if (!modelState.IsValid) return null;

            _mapper.Map(auctionDto, auction);
            await _auctionRepository.UpdateAuctionAsync(auction);

            return _mapper.Map<AuctionDTO>(auction);
        } 

        public async Task DeleteAuctionsAsync(int id)
        {
            DbAuction auction = await _auctionRepository.GetAuctionByIdAsync(id);
            if (auction == null) return;

            await _auctionRepository.DeleteAuctionAsync(auction);
        }
    }
}
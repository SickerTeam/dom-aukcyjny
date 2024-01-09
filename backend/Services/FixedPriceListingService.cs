using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public class FixedPriceListingService(IFixedPriceListingRepository fixedPriceListingRepository, IMapper mapper, IProductService productService) : IFixedPriceListingService
    {
        private readonly IFixedPriceListingRepository _fixedPriceListingRepository = fixedPriceListingRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<FixedPriceListingDTO>> GetAllFixedPriceListingsAsync()
        {
            IEnumerable<DbFixedPriceListing> fixedPriceListings = await _fixedPriceListingRepository.GetAllFixedPriceListingsAsync();
            return _mapper.Map<IEnumerable<FixedPriceListingDTO>>(fixedPriceListings);
        }

        public async Task<FixedPriceListingDTO> GetFixedPriceListingByIdAsync(int id)
        {
            DbFixedPriceListing fixedPriceListing = await _fixedPriceListingRepository.GetFixedPriceListingByIdAsync(id);
            return _mapper.Map<FixedPriceListingDTO>(fixedPriceListing);
        }

        public async Task AddFixedPriceListingAsync(FixedPriceListingCreationDTO fixedPriceListingDto)
        {
            DbFixedPriceListing fixedPriceListing = _mapper.Map<DbFixedPriceListing>(fixedPriceListingDto);
            fixedPriceListing.IsArchived = false;
            fixedPriceListing.CreatedAt = DateTime.UtcNow;
            fixedPriceListing.Product = await _productService.GetProductByIdAsync(fixedPriceListingDto.ProductId);
            await _fixedPriceListingRepository.AddFixedPriceListingAsync(fixedPriceListing);
        }

        public async Task<FixedPriceListingDTO?> UpdateFixedPriceListingAsync(int id, JsonPatchDocument<FixedPriceListingDTO> patchDoc)
        {
            DbFixedPriceListing fixedPriceListing = await _fixedPriceListingRepository.GetFixedPriceListingByIdAsync(id);
            if (fixedPriceListing == null)
            {
                return null;
            }

            FixedPriceListingDTO fixedPriceListingDto = _mapper.Map<FixedPriceListingDTO>(fixedPriceListing);
            patchDoc.ApplyTo(fixedPriceListingDto);

            _mapper.Map(fixedPriceListingDto, fixedPriceListing);
            await _fixedPriceListingRepository.UpdateFixedPriceListingAsync(fixedPriceListing);

            return _mapper.Map<FixedPriceListingDTO>(fixedPriceListing);
        }

        public async Task DeleteFixedPriceListingAsync(int id)
        {
            DbFixedPriceListing insta = await _fixedPriceListingRepository.GetFixedPriceListingByIdAsync(id);
            if (insta == null) return;

            await _fixedPriceListingRepository.DeleteFixedPriceListingAsync(id);
        }
    }
}

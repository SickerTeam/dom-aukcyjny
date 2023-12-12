using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class FixedPriceListingService(IFixedPriceListingRepository fixedPriceListingRepository, IMapper mapper, IProductService productService) : IFixedPriceListingService
    {
        private readonly IFixedPriceListingRepository _fixedPriceListingRepository = fixedPriceListingRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<FixedPriceListingDTO>> GetAllFixedPriceListingsAsync()
        {
            var fixedPriceListings = await _fixedPriceListingRepository.GetAllFixedPriceListingsAsync();
            return _mapper.Map<IEnumerable<FixedPriceListingDTO>>(fixedPriceListings);
        }

        public async Task<FixedPriceListingDTO> GetFixedPriceListingByIdAsync(int id)
        {
            var fixedPriceListing = await _fixedPriceListingRepository.GetFixedPriceListingByIdAsync(id);
            return _mapper.Map<FixedPriceListingDTO>(fixedPriceListing);
        }

        public async Task AddFixedPriceListingAsync(FixedPriceListingRegistrationDTO fixedPriceListingDto)
        {
            var fixedPriceListing = _mapper.Map<FixedPriceListing>(fixedPriceListingDto);
            fixedPriceListing.IsArchived = false;
            fixedPriceListing.CreatedAt = DateTime.Now;
            // fixedPriceListing.Product = await _productService.GetModelById(fixedPriceListingDto.ProductId);
            await _fixedPriceListingRepository.AddFixedPriceListingAsync(fixedPriceListing);
        }

        public async Task UpdateFixedPriceListingAsync(FixedPriceListingDTO fixedPriceListingDto)
        {
            var fixedPriceListing = await _fixedPriceListingRepository.GetFixedPriceListingByIdAsync((int)fixedPriceListingDto.Id);
            if (fixedPriceListing == null) return;

            _mapper.Map(fixedPriceListingDto, fixedPriceListing);
            await _fixedPriceListingRepository.UpdateFixedPriceListingAsync(fixedPriceListing);
        }

        public async Task DeleteFixedPriceListingAsync(int id)
        {
            var insta = await _fixedPriceListingRepository.GetFixedPriceListingByIdAsync(id);
            if (insta != null) {
                await _fixedPriceListingRepository.DeleteFixedPriceListingAsync(id);
            }
        }
    }
}

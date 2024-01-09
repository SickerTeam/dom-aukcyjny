using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public class FixedPriceListingService(IFixedPriceListingRepository listingRepository, IMapper mapper, IProductService productService) : IFixedPriceListingService
    {
        private readonly IFixedPriceListingRepository _listingRepository = listingRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<FixedPriceListingDTO>> GetAllFixedPriceListingsAsync()
        {
            IEnumerable<DbFixedPriceListing> listings = await _listingRepository.GetAllFixedPriceListingsAsync();
            return _mapper.Map<IEnumerable<FixedPriceListingDTO>>(listings);
        }

        public async Task<FixedPriceListingDTO> GetFixedPriceListingByIdAsync(int id)
        {
            DbFixedPriceListing fixedPriceListing = await _listingRepository.GetFixedPriceListingByIdAsync(id);
            return _mapper.Map<FixedPriceListingDTO>(fixedPriceListing);
        }

        public async Task AddFixedPriceListingAsync(FixedPriceListingCreationDTO listingDto)
        {
            DbFixedPriceListing listing = _mapper.Map<DbFixedPriceListing>(listingDto);
            listing.IsArchived = false;
            listing.CreatedAt = DateTime.UtcNow;
            listing.Product = await _productService.GetProductByIdAsync(listingDto.ProductId);
            await _listingRepository.AddFixedPriceListingAsync(listing);
        }

        public async Task<FixedPriceListingDTO?> UpdateFixedPriceListingAsync(int id, JsonPatchDocument<FixedPriceListingDTO> patchDoc)
        {
            DbFixedPriceListing listing = await _listingRepository.GetFixedPriceListingByIdAsync(id);
            if (listing == null) return null;

            FixedPriceListingDTO listingDto = _mapper.Map<FixedPriceListingDTO>(listing);
            patchDoc.ApplyTo(listingDto);

            foreach (var operation in patchDoc.Operations)
            {
                if (operation.path.StartsWith("/product/seller") || operation.path.StartsWith("/product/sellerId"))
                {
                    throw new InvalidOperationException("Updating the Seller information is not allowed.");
                }
            }

            _mapper.Map(listingDto, listing);
            await _listingRepository.UpdateFixedPriceListingAsync(listing);

            return _mapper.Map<FixedPriceListingDTO>(listing);
        }

        public async Task DeleteFixedPriceListingAsync(int id)
        {
            DbFixedPriceListing listing = await _listingRepository.GetFixedPriceListingByIdAsync(id);
            if (listing == null) return;

            await _listingRepository.DeleteFixedPriceListingAsync(listing);
        }
    }
}

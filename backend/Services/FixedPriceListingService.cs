using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class FixedPriceListingService(IFixedPriceListingRepository listingRepository, IMapper mapper, IProductService productService) : IFixedPriceListingService
    {
        private readonly IFixedPriceListingRepository _listingRepository = listingRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;
        protected internal ModelStateDictionary modelState = new();

        public async Task<IEnumerable<FixedPriceListingDTO>> GetAllFixedPriceListingsAsync()
        {
            IEnumerable<DbFixedPriceListing> listings = await _listingRepository.GetAllFixedPriceListingsAsync();

            var listingDtos = new List<FixedPriceListingDTO>();

            foreach (var listing in listings)
            {
                var listingDto = _mapper.Map<FixedPriceListingDTO>(listing);

                if (listing.ProductId.HasValue)
                {
                    var productDto = await _productService.GetProductByIdAsync(listing.ProductId.Value);
                    listingDto.Product = productDto;
                    listingDtos.Add(listingDto);
                }
            }

            return listingDtos;
        }

        public async Task<FixedPriceListingDTO> GetFixedPriceListingByIdAsync(int id)
        {
            DbFixedPriceListing listing = await _listingRepository.GetFixedPriceListingByIdAsync(id);
            var listingDto = _mapper.Map<FixedPriceListingDTO>(listing);

            if (listing.ProductId.HasValue)
            {
                var productDto = await _productService.GetProductByIdAsync(listing.ProductId.Value);
                listingDto.Product = productDto;
            }

            return listingDto;
        }

        public async Task<int> GetNumberOfFixedPriceListingsAsync()
        {
            return await _listingRepository.GetNumberOfFixedPriceListingsAsync();
        }

        public async Task<DbFixedPriceListing> AddFixedPriceListingAsync(FixedPriceListingCreationDTO fixedPriceListingDto)
        {
            var fixedPriceListing = _mapper.Map<DbFixedPriceListing>(fixedPriceListingDto);
            fixedPriceListing.IsArchived = false;
            fixedPriceListing.CreatedAt = DateTime.Now;
            return await _listingRepository.AddFixedPriceListingAsync(fixedPriceListing);
        }

        public async Task<FixedPriceListingDTO?> UpdateFixedPriceListingAsync(int id, JsonPatchDocument<FixedPriceListingDTO> patchDoc)
        {
            DbFixedPriceListing listing = await _listingRepository.GetFixedPriceListingByIdAsync(id);
            if (listing == null) return null;

            foreach (var operation in patchDoc.Operations)
            {
                if (operation.path == "id" || operation.path == "createdAt" ||
                    operation.path.StartsWith("/product/seller") || operation.path.StartsWith("/product/sellerId") ||
                    operation.op != "replace")
                {
                    throw new InvalidOperationException("Updating one or more fields is not allowed.");
                }
            }

            FixedPriceListingDTO listingDto = _mapper.Map<FixedPriceListingDTO>(listing);
            patchDoc.ApplyTo(listingDto, modelState);

            if (!modelState.IsValid) return null;

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

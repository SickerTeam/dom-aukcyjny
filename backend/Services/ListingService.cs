using backend.DTOs;
using backend.Repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace backend.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        public ListingDTO CreateListing()
        {
            throw new NotImplementedException();
        }

        public ListingDTO GetListing(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<ListingDTO> GetListings()
        {
            throw new NotImplementedException();
        }

        public ListingDTO UpdateListing()
        {
            throw new NotImplementedException();
        }

//        private ListingDTO MapToDTO(ListingDTO listing)
//        {
//            return _mapper.Map<ListingDTO>(listing);
//        }
    }
}

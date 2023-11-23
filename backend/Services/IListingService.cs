using backend.DTOs;

namespace backend.Services
{
    public interface IListingService
    {
        ListingDTO GetListing(int Id);
        IList<ListingDTO> GetListings();
        public ListingDTO CreateListing();
        public ListingDTO UpdateListing();

    }
}

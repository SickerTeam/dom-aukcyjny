using backend.Models;

namespace backend.Repository
{
    public interface IListingRepository
    {
        Listing Add(Listing listing);
        IList<Listing> GetAll();
        IList<Listing> Get(int id);
        Listing Update(Listing listing);
    }
}
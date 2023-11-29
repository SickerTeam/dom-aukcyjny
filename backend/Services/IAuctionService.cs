namespace backend.Services
{
    public interface IAuctionService
    {
        IList<AuctionDTO> GetAuctions();
        AuctionDTO CreateAuction();

    }
}

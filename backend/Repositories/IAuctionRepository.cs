﻿using backend.Models;

namespace backend.Repositories
{
    public interface IAuctionRepository
    {
        Task<IList<Auction>> GetAuctionsAsync();
        Task<Auction> GetAuctionByIdAsync(int id);
        Task AddAuctionAsync(Auction auction);
        Task UpdateAuctionAsync(Auction auction);
        Task DeleteAuctionAsync(int id);
    }
}

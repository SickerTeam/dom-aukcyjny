using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Auction, AuctionDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}

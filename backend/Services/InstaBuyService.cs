using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class InstaBuyService(IInstaBuyRepository instaBuyRepository) : IInstaBuyService
    {
        private readonly IInstaBuyRepository _instaBuyRepository = instaBuyRepository;

        public async Task<IEnumerable<InstaBuyDTO>> GetAllInstaBuysAsync()
        {
            var instaBuys = await _instaBuyRepository.GetAllInstaBuysAsync();
            return instaBuys.Select(i => new InstaBuyDTO(i.Id, i.ProductId, i.Price, i.IsArchived, i.CreatedAt));
        }

        public async Task<InstaBuyDTO> GetInstaBuyByIdAsync(int id)
        {
            var instaBuy = await _instaBuyRepository.GetInstaBuyByIdAsync(id);
            return new InstaBuyDTO(instaBuy.Id, instaBuy.ProductId, instaBuy.Price, instaBuy.IsArchived, instaBuy.CreatedAt);
        }
        
        public async Task AddInstaBuyAsync(InstaBuyDTO instaBuyDto)
        {
            var instaBuy = new InstaBuy
            {
                Id = instaBuyDto.Id,
                ProductId = instaBuyDto.ProductId,
                Price = instaBuyDto.Price,
                IsArchived = instaBuyDto.IsArchived,
                CreatedAt = instaBuyDto.CreatedAt
            };

            await _instaBuyRepository.AddInstaBuyAsync(instaBuy);
        }

        public async Task UpdateInstaBuyAsync(InstaBuyDTO instaBuyDto)
        {
            var instaBuy = await _instaBuyRepository.GetInstaBuyByIdAsync(instaBuyDto.Id);
            if (instaBuy == null) return;

            instaBuy.ProductId = instaBuyDto.ProductId;
            instaBuy.Price = instaBuyDto.Price;
            instaBuy.IsArchived = instaBuyDto.IsArchived;
            instaBuy.CreatedAt = instaBuyDto.CreatedAt;

            await _instaBuyRepository.UpdateInstaBuyAsync(instaBuy);
        }

        public async Task DeleteInstaBuyAsync(int id)
        {
            await _instaBuyRepository.DeleteInstaBuyAsync(id);
        }
    }
}

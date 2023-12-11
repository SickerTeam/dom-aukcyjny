using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class InstaBuyService(IInstaBuyRepository instaBuyRepository, IMapper mapper, IProductService productService) : IInstaBuyService
    {
        private readonly IInstaBuyRepository _instaBuyRepository = instaBuyRepository;
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<InstaBuyDTO>> GetAllInstaBuysAsync()
        {
            var instaBuys = await _instaBuyRepository.GetAllInstaBuysAsync();
            return _mapper.Map<IEnumerable<InstaBuyDTO>>(instaBuys);
        }

        public async Task<InstaBuyDTO> GetInstaBuyByIdAsync(int id)
        {
            var instaBuy = await _instaBuyRepository.GetInstaBuyByIdAsync(id);
            return _mapper.Map<InstaBuyDTO>(instaBuy);
        }

        public async Task AddInstaBuyAsync(InstaBuyRegistrationDTO instaBuyDto)
        {
            var instaBuy = _mapper.Map<InstaBuy>(instaBuyDto);
            instaBuy.IsArchived = false;
            instaBuy.CreatedAt = DateTime.Now;
            // instaBuy.Product = await _productService.GetModelById(instaBuyDto.ProductId);
            await _instaBuyRepository.AddInstaBuyAsync(instaBuy);
        }

        public async Task UpdateInstaBuyAsync(InstaBuyDTO instaBuyDto)
        {
            var instaBuy = await _instaBuyRepository.GetInstaBuyByIdAsync((int)instaBuyDto.Id);
            if (instaBuy == null) return;

            _mapper.Map(instaBuyDto, instaBuy);
            await _instaBuyRepository.UpdateInstaBuyAsync(instaBuy);
        }

        public async Task DeleteInstaBuyAsync(int id)
        {
            var insta = await _instaBuyRepository.GetInstaBuyByIdAsync(id);
            if (insta != null && !(insta.IsArchived ?? false)) {
                await _instaBuyRepository.DeleteInstaBuyAsync(id);
            }
        }
    }
}

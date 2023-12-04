using backend.DTOs;

namespace backend.Services
{
    public interface IInstaBuyService
    {
        Task AddInstaBuyAsync(InstaBuyDTO instaBuyDto);
        Task UpdateInstaBuyAsync(InstaBuyDTO instaBuyDto);
        Task DeleteInstaBuyAsync(int id);
        Task<IEnumerable<InstaBuyDTO>> GetAllInstaBuysAsync();
        Task<InstaBuyDTO> GetInstaBuyByIdAsync(int id);
    }
}

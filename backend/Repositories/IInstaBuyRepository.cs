using backend.DTOs;
using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IInstaBuyRepository
    {
        Task AddInstaBuyAsync(InstaBuy instaBuy);
        Task UpdateInstaBuyAsync(InstaBuy instaBuy);
        Task DeleteInstaBuyAsync(int id);
        Task<InstaBuy> GetInstaBuyByIdAsync(int id);
        Task<IEnumerable<InstaBuy>> GetAllInstaBuysAsync();
    }
}

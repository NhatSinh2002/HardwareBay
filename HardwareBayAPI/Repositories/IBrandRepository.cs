using HardwareBayAPI.Models.Domain;

namespace HardwareBayAPI.Repositories
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand?> UpdateAsync(int id, Brand brand);
    }
}

using HardwareBayAPI.Models.Domain;

namespace HardwareBayAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> UpdateAsync(int id, Category category);
        Task<Category?> DeleteAsync(int id);
        Task<Category> CreateAsync(Category category);

    }
}

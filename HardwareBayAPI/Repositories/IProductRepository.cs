using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;

namespace HardwareBayAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product product);
        Task <Product?> DeleteAsync(int id);
    }
}

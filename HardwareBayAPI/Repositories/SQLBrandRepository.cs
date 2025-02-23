using HardwareBayAPI.Data;
using HardwareBayAPI.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HardwareBayAPI.Repositories
{
    public class SQLBrandRepository : IBrandRepository
    {
        private readonly HardwareDbContext dbContext;

        public SQLBrandRepository(HardwareDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Brand>> GetAllAsync()
        {
            return await dbContext.Brands.ToListAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await dbContext.Brands.FirstOrDefaultAsync(x => x.BrandID == id);
        }

        public async Task<Brand> UpdateAsync(int id, Brand brand)
        {
            var existingBrand = await dbContext.Brands.FirstOrDefaultAsync(x=>x.BrandID == id);
            if (existingBrand == null)
            {
                return null;
            }
            existingBrand.BrandName = brand.BrandName;
            existingBrand.Description = brand.Description;
            existingBrand.IsActive = brand.IsActive;
            await dbContext.SaveChangesAsync();
            return existingBrand;
        }
    }
}

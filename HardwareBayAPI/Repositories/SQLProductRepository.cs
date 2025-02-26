using HardwareBayAPI.Data;
using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HardwareBayAPI.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly HardwareDbContext dbContext;

        public SQLProductRepository(HardwareDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var existingProduct = await dbContext.Products.Include("Brand").Include("Category").FirstOrDefaultAsync(x=>x.ProductID == id);
            if (existingProduct ==null)
            {
                return null;
            }
            dbContext.Products.Remove(existingProduct);
            dbContext.SaveChanges();
            return existingProduct;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.Include("Brand").Include("Category").ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await dbContext.Products.Include("Brand").Include("Category").FirstOrDefaultAsync(x => x.ProductID == id);
        }


        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var existingProduct = await dbContext.Products.Include("Brand").Include("Category").FirstOrDefaultAsync(x => x.ProductID == id);
            if (existingProduct == null) { return null; }
            existingProduct.ProductName = product.ProductName;
            existingProduct.BrandID = product.BrandID;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.Description = product.Description;
            existingProduct.ImageURL = product.ImageURL;
            existingProduct.IsActive = product.IsActive;
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}

